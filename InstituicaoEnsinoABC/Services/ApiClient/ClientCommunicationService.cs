using InstituicaoEnsinoABC.DTO.OpenPixDTOs.RequestsDTO;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca;
using InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.ObterCobranca;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.Services.ApiClient
{
    public class ClientCommunicationService
    {
        private const string Auth = "Q2xpZW50X0lkX2FjNWEzODk0LWNhNjktNDM3My04ZTI0LWI3ZjkxYjJiMDcxNDpDbGllbnRfU2VjcmV0XzFjZ0U3Q0ZzRnY2SWVVQVFCUmFTeU85MHhuVE4wN0p1VlIyQm5ucUVKQTg9";
        private const string BaseUrl = "https://api.openpix.com.br/api/openpix/";
        public async Task<OpenPixCriarCobrancaResponseDTO> GerarCobrancaPix(OpenPixCriarCobrancaRequestDTO requestDTO)
        {
            var endPoint = "v1/charge";

            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl + "?return_existing=true")
            };
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Authorization", Auth);

            var jsonRequest = JsonConvert.SerializeObject(requestDTO);
            var contentRequest = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync(endPoint, contentRequest);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content200 = response.Content.ReadAsStringAsync().Result;

                    var _openPixCriarCobrancaResponseDTO = JsonConvert.DeserializeObject<OpenPixCriarCobrancaResponseDTO>(content200);
                    _openPixCriarCobrancaResponseDTO.Response = content200;
                    return _openPixCriarCobrancaResponseDTO;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var content400 = response.Content.ReadAsStringAsync().Result;

                    OpenPixErroResponseDTO _res = JsonConvert.DeserializeObject<OpenPixErroResponseDTO>(content400);

                    throw new Exception(_res.Error);
                }

                throw new Exception($"Erro ao gerar cobrança. Status {response.StatusCode} retornado pelo OpenPIX.");
            }
            catch (Exception ex)
            {
                return new OpenPixCriarCobrancaResponseDTO
                {
                    Error = ex.Message
                };
            }
        }

        public async Task<ObterCobrancaResponseDTO> ObterParcelaPixPorcorrelationID(string correlationID)
        {
            var endPoint = "v1/charge/" + correlationID;

            using (var webClient = new WebClient())
            {
                webClient.BaseAddress = BaseUrl;
                webClient.Headers[HttpRequestHeader.Authorization] = Auth;
                webClient.Encoding = System.Text.Encoding.UTF8;

                var jsonResponse = string.Empty;

                try
                {
                    jsonResponse = await webClient.DownloadStringTaskAsync(endPoint);
                    var _obterCobrancaResponseDTO = JsonConvert.DeserializeObject<ObterCobrancaResponseDTO>(jsonResponse);
                    _obterCobrancaResponseDTO.Response = jsonResponse;
                    return _obterCobrancaResponseDTO;
                }
                catch (WebException)
                {
                    return JsonConvert.DeserializeObject<ObterCobrancaResponseDTO>(jsonResponse);
                }
            }
        }
    }
}