using DataLayer.Models;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.RequestsDTO;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Builders
{
    public class OpenPixRequestBuilder
    {
        private readonly AlunoViewModel _aluno;
        private readonly Parcela _parcela;

        public OpenPixRequestBuilder(AlunoViewModel aluno, Parcela parcela)
        {
            _aluno = aluno;
            _parcela = parcela;
        }

        public OpenPixCriarCobrancaRequestDTO BuildOpenPixCriarCobrancaRequestDTO()
        {
            var valor = Int32.Parse(_parcela.ValorParcela.ToString().Replace(",", "").Replace(".", ""));

            OpenPixCriarCobrancaRequestDTO _openPixCriarCobrancaRequestDTO = new OpenPixCriarCobrancaRequestDTO
            {
                IdCorrelacao = Guid.NewGuid().ToString(),
                Valor = valor,
                Comentario = "Pagamento Parcela",
                InformacoesAlunoRequestDTO = new InformacoesAlunoRequestDTO
                {
                    Nome = _aluno.NomeCompleto,
                    CPF = _aluno.Cpf,
                    Email = String.Empty,
                    Phone = string.Empty
                },
                InformacoesAdicionais = new List<InformacoesAdicionaisDTO>()
            };

            _openPixCriarCobrancaRequestDTO.InformacoesAdicionais.Add(new InformacoesAdicionaisDTO
            {
                Chave = "Financeiro",
                Valor = "Parcela universitária"
            });

            return _openPixCriarCobrancaRequestDTO;
        }
    }
}
