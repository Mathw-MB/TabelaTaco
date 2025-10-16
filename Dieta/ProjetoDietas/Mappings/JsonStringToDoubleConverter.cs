using System.Text.Json;
using System.Text.Json.Serialization;

// Este é o nosso "tradutor" para o leitor de JSON
public class JsonStringToDoubleConverter : JsonConverter<double>
{
    // Lógica de leitura: como transformar o dado do JSON em um double
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Se o dado no JSON for um número, leia-o normalmente
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetDouble();
        }

        // Se for um texto...
        if (reader.TokenType == JsonTokenType.String)
        {
            string? text = reader.GetString();
            // Verificamos se é "NA", "Tr" ou vazio. Se for, retornamos 0.
            if (string.IsNullOrEmpty(text) || text == "NA" || text == "Tr")
            {
                return 0.0;
            }

            // Se for um texto que representa um número, tentamos convertê-lo
            if (double.TryParse(text, out double value))
            {
                return value;
            }
        }

        // Caso padrão de segurança
        return 0.0;
    }

    // Lógica de escrita: como transformar um double do C# em JSON (não usaremos, mas é obrigatório implementar)
    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}