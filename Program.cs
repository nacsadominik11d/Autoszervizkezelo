using Autoszervizkezelo;


List<Munkalap> munkalapok = new List<Munkalap>();

string[] sorok = File.ReadAllLines("munkalapok.txt");

Console.WriteLine("Rögzített munkalapok:");

foreach (string sor in sorok)
{
    Munkalap munkalap = new Munkalap(sor);
    munkalapok.Add(munkalap);
    Console.WriteLine(munkalap);
}
Console.WriteLine();

int teljesBevetel = munkalapok.Sum(m => m.FizetendoDij());
Console.WriteLine($"Szerviz teljes bevétele: {teljesBevetel} Ft");

int minOra = munkalapok.Min(m => m.Munkaora);
int maxOra = munkalapok.Max(m => m.Munkaora);
Console.WriteLine($"Legrövidebb javítás: {minOra} óra, leghosszabb javítás: {maxOra} óra");

double atlagOra = munkalapok.Average(m => m.Munkaora);
Console.WriteLine($"Átlagos munkaidő: {atlagOra:F1} óra");

var legtobbetFizeto = munkalapok.OrderByDescending(m => m.FizetendoDij()).First();
Console.WriteLine($"Legtöbbet fizető ügyfél: {legtobbetFizeto.UgyfelNev} ({legtobbetFizeto.FizetendoDij()} Ft)");

int fizetosDb = munkalapok.Count(m => m.Garancialis == false);
Console.WriteLine($"Fizetős munkalapok száma: {fizetosDb} db");