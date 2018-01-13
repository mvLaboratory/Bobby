using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RailwayElf
{
    public class TicketsChecker
    {
        public TicketsChecker()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://booking.uz.gov.ua");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<String> checkBookings(TicketSearchParameter parameters)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("station_id_from", parameters.StationFrom.StationId),
                new KeyValuePair<string, string>("station_id_till", parameters.StationTill.StationId),
                new KeyValuePair<string, string>("station_from", parameters.StationFrom.StationName),
                new KeyValuePair<string, string>("station_till", parameters.StationTill.StationName),
                new KeyValuePair<string, string>("date_dep", parameters.DepartureDate.ToString(new CultureInfo("de-DE"))),
                new KeyValuePair<string, string>("time_dep", "00:00"),
                new KeyValuePair<string, string>("time_dep_till", ""),
                new KeyValuePair<string, string>("another_ec", "0"),
                new KeyValuePair<string, string>("search", "")
            });
            HttpResponseMessage response = await _client.PostAsync("/purchase/search/", content);
            String result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return result;
            }
            return result;
        }

        public async Task<SearchResultModel> checkTickets(String depDate)
        {
            var resultingDepDate = DateTime.Parse(depDate, new CultureInfo("de-DE"));
            return await checkTickets(resultingDepDate);
        }

        public async Task<SearchResultModel> checkTickets(DateTime? depDateNullable = null)
        {
            DateTime depDate = depDateNullable ?? DateTime.Now;
            var kolomyia = new Station("2218030", "Коломия");
            var ternopil = new Station("2218300", "Тернопіль");
            var searchKolTern = new TicketSearchParameter(kolomyia, ternopil, depDate.ToString("dd.MM.yyyy"));

            String stringResult = await checkBookings(searchKolTern);
            stringResult = Regex.Unescape(stringResult);
            stringResult = stringResult.Replace("\\", "");
            var result = JsonConvert.DeserializeObject<SearchResultModel>(stringResult, new SearchResultModelConvertor());
            return result;
        } 

        private HttpClient _client;
    }
}
