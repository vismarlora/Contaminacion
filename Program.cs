using System;
using System.Threading;

namespace Contaminacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int poblacion = 0, contaminacion = 0, industria;
            poblacion = random.Next(10000, 15000000);
            industria = random.Next(100000, 2000000000);
            int canIndustria = random.Next(1, 1000);
            int CapxInd = industria / canIndustria;
            int longitud = 300;
            int aux = 0, ald = 0, aldtotal = 0;
            int ac1 = 0, ac2 = 0, alm = 0, alin = 0, alm2 = 0;
            int totalP = 0, totalin = 0, aldin = 0;


            float desidad = poblacion / longitud;


            do
            {
                int rP = random.Next(1, 2000);
                int PL = random.Next(1, 10000);
                int Ri = random.Next(1, 500000);
                int PM = random.Next(1, 80000);
                int Im = random.Next(1, 800000);
                for (int i = 0; i < poblacion; i++)
                {
                    if (i % 250000 == 0)
                    {
                        contaminacion++;
                    }
                }
                for (int i = 0; i < industria; i++)
                {
                    if (i % 6000000 == 0)
                    {
                        poblacion += rP;
                        ac1++;
                    }
                    if (i % 50000000 == 0)
                    {
                        contaminacion++;
                    }
                }
                aux = contaminacion;
                alm = PL;
                alm2 = Ri;
                poblacion += PL;
                industria += Ri;
                if (contaminacion > 20)
                {
                    ac2++;
                    poblacion = poblacion - PM;
                    industria = industria - Im;
                }
                if (ac1 > 0 && ac2 > 0)
                {
                    totalP = rP + alm - PM;
                    totalin = alm2 - Im;
                }
                else if (ac1 > 0)
                {
                    totalP = rP + alm;
                }
                else if (ac2 > 0)
                {
                    totalP = alm - PM;
                    totalin = alm2 - Im;
                }
                if (totalP < 0)
                {
                    ald++;
                    aldtotal -= totalP;
                }
                if (totalin < 0)
                {
                    alin++;
                    aldin -= totalin;
                }

                Console.WriteLine($"Cantidad de la Poblacion: {poblacion}");
                Console.WriteLine($"Tasa de Crecimiento: {totalP}");
                Console.WriteLine($"Capital En Industrias: {industria} ");
                Console.WriteLine($"Contaminacion: {contaminacion}%");
                Console.WriteLine("\n\n--------------------------------------------------\n\n");
                Thread.Sleep(100);
                contaminacion = 0;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.WriteLine("\n\n--------------------------------------------------\n\n");
            Console.WriteLine($"Cantidad de veces que disminuyo la poblacion: {ald}");
            Console.WriteLine($"Total disminuido : {aldtotal}");
            Console.WriteLine($"Cantidad de veces que disminuyo el Capital Industrial: {alin} ");
            Console.WriteLine($"Total disminuido: {aldin}");
            Console.WriteLine("\n\n--------------------------------------------------\n\n");
        }
    }
}
