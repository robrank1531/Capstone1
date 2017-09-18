using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises
{
    public class WordsToNumbers
    {

        Dictionary<string, int> numberStrings = new Dictionary<string, int>();
        public WordsToNumbers()
        {
            numberStrings[""] = 0;
            numberStrings["zero"] = 0;
            numberStrings["one"] = 1;
            numberStrings["two"] = 2;
            numberStrings["three"] = 3;
            numberStrings["four"] = 4;
            numberStrings["five"] = 5;
            numberStrings["six"] = 6;
            numberStrings["seven"] = 7;
            numberStrings["eight"] = 8;
            numberStrings["nine"] = 9;
            numberStrings["ten"] = 10;
            numberStrings["eleven"] = 11;
            numberStrings["twelve"] = 12;
            numberStrings["thirteen"] = 13;
            numberStrings["fourteen"] = 14;
            numberStrings["fifteen"] = 15;
            numberStrings["sixteen"] = 16;
            numberStrings["seventeen"] = 17;
            numberStrings["eightteen"] = 18;
            numberStrings["nineteen"] = 19;
            numberStrings["twenty"] = 20;
            numberStrings["thirty"] = 30;
            numberStrings["forty"] = 40;
            numberStrings["fifty"] = 50;
            numberStrings["sixty"] = 60;
            numberStrings["seventy"] = 70;
            numberStrings["eighty"] = 80;
            numberStrings["ninety"] = 90;
            numberStrings["hundred"] = 100;
            numberStrings["thousand"] = 1000;
            numberStrings["million"] = 1000000;
        }
        public int WordsConverter(string nums)
        {
            int result = 0;
            string nums2 = nums.Replace('-', ' ');
            string[] numsArray = nums.Split(' ');
            List<string> numsList = numsArray.ToList<string>();
            if (!nums.Contains("thousand") && !nums.Contains("hundred"))
            {
                result = Teens(nums);
            }
            else if (!nums.Contains("thousand") && nums.Contains("hundred"))
            {
                result = Hundreds(nums);
            }
            else if (numsList.IndexOf("thousand") < 2)
            {
                result = TenThousands(nums);
            }
            else { result = HundredThousands(nums); }
            return result;

        }
        public int Teens(string nums)
        {
            int result = 0;
            string[] numsArray = nums.Split(' ');
            List<string> numsList = numsArray.ToList<string>();
            if (numsList.Count > 1)
            {
                result += numberStrings[numsList[0]];
                result += numberStrings[numsList[1]];
            }
            else { result = numberStrings[numsList[0]]; }
            return result;
        }
        public int Hundreds(string nums)
        {
            int result = 0;
            string nums2 = nums.Replace('-', ' ');
            string[] numsArray = nums2.Split(' ');
            List<string> numsList = numsArray.ToList<string>();
            List<string> numsList2 = new List<string>();
            foreach (string x in numsList)
            {
                if (x != "and" && x != "hundred")
                {
                    numsList2.Add(x);
                }
            }
            result = (numberStrings[numsList2[0]]) * 100;
            for (int i = 1; i < numsList2.Count; i++)
            {
                result += numberStrings[numsList2[i]];
            }

            return result;
        }
        public int HundredThousands(string nums)
        {
            int result = 0;
            string nums2 = nums.Replace('-', ' ');
            string[] numsArray = nums2.Split(' ');
            List<string> numsList = numsArray.ToList<string>();
            List<string> numsList2 = new List<string>();
            List<string> numsList3 = new List<string>();
            foreach (string x in numsList)
            {
                if (x != "and" && x != "hundred")
                {
                    numsList2.Add(x);
                    numsList3.Add(x);
                }
            }
            string numsString = "";
            for (int i = 0; i < numsList2.IndexOf("thousand"); i++)
            {

                numsString += numsList2[i] + " ";
            }
            result = Hundreds(numsString) * 1000;
            string numsString2 = "";
            for (int i = numsList3.IndexOf("thousand") + 1; i < numsList3.Count; i++)
            {
                numsString2 += numsList3[i] + " ";
            }
            result = result + Hundreds(numsString2);
            return result;
        }
        public int TenThousands(string nums)
        {
            int result = 0;
            string nums2 = nums.Replace('-', ' ');
            string[] numsArray = nums2.Split(' ');
            List<string> numsList = numsArray.ToList<string>();
            List<string> numsList2 = new List<string>();
            List<string> numsList3 = new List<string>();
            foreach (string x in numsList)
            {
                if (x != "and" && x != "hundred")
                {
                    numsList2.Add(x);
                    numsList3.Add(x);
                }
            }
            string numsString = "";
            for (int i = 0; i < numsList2.IndexOf("thousand"); i++)
            {

                numsString += numsList2[i] + " ";
            }
            result = Teens(numsString) * 1000;
            string numsString2 = "";
            for (int i = numsList3.IndexOf("thousand") + 1; i < numsList3.Count; i++)
            {
                numsString2 += numsList3[i] + " ";
            }
            result = result + Hundreds(numsString2);
            return result;

        }
    }
}

