using System;

namespace Konsola
{
    using Model;
    using Kontroler;
    using Konsola.Widok;

    public class Program
    {
        private static UstawieniaKonsoli poprzednieUstawienia 
            = UstawieniaKonsoliHelper.UstawieniaBiezace;
        private static void OnUstawieniaZmienione(object sender, UstawieniaKonsoli ustawienia)
        {
            //Console.WriteLine("Próbuje zastosować ustawienia");
            //Console.WriteLine($"(Wywołane przez: {sender.GetType().Name})");
            sprobujZastosowacUstawienia(ustawienia);
        }
        private static void sprobujZastosowacUstawienia(UstawieniaKonsoli ustawienia)
        {
            if (StosowanieUstawienKonsoli.ZastosujUstawieniaKonsoli(ustawienia))
            {
                poprzednieUstawienia = (UstawieniaKonsoli)ustawienia.Clone();
            }
            else
            {
                Console.Error.WriteLine("Przywracam poprzednie ustawienia.");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                StosowanieUstawienKonsoli.ZastosujUstawieniaKonsoli(poprzednieUstawienia);
            }
        }
        static void Main()
        {
            UstawieniaKonsoli model = UstawieniaKonsoliHelper.UstawieniaBiezace;
            sprobujZastosowacUstawienia(model);
            Menu kontroler = new Menu(model);
            //subskrybowanie zdarzenia
            kontroler.UstawieniaZmienione += OnUstawieniaZmienione;

            kontroler.Uruchom();
        }
    }
}