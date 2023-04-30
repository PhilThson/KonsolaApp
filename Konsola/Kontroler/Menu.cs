namespace Konsola.Kontroler
{
    using static Wejscie;
    using Model;
    using Widok;
    public class Menu
    {
        private UstawieniaKonsoli ustawienia;
        public delegate void DelegataWyborMenu();
        private static readonly Dictionary<string, DelegataWyborMenu> slownik
            = new Dictionary<string, DelegataWyborMenu>();
        private static readonly Dictionary<int, KeyValuePair<string, DelegataWyborMenu>> menu
            = new Dictionary<int, KeyValuePair<string, DelegataWyborMenu>>();
        private static List<UstawieniaKonsoli> historiaUstawien
            = new List<UstawieniaKonsoli>();

        public delegate void Delegata(object sender, UstawieniaKonsoli ustawienia);

        public event Delegata UstawieniaZmienione;

        private void initSlownik()
        {
            DelegataWyborMenu referencjaDoMetodMenu = przywrocUstawieniaDomyslne;
            referencjaDoMetodMenu += zmienKolorTla;
            referencjaDoMetodMenu += zmienKolorCzcionki;
            referencjaDoMetodMenu += zmienRozmiarOkna;
            referencjaDoMetodMenu += zmienRozmiarBufora;
            referencjaDoMetodMenu += zmienTytulOkna;
            referencjaDoMetodMenu += cofnijZmiany;
            referencjaDoMetodMenu += powtorzZmiany;
            slownik.Add("\n1. Przywróć ustawienia domyślne", 
                (DelegataWyborMenu)referencjaDoMetodMenu.GetInvocationList()[0]);
            slownik.Add("\n2. Zmień kolor tła",
                (DelegataWyborMenu)referencjaDoMetodMenu.GetInvocationList()[1]);
            slownik.Add("\n3. Zmień kolor czcionki",
                (DelegataWyborMenu)referencjaDoMetodMenu.GetInvocationList()[2]);
            slownik.Add("\n4. Zmień rozmiar okna",
                (DelegataWyborMenu)referencjaDoMetodMenu.GetInvocationList()[3]);
            slownik.Add("\n5. Zmień rozmiar bufora",
                (DelegataWyborMenu)referencjaDoMetodMenu.GetInvocationList()[4]);
            slownik.Add("\n6. Zmień tytuł okna",
                (DelegataWyborMenu)referencjaDoMetodMenu.GetInvocationList()[5]);
            slownik.Add("\n7. Cofnij zmiany",
                (DelegataWyborMenu)referencjaDoMetodMenu.GetInvocationList()[6]);
            slownik.Add("\n8. Powtórz zmiany",
                (DelegataWyborMenu)referencjaDoMetodMenu.GetInvocationList()[7]);
        }
        private void initMenu()
        {
            int i = 0;
            foreach(KeyValuePair<string, DelegataWyborMenu> kvp in slownik)
                menu.Add(++i, kvp);
        }
        private Menu()
        {
            initSlownik();
            initMenu();
            //NIE DAWAĆ REFERNCJI
            //Bo przy zmianie pola, zmieniaja sie ustawienia globalne
            //historiaUstawien.Add(UstawieniaKonsoliHelper.UstawieniaBiezace);
        }
        public Menu(UstawieniaKonsoli ustawienia) : this()
        {
            this.ustawienia = ustawienia;
            historiaUstawien.Add((UstawieniaKonsoli)ustawienia.Clone());
        }
        private void przywrocUstawieniaDomyslne()
        {
            Console.WriteLine("Przywracam ustawienia domyślne");
            ustawienia.KolorTla = UstawieniaKonsoliHelper.UstawieniaDomyslne.KolorTla;
            ustawienia.KolorCzcionki = UstawieniaKonsoliHelper.UstawieniaDomyslne.KolorCzcionki;
            ustawienia.RozmiarOkna = UstawieniaKonsoliHelper.UstawieniaDomyslne.RozmiarOkna;
            ustawienia.RozmiarBufora = UstawieniaKonsoliHelper.UstawieniaDomyslne.RozmiarBufora;
            ustawienia.Tytul = UstawieniaKonsoliHelper.UstawieniaDomyslne.Tytul;
        }
        private void zmienKolorTla()
        {
            ConsoleColor kolorTla = PobierzOdUzytkownikaKolor("Podaj kolor tła: ");
            ustawienia.KolorTla = kolorTla;
        }
        private void zmienKolorCzcionki()
        {
            ConsoleColor kolorCzcionki = PobierzOdUzytkownikaKolor("Podaj kolor czcionki: ");
            ustawienia.KolorCzcionki = kolorCzcionki;
        }
        private void zmienRozmiarOkna()
        {
            int x = PobierzOdUzytkownikaLiczbeCalkowita("Podaj szerkość okna: ", Console.LargestWindowWidth);
            int y = PobierzOdUzytkownikaLiczbeCalkowita("Podaj wysokość okna: ", Console.LargestWindowHeight);
            Rozmiar rozmiar = new Rozmiar()
            {
                Szerokosc = x,
                Wysokosc = y
            };
            ustawienia.RozmiarOkna = rozmiar;
        }
        private void zmienRozmiarBufora()
        {
            int x = PobierzOdUzytkownikaLiczbeCalkowita("Podaj szerokość bufora: ", short.MaxValue);
            int y = PobierzOdUzytkownikaLiczbeCalkowita("Podaj wysokość bufora: ", short.MaxValue);
            Rozmiar rozmiar = new Rozmiar()
            {
                Szerokosc = x,
                Wysokosc = y
            };
            ustawienia.RozmiarBufora = rozmiar;
        }
        private void zmienTytulOkna()
        {
            Console.Write("Podaj tytuł okna: ");
            string tytul = Console.ReadLine();
            ustawienia.Tytul = tytul;
        }
        private void cofnijZmiany()
        {
            if (historiaUstawien[historiaUstawien.Count - 2] != null)
            {
                ustawienia = historiaUstawien[historiaUstawien.Count - 2];
                historiaUstawien.RemoveRange(historiaUstawien.Count - 2, 2);
            }
            else
                Console.WriteLine("Nie udało się powtórzyć zmian.");
        }
        private void powtorzZmiany()
        {
            ustawienia = historiaUstawien[historiaUstawien.Count - 2];
        }

        public void Uruchom()
        {
            int wybor;
            do
            {
                if (historiaUstawien[historiaUstawien.Count - 1] != ustawienia)
                    historiaUstawien.Add((UstawieniaKonsoli)ustawienia.Clone());

                wybor = WyswietlMenu.wyswietlMenu(menu);

                switch (wybor)
                {
                    case 1: menu.GetValueOrDefault(1).Value.Invoke();
                        break;
                    case 2: menu.GetValueOrDefault(2).Value.Invoke();
                        break;
                    case 3: menu.GetValueOrDefault(3).Value.Invoke(); 
                        break;
                    case 4: menu.GetValueOrDefault(4).Value.Invoke(); 
                        break;
                    case 5: menu.GetValueOrDefault(5).Value.Invoke(); 
                        break;
                    case 6: menu.GetValueOrDefault(6).Value.Invoke(); 
                        break;
                    case 7: menu.GetValueOrDefault(7).Value.Invoke();
                        break;
                    case 8: menu.GetValueOrDefault(8).Value.Invoke();
                        break;
                }
                UstawieniaZmienione(this, ustawienia);
            } while (wybor != 0);
        }
    }
}
