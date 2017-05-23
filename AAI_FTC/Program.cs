using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_FTC
{
    class Program
    {
        private static string StrLida = Console.ReadLine();
        private static int aux;
        public static void Main(string[] args)
        {
            //Pega entrada do Alfabeto e coloca cada item nu ma posição dum vetor
            //ex: Entrada => ABC: 1 2 3
            //Alfabeto[0] = ABC:
            //Alfabeto[1] = 1
            //Alfabeto[2] = 2
            //Alfabeto[3] = 3
            string[] Alfabeto = StrLida.Split(' ');//pegar pos 1 em diante

            //Pegar estado inicial
            //ex: Entrada => I: 1
            //EstadoInicial = 1
            StrLida = Console.ReadLine();
            //Pega a posição seguinte ao último espaço presente na string
            int.TryParse(StrLida.Substring(StrLida.LastIndexOf(' ')+1), out int EstadoInicial);
            aux = EstadoInicial;

            //Pegar estado final
            //ex: Entrada => I: 5
            //EstadoFinal = 5
            StrLida = Console.ReadLine();
            //Pega a posição seguinte ao último espaço presente na string
            int.TryParse(StrLida.Substring(StrLida.LastIndexOf(' ') + 1), out int EstadoFinal);

            //Cria uma lista para saber quais s~ao os estados
            List<string> Estados = new List<string>();

            do
            {
                StrLida = Console.ReadLine();
                //Inicio nova entrada
                //if (aux % (Alfabeto.Length - 1) == EstadoInicial)
                //{
                    //Estrutura:
                    //EstadoAtual Entrada Saida
                    string[] str = new string[3];
                    str[0] = StrLida[0].ToString();
                    str[1] = StrLida[2].ToString();
                    try
                    {
                        str[2] = (StrLida.Substring(4)).Replace(" ", "");
                    }
                    catch
                    {
                        str[2] = "";
                    }

                    if (!Estados.Contains(str[2]) && !string.IsNullOrWhiteSpace(str[2]))
                    {
                        Estados.Add(str[2]);
                    }
                //}
                aux++;
            } while (aux <= (EstadoFinal * (Alfabeto.Length-1)));

            Console.WriteLine(EstadoInicial);
            Console.WriteLine(EstadoFinal);
            Console.ReadLine();

            //estado entrada saida
            //1 0 1
            //1 1 1 2
            //2 0 3
            //2 1
            //3 0
            //3 1 4
            //4 0 5
            //4 1
            //5 0
            //5 1
        }
    }
}
