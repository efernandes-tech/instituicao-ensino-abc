using DataLayer.Context;
using DataLayer.Models;
using InstituicaoEnsinoABC.DTO;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Services
{
    public class PagamentoService
    {
        private InstituicaoEnsinoABCDbContext _db;

        public PagamentoService(InstituicaoEnsinoABCDbContext dBContext)
        {
            _db = dBContext;
        }

        public List<PagamentoViewModel> ReadPagamentos()
        {
            var _listPagamentoViewModel = new List<PagamentoViewModel>();

            var _pagamentosDb = _db.Pagamentos.ToList();

            foreach (Pagamento pagamento in _pagamentosDb)
            {
                _listPagamentoViewModel.Add(DataTransferObject.PagamentoDTO(pagamento));
            }

            return _listPagamentoViewModel;
        }

        public PagamentoViewModel ReadPagamentoPorId(int id)
        {
            var _pagamento = _db.Pagamentos.Include(x => x.IdAlunoNavigation).FirstOrDefault(x => x.Id == id);

            _pagamento.IdAlunoNavigation = _db.Alunos.Where(x => x.Id == _pagamento.IdAluno).ToList().First();

            return PagamentoDTO.PagamentoDataTransferObject(_pagamento);
        }

        public PagamentoViewModel CreatePagamento(PagamentoViewModel pagamentoViewModel)
        {
            var valor = pagamentoViewModel.ValorPago.Replace("R$", "").Replace(".", "").Trim();

            var pagamento = new Pagamento
            {
                DataPagamento = DateTime.Parse(pagamentoViewModel.DataPagamento),
                ValorPago = Convert.ToDecimal(valor),
                FormaPagamento = pagamentoViewModel.FormaPagamento,
                PixIdCorrelacao = pagamentoViewModel.PixIdCorrelacao,
                PixStatus = pagamentoViewModel.PixStatus,
                PixResponse = pagamentoViewModel.PixResponse,
                IdAluno = pagamentoViewModel.IdAluno,
                IdParcela = pagamentoViewModel.IdParcela
            };
            _db.Pagamentos.Add(pagamento);
            _db.SaveChanges();
            pagamentoViewModel.Id = pagamento.Id;
            return pagamentoViewModel;
        }

        public PagamentoViewModel UpdatePagamento(PagamentoViewModel pagamentoViewModel)
        {
            var pagamento = _db.Pagamentos.Find(pagamentoViewModel.Id);

            var valor = pagamentoViewModel.ValorPago.Replace("R$", "").Replace(".", "").Trim();

            pagamento.DataPagamento = DateTime.Parse(pagamentoViewModel.DataPagamento);
            pagamento.ValorPago = Convert.ToDecimal(valor);
            pagamento.FormaPagamento = pagamentoViewModel.FormaPagamento;
            pagamento.PixIdCorrelacao = pagamentoViewModel.PixIdCorrelacao;
            pagamento.PixStatus = pagamentoViewModel.PixStatus;
            pagamento.PixResponse = pagamentoViewModel.PixResponse;

            _db.SaveChanges();

            pagamentoViewModel.Id = pagamento.Id;

            return pagamentoViewModel;
        }
    }
}
