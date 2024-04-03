using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SDKBrasilAPI.Utils
{
    public class FlexibleEnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        private readonly Dictionary<T, string> _enumToString = new Dictionary<T, string>();
        private readonly Dictionary<string, T> _stringToEnum = new Dictionary<string, T>();

        public FlexibleEnumConverter()
        {
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                var enumMember = typeof(T).GetMember(value.ToString())[0];
                var attr = enumMember.GetCustomAttributes(typeof(EnumMemberAttribute), false)
                    .Cast<EnumMemberAttribute>()
                    .FirstOrDefault();

                if (attr == null)
                {
                    _enumToString[value] = value.ToString();
                    _stringToEnum[value.ToString()] = value;
                    continue;
                }
                
                _enumToString[value] = attr.Value;
                _stringToEnum[attr.Value] = value;
            }
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (_stringToEnum.TryGetValue(reader.GetString(), out var enumValue))
                    return enumValue;
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                var intValue = reader.GetInt32();
                if (Enum.IsDefined(typeof(T), intValue))
                {
                    return (T)Enum.ToObject(typeof(T), intValue);
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
