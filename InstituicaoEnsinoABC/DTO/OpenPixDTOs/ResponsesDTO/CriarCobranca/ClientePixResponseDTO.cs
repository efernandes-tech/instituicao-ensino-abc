using Newtonsoft.Json;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca
{
    public class ClientePixResponseDTO
    {
        [JsonProperty(PropertyName = "name")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "taxID")]
        public DocumentoAlunoResponseDTO DocumentoAluno { get; set; }

        [JsonProperty(PropertyName = "correlationID")]
        public string IdCorrelacao { get; set; }

    }
}
