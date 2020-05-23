using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HotelFair.Models
{
    public partial class Destinations
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("highlightedTitle")]
        public string HighlightedTitle { get; set; }

        [JsonProperty("vicinity", NullValueHandling = NullValueHandling.Ignore)]
        public string Vicinity { get; set; }

        [JsonProperty("highlightedVicinity", NullValueHandling = NullValueHandling.Ignore)]
        public string HighlightedVicinity { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Position { get; set; }

        [JsonProperty("category")]
        public DestinationType DestinationType { get; set; }

        [JsonProperty("categoryTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryTitle { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("resultType")]
        public ResultType ResultType { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("distance", NullValueHandling = NullValueHandling.Ignore)]
        public long? Distance { get; set; }

        [JsonProperty("bbox", NullValueHandling = NullValueHandling.Ignore)]
        public List<double> Bbox { get; set; }

        [JsonProperty("completion", NullValueHandling = NullValueHandling.Ignore)]
        public string Completion { get; set; }

        public override string ToString()
        {
            string v = $"{Title}, {HighlightedVicinity}";
            v=v.Replace(@"<b>", string.Empty);
            v=v.Replace(@"</b>", string.Empty);
            v=v.Replace(@"<br/>", ", ");
            v = v.Replace(@"<B>", string.Empty);
            v = v.Replace(@"</B>", string.Empty);
            v = v.Replace(@"<BR/>", ", ");
            return v;
        }
    }

    public enum ResultType { Address, Place, Query };

    public enum TypeEnum { UrnNlpTypesAutosuggest, UrnNlpTypesPlace };

    public enum DestinationType { Cities, Landmarks, Properties, Airports, Stations, Other };

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
                TypeEnumConverter.Singleton,
                DestinationTypeConverter.Singleton,
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
                case "address":
                    return ResultType.Address;
                case "place":
                    return ResultType.Place;
                case "query":
                    return ResultType.Query;
                default:
                    return ResultType.Query;
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
                case ResultType.Address:
                    serializer.Serialize(writer, "address");
                    return;
                case ResultType.Place:
                    serializer.Serialize(writer, "place");
                    return;
                case ResultType.Query:
                    serializer.Serialize(writer, "query");
                    return;
            }
            throw new Exception("Cannot marshal type ResultType");
        }

        public static readonly ResultTypeConverter Singleton = new ResultTypeConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "urn:nlp-types:autosuggest":
                    return TypeEnum.UrnNlpTypesAutosuggest;
                case "urn:nlp-types:place":
                    return TypeEnum.UrnNlpTypesPlace;
                default:
                    return TypeEnum.UrnNlpTypesAutosuggest;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.UrnNlpTypesAutosuggest:
                    serializer.Serialize(writer, "urn:nlp-types:autosuggest");
                    return;
                case TypeEnum.UrnNlpTypesPlace:
                    serializer.Serialize(writer, "urn:nlp-types:place");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class DestinationTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DestinationType) || t == typeof(DestinationType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "airport":
                    return DestinationType.Airports;

                case "city-town-village":
                    return DestinationType.Cities;
                case "administrative-region":
                    return DestinationType.Cities;

                case "museum":
                case "landmark-attraction":
                case "amusement-holiday-park":
                case "recreation":
                    return DestinationType.Landmarks;

                case "hotel":
                    return DestinationType.Properties;

                case "public-transport":
                    return DestinationType.Stations;

                default:
                    return DestinationType.Other;
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
            var value = (DestinationType)untypedValue;
            switch (value)
            {
                case DestinationType.Other:
                    serializer.Serialize(writer, "address");
                    return;
                case DestinationType.Airports:
                    serializer.Serialize(writer, "place");
                    return;
                case DestinationType.Cities:
                    serializer.Serialize(writer, "query");
                    return;
            }
            throw new Exception("Cannot marshal type ResultType");
        }

        public static readonly DestinationTypeConverter Singleton = new DestinationTypeConverter();
    }
}