using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int Answer(int[] portfolios)
        {
            //TODO: Please work out the solution;
            int i;
            int j;
            int answer = 0;
            for (i = 0 ; i < portfolios.Length ; i++) {
                for (j = i + 1 ; j < portfolios.Length ; j++) {
                    answer = Math.Max(answer, portfolios[i] ^ portfolios[j]);
                }
            }
            return answer;
        }
    }
}
