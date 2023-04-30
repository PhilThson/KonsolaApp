namespace Konsola.Model
{
    public struct Rozmiar
    {
        public int Szerokosc, Wysokosc;
        public override string ToString()
        {
            return $"{Szerokosc} x {Wysokosc}";
        }
    }
    public class UstawieniaKonsoli : ICloneable
    {
        public ConsoleColor KolorTla, KolorCzcionki;
        public Rozmiar RozmiarOkna, RozmiarBufora;
        public string Tytul;

        public object Clone()
        {
            return new UstawieniaKonsoli()
            {
                KolorTla = this.KolorTla,
                KolorCzcionki = this.KolorCzcionki,
                RozmiarOkna = this.RozmiarOkna,
                RozmiarBufora = this.RozmiarBufora,
                Tytul = this.Tytul
            };
        }

        public override string ToString()
        {
            string s = "";
            s += $"Kolor tła: {KolorTla}";
            s += $"\nKolor czcionki: {KolorCzcionki}";
            s += $"\nRozmiar okna: {RozmiarOkna}";
            s += $"\nRozmiar bufora: {RozmiarBufora}";
            s += $"\nTytuł: {Tytul}";
            return s;
        }
    }
}
