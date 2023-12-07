using ranking_da_comunidade_backend.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var teamsRanking = new List<Team>
{
    new("Furia", new[] { "Fallen", "Art" }, 3),
    new("MIBR", new[] { "Insani", "Brnzan" }, 2),
    new("O Plano", new[] { "Kng", "Fer" }, 1)
};
app.MapGet("/teams", () => teamsRanking);
app.MapPost("/submitRanking", (List<Team> userRanking) =>
{
    teamsRanking = userRanking;
});

app.Run();