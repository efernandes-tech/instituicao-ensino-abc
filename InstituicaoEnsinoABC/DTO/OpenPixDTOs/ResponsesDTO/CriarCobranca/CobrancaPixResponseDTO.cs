using Newtonsoft.Json;
using System;

namespace InstituicaoEnsinoABC.DTO.OpenPixDTOs.ResponsesDTO.CriarCobranca
{
    public class CobrancaPixResponseDTO
    {
        [JsonProperty(PropertyName = "customer")]
        public ClientePixResponseDTO Cliente { get; set; }

        [JsonProperty(PropertyName = "value")]
        public decimal Valor { get; set; }

        [JsonProperty(PropertyName = "comment")]
        public string Comentário { get; set; }

        [JsonProperty(PropertyName = "identifier")]
        public string Identficador { get; set; }

        [JsonProperty(PropertyName = "correlationID")]
        public string IdCorrelacao { get; set; }

        [JsonProperty(PropertyName = "transactionID")]
        public string IdTransacao { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "additionalInfo")]
        public InformacaoAdicionalResponseDTO[] InformacaoAdicionais { get; set; }

        [JsonProperty(PropertyName = "giftbackAppliedValue")]
        public decimal CashBack { get; set; }

        [JsonProperty(PropertyName = "discount")]
        public decimal Disconto { get; set; }

        [JsonProperty(PropertyName = "valueWithDiscount")]
        public decimal ValorComDesconto { get; set; }

        [JsonProperty(PropertyName = "paymentLinkID")]
        public string IdLinkPagamento { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTime DataDeCriacao { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public DateTime DataDeAtualizacao { get; set; }

        [JsonProperty(PropertyName = "expiresIn")]
        public long ExpiraEm { get; set; }

        [JsonProperty(PropertyName = "pixKey")]
        public string PixId { get; set; }

        [JsonProperty(PropertyName = "brCode")]
        public string ChavePix { get; set; }

        [JsonProperty(PropertyName = "paymentLinkUrl")]
        public string UrlPagamento { get; set; }

        [JsonProperty(PropertyName = "qrCodeImage")]
        public string QrCodeUrl { get; set; }

        [JsonProperty(PropertyName = "globalID")]
        public string Global { get; set; }
    }
}
