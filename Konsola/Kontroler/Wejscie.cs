namespace Konsola.Kontroler
{
    using static Console;
    public static class Wejscie
    {
        private delegate string Delegata(string s, int a, int b);

        private static readonly SortedList<string, string> slownik = new SortedList<string, string>();
       
        static Wejscie()
        {
            initDictionary();
        }

        private static void initDictionary()
        {
            slownik.Add("Czarny", "Black");
            slownik.Add("Ciemno niebieski", "DarkBlue");
            slownik.Add("Ciemnoniebieski", "DarkBlue");
            slownik.Add("Ciemno zielony", "DarkGreen");
            slownik.Add("Ciemnozielony", "DarkGreen");
            slownik.Add("Ciemno czerwony", "DarkRed");
            slownik.Add("Ciemnoczerwony", "DarkRed");
            slownik.Add("Ciemno żółty", "DarkYellow");
            slownik.Add("Ciemno zolty", "DarkYellow");
            slownik.Add("Ciemnożółty", "DarkYellow");
            slownik.Add("Ciemnozolty", "DarkYellow");
            slownik.Add("Szary", "Gray");
            slownik.Add("Ciemno szary", "DarkGray");
            slownik.Add("Ciemnoszary", "DarkGray");
            slownik.Add("Niebieski", "Blue");
            slownik.Add("Zielony", "Green");
            slownik.Add("Czerwony", "Red");
            slownik.Add("Żółty", "Yellow");
            slownik.Add("Zolty", "Yellow");
            slownik.Add("Biały", "White");
            slownik.Add("Bialy", "White");
        }

        public static int PobierzOdUzytkownikaLiczbeCalkowita(
            string zacheta, 
            int wartoscMaksymalna, 
            int wartoscMinimalna = 0)
        {
            int? liczba = null;
            do
            {
                try
                {
                    string s;
                    do
                    {
                        Write(zacheta);
                        s = ReadLine();
                    } while (string.IsNullOrWhiteSpace(s));
                    liczba = int.Parse(s);
                    if (liczba < wartoscMinimalna || liczba > wartoscMaksymalna)
                        throw new Exception("Niepoprawna wartość liczby.");
                }
                catch(Exception exc)
                {
                    WriteLine($"Błąd: {exc.Message}");
                    WriteLine("Niepoprawna wartość. Spróbuj jeszcze raz.");
                }
            } while (!liczba.HasValue);
            return liczba.Value;
        }

        public static ConsoleColor PobierzOdUzytkownikaKolor(string zacheta)
        {
            ConsoleColor? kolor = null;
            do
            {
                try
                {
                    string s;
                    Delegata delegata = (s, a, b) => 
                        char.ToUpper(s[a]) + s.ToLower().Substring(b);
                    do
                    {
                        Write(zacheta);
                        s = ReadLine();
                        // poniższa lnia zastąpiona delegatą
                        //s = char.ToUpper(s[0]) + s.ToLower().Substring(1);
                        s = delegata(s, 0, 1);
                        if (slownik.TryGetValue(s, out string value))
                            s = value;
                        //obsługa np. DarkBlue
                        if (s.StartsWith("Dark") && s.Length > 5)
                            s = "Dark" + delegata(s, 4, 5);
                            //s = "Dark" + char.ToUpper(s[4]) + s.ToLower().Substring(5);
                    } while (string.IsNullOrWhiteSpace(s));
                    kolor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), s);
                }
                catch (Exception exc)
                {
                    WriteLine($"Błąd: {exc.Message}");
                    WriteLine("Niepoprawna nazwa koloru. Spróbuj jeszcze raz.");
                }
            } while (!kolor.HasValue);
            return kolor.Value;
        }
    }
}