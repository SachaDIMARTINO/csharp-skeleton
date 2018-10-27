using System;
using System.Linq;
using System.Collections.Generic;
﻿namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static IList<IList<T>> PowerSet<T>(IList<T> list)
        {
          int n = 1 << list.Count;
          IList<IList<T>> powerset = new List<IList<T>>();
          for (int i = 0; i < n; ++i)
          {
            IList<T> set = new List<T>();
            for (int bits = i, j = 0; bits != 0; bits >>= 1, ++j)
            {
              if ((bits & 1) != 0)
                set.Add(list[j]);
            }
            powerset.Add(set);
          }
          return powerset;
        }
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            //TODO: Please work out the solution;
            IList<IList<int>> PScashflowIn = PowerSet(cashflowIn);
            List<int> sumPSCashflowIn = new List<int>();
            foreach(IList<int> set in PScashflowIn) {
              int n = set.Sum();
              if(n > 0) {
                sumPSCashflowIn.Add(n);
              }
            }

            IList<IList<int>> PScashflowOut = PowerSet(cashflowOut);
            List<int> sumPSCashflowOut = new List<int>();
            foreach(IList<int> set in PScashflowOut) {
              int n = set.Sum();
              if(n > 0) {
                sumPSCashflowOut.Add(n);
              }
            }

            int i = 0;
            List<int> sumPSMin = new List<int>();
            List<int> sumPSMax = new List<int>();
            if (sumPSCashflowIn.Count > sumPSCashflowOut.Count) {
              sumPSMin = sumPSCashflowOut;
              sumPSMax = sumPSCashflowIn;
            }
            else {
              sumPSMin = sumPSCashflowIn;
              sumPSMax = sumPSCashflowOut;
            }
            int minSumPSCashflowIn = sumPSCashflowIn.Min();
            int minSumPSCashflowOut = sumPSCashflowOut.Min();
            int minMin = Math.Min(minSumPSCashflowIn, minSumPSCashflowOut);
            while(i < minMin) {
              foreach(int sum in sumPSMin) {
                if(sumPSMax.Contains(sum + i) || sumPSMax.Contains(sum - i)) {
                  return Math.Min(i, minMin);
                }
              }
              i++;
            }
            return minMin;
        }
    }
}
