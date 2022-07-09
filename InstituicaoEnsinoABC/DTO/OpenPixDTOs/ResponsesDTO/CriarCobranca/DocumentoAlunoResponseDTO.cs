using Newtonsoft.Json;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca
{
    public class DocumentoAlunoResponseDTO
    {
        [JsonProperty(PropertyName = "taxID")]
        public string IdAluno { get; set; }
        [JsonProperty(PropertyName = "Type")]
        public string TipoId { get; set; }
    }
}