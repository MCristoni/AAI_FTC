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
            int.TryParse(StrLida.Substring(StrLida.LastIndexOf(' ') + 1), out int EstadoInicial);
            aux = EstadoInicial;

            //Pegar estado final
            //ex: Entrada => I: 5
            //EstadoFinal = 5
            StrLida = Console.ReadLine();
            //Pega a posição seguinte ao último espaço presente na string
            int.TryParse(StrLida.Substring(StrLida.LastIndexOf(' ') + 1), out int EstadoFinal);

            //Cria uma lista para saber quais são os estados
            List<List<string>> Estados = new List<List<string>>();
            List<string> entradas = new List<string>();
            do
            {
                StrLida = Console.ReadLine();

                //Estrutura:
                //EstadoAtual -> pos 0
                //Entrada     -> pos 1 
                //Saida       -> pos 2+
                string[] str = new string[3];
                str[0] = StrLida[0].ToString();
                str[1] = StrLida[2].ToString();
                try
                {
                    //Juntar tudo da saída em um string só. Ex: '1 2' vai virar 12
                    str[2] = (StrLida.Substring(4)).Replace(" ", "");
                }
                catch
                {
                    //Se no AFN, para uma certa entrada, não houver saída, setar o 3 elemento para ""
                    str[2] = "";
                }

                //Lista de estados
                //  Lista de cada entrada para este estado
                //      Saida para cada entrada de cada estado
                if (aux % (Alfabeto.Length - 1) == EstadoInicial)
                {
                    //Inicio nova entrada
                    entradas = new List<string>();
                    entradas.Add(str[2]);
                    Estados.Add(entradas);
                }
                else
                {
                    entradas.Add(str[2]);
                }
                aux++;
            } while (aux <= (EstadoFinal * (Alfabeto.Length - 1)));

            List<string[]> saida = new List<string[]>();
            List<string> estadosAFD = new List<string>();
            List<string> estadosAFDAux = new List<string>();
            int EstadoAtual = EstadoInicial;
            estadosAFD.Add(EstadoInicial.ToString());
            estadosAFDAux.Add(EstadoInicial.ToString());
            int posEstadoafd = 0;
            do
            {
                for (int i = 0; i < (Alfabeto.Length - 1); i++)
                {
                    try
                    {
                        //todo: Continuar a partir daqui
                        //Tentar usar algo tipo hashmap para indexar strings
                        string[] str2 = new string[3];
                        //Estado
                        str2[0] = EstadoAtual.ToString();
                        //Entrada
                        str2[1] = Alfabeto[i + 1]; //i+1 pois a primeira posição seria ABC:, por exemplo 
                        //Saida
                        str2[2] = Estados[EstadoAtual - 1][int.Parse(str2[1])];

                        if (!estadosAFD.Contains(str2[2]) && !string.IsNullOrWhiteSpace(str2[2]))
                        {
                            estadosAFD.Add(str2[2]);
                        }
                        saida.Add(str2);
                        estadosAFDAux.RemoveAt(0);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
                EstadoAtual++;
            } while (estadosAFDAux.Count > 0);



            Console.WriteLine("\n\n\n===== AFD =====");
            Console.WriteLine(string.Join(" ", Alfabeto));
            Console.WriteLine("i: " + EstadoInicial);
            Console.WriteLine("f: " + EstadoFinal);

            Console.Write("Pressione ENTER pra sair");
            Console.ReadLine();
        }
    }
}
