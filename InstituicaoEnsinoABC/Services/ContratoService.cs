using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.Builders;
using InstituicaoEnsinoABC.DTO;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.RequestsDTO;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.ObterCobranca;
using InstituicaoEnsinoABC.Services.ApiClient;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Services
{
    public class ContratoService
    {
        private InstituicaoEnsinoABCDbContext _db;

        public ContratoService(InstituicaoEnsinoABCDbContext dBContext)
        {
            _db = dBContext;
        }

        public List<ContratoViewModel> ReadContratos()
        {
            var _listContratoViewModel = new List<ContratoViewModel>();

            var _contratosDb = _db.Contratos.ToList();

            foreach (Contrato contrato in _contratosDb)
            {
                _listContratoViewModel.Add(DataTransferObject.ContratoDTO(contrato));
            }

            return _listContratoViewModel;
        }

        public ContratoViewModel ReadContratoPorId(int id)
        {
            var _contrato = _db.Contratos.Include(x => x.ParcelasNavigation).FirstOrDefault(x => x.Id == id);

            _contrato.ParcelasNavigation = _db.Parcelas.Where(x => x.IdContrato == id).ToList();

            if (_contrato.ParcelasNavigation != null)
            {
                foreach (Parcela _parcela in _contrato.ParcelasNavigation)
                {
                    _parcela.Pagamentos = _db.Pagamentos.Where(x => x.IdParcela == _parcela.Id).ToList();
                }
            }

            return ContratoDTO.ContratoDataTransferObject(_contrato);
        }

        public async Task<ParcelaViewModel> ReadParcelaPorId(int id, int idContrato)
        {
            var clientCommunication = new ClientCommunicationService();
            var pagamentoService = new PagamentoService(_db);
            var alunoService = new AlunoService(_db);
            ObterCobrancaResponseDTO _responsePix;
            OpenPixCriarCobrancaRequestDTO _openApiRequest;

            Parcela _parcela = _db.Parcelas.FirstOrDefault(pc => pc.Id == id && pc.IdContrato == idContrato);
            ParcelaViewModel _parcelaViewModel = ParcelaDTO.ParcelaDataTransferObject(_parcela);

            AlunoViewModel _alunoViewModel = alunoService.ReadAlunoPorId(_parcela.IdContratoNavigation.IdAluno);

            if (_parcela.Pagamentos.Count() > 0)
            {
                Pagamento _pagamento = _parcela.Pagamentos.First();
                PagamentoViewModel _pagamentoViewModel = PagamentoDTO.PagamentoDataTransferObject(_pagamento);

                _responsePix = await clientCommunication.ObterParcelaPixPorcorrelationID(_pagamento.PixIdCorrelacao);

                _pagamentoViewModel.PixStatus = _responsePix.Cobranca.Status;
                _pagamentoViewModel.PixResponse = _responsePix.Response;

                pagamentoService.UpdatePagamento(_pagamentoViewModel);

                _parcelaViewModel.Pagamento = _pagamentoViewModel;

                return _parcelaViewModel;
            }
            else
            {
                _openApiRequest = new OpenPixRequestBuilder(_alunoViewModel, _parcela).BuildOpenPixCriarCobrancaRequestDTO();

                var _response = await clientCommunication.GerarCobrancaPix(_openApiRequest);

                if (_response.Error != null)
                {
                    _parcelaViewModel.InformacoesPix = new PixViewModel
                    {
                        Error = _response.Error
                    };

                    return _parcelaViewModel;
                }

                PagamentoViewModel _pagamentoViewModel = new PagamentoViewModel
                {
                    DataPagamento = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    ValorPago = _parcela.ValorParcela?.ToString("C", CultureInfo.CurrentCulture),
                    FormaPagamento = "Pix",
                    PixIdCorrelacao = _response.Cobranca.IdCorrelacao,
                    PixStatus = _response.Cobranca.Status,
                    PixResponse = _response.Response,
                    IdAluno = _alunoViewModel.Id,
                    IdParcela = _parcela.Id
                };

                pagamentoService.CreatePagamento(_pagamentoViewModel);

                _parcelaViewModel.Pagamento = _pagamentoViewModel;

                _responsePix = await clientCommunication.ObterParcelaPixPorcorrelationID(_response.IdCorrelacao);

                _parcelaViewModel.InformacoesPix = new PixViewModel
                {
                    IdCorrelacao = _responsePix.Cobranca.IdCorrelacao,
                    ChavePix = _responsePix.Cobranca.ChavePix,
                    UrlQrCode = _responsePix.Cobranca.QrCodeUrl,
                    Valor = _responsePix.Cobranca.Valor
                };

                return _parcelaViewModel;
            }
        }
    }
}
