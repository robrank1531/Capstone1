using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int result = 0;
            string[] test = numbers.Split(',');
            List<string> test2 = new List<string>();

            if (numbers.Length == 0)
            {
                result = 0;
            }
            else if (!numbers.Contains(',') && !numbers.Contains("\n"))
            {
                result = Int32.Parse(numbers.Substring(0));
            }

            
        

            else{ for (int i = 0; i < test.Length; i++)
                {
                    if (test[i].Contains("\n"))
                    {
                        test2 = test[i].Split('\n').ToList<string>();/*new string[] { "\n" }, StringSplitOptions.None).ToList<string>();*/
                        test[i] = "0";
                    }
                }

                for (int i = 0; i < test.Length; i++)
                {
                    //if (!test[i].Contains("\n"))
                    //{
                        result += Int32.Parse(test[i]);
                    //}
                }
                for (int i = 0; i < test2.Count; i++)
                {
                    result += Int32.Parse(test2[i]);
                }
            }
            return result;
            
        }
    }
}
