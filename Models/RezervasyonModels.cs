namespace AdaYazilimProject.Models;

public record Vagon(string Ad, int Kapasite, int DoluKoltukAdet);
public record Tren(string Ad, List<Vagon> Vagonlar);

public record RezervasyonIstek
{
    public Tren Tren { get; init; } = default!;
    public int RezervasyonYapilacakKisiSayisi { get; init; }
    public bool KisilerFarkliVagonlaraYerlestirilebilir { get; init; }
}

public record YerlesimAyrinti(string VagonAdi, int KisiSayisi);

public record RezervasyonYaniti(bool RezervasyonYapilabilir, List<YerlesimAyrinti> YerlesimAyrinti);
 