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
            if (totalValueOfShares < 1 || numOfShares == null || numOfShares.Length == 0) {
              return 0;
            }
            int[] setArr = numOfShares.Distinct().ToArray();
            Array.Sort(setArr);
            if (setArr.Contains(0)) {
              setArr = setArr.Skip(1).ToArray();
            }
            Array.Reverse(setArr);
            int infinity = 1000000;
            int[] resArr = new int[totalValueOfShares + 1];
            resArr[0] = 0;
            for (int i = 1; i <= totalValueOfShares; i++) {
              resArr[i] = infinity;
            }

            for (int i = 0; i < setArr.Length; i++) {
              for (int j = 1; j <= totalValueOfShares; j++) {
                if(setArr[i] <= j && (resArr[j - setArr[i]] + 1) < resArr[j]) {
                  resArr[j] = resArr[j - setArr[i]] + 1;
                }
              }
            }
            return (resArr[totalValueOfShares] != infinity) ? resArr[totalValueOfShares] : 0;
        }
    }
}

/*
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
                j += 1;
              }
              if (remaining == 0) {
                if (res < answer) {
                  answer = res;
                }
              }
            }
            return (answer == totalValueOfShares + 1) ? 0 : answer;
        }
    }
}
*/
