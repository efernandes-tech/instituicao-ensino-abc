using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.DTO
{
    public static class ContratoDTO
    {
        public static ContratoViewModel ContratoDataTransferObject(Contrato _contrato)
        {
            ContratoViewModel _contratoViewModel = new ContratoViewModel
            {
                Id = _contrato.Id,
                Descricao = _contrato.Descricao,
                ValorTotal = _contrato.ValorTotal?.ToString("C", CultureInfo.CurrentCulture),
                NumParcelas = _contrato.Parcelas,
                DiaPagamento = _contrato.DiaPagamento,
                DataInicio = _contrato.DataInicio?.ToString("dd/MM/yyyy"),
                ValorPago = _contrato.ValorPago?.ToString("C", CultureInfo.CurrentCulture),
                Status = _contrato.Status,
                Parcelas = new List<ParcelaViewModel>()
            };

            foreach (Parcela parcela in _contrato.ParcelasNavigation)
            {
                _contratoViewModel.Parcelas.Add(ParcelaDataTransferObject(parcela));
            }

            return _contratoViewModel;
        }

        public static ParcelaViewModel ParcelaDataTransferObject(Parcela _parcela)
        {
            ParcelaViewModel _parcelaViewModel = new ParcelaViewModel
            {
                Id = _parcela.Id,
                NumeroParcela = _parcela.NumeroParcela,
                Vencimento = _parcela.DataVencimento?.ToString("dd/MM/yyyy"),
                Valor = _parcela.ValorParcela?.ToString("C", CultureInfo.CurrentCulture),
                Pagamento = new PagamentoViewModel()
            };

            if (_parcela.Pagamentos.Count() > 0)
            {
                var pagamento = _parcela.Pagamentos.First();
                _parcelaViewModel.Pagamento = new PagamentoViewModel
                {
                    Id = pagamento.Id,
                    DataPagamento = pagamento.DataPagamento?.ToString("dd/MM/yyyy"),
                    ValorPago = pagamento.ValorPago?.ToString("C", CultureInfo.CurrentCulture),
                    FormaPagamento = pagamento.FormaPagamento,
                    PixIdCorrelacao = pagamento.PixIdCorrelacao,
                    PixStatus = pagamento.PixStatus,
                    PixResponse = pagamento.PixResponse,
                    IdAluno = pagamento.IdAluno,
                    IdParcela = pagamento.IdParcela
                };
            }

            return _parcelaViewModel;
        }
    }
}
