using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    class Program
    {

        static bool Is(List<int[]> num, List<List<int[]>> Zahal)
        {

            for (int i = 0; i < Zahal.Count; i++)
            {
                if (Zahal[i].Count == num.Count)

                {
                    int counter = 0;
                    for (int k = 0; k < Zahal[i].Count; k++)
                    {

                        for (int l = 0; l < num.Count; l++)
                        {
                            if (Zahal[i][k][0] == num[l][0] && Zahal[i][k][1] == num[l][1])
                            {
                                counter++;
                                break;
                            }
                        }
                    }

                    if (counter == num.Count)
                    {
                        return false;
                    }



                }
            }

            return true;

        }
        static List<List<int[]>> On(List<List<int[]>> Zahal)
        {
            List<List<int[]>> mas = new List<List<int[]>>();
            for (int i = 0; i < Zahal.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < Zahal.Count; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < Zahal[i].Count; k++)
                        {
                            for (int l = 0; l < Zahal[j].Count; l++)
                            {
                                if (Zahal[i][k][0] == Zahal[j][l][0] && Zahal[i][k][1] == Zahal[j][l][1])
                                {
                                    flag = false;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (flag)
                {
                    mas.Add(Zahal[i]);
                }

            }

            return mas;

        }
        static void Main(string[] args)
        {
            Console.Write("Enter m:");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter n:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] a = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                string[] info = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = Int32.Parse(info[j]);
                }
            }



            List<List<int[]>> Zahal = new List<List<int[]>>();
            Console.WriteLine("Max Ryadok");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                 
                    
                        if ((j + 1 < n && a[i, j] == a[i, j + 1]) || (j - 1 > 0 && a[i, j] == a[i, j - 1]))
                        {
                            List<int[]> num = new List<int[]>();

                            for (int k = j; k < n; k++)
                            {
                                if (a[i, j] == a[i, k])
                                {
                                    int[] masKoop = new int[2];

                                    masKoop[0] = i;
                                    masKoop[1] = k;
                                    num.Add(masKoop);
                                    //Console.WriteLine(i + " " + k);
                                }
                                else
                                {
                                    break;
                                }
                            }

                            for (int k = j - 1; k >= 0; k--)
                            {

                                if (a[i, j] == a[i, k])
                                {
                                    int[] masKoop = new int[2];

                                    masKoop[0] = i;
                                    masKoop[1] = k;
                                    num.Add(masKoop);
                                    //  Console.WriteLine(i + " " + k);
                                }


                                else
                                {
                                    break;
                                }
                            }

                            if (Is(num, Zahal))
                            {
                                Zahal.Add(num);
                            }

                            /*
                            for (int k = 1; k < num.Count; k++)
                            {
                                a[num[k][0], num[k][1]] = 0;
                            }
                            */
                        }



                        if ((i + 1 < m && a[i, j] == a[i + 1, j]) || (i - 1 > 0 && a[i, j] == a[i - 1, j]))
                        {
                            List<int[]> num = new List<int[]>();

                            for (int k = i; k < m; k++)
                            {
                                if (a[i, j] == a[k, j])
                                {
                                    int[] masKoop = new int[2];
                                    masKoop[0] = k;
                                    masKoop[1] = j;
                                    num.Add(masKoop);
                                    //Console.WriteLine(k + " " + j);
                                }
                                else
                                {
                                    break;
                                }


                            }

                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (a[i, j] == a[k, j])
                                {
                                    int[] masKoop = new int[2];

                                    masKoop[0] = k;
                                    masKoop[1] = j;
                                    num.Add(masKoop);
                                    //Console.WriteLine(k + " " + j);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (Is(num, Zahal))
                            {
                                Zahal.Add(num);
                            }

                            /*
                            for (int k = 1; k < num.Count; k++)
                            {
                                a[num[k][0], num[k][1]] = 0;
                            }
                            */
                        }
                        if ((i + 1 < m && j + 1 < n && a[i, j] == a[i + 1, j + 1]) || (i - 1 > 0 && j - 1 > 0 && a[i, j] == a[i - 1, j - 1]))
                        {
                            List<int[]> num = new List<int[]>();

                            for (int k = 0; k + i < m && k + j < n; k++)
                            {

                                if (a[i, j] == a[i + k, j + k])
                                {
                                    int[] masKoop = new int[2];
                                    masKoop[0] = i + k;
                                    masKoop[1] = j + k;
                                    num.Add(masKoop);
                                    //Console.WriteLine((i + k) + " " + (j + k));
                                }
                                else
                                {
                                    break;
                                }

                            }


                            for (int k = 1; i - k >= 0 && j - k >= 0; k++)
                            {

                                if (a[i, j] == a[i - k, j - k])
                                {
                                    int[] masKoop = new int[2];
                                    masKoop[0] = i - k;
                                    masKoop[1] = j - k;
                                    num.Add(masKoop);
                                    //Console.WriteLine((i + k) + " " + (j + k));
                                }
                                else
                                {
                                    break;
                                }

                            }

                            if (Is(num, Zahal))
                            {
                                Zahal.Add(num);
                            }

                            /*
                            for (int k = 1; k < num.Count; k++)
                            {
                                a[num[k][0], num[k][1]] = 0;
                            }
                            */
                        }

           

                    if ((i - 1 > 0 && j + 1 < n && a[i, j] == a[i - 1, j + 1]) || (i + 1 < m && j - 1 > 0 && a[i, j] == a[i + 1, j - 1]))
                    {
                        List<int[]> num = new List<int[]>();


                        for (int k = 0; i + k <m  && j - k >= 0; k++)
                        {
                            if (a[i, j] == a[i + k, j - k])
                            {
                                int[] masKoop = new int[2];

                                masKoop[0] = i + k;
                                masKoop[1] = j - k;
                                num.Add(masKoop);
                                //Console.WriteLine((i + k) + " " + (j - k));
                            }
                            else
                            {
                                break;
                            }

                        }
                        for (int k = 1; i - k >= 0 && j + k < m; k++)
                        {
                            if (a[i, j] == a[i - k, j + k])
                            {
                                int[] masKoop = new int[2];

                                masKoop[0] = i - k;
                                masKoop[1] = j + k;
                                num.Add(masKoop);
                                //Console.WriteLine((i + k) + " " + (j - k));
                            }
                            else
                            {
                                break;
                            }

                        }
                        if (Is(num, Zahal))
                        {
                            Zahal.Add(num);
                        }

                      

                    }
                    

                }

            }

            Console.WriteLine();
            for (int i = 0; i < Zahal.Count; i++)
            {
                for (int j = 0; j < Zahal[i].Count; j++)
                {
                    Console.Write(" [ " + Zahal[i][j][0] + " ; " + Zahal[i][j][1] + " ] ");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
            }

            Zahal = On(Zahal);
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");


            for (int i = 0; i < Zahal.Count; i++)
            {
                for (int j = 0; j < Zahal[i].Count; j++)
                {
                    Console.Write(" [ " + Zahal[i][j][0] + " ; " + Zahal[i][j][1] + " ] ");
                }
                Console.WriteLine();
                Console.WriteLine("----------------------------------");
            }
            

            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Max");
            int max = 0;
            for (int i = 0; i < Zahal.Count; i++)
            {
                if (max < Zahal[i].Count)
                {
                    max = Zahal[i].Count;
                }
            }
            for (int i = 0; i < Zahal.Count; i++)
            {
                if (max == Zahal[i].Count)
                {
                    for (int j = 0; j < Zahal[i].Count; j++)
                    {
                        Console.Write(" [ " + Zahal[i][j][0] + " ; " + Zahal[i][j][1] + " ] ");
                    }
                    Console.Write("Len " + Zahal[i].Count + " Color " + a[Zahal[i][0][0], Zahal[i][0][1]]);
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------");
                }
            }
            Console.ReadLine();

        }
    }
}



//int color = Convert.ToInt32(Console.ReadLine());
//switch (color)
//{
//    case 1:
//        Console.WriteLine("Пряма синього кольору");
//        break;
//    case 2:
//        Console.WriteLine("Пряма зеленого кольору");
//        break;
//    case 3:
//        Console.WriteLine("Пряма червоного кольору");
//        break;
//    case 4:
//        Console.WriteLine("Пряма сірого кольору");
//        break;
//    case 5:
//        Console.WriteLine("Пряма чорного кольору");
//        break;
//    case 6:
//        Console.WriteLine("Пряма білого кольору");
//        break;
//    case 7:
//        Console.WriteLine("Пряма коричнивого кольору");
//        break;
//    case 8:
//        Console.WriteLine("Пряма рожевого кольору");
//        break;
//    case 9:
//        Console.WriteLine("Пряма фіолетового кольору");
//        break;
//    default:
//        Console.WriteLine("Пряма без кольору");
//        break;
//}

