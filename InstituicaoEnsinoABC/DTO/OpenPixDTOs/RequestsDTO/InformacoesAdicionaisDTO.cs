using Newtonsoft.Json;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.RequestsDTO
{
    public class InformacoesAdicionaisDTO
    {
        [JsonProperty(PropertyName = "key")]
        public string Chave { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Valor { get; set; }
    }
}
