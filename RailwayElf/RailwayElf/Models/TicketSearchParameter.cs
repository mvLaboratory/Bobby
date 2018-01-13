using System;
using System.Globalization;

namespace RailwayElf
{
    public struct TicketSearchParameter
    {
        public Station StationFrom { get; set; }
        public Station StationTill { get; set; }
        public DateTime DepartureDate { get; set; }

        public TicketSearchParameter(Station stationFrom, Station stationTill, DateTime departureDate)
        {
            StationFrom = stationFrom;
            StationTill = stationTill;
            DepartureDate = departureDate;
        }

        public TicketSearchParameter(Station stationFrom, Station stationTill, String departureDate)
            : this(stationFrom, stationTill, DateTime.Parse(departureDate, new CultureInfo("de-DE")))
        {
        }
    }
}
