using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Crytography_WPF.Caesar
{
    public class CaesarMethod
    {
        //Convert letter to Tuple
        public static char[] ConvertLetterToTuple(string letter)
        {
            var letterRes = Tuple.Create(letter.ToUpper().ToArray());

            return letterRes.Item1;
        }

        //Get character alphabet
        public static IEnumerable<char> GetAlphabet()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                yield return c;
            }
        }

        // Get index of character
        public static int GetIndexChar(char x) => Array.IndexOf(GetAlphabet().ToArray(), x);

        //Method Ceasar include encrypt and Decrypt
        public static char[] Caesar(string letter, int k, string method)
        {
            var letterTuple = ConvertLetterToTuple(letter);
            var alphabet = GetAlphabet().ToArray();

            char[] arrChar = new char[letterTuple.Length];

            if (method != "Encrypt" && method != "Decrypt")
            {
                var err = "Not Format";
                arrChar = err.ToArray();
            }
            else
            {
                for (int i = 0; i < letterTuple.Length; i++)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        bool isNumeric = int.TryParse(letterTuple[i].ToString(), out _);

                        if (isNumeric == true)
                            arrChar[i] = letterTuple[i];
                        else
                        {
                            if (letterTuple[i] == ' ')
                                arrChar[i] = ' ';
                            if (alphabet[j] == letterTuple[i])
                            {
                                if (method == "Decrypt")
                                {
                                    try
                                    {
                                        arrChar[i] = GetAlphabet().ToArray()[j - k];
                                    }
                                    catch (Exception)
                                    {
                                        arrChar[i] = GetAlphabet().ToArray()[j - k + alphabet.Length];
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        arrChar[i] = GetAlphabet().ToArray()[j + k];
                                    }
                                    catch (Exception)
                                    {
                                        arrChar[i] = GetAlphabet().ToArray()[j + k - alphabet.Length];
                                    }
                                }
                            }
                        }
                       
                    }
                }
            }
            
            return arrChar;
        }
    }
}
