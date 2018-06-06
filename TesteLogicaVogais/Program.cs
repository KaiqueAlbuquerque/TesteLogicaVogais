using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteLogicaVogais
{
    class Program
    {
        //Vetor com as vogais
        private static readonly string[] vowels = { "a", "e", "i", "o", "u" };        

        //Lista que será populada com as vogais
        private static IList<string> vowelsOfString = new List<string>();

        static void Main(string[] args)
        {
            //Variável que recebe a entrada da frase
            string input = string.Empty;

            do
            {
                Console.Write("Olá! \nDigite uma palavra para descobrir a quantidade de vogais que ela possui e qual \né a ultima vogal que não repete nesta palavra. \n(Ou se preferir, -1 para sair): ");
                
                do
                {
                    input = Console.ReadLine().ToLower();

                    //Verifica se foi digitado algo
                    if (string.IsNullOrEmpty(input)) Console.Write("Por favor, digite uma palavra (Ou se preferir, -1 para sair): ");
                } while (string.IsNullOrEmpty(input));
                
                //Apresenta a quantidade de vogais invocando o método que calcula esta quantidade
                Console.WriteLine("\nA quantidade de vogais desta frase é: " + getQuantityOfVowels(input));

                //Apresenta a ultima vogal a não se repetir invocando o método que encontra esta vogal
                Console.WriteLine(getLastVowelDoesNotRepeat(vowelsOfString)+"\n");
                vowelsOfString.Clear();

            } while (input != "-1");
            
        }

        /// <summary>
        /// Método responsável por retornar o número total de vogais da string e preencher a variavel global vowelsOfString 
        /// com as vogais da frase
        /// </summary>
        /// <param name="input">String que será analisada</param>
        /// <returns>Quantidade de vogais encontradas na string</returns>
        static int getQuantityOfVowels(string input)
        {
            int quantityOfVowels = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                if (vowels.Contains(input[i].ToString()))
                {
                    quantityOfVowels++;
                    vowelsOfString.Add(input[i].ToString());
                }
            }
            return quantityOfVowels;
        }

        /// <summary>
        /// Método responsável por retornar qual a ultima vogal da string a não se repetir na sequencia.
        /// </summary>
        /// <param name="input">Lista com as vogais</param>
        /// <returns>Ultima vogal da string a não se repetir na sequencia</returns>
        static string getLastVowelDoesNotRepeat(IList<string> vowelsOfString)
        {
            string vowelDoesNotRepeat = string.Empty;
            if (vowelsOfString.Count() > 1)
            {
                for (int j = (vowelsOfString.Count() - 1); j >= 0; j--)
                {
                    if (vowelsOfString[j] != vowelsOfString[j - 1])
                    {
                        vowelDoesNotRepeat = vowelsOfString[j].ToString();
                        break;
                    }
                    if (j <= 2)
                    {
                        break;
                    }
                    j = j - 1;
                }
            }
            if (vowelsOfString.Count() == 1 && vowels.Contains(vowelsOfString[0]))
            {
                vowelDoesNotRepeat = vowelsOfString[0];
            }
            vowelDoesNotRepeat = string.IsNullOrEmpty(vowelDoesNotRepeat) 
                ? "Não existe vogal que não esteja repetida em sequencia nesta frase"
                : "A ultima vogal a não se reptir na sequencia é: " + vowelDoesNotRepeat;

            return vowelDoesNotRepeat;
        }
    }
}
