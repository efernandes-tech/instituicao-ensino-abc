using Newtonsoft.Json;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca
{
    public class OpenPixErroResponseDTO
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}