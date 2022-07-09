using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC
{
    public static class DataTransferObject
    {
        public static AlunoViewModel AlunoDTO(Aluno aluno)
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel
            {
                Id = aluno.Id,
                NomeCompleto = aluno.NomeCompleto,
                Cpf = aluno.Cpf,
                DataNascimento = aluno.DataNascimento?.ToString("yyyy-MM-dd"),
                EnderecoCompleto = aluno.EnderecoCompleto
            };

            return alunoViewModel;
        }

        public static ContratoViewModel ContratoDTO(Contrato _contrato)
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
            foreach (Parcela _parcela in _contrato.ParcelasNavigation)
            {
                _contratoViewModel.Parcelas.Add(ParcelaDTO(_parcela));
            }
            return _contratoViewModel;
        }

        public static ParcelaViewModel ParcelaDTO(Parcela _parcela)
        {
            ParcelaViewModel _parcelaViewModel = new ParcelaViewModel
            {
                Id = _parcela.Id,
                NumeroParcela = _parcela.NumeroParcela,
                Vencimento = _parcela.DataVencimento?.ToString("dd/MM/yyyy"),
                Valor = _parcela.ValorParcela?.ToString("C", CultureInfo.CurrentCulture),
            };

            if (_parcelaViewModel.Contrato is not null)
            {
                _parcelaViewModel.Contrato = new ContratoViewModel
                {
                    Id = _parcela.IdContratoNavigation.Id,
                    Descricao = _parcela.IdContratoNavigation.Descricao
                };
            }

            return _parcelaViewModel;
        }

        public static PagamentoViewModel PagamentoDTO(Pagamento pagamento)
        {
            PagamentoViewModel pagamentoViewModel = new PagamentoViewModel
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

            if (pagamento.IdAlunoNavigation is not null)
            {
                pagamentoViewModel.Aluno = new AlunoViewModel
                {
                    Id = pagamento.IdAlunoNavigation.Id,
                    NomeCompleto = pagamento.IdAlunoNavigation.NomeCompleto,
                    Cpf = pagamento.IdAlunoNavigation.Cpf,
                    DataNascimento = pagamento.IdAlunoNavigation.DataNascimento?.ToString("yyyy-MM-dd"),
                    EnderecoCompleto = pagamento.IdAlunoNavigation.EnderecoCompleto
                };
            }

            return pagamentoViewModel;
        }
    }
}
