using InstituicaoEnsinoABC.DTO.OpenPixDTOs.RequestsDTO;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.ObterCobranca;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Services.ApiClient
{
    public interface IOpenPixClientCommunicationService
    {
        public Task<ObterCobrancaResponseDTO> ObterParcelaPixPorcorrelationID(string correlationID);
        public Task<OpenPixCriarCobrancaResponseDTO> GerarCobrancaPix(OpenPixCriarCobrancaRequestDTO requestDTO);
    }
}