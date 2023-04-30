namespace Konsola.Widok
{
    using Model;

    public class StosowanieUstawienKonsoli
    {
        public static bool ZastosujUstawieniaKonsoli(UstawieniaKonsoli ustawienia, bool wyczyscKonsole = true)
        {
            try
            {
                Console.BackgroundColor = ustawienia.KolorTla;
                Console.ForegroundColor = ustawienia.KolorCzcionki;
                Console.SetWindowSize(ustawienia.RozmiarOkna.Szerokosc, ustawienia.RozmiarOkna.Wysokosc);
                Console.SetBufferSize(ustawienia.RozmiarBufora.Szerokosc, ustawienia.RozmiarBufora.Wysokosc);
                Console.Title = ustawienia.Tytul;
                if (wyczyscKonsole)
                    Console.Clear();
                return true;
            }
            catch(Exception exc)
            {
                Console.Error.WriteLine($"Wystąpił bład: {exc.Message}");
                return false;
            }
        }
    }
}
