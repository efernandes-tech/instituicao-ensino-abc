using Newtonsoft.Json;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca
{
    public class OpenPixCriarCobrancaResponseDTO
    {
        [JsonProperty(PropertyName = "charge")]
        public CobrancaPixResponseDTO Cobranca { get; set; }

        [JsonProperty(PropertyName = "correlationID")]
        public string IdCorrelacao { get; set; }

        [JsonProperty(PropertyName = "brCode")]
        public string ChavePix { get; set; }
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
        public string Response { get; set; }
    }
}