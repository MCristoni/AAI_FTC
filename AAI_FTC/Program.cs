using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_FTC
{
    class Program
    {
        private static string StrLida;
        private static int aux;
        public static void Main(string[] args)
        {
            Console.WriteLine("===== Entrada (AFN) =====");
            StrLida = Console.ReadLine();
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
            string[] auxVet;
            do
            {
                auxVet = new string[(Alfabeto.Length - 1)];
                for (int k = 0; k < estadosAFD[EstadoAtual - EstadoInicial].Length; k++)
                {
                    for(int i = 0; i < (Alfabeto.Length - 1); i++)
                    {
                        auxVet[i] += Estados[(int.Parse((estadosAFDAux[0][k]).ToString()) - 1)][i];
                    }
                }
                for (int j = 0; j < auxVet.Length; j++)
                {
                    saida.Add(new string[] { EstadoAtual.ToString(), j.ToString(), auxVet[j] });
                    if (!estadosAFD.Contains(auxVet[j]) && !string.IsNullOrWhiteSpace(auxVet[j]))
                    {
                        estadosAFD.Add(auxVet[j]);
                        estadosAFDAux.Add(auxVet[j]);
                    }
                }
                EstadoAtual++;
                estadosAFDAux.RemoveAt(0);
            } while (estadosAFDAux.Count > 0);

            //do
            //{
            //    auxVet = new string[(Alfabeto.Length - 1)];
            //    for (int i = 0; i < (Alfabeto.Length - 1); i++)
            //    {
            //        try
            //        {
            //            //todo: Continuar a partir daqui
            //            //Tentar usar algo tipo hashmap para indexar strings
            //            string[] str2 = new string[3];
            //            //Estado
            //            str2[0] = EstadoAtual.ToString();
            //            //Entrada
            //            str2[1] = Alfabeto[i + 1]; //i+1 pois a primeira posição seria ABC:, por exemplo 
            //            //Saida
            //            if (estadosAFD[EstadoAtual - EstadoInicial].Length > 1)
            //            {
            //                precisaAdd = true;
            //                //Percorrer dentro da entrada
            //                for (int k = 0; k < estadosAFD[EstadoAtual - EstadoInicial].Length; k++)
            //                {
            //                    //if (k <= i)
            //                    //{
            //                      //auxVet[k % (Alfabeto.Length - 1)] += Estados[(int.Parse((estadosAFDAux[0][i]).ToString()) - 1)][k % (Alfabeto.Length - 1)];

            //                    int pos = int.Parse((estadosAFD[EstadoAtual - EstadoInicial][i]).ToString());
            //                    var test = Estados[pos - 1][k % (Alfabeto.Length - 1)];
            //                    auxVet[k % (Alfabeto.Length - 1)] += test;
            //                    //}
            //                    //else
            //                    //{
            //                    //  auxVet[k % (Alfabeto.Length - 1)] += Estados[(int.Parse((estadosAFDAux[0][k]).ToString()) - 1)][k % (Alfabeto.Length - 1)];
            //                    //}
            //                    //str2[2] = "";
            //                    //int m;
            //                    //for (m= 0; m < (Alfabeto.Length - 1); m++)
            //                    //{
            //                    //    str2[2] += Estados[(int.Parse((estadosAFDAux[0][m]).ToString()) - 1)][k];
            //                    //}
            //                    //saida.Add(str2);
            //                    //if (!estadosAFD.Contains(str2[2]) && !string.IsNullOrWhiteSpace(str2[2]))
            //                    //{
            //                    //    estadosAFD.Add(str2[2]);
            //                    //    estadosAFDAux.Add(str2[2]);
            //                    //}
            //                    //break;
            //                }
            //            }
            //            else
            //            {
            //                str2[2] = Estados[EstadoAtual - 1][int.Parse(str2[1])];
            //                saida.Add(str2);
            //                precisaAdd = false;
            //                if (!estadosAFD.Contains(str2[2]) && !string.IsNullOrWhiteSpace(str2[2]))
            //                {
            //                    estadosAFD.Add(str2[2]);
            //                    estadosAFDAux.Add(str2[2]);
            //                }
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }
            //    }
            //    for (int m = 0; m < auxVet.Length; m++)
            //    {
            //        if (precisaAdd)
            //        {
            //            saida.Add(new string[] { EstadoAtual.ToString(), m.ToString(), auxVet[m] });
            //        }
                    
            //    }
            //    EstadoAtual++;

            //    estadosAFDAux.RemoveAt(0);
            //} while (estadosAFDAux.Count > 0);



            Console.WriteLine("\n\n===== Saída (AFD) =====");
            Console.WriteLine(string.Join(" ", Alfabeto));
            Console.WriteLine("i: " + EstadoInicial);
            Console.WriteLine("f: " + EstadoFinal);
            for (int i = 0; i < saida.Count; i++)
            {
                Console.WriteLine(saida[i][0] + " " + saida[i][1] + " " + (estadosAFD.IndexOf(saida[i][2]) + 1).ToString());
            }
            Console.Write("Pressione ENTER pra sair");
            Console.ReadLine();
        }
    }
}
