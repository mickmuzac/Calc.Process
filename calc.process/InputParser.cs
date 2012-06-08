using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calc.process
{
    class InputParser
    {
        public IEnumerable<char> query;

        public InputParser(String s)
        {
            query = s.Where(x => char.IsNumber(x) || x == '+' || x == '-' || x == '^');
        }

        public void getMonomialsFromQuery(FunctionProcess f)
        {

            String currentNum = "";

            List<double> coeff = new List<double>(10);
            List<int> exponent = new List<int>(10);

            bool first = true;
            bool isExponent = false;
            int negative = 1;

            int temp;
            
            foreach (char c in query)
            {
                //Console.WriteLine(c);

                if (c == '^')
                {
                    temp = Int32.Parse(currentNum);
                    temp *= negative;

                    currentNum = "";

                    coeff.Add(temp);
                    isExponent = true;
                    first = false;
                    negative = 1;
                }

                else if (isExponent && char.IsNumber(c))
                {
                    currentNum += c;
                    first = false;
                }

                else if (!isExponent && (char.IsNumber(c) || (first && c == '-')))
                {
                    if(c == '-')
                        negative = -1;

                    else currentNum += c;

                    first = false;
                }

                else if(currentNum.Length > 0)
                {
                    
                    temp = Int32.Parse(currentNum);
                    temp *= negative;

                    currentNum = "";

                    if (isExponent)
                        exponent.Add(temp);

                    else
                        coeff.Add(temp);

                    first = true;
                    isExponent = false;
                    negative = 1;

                    if (c == '-')
                        negative = -1;
                }

            }

            if(currentNum.Length > 0){

                temp = Int32.Parse(currentNum);
                temp *= negative;

                if (isExponent)
                    exponent.Add(temp);

                else
                    coeff.Add(temp);
            }

            f.constructPolynomial(coeff, exponent);
            //Console.WriteLine("" + coeff[0] + exponent[0] + coeff[1] + exponent[1]);
        }

    }
}
