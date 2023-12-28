namespace Ex_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduceti numaratorul (m): ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduceti numitorul (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Rezultatul fractiei {m}/{n} in format zecimal este: {ConvertFractionToDecimal(m, n)}");
            Console.WriteLine($"Tipul de fractie este: {DetermineFractionType(n)}");
        }

        static string ConvertFractionToDecimal(int m, int n)
        {
            
            string result = (m / n).ToString() + ".";
            long remainder = m % n;
            var remainderPositions = new System.Collections.Generic.Dictionary<long, int>();
            var decimalPart = new System.Text.StringBuilder();
      
            int position = 0;

            while (remainder != 0 && !remainderPositions.ContainsKey(remainder))
            {
                remainderPositions.Add(remainder, position);

                remainder *= 10;
                long quotient = remainder / n;
                decimalPart.Append(quotient);

                remainder = remainder % n;

                position++;
            }

            if (decimalPart.Length > 0)
            {
                if (remainderPositions.ContainsKey(remainder))
                {
                    int repeatStart = remainderPositions[remainder];
                    string nonRepeatingPart = decimalPart.ToString().Substring(0, repeatStart);
                    string repeatingPart = decimalPart.ToString().Substring(repeatStart);

                    result += nonRepeatingPart + "(" + repeatingPart + ")";
                }
                else
                {
                    result += decimalPart.ToString();
                }
            }

            return result;
        }

        static string DetermineFractionType(int n)
        {
            if (IsNonRepeatingFraction(n))
            {
                return "Neperiodica";
            }
            else if (IsSimpleRepeatingFraction(n))
            {
                return "Periodica Simpla";
            }
            else
            {
                return "Periodica Mixta";
            }
        }

        static bool IsNonRepeatingFraction(int n)
        {
            return n % 2 == 0 || n % 5 == 0;
        }

        static bool IsSimpleRepeatingFraction(int n)
        {
            return !IsNonRepeatingFraction(n);
        }
    }
}