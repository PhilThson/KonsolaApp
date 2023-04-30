namespace Konsola.Model
{
    public static class UstawieniaKonsoliHelper
    {
        public static UstawieniaKonsoli UstawieniaBiezace
        {
            get
            {
                return new UstawieniaKonsoli()
                {
                    KolorTla = Console.BackgroundColor,
                    KolorCzcionki = Console.ForegroundColor,
                    RozmiarOkna =
                    {
                        Szerokosc = Console.WindowWidth,
                        Wysokosc = Console.WindowHeight
                    },
                    RozmiarBufora =
                    {
                        Szerokosc = Console.BufferWidth,
                        Wysokosc = Console.BufferHeight
                    },
                    Tytul = Console.Title
                };
            }
        }

        public static UstawieniaKonsoli UstawieniaDomyslne { get; } =
            new UstawieniaKonsoli()
            {
                KolorTla = ConsoleColor.Black,
                KolorCzcionki = ConsoleColor.Gray,
                RozmiarOkna = { Szerokosc = 120, Wysokosc = 30 },
                RozmiarBufora = { Szerokosc = 120, Wysokosc = 9001 },
                Tytul = System.Reflection.Assembly.GetEntryAssembly().Location
            };
    }
}
