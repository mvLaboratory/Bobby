using System;

namespace RailwayElf
{
    public class SearchResultValue
    {
        public String Num { get; set; }
        public String Model { get; set; }
        public String Category { get; set; }
        public String Travel_time { get; set; }
        public SearchResultStation From { get; set; }
        public SearchResultStation Till { get; set; }
        public CarriageTypes[] Types { get; set; }
        public bool Allow_transportation { get; set; }
        public bool Is_europe { get; set; }
        public bool Allow_booking { get; set; }
        public bool Allow_roundtrip { get; set; }
        public bool Allow_stud { get; set; }
    }
}
