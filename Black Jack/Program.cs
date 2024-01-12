using System.ComponentModel;
using System.ComponentModel.Design;

namespace Black_Jack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Programmet är skapat av Manh Dao

            int SpelarePoängSumma = 0;
            int DatornPoängSumma = 0;
            int kortvärde = 0;
            string[] SenasteVinnare = new string[1];
            string spelsvar = "";
            Console.WriteLine("Välkommen till 21:an");
          

            while (spelsvar != "4")
            {
                
                Console.WriteLine("Välj ett alternativ\n1. Spela 21:an\n2. Visa senaste vinnaren\n3. Spelets regler\n4. Avsluta programmet");
                 spelsvar = Console.ReadLine();

                switch (spelsvar)
                {
                    case "1":
                        Console.WriteLine("Nu kommer två kort dras per spelare");
                        SpelarePoängSumma += drakort(2);
                        DatornPoängSumma += drakort(2);
                        Console.WriteLine($"Din poäng: {SpelarePoängSumma}\nDatorns poäng: {DatornPoängSumma}\nVill du ha ett till kort? (j/n)");
                        string fortsättningsvar = Console.ReadLine();
                        while (fortsättningsvar != "n")
                        {

                            kortvärde = drakort(1);
                            SpelarePoängSumma += kortvärde;
                            Console.WriteLine($"Kortet du drog var värt {kortvärde} poäng\nDin totolpoäng: {SpelarePoängSumma}\nDatorns totalpoäng: {DatornPoängSumma}\nVill du ha ett till kort? (j/n)");
                            fortsättningsvar = Console.ReadLine();

                        }
                        if (fortsättningsvar == "n")
                        {
                            kortvärde = drakort(1);
                            DatornPoängSumma += kortvärde;
                            Console.WriteLine($"Datorn drog ett kort värt {kortvärde} poäng");
                            Console.WriteLine($"Din poäng: {SpelarePoängSumma}\nDatorns poäng: {DatornPoängSumma}\nVill du ha ett till kort? (j/n)");
                            if (UtseVinnare(DatornPoängSumma, SpelarePoängSumma) == "Datorn")
                            {
                                Console.WriteLine("Tyvärr, datorn har vunnit");
                                SenasteVinnare[0] = "Datorn";
                                ResetPoängSumma(DatornPoängSumma, SpelarePoängSumma);
                            }
                            else
                            {
                                Console.WriteLine("Grattis du har vunnit!\n Vad heter du?");
                                SenasteVinnare[0] = Console.ReadLine();
                                ResetPoängSumma(DatornPoängSumma, SpelarePoängSumma);

                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine($"Senaste vinnare är: {SenasteVinnare[0]}");
                        break;
                    case "3":
                        Console.WriteLine("Spelreglerna finns i följande länk: https://www.progsharp.se/projektuppgifter/1-21an/");
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Välj ett giltligt alternativ");
                        break;

                }
            }
        }
            static int drakort(int antalkort)
            {
                int dragenkortPoängSumma = 0;

                for (int i = 0; i < antalkort; i++)
                {
                    Random slum = new Random();
                    int SlumKort = slum.Next(1, 10);
                    dragenkortPoängSumma += SlumKort;

                }
             
                return dragenkortPoängSumma;
            }
            static string UtseVinnare(int DatornPoängSumma, int SpelarePoängSumma)
            {
            string vinnaren = " ";
                if (SpelarePoängSumma > 21)
                {
                vinnaren = "Datorn";
                }
                if (DatornPoängSumma > SpelarePoängSumma && DatornPoängSumma <= 21)
                {
                    vinnaren = "Datorn";
                }
                else if (SpelarePoängSumma > DatornPoängSumma && SpelarePoängSumma < 21) 
                {
                    vinnaren = "Spelare";
                }
                return vinnaren;
            }

        static void ResetPoängSumma(int SpelarePoängSumma, int DatornPoängSumma)
        {
            SpelarePoängSumma = 0;
            DatornPoängSumma = 0;
        }
        

        
    }
}