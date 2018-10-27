using System;
using System.Linq;
using System.Collections.Generic;
﻿namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            //TODO: Please work out the solution;
            int answer = totalValueOfShares + 1;
            int[] setArr = numOfShares.Distinct().ToArray();
            Array.Sort(setArr);
            if (setArr.Contains(0)) {
              setArr = setArr.Skip(1).ToArray();
            }
            Array.Reverse(setArr);
            for (int i = 0; i < setArr.Length; i++) {
              int j = i;
              int remaining = totalValueOfShares;
              int res = 0;
              while (remaining > 0 && j < setArr.Length) {
                int n = remaining / setArr[j];
                res = res + n;
                remaining = remaining - n * setArr[j];
                j++;
              }
              if (remaining == 0) {
                answer = Math.Min(answer, res);
              }
            }
            if (answer == totalValueOfShares + 1) {
              return 0;
            }
            else {
              return answer;
            }
        }
    }
}
