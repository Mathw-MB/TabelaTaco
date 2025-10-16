using ProjetoDietas.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

// ======== POPULAR BANCO COM O ARQUIVO JSON DO TACO ========
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AppDataContext>();
    ctx.Database.Migrate();

    if (!ctx.Alimentos.Any())
    {
        // Salve o seu novo arquivo JSON com este nome na pasta do projeto
        string json = File.ReadAllText("taco.json");

        // A "mágica" acontece aqui: deserializa o JSON diretamente para uma lista de Alimentos
        var alimentos = System.Text.Json.JsonSerializer.Deserialize<List<Alimento>>(json);

        if (alimentos != null)
        {
            ctx.Alimentos.AddRange(alimentos);
            ctx.SaveChanges();
            Console.WriteLine("✅ Banco de dados populado com sucesso a partir do arquivo JSON!");
        }
    }
}

app.Run();