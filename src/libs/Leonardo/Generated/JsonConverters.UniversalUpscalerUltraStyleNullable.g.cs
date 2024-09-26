#nullable enable

namespace Leonardo.JsonConverters
{
    /// <inheritdoc />
    public sealed class UniversalUpscalerUltraStyleNullableJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Leonardo.UniversalUpscalerUltraStyle?>
    {
        /// <inheritdoc />
        public override global::Leonardo.UniversalUpscalerUltraStyle? Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::Leonardo.UniversalUpscalerUltraStyleExtensions.ToEnum(stringValue);
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Leonardo.UniversalUpscalerUltraStyle)numValue;
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Leonardo.UniversalUpscalerUltraStyle? value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            if (value == null)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(global::Leonardo.UniversalUpscalerUltraStyleExtensions.ToValueString(value.Value));
            }
        }
    }
}