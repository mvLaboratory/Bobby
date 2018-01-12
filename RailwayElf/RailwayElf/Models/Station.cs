using System;

namespace RailwayElf
{
    public class Station
    {
        public String StationId { get; set; }
        public String StationName { get; set; }

        public Station(String stationId, String stationName)
        {
            StationId = stationId;
            StationName = stationName;
        }

        public override String ToString()
        {
            return "{$StatioId: $StationName}";
        }
    }
}
