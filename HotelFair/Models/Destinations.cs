using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HotelFair.Models
{
    public partial class Destinations
    {
        [JsonProperty("items")]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("resultType")]
        public ResultType ResultType { get; set; }

        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public ItemAddress Address { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public List<Category> Categories { get; set; }

 
        public override string ToString()
        {
            string v = $"{Title}";
            return v;
        }
    }

    public partial class ItemAddress
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("district", NullValueHandling = NullValueHandling.Ignore)]
        public string District { get; set; }

        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        public string Street { get; set; }

        [JsonProperty("postalCode", NullValueHandling = NullValueHandling.Ignore)]
        public string PostalCode { get; set; }

        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
    }

    public partial class Position
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }
    public partial class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public enum ResultType { Locality, Place };   
    

    public partial class Destinations
    {
        public static Destinations FromJson(string json) => JsonConvert.DeserializeObject<Destinations>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Destinations self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ResultTypeConverter.Singleton,  
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ResultTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ResultType) || t == typeof(ResultType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "locality":
                    return ResultType.Locality;
                case "place":
                    return ResultType.Place;
                default:
                    return ResultType.Place;
            }
            throw new Exception("Cannot unmarshal type ResultType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ResultType)untypedValue;
            switch (value)
            {
                case ResultType.Locality:
                    serializer.Serialize(writer, "locality");
                    return;
                case ResultType.Place:
                    serializer.Serialize(writer, "place");
                    return;
                     
            }
            throw new Exception("Cannot marshal type ResultType");
        }

        public static readonly ResultTypeConverter Singleton = new ResultTypeConverter();
    }

    
}