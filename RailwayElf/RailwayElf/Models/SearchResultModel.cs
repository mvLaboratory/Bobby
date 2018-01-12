using System;

namespace RailwayElf
{
    public class SearchResultModel
    {
        public String Error { get; set; }
        public String Captcha { get; set; }
        public String Data { get; set; }
        public ISearchResultValue Value { get; set; }

        public SearchResultModel(String captcha, String data, String error, ISearchResultValue value)
        {
            Captcha = captcha;
            Data = data;
            Error = error;
            Value = value;
        }
    }
}
