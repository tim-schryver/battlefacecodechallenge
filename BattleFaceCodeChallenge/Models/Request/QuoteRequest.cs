using System;
using System.ComponentModel.DataAnnotations;

namespace BattleFaceCodeChallenge.Models
{
    public class QuoteRequest
    {
        [Required(ErrorMessage = "Age is required")]
        public string Age { get; set; }

        // ISO 4217
        [Required(ErrorMessage = "Currency Type is required")]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "ISO 4217 currency values are 3 characters")]
        public string Currency_Id { get; set; }
        
        // ISO 8601 Date
        [Required(ErrorMessage ="start date is required")]
        [DataType(DataType.Date)]
        public DateTime Start_Date { get; set; }

        // ISO 8601 Date
        [Required(ErrorMessage = "end date is required")]
        [DataType(DataType.Date)]
        public DateTime End_Date { get; set; }
    }
}
