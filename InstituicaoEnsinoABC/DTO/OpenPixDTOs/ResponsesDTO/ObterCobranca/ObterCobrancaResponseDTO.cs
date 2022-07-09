using InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca;
using Newtonsoft.Json;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.ObterCobranca
{
    public class ObterCobrancaResponseDTO
    {
        [JsonProperty(PropertyName = "charge")]
        public CobrancaPixResponseDTO Cobranca { get; set; }
        public string Response { get; set; }
    }
}
