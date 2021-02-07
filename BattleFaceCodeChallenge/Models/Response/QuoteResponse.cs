using System.ComponentModel.DataAnnotations;

namespace BattleFaceCodeChallenge.Models
{
    public class QuoteResponse
    {
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        // ISO 4217
        public string Currency_Id { get; set; }

        public string Quotation_Id { get; set; }
    }
}
