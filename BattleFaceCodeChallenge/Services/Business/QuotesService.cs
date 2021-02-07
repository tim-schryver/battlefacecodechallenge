using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleFaceCodeChallenge.Models;

namespace BattleFaceCodeChallenge
{
    public class QuotesService : IQuotesService
    {
        public QuotesService(){ }

        public async Task<QuoteResponse> CalculateQuote(QuoteRequest quoteParamters)
        {
            try
            {
                List<int> ageCollection = GetAgeCollection(quoteParamters);

                ValidateQuoteParameters(quoteParamters, ageCollection);

                decimal total = CalculateTripQuote(ageCollection, DaysInTrip(quoteParamters));

                return new QuoteResponse() { Currency_Id = quoteParamters.Currency_Id, Quotation_Id = new Random().Next(1, 9999999).ToString(), Total = total };
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (FormatException ex)
            {
                throw new FormatException("An age must be a valid integer value.", ex);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static decimal CalculateTripQuote(List<int> ageCollection, int daysInTrip)
        {
            decimal total = 0.00M;
            const decimal fixedRate = 3.0M;
            ageCollection.ForEach(age =>
            {
                decimal ageLoad;
                // Find age load. 
                if (age >= 1 && age < 18) ageLoad = .5m; // Made an assumption that minors (age 1-17) are at a lower rate but more importantly not excluded.
                else if (age >= 18 && age <= 30) ageLoad = .6M;
                else if (age >= 31 && age <= 40) ageLoad = .7m;
                else if (age >= 41 && age <= 50) ageLoad = .8m;
                else if (age >= 51 && age <= 60) ageLoad = .9m;
                else if (age >= 61 && age <= 70) ageLoad = 1m;
                else throw new ArgumentException("Age exceeds 70");

                total += fixedRate * ageLoad * daysInTrip;
            });

            return total;
        }

        private static List<int> GetAgeCollection(QuoteRequest quoteParamters)
        {
            // Comma separated list of insureds’ ages.
            List<int> ageCollection = new List<int>();
            ageCollection = quoteParamters.Age.Split(',')
                .Select(m => int.Parse(m))
                .ToList();
            return ageCollection;
        }

        private static int DaysInTrip(QuoteRequest quoteParamters)
        {
            // Find Date Diff.
            // Start Date and End Date are equal, assuming that is 1 day as someone may travel for just a single day.
            return quoteParamters.Start_Date == quoteParamters.End_Date ? 1 : ((quoteParamters.End_Date - quoteParamters.Start_Date).Days + 1);
        }

        private static void ValidateQuoteParameters(QuoteRequest quoteParamters, List<int> ageCollection)
        {
            if (ageCollection.Count == 0) throw new ArgumentException("At least one value is required.");
            if (ageCollection.First() < 18) throw new ArgumentException("First Age value must be 18 or over.");
            if (ageCollection.Any(val => val < 1)) throw new ArgumentException("0 and negative numbers are not a valid age.");

            // Trip length is inclusive of both start date and end date so a start date of 2020-10-01 and an
            // end date of 2020-10-30 will constitute a trip length of 30 days.
            if (quoteParamters.Start_Date < DateTime.Now.Date) throw new ArgumentException("Start Date can not be before current Date.");
            if (quoteParamters.Start_Date > quoteParamters.End_Date) throw new ArgumentException("Start Date can not be after End Date.");
            
        }
    }
}
