using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace RailwayElf
{
    public class SearchResultModelConvertor : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject obj = JObject.Load(reader);
                bool error = obj["error"].Value<bool?>() ?? false;
                String errorMessage = "";
                SearchResultValue[] value = new SearchResultValue[] { };
                String captcha = obj["captcha"].ToString();
                String data = obj["data"].ToString();
                if (!error)
                {
                    value = obj["value"].ToObject<SearchResultValue[]>(serializer);
                }
                else
                {
                    errorMessage = obj["value"].ToString();
                }
                return new SearchResultModel(captcha, data, error, errorMessage, value);
            }
            else
            {
                JArray array = JArray.Load(reader);
               
                var value = array.ToObject<SearchResultValue[]>();
                return value;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
