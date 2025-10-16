using System.Text.Json.Serialization;

namespace ProjetoDietas.Models;

public class Alimento
{
    [JsonPropertyName("id")] // Mapeia o "id" do JSON para a propriedade Id
    public int Id { get; set; }

    [JsonPropertyName("description")]
    public string? Nome { get; set; }

    [JsonPropertyName("category")]
    public string? Categoria { get; set; }

    // Aplicamos nosso "tradutor" a todas as propriedades que podem ter "NA", "Tr", etc.
    [JsonPropertyName("energy_kcal")]
    [JsonConverter(typeof(JsonStringToDoubleConverter))]
    public double EnergiaKcal { get; set; }

    [JsonPropertyName("protein_g")]
    [JsonConverter(typeof(JsonStringToDoubleConverter))]
    public double Proteina { get; set; }

    [JsonPropertyName("lipid_g")]
    [JsonConverter(typeof(JsonStringToDoubleConverter))]
    public double Lipideos { get; set; }

    [JsonPropertyName("carbohydrate_g")]
    [JsonConverter(typeof(JsonStringToDoubleConverter))]
    public double Carboidratos { get; set; }

    [JsonPropertyName("fiber_g")]
    [JsonConverter(typeof(JsonStringToDoubleConverter))]
    public double FibraAlimentar { get; set; }

    [JsonPropertyName("sodium_mg")]
    [JsonConverter(typeof(JsonStringToDoubleConverter))]
    public double Sodio { get; set; }
}