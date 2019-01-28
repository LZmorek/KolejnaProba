using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolejnaProba
{


    public abstract class Operacje
    {
        public int First { get; set; }
        public int Second { get; set; }

        public abstract void Dzialanie();

    }
    public class Dodawanie : Operacje
    {
        public override void Dzialanie()
        {
            Console.WriteLine($"Sum:{ First + Second}");
            Console.ReadKey();

        }
    }
    public class Odejmowanie : Operacje
    {
        public override void Dzialanie()
        {
            Console.WriteLine($"Min:{ First - Second}");
            Console.ReadKey();

        }
    }
    public class Mnozenie : Operacje
    {
        public override void Dzialanie()
        {
            Console.WriteLine($"mnoz{ First * Second}");
            Console.ReadKey();

        }
    }
    public class Dzielenie : Operacje
    {
        public override void Dzialanie()
        {
            Console.WriteLine($"dziel:{ (float)First / Second}");
            Console.ReadKey();
        }
    }
    public class Liczby
    {

        public int PobierzLiczbe(int Num)
        {

            string end = "";
            do
            {
                try
                {
                    Console.WriteLine("Prosze podac liczbe: ");
                    string FirstNum = Console.ReadLine();
                    Num = Convert.ToInt32(FirstNum);
                    end = "end";
                }
                catch (FormatException fEx)
                {
                    Console.WriteLine(fEx.Message);
                    Console.WriteLine("Wpisz Liczbe Ponownie: ");
                }
                catch (OverflowException OverEx)
                {
                    Console.WriteLine(OverEx.Message);
                    Console.WriteLine("Wpisz Liczbe Ponownie: ");
                }
                catch (DivideByZeroException fEx)
                {
                    Console.WriteLine(fEx.Message);
                    Console.WriteLine("nie dziel przez 0! :)");
                }
                catch (ArithmeticException ArgEx)
                {
                    Console.WriteLine(ArgEx.Message);
                    Console.WriteLine("Wpisz Liczbe Ponownie: ");
                }
                catch (Exception Ex)
                {
                    Console.WriteLine("Coœ posz³o nie tak");
                    Console.WriteLine("Wpisz Liczbe Ponownie: ");
                }
                
            } while (end != "end");
            return Num;
        }
    }
    public class WybierzDzialanie
        {
        public int Wybierz()

            {
            string end = "";
            int wyb=0;
            do
            {
                
                Console.WriteLine("Wybierz Dzialanie od 1 do 4:  ");
                Console.WriteLine("1.Dodawanie ");
                Console.WriteLine("2.Odejmowanie ");
                Console.WriteLine("3.Mnozenie ");
                Console.WriteLine("4.Dzielenie ");
                string wybor = Console.ReadLine();
                wyb = Convert.ToInt32(wybor);

                if (wyb <= 0 && wyb >= 4)
                {
                    Console.WriteLine("wybrano zla liczbe, prosze wybrac liczbe od 1-4: ");
                    Wybierz();
                }
                else
                {
                    end = "end";
                }
            } while (end != "end");
            return wyb;
            
            }
        }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witamy w PseudoKalulatorze 2000:) ");
            Console.WriteLine(" ");
            int Num=0;
            Liczby num = new Liczby();

            int FirstNumber=num.PobierzLiczbe(Num);
            int SecondNumber = num.PobierzLiczbe(Num);

            WybierzDzialanie Wybor = new WybierzDzialanie();

            Dodawanie dodaj = new Dodawanie() { First = FirstNumber, Second = SecondNumber };
            Odejmowanie odejm = new Odejmowanie() { First = FirstNumber, Second = SecondNumber };
            Mnozenie mnoz = new Mnozenie() { First = FirstNumber, Second = SecondNumber };
            Dzielenie dziel = new Dzielenie() { First = FirstNumber, Second = SecondNumber };

            switch (Wybor.Wybierz())
            {
                case 1: { dodaj.Dzialanie(); break; }
                case 2: { odejm.Dzialanie(); break; }
                case 3: { mnoz.Dzialanie(); break; }
                case 4: { dziel.Dzialanie(); break; }
                default : { Console.WriteLine("Wybrano niewlasciwa liczbe"); break; }
            }
        }
    }
}
