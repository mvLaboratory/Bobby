using Newtonsoft.Json;
using System;

namespace RailwayElf
{
    public class Station
    {
        [JsonProperty(PropertyName = "value")]
        public String StationId { get; set; }

        [JsonProperty(PropertyName = "title")]
        public String StationName { get; set; }

        public Station(String stationId, String stationName)
        {
            StationId = stationId;
            StationName = stationName;
        }

        public override String ToString()
        {
            return String.Format("{{0}: {1}}", StationId, StationName);
        }
    }
}
