using AdaYazilimProject.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// --- Algoritma ---
static RezervasyonYaniti Hesapla(RezervasyonIstek istek)
{
    int kalan = istek.RezervasyonYapilacakKisiSayisi;
    var yerlesim = new List<YerlesimAyrinti>();

    var vagonlar = istek.Tren.Vagonlar
        .Select(v =>
        {
            int max = (int)Math.Floor(v.Kapasite * 0.7);
            int musait = Math.Max(0, max - v.DoluKoltukAdet);
            return new { v.Ad, Musait = musait };
        })
        .ToList();

    if (!istek.KisilerFarkliVagonlaraYerlestirilebilir)
    {
        var uygun = vagonlar.FirstOrDefault(v => v.Musait >= kalan);
        if (uygun is null)
            return new RezervasyonYaniti(false, new());
        yerlesim.Add(new YerlesimAyrinti(uygun.Ad, kalan));
        return new RezervasyonYaniti(true, yerlesim);
    }
    else
    {
        foreach (var v in vagonlar.OrderByDescending(v => v.Musait))
        {
            if (kalan == 0) break;
            if (v.Musait <= 0) continue;

            int yerlestir = Math.Min(v.Musait, kalan);
            yerlesim.Add(new YerlesimAyrinti(v.Ad, yerlestir));
            kalan -= yerlestir;
        }

        return kalan == 0
            ? new RezervasyonYaniti(true, yerlesim)
            : new RezervasyonYaniti(false, new());
    }
}

// --- Endpoint ---
app.MapPost("/rezervasyon", (RezervasyonIstek istek) =>
{
    if (istek.RezervasyonYapilacakKisiSayisi <= 0 || istek.Tren?.Vagonlar == null || istek.Tren.Vagonlar.Count == 0)
        return Results.BadRequest("Geçersiz istek.");

    var yanit = Hesapla(istek);
    return Results.Ok(yanit);
})
.WithName("RezervasyonYap")
.WithOpenApi();

app.Run();
 