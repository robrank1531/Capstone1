using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises
{
    public class NumbersToWords
    {

        Dictionary<int, string> numberStrings = new Dictionary<int, string>();
        public NumbersToWords()
        {

            numberStrings[0] = "zero";
            numberStrings[1] = "one";
            numberStrings[2] = "two";
            numberStrings[3] = "three";
            numberStrings[4] = "four";
            numberStrings[5] = "five";
            numberStrings[6] = "six";
            numberStrings[7] = "seven";
            numberStrings[8] = "eight";
            numberStrings[9] = "nine";
            numberStrings[10] = "ten";
            numberStrings[11] = "eleven";
            numberStrings[12] = "twelve";
            numberStrings[13] = "thirteen";
            numberStrings[14] = "fourteen";
            numberStrings[15] = "fifteen";
            numberStrings[16] = "sixteen";
            numberStrings[17] = "seventeen";
            numberStrings[18] = "eightteen";
            numberStrings[19] = "nineteen";
            numberStrings[20] = "twenty";
            numberStrings[30] = "thirty";
            numberStrings[40] = "forty";
            numberStrings[50] = "fifty";
            numberStrings[60] = "sixty";
            numberStrings[70] = "seventy";
            numberStrings[80] = "eighty";
            numberStrings[90] = "ninety";
            numberStrings[100] = "hundred";
            numberStrings[1000] = "thousand";
            numberStrings[1000000] = "million";
        }
        public string NumberConverter(int nums)
        {
            if (nums >= 0 && nums < 100)
            {
                return Teens(nums);
            }
            else if (nums > 99 && nums < 1000)
            {
                return Hundreds(nums);
            }
            else if (nums > 999 && nums < 100000)
            {
                return Thousands(nums);
            }
            else { return HundredThousands(nums); }
        }
        public string Teens(int nums)
        {
            string result = "";

            if (nums <= 20)
            {
                result = numberStrings[nums];
            }
            else if (nums > 20 && nums < 99)
            {
                int firstDigit = nums / 10;
                nums = nums % (firstDigit * 10);
                result = numberStrings[firstDigit * 10] + " " + numberStrings[nums];
            }
            return result;
        }

        public string Hundreds(int nums)
        {
            string result = "";
            int firstDigit = nums / 100;
            nums = nums % (firstDigit * 100);
            if (nums != 0)
            {
                result = numberStrings[firstDigit] + " hundred and " + Teens(nums);
            }
            else { result = numberStrings[firstDigit] + " hundred"; }
            return result;
        }

        public string Thousands(int nums)
        {
            string result = "";
            int firstDigit = nums / 1000;
            nums = nums % (firstDigit * 1000);
            if (nums != 0)
            {
                result = Teens(firstDigit) + " thousand " + Hundreds(nums);
            }
            else { result = Teens(firstDigit) + " thousand"; }
            return result;
        }
        public string HundredThousands(int nums)
        {
            string result = "";
            int firstDigit = nums / 100000;
            nums = nums % (firstDigit * 1000000);
            if (nums != 0)
            {
                result = numberStrings[firstDigit] + " hundred" + Thousands(nums);
            }
            else { result = numberStrings[firstDigit] + " hundred thousand"; }
            return result;
        }


    }
}
