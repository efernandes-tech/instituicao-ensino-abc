using Newtonsoft.Json;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca
{
    public class InformacaoAdicionalResponseDTO
    {
        [JsonProperty(PropertyName= "key")]
        public string Chave { get; set; }

        [JsonProperty(PropertyName = "values")]
        public string Valor { get; set; }
    }
}