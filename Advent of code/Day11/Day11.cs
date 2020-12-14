using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
namespace Advent_of_code.Day11
{
    public class Day11
    {
        public int AnswerPartOne { get; set; }
        public int AnswerPartTwo { get; set; }

        public Day11()
        {
            var input = ParseDataToStringArray();
            //AnswerPartOne = PartOne(input);
            AnswerPartTwo = PartTwo(input);
        }

        private int PartOne(string[] layout)
        {
            int size = layout.Length;
            string[] newLine = new string[size];
            int lapCount = 0;


            for (int numberOfLine = 0; numberOfLine < layout.Length; numberOfLine++)
            {
                string stringer = "";
                for (int seat = 0; seat < layout[numberOfLine].Length; seat++)
                {
                    char[] seats = new char[8];
                    #region CheckMinusIndexWTryCatch
                    if (numberOfLine < 1 || seat < 1 || seat + 2 > layout[numberOfLine].Length || numberOfLine + 2 > layout.Length)
                    {
                        try { seats[0] = layout[numberOfLine - 1][seat - 1]; } catch { seats[0] = 'L'; };
                        try { seats[1] = layout[numberOfLine - 1][seat]; } catch { seats[1] = 'L'; };
                        try { seats[2] = layout[numberOfLine - 1][seat + 1]; } catch { seats[2] = 'L'; };
                        try { seats[3] = layout[numberOfLine][seat + 1]; } catch { seats[3] = 'L'; };
                        try { seats[4] = layout[numberOfLine + 1][seat + 1]; } catch { seats[4] = 'L'; };
                        try { seats[5] = layout[numberOfLine + 1][seat]; } catch { seats[5] = 'L'; };
                        try { seats[6] = layout[numberOfLine + 1][seat - 1]; } catch { seats[6] = 'L'; };
                        try { seats[7] = layout[numberOfLine][seat - 1]; } catch { seats[7] = 'L'; };
                    }
                    else
                    {
                        seats[0] = layout[numberOfLine - 1][seat - 1];
                        seats[1] = layout[numberOfLine - 1][seat];
                        seats[2] = layout[numberOfLine - 1][seat + 1];
                        seats[3] = layout[numberOfLine][seat + 1];
                        seats[4] = layout[numberOfLine + 1][seat + 1];
                        seats[5] = layout[numberOfLine + 1][seat];
                        seats[7] = layout[numberOfLine][seat - 1];
                    }
                    #endregion

                    List<char> newlist = new List<char>(seats);
                    if (layout[numberOfLine][seat] == '.')
                    {
                        stringer += '.';
                    }
                    else if (layout[numberOfLine][seat] == 'L' && !newlist.Contains('#'))
                    {
                        stringer += '#';
                    }
                    else if (layout[numberOfLine][seat] == '#' && newlist.FindAll(x => x == '#').Count >= 4)
                    {
                        stringer += 'L';
                    }
                    else
                    {
                        stringer += layout[numberOfLine][seat];
                    }
                }
                newLine[numberOfLine] = stringer;
            }
            var newCheck = string.Join("", newLine);
            var check = string.Join("", layout);
            int answer = 0;
            int count = 0;
            while (check[count] == newCheck[count])
            {
                count++;
                if (count == check.Length)
                {
                    return answer = check.ToCharArray().ToList().FindAll(x => x == '#').Count;
                }


            }
            return PartOne(newLine);

        }

        public int PartTwo(string[] layout)
        {
            int size = layout.Length;
            string[] newLine = new string[size];

            
            for (int numberOfLine = 0; numberOfLine < layout.Length; numberOfLine++) {
                string stringer = "";

                for (int seat = 0; seat < layout[numberOfLine].Length; seat++)
                              {
                    char[] seats = new char[8];
                    #region check diagonally left up
                    for (int i = numberOfLine - 1, j = seat -1;    i >= -1 || j >= -1; i--, j--)
                     {
                                    if (i < 0 || j < 0)
                        {
                            seats[0] = 'L';
                            break;

                        }

                               else if (layout[i][j] != '.')
                                {

                                    seats[0] = layout[i][j];
                                    break;
                                }
                        
                      

                    }
                    #endregion
                    #region check up

                    for (int i = numberOfLine - 1; i >= -1; i--)
                    {
                        if (i < 0)
                        {
                            seats[1] = 'L';
                            break;

                        }

                        else if (layout[i][seat] != '.')
                        {

                            seats[1] = layout[i][seat];
                            break;
                        }


                    }


                    #endregion
                    #region check diagonally right up


                    for (int i = numberOfLine - 1, j = seat + 1; i >= -1; i--, j++)
                    {

                        if (i < 0 || j == layout[i].Length)
                        {
                            seats[2] = 'L';
                            break;

                        }

                        else if (layout[i][j] != '.')
                        {

                            seats[2] = layout[i][j];
                            break;
                        }



                    }
                    #endregion
                    #region check right
                    for (int i = seat + 1; i < layout[numberOfLine].Length +1; i++)
                    {
                        if (i > layout[numberOfLine].Length -1)
                        {
                            seats[3] = 'L';
                            break;

                        }

                        else if (layout[numberOfLine][i] != '.')
                        {

                            seats[3] = layout[numberOfLine][i];
                            break;
                        }


                    }
                    #endregion
                    #region check diagonally right down
                    for (int i = numberOfLine+1, j = seat + 1;  numberOfLine < layout.Length || seat < layout[numberOfLine].Length; i++, j++)
                    {
                        if (i == layout.Length || j == layout[i].Length)
                        {
                            seats[4] = 'L';
                            break;

                        }

                        else if (layout[i][j] != '.')
                        {

                            seats[4] = layout[i][j];
                            break;
                        }
                    }
                    #endregion
                    #region check down
                    for (int i = numberOfLine + 1, j = seat; numberOfLine < layout.Length; i++)
                    {
                        if (i == layout.Length)
                        {
                            seats[5] = 'L';
                            break;

                        }

                        else if (layout[i][seat] != '.')
                        {

                            seats[5] = layout[i][seat];
                            break;
                        }

                    }
                    #endregion
                    #region check diagonally left down
                    for (int i = numberOfLine + 1, j = seat - 1; numberOfLine < layout.Length || seat >= 0; i++, j--)
                    {
                        if (i == layout.Length || j < 0)
                        {
                            seats[6] = 'L';
                            break;

                        }

                        else if (layout[i][j] != '.')
                        {

                            seats[6] = layout[i][j];
                            break;
                        }

                    }
                    #endregion
                    #region check left
                    for (int i = numberOfLine, j = seat- 1; seat >= 0;  j--)
                    {
                        if (j < 0)
                        {
                            seats[7] = 'L';
                            break;

                        }

                        else if (layout[i][j] != '.')
                        {

                            seats[7] = layout[i][j];
                            break;
                        }

                     }
                    #endregion
                    List<char> newlist = new List<char>(seats);
                    if (layout[numberOfLine][seat] == '.')
                    {
                        stringer += '.';
                    }
                    else if (layout[numberOfLine][seat] == 'L' && !newlist.Contains('#'))
                    {
                        stringer += '#';
                    }
                    else if (layout[numberOfLine][seat] == '#' && newlist.FindAll(x => x == '#').Count >= 5)
                    {
                        stringer += 'L';
                    }
                    else
                    {
                      stringer += layout[numberOfLine][seat];
                    }

                }
                newLine[numberOfLine] = stringer;

            }

            var newCheck = string.Join("", newLine);
            var check = string.Join("", layout);
            int answer = 0;
            int count = 0;
            while (check[count] == newCheck[count])
            {
                count++;
                if (count == check.Length)
                {
                    return answer = check.ToCharArray().ToList().FindAll(x => x == '#').Count;
                }


            }
            return PartTwo(newLine);


        }
        private string[] ParseDataToStringArray()
        {

            string[] data = File.ReadAllLines("C:\\Users\\marte\\source\\repos\\AdventOfCode2020\\Advent of code\\Day11\\data.txt");
            return data;


        }
    }
}
