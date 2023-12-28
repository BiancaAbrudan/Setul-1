namespace Ex_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ghiceste numarul intre 1 si 1024!");
            int numarAles = GhicesteNumarul(1, 1024);
            Console.WriteLine($"Numarul ales este: {numarAles}");
        }

        static int GhicesteNumarul(int limitaInferioara, int limitaSuperioara)
        {
            Console.WriteLine($"Numarul este mai mare sau egal cu {limitaInferioara}? (da/nu)");
            string raspuns = Console.ReadLine();

            if (raspuns.ToLower() == "da")
            {
                if (limitaInferioara == limitaSuperioara)
                {
                    return limitaInferioara;
                }

                int mijloc = (limitaInferioara + limitaSuperioara) / 2;
                return GhicesteNumarul(mijloc, limitaSuperioara);
            }
            else if (raspuns.ToLower() == "nu")
            {
                if (limitaInferioara == limitaSuperioara)
                {
                    return limitaInferioara + 1;
                }

                int mijloc = (limitaInferioara + limitaSuperioara) / 2 + 1;
                return GhicesteNumarul(limitaInferioara, mijloc - 1);
            }
            else
            {
                Console.WriteLine("Raspuns invalid. Te rog sa raspunzi cu 'da' sau 'nu'.");
                return GhicesteNumarul(limitaInferioara, limitaSuperioara);
            }
        }
    }
}