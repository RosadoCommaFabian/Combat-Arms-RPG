#nullable enable // you can remove this if you have nullable reference types enabled in your project
#define BRANCHLESS // comment this out to use the branched version

using System;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CombatArmsRPG
{
    public class BitArrayConverter : JsonConverter<BitArray>
    {
        public override BitArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
#if BRANCHLESS
            // branchless will perform better, but will not be as robust as it expects 

            reader.Read();
            reader.Read();

            int length = reader.GetInt32();
            reader.Read();
            reader.Read();
            byte[] bytes = reader.GetBytesFromBase64();
            reader.Read();
            reader.Read();
#else
            // branched will most likely be less performant due to the branch predictor having to work more, but can take the JSON fields in any order.
            
            int length = -1;
            byte[]? bytes = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.ValueTextEquals("Length"))
                {
                    reader.Read();
                    length = reader.GetInt32();
                }
                else if (reader.ValueTextEquals("Value"))
                {
                    reader.Read();
                    bytes = reader.GetBytesFromBase64();
                }
            }

            if (bytes == null || (uint)(bytes.Length * 8) < (uint)length)
            {
                throw new JsonException("Invalid JSON data, length must be a number lower than the amount of bits stored.");
            }
#endif

            return new BitArray(bytes)
            {
                Length = length
            };
        }

        public override void Write(Utf8JsonWriter writer, BitArray value, JsonSerializerOptions options)
        {
            byte[] ret = new byte[(value.Length - 1) / 8 + 1];
            value.CopyTo(ret, 0);

            writer.WriteStartObject();

            writer.WriteNumber("Length", value.Length);
            writer.WriteBase64String("Value", ret);

            writer.WriteEndObject();
        }
    }
}