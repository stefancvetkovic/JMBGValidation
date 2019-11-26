using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMBGValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Molimo unesite JMBG:");
            string input = Console.ReadLine();
            JMBGInfo result = checkIsJMBGValid(input);

            if (!string.IsNullOrEmpty(result.Error))
            {
                Console.WriteLine(result.Error);
            }
            else if (result.Success)
            {
                Console.WriteLine("Validan!");
            }
            Console.ReadKey();
        }

        private static JMBGInfo checkIsJMBGValid(string input)
        {
            JMBGInfo response = new JMBGInfo();

            response.HasData = true;
            response.Success = true;


            if (input.Length != 13)
            {
                response.Error = "JMBG mora sadržati 13 brojeva";
                response.Success = false;
            }
            else
            {
                int tmpC;
                for (int i = 0; i < 13; i++)
                {
                    if (!int.TryParse(input[i].ToString(), out tmpC))
                    {
                        response.Error = "JMBG mora sadržati samo brojeve";
                        response.Success = false;
                        i = 14;
                    }
                }
                if (response.Success)
                {
                    int[] cifre = new int[13];
                    int ostatak = 0;
                    DateTime dRodjenja = new DateTime();
                    for (int i = 0; i < 13; i++)
                    {
                        cifre[i] = int.Parse(input[i].ToString());
                    }
                    ostatak = 11 - ((7 * (cifre[0] + cifre[6]) + 6 * (cifre[1] + cifre[7]) + 5 * (cifre[2] + cifre[8]) + 4 * (cifre[3] + cifre[9]) + 3 * (cifre[4] + cifre[10]) + 2 * (cifre[5] + cifre[11])) % 11);

                    if (ostatak > 9)
                    {
                        ostatak = 0;
                    }
                    if (ostatak != cifre[12])
                    {
                        response.Error = "JMBG nije prošao proveru po modulu 13";
                        response.Success = false;
                    }
                    else
                    {
                        int dan = int.Parse(input.Substring(0, 2));
                        int mesec = int.Parse(input.Substring(2, 2));
                        int godina = int.Parse(input.Substring(4, 3));
                        if (godina > 500)
                        {
                            godina += 1000;
                        }
                        else
                        {
                            godina += 2000;
                        }
                        try
                        {
                            dRodjenja = new DateTime(godina, mesec, dan);
                        }
                        catch
                        {
                            response.Error = "JMBG ne sadrži ispravan datum rođenja";
                            response.Success = false;
                        }
                        response.dRodjenja = dRodjenja;
                        if (int.Parse(input.Substring(9, 3)) > 499)
                        {
                            response.pol = 'Ž';
                        }
                        else
                        {
                            response.pol = 'M';
                        }
                    }
                }
            }
            return response;

        }
    }
}
