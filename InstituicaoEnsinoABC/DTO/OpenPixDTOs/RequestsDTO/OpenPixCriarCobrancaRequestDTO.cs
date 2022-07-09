using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.RequestsDTO
{
    public class OpenPixCriarCobrancaRequestDTO
    {
        public OpenPixCriarCobrancaRequestDTO()
        {
        }

        public OpenPixCriarCobrancaRequestDTO(
            string idCorrelacao,
            int valor,
            string comentario,
            InformacoesAlunoRequestDTO informacoesAlunoRequestDTO,
            List<InformacoesAdicionaisDTO> informacoesAdicionais)
        {
            IdCorrelacao = idCorrelacao;
            Valor = valor;
            Comentario = comentario;
            InformacoesAlunoRequestDTO = informacoesAlunoRequestDTO;
            InformacoesAdicionais = informacoesAdicionais;
        }

        [JsonProperty(PropertyName = "correlationID")]
        public string IdCorrelacao { get; set; }

        [JsonProperty(PropertyName = "value")]
        public int Valor { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public string Comentario { get; set; }

        [JsonProperty(PropertyName = "customer")]
        public InformacoesAlunoRequestDTO InformacoesAlunoRequestDTO { get; set; }

        [JsonProperty(PropertyName = "additionalInfo")]
        public List<InformacoesAdicionaisDTO> InformacoesAdicionais { get; set; }
    }
}
