using System;

namespace RailwayElf
{
    public class SearchResultModel
    {
        public bool Error { get; set; }
        public String ErrorMessage { get; set; }
        public String Captcha { get; set; }
        public String Data { get; set; }
        public String Value { get; set; }

        public SearchResultModel(String captcha, String data, bool error, String value)
        {
            Captcha = captcha;
            Data = data;
            Error = error;
            Value = value;
        }
    }
}
