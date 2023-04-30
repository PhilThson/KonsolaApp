using Konsola.Kontroler;

namespace Konsola.Widok
{
    using static Konsola.Kontroler.Menu;
    using static Wejscie;
    public class WyswietlMenu
    {
        public static int wyswietlMenu(Dictionary<int, KeyValuePair<string, DelegataWyborMenu>> menu)
        {
            int wybor = 0;
            Console.Write("Menu:");
            foreach (KeyValuePair<int, KeyValuePair<string, DelegataWyborMenu>> kvp in menu)
            {
                Console.Write($"{kvp.Value.Key}");
            }
            Console.WriteLine("\n0. Zakończ program");
            wybor = PobierzOdUzytkownikaLiczbeCalkowita(
                "Wybierz pozycję z menu wpisując liczbę i naciskając klawisz Enter: ", 6);
            return wybor;
        }
    }
}
