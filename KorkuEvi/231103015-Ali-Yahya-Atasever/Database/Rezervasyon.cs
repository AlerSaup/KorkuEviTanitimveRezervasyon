using System;
using System.Collections.Generic;

namespace _231103015_Ali_Yahya_Atasever.Database;

public partial class Rezervasyon
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public DateTime RezervasyonTarihi { get; set; }

    public TimeSpan? RezervasyonSaati { get; set; }
}
