using System;

namespace PatronSingleton_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INSERTE UN NUMERO ENTERO ");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0)
            {
                String resultado = "";
                while (num > 0)
                {
                    if (num % 2 == 0)
                    {
                        resultado = "0" + resultado;
                    }
                    else
                    {
                        resultado = "1" + resultado;
                    }
                    num = (int)(num / 2);
                }
                Console.WriteLine("Numero binario: ");
                Console.WriteLine(resultado);
            }
            else
            {
                if (num == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine("INSERTE SOLO NUMEROS POSITIVOS ");
                }
            }
            Console.ReadLine();
        }
    }
}
