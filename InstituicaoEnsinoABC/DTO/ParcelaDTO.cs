using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.DTO
{
    public static class ParcelaDTO
    {
        public static ParcelaViewModel ParcelaDataTransferObject(Parcela _parcela)
        {
            ParcelaViewModel _parcelaViewModel = new ParcelaViewModel
            {
                Id = _parcela.Id,
                NumeroParcela = _parcela.NumeroParcela,
                Vencimento = _parcela.DataVencimento?.ToString("dd/MM/yyyy"),
                Valor = _parcela.ValorParcela?.ToString("C", CultureInfo.CurrentCulture),
                Contrato = new ContratoViewModel()
            };

            if (_parcela.IdContratoNavigation != null)
            {
                _parcelaViewModel.Contrato = new ContratoViewModel
                {
                    Id = _parcela.IdContratoNavigation.Id,
                    Descricao = _parcela.IdContratoNavigation.Descricao,
                    ValorTotal = _parcela.IdContratoNavigation.ValorTotal?.ToString("C", CultureInfo.CurrentCulture),
                    NumParcelas = _parcela.IdContratoNavigation.Parcelas,
                    DiaPagamento = _parcela.IdContratoNavigation.DiaPagamento,
                    DataInicio = _parcela.IdContratoNavigation.DataInicio?.ToString("dd/MM/yyyy"),
                    ValorPago = _parcela.IdContratoNavigation.ValorPago?.ToString("C", CultureInfo.CurrentCulture),
                    Status = _parcela.IdContratoNavigation.Status
                };
            }

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
