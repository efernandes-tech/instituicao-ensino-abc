using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.DTO
{
    public static class PagamentoDTO
    {
        public static PagamentoViewModel PagamentoDataTransferObject(Pagamento _pagamento)
        {
            PagamentoViewModel _pagamentoViewModel = new PagamentoViewModel
            {
                Id = _pagamento.Id,
                DataPagamento = _pagamento.DataPagamento?.ToString("dd/MM/yyyy"),
                ValorPago = _pagamento.ValorPago?.ToString("C", CultureInfo.CurrentCulture),
                FormaPagamento = _pagamento.FormaPagamento,
                PixIdCorrelacao = _pagamento.PixIdCorrelacao,
                PixStatus = _pagamento.PixStatus,
                PixResponse = _pagamento.PixResponse,
                IdAluno = _pagamento.IdAluno,
                IdParcela = _pagamento.IdParcela,
            };

            if (_pagamento.IdAlunoNavigation != null)
            {
                _pagamentoViewModel.Aluno = new AlunoViewModel
                {
                    Id = _pagamento.IdAlunoNavigation.Id,
                    NomeCompleto = _pagamento.IdAlunoNavigation.NomeCompleto
                };
            }

            return _pagamentoViewModel;
        }
    }
}
