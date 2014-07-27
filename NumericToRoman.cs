using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRoman
{
    public class KataRoman
    {
        public Dictionary<string, int> dicto { get; private set; }

        public KataRoman()
        {
            dicto = new Dictionary<string, int>();
            dicto.Add("M", 1000);
            dicto.Add("CM", 900);
            dicto.Add("D", 500);
            dicto.Add("CD", 400);
            dicto.Add("C", 100);
            dicto.Add("XC", 90);
            dicto.Add("L", 50);
            dicto.Add("XL", 40);
            dicto.Add("X", 10);
            dicto.Add("IX", 9);
            dicto.Add("V", 5);
            dicto.Add("IV", 4);
            dicto.Add("I", 1);
        }

        /// <summary>
        /// Methode d'entrée qui permet de convertir en Roman ou Numeric.
        /// </summary>
        /// <param name="input">String Entrée.</param>
        /// <returns>String Resultat.</returns>
        public string Transform(string input)
        {
            int result;
            return int.TryParse(input, out result) ? NumToRoman(result) : RomanToNum(input);
        }


        /// <summary>
        /// Permet de convertir des caractères Romain en Numérique
        /// </summary>
        /// <param name="input">String Input.</param>
        /// <returns>String Resultat.</returns>
        public string RomanToNum(string input)
        {
            int value = 0;
            CheckSpecialRomanCharacters(ref input, ref value, "CM");
            CheckSpecialRomanCharacters(ref input, ref value, "CD");
            CheckSpecialRomanCharacters(ref input, ref value, "XC");
            CheckSpecialRomanCharacters(ref input, ref value, "XL");
            CheckSpecialRomanCharacters(ref input, ref value, "IX");
            CheckSpecialRomanCharacters(ref input, ref value, "IV");
            foreach (var item in dicto)
            {
                if (string.Equals(input, item.Key))
                {
                    value = item.Value;
                }
                else
                {
                    char[] letters = input.ToCharArray();
                    foreach (var letter in letters)
                    {
                        if (string.Equals(letter.ToString(), item.Key))
                        {
                            value += item.Value;
                        }
                    }
                }
            }
            return value == 0 ? string.Empty : value.ToString();
        }

        /// <summary>
        /// Controlle les caractères spéciaux "romains"
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <param name="carac"></param>
        private void CheckSpecialRomanCharacters(ref string input, ref int value, string carac)
        {
            if (input.Contains(carac))
            {
                value += dicto.Where(x => x.Key == carac).First().Value;
                input = input.Replace(carac, " ");
            }
        }

        /// <summary>
        /// Permet de transformer un numérique en "Roman"
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        public string NumToRoman(int nb)
        {
            string result = string.Empty;
            if (nb == 0)
            {
                result = string.Empty;
            }
            else
            {
                while (nb > 0)
                {
                    foreach (var item in dicto)
                    {
                        if (nb != 0)
                        {
                            if (item.Value == nb)
                            {
                                nb = nb - item.Value;
                                result += item.Key;
                            }
                            if (nb - item.Value > 0)
                            {
                                while ((nb - item.Value) >= 0)
                                {
                                    nb = nb - item.Value;
                                    result += item.Key;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
