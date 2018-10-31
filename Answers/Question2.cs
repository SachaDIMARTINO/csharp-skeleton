/*
using System;
using System.Linq;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {

        public static List<int> subSumSet(List<int> sumSet, int val, int[] counts, bool[] sumSetIdx){
            List<int> subSumSet = new List<int>();
            int lenSumSet = sumSet.Count();
            int count = counts[val];
            for(int j=0; j<lenSumSet; j++){
                int newSum = sumSet[j]+val;
                for(int k=0; k<count; k++){
                    if(!sumSetIdx[newSum]){
                        sumSetIdx[newSum] = true;
                        subSumSet.Add(newSum);
                    }
                    newSum += val;
                }
            }
            return subSumSet;
        }
        public static int lookAround(int val, int minDist, int n, bool[] l){
            // Preliminary checks
            if(minDist == -1)
                minDist = val;
            if(val > n + minDist)
                return minDist;
            else if(val > n){
                minDist = val-n;
                return minDist;
            }
            else if(l[val])
                return 0;
            // Look around in outSumSetIdx
            int posI = val+1;
            int negI = val-1;
            int posDist = 1;
            int negDist = 1;
            while((posI < n && posDist < minDist) || (negI >= 0 && negDist < minDist)){
                if(posI < n && posDist < minDist){
                    if(l[posI]){
                        minDist = posDist;
                        break;
                    }
                    posI ++;
                    posDist ++;
                }
                if(negI >= 0 && negDist < minDist){
                    if(l[negI]){
                        minDist = negDist;
                        break;
                    }
                    negI --;
                    negDist ++;
                }
            }
            return minDist;
        }

        public static int minDistSumSetClean(int[] inSet, int[] outSet){
            if(inSet.Length == 0){
                if(outSet.Length == 0) return int.MaxValue;
                else return outSet.Min();
            }
            else if(outSet.Length == 0)
                return inSet.Min();

            // init counts
            int nIn = inSet.Max()+1;
            int nOut = outSet.Max()+1;
            int[] inCounts = new int[nIn];
            int[] outCounts = new int[nOut];
            // find max
            int inMaxSum = 0;
            for(int i=0; i<inSet.Length; i++){
                inCounts[inSet[i]] ++;
                inMaxSum += inSet[i];
            }
            int outMaxSum = 0;
            for(int i=0; i<outSet.Length; i++){
                outCounts[outSet[i]] ++;
                outMaxSum += outSet[i];
            }
            // init idx arrays
            bool[] inSumSetIdx = new bool[inMaxSum+1];
            for(int i=0; i<inMaxSum+1; ++i)
                inSumSetIdx[i] = false;
            inSumSetIdx[0] = true;
            bool[] outSumSetIdx = new bool[outMaxSum+1];
            for(int i=0; i<outMaxSum+1; ++i)
                outSumSetIdx[i] = false;
            outSumSetIdx[0] = true;

            // Main computation
            int minDist = -1;
            List<int> inSumSet = new List<int>();
            List<int> outSumSet = new List<int>();
            inSumSet.Add(0);
            outSumSet.Add(0);
            int iIn = -1;
            int iOut = -1;
            while(iIn < nIn-1 || iOut < nOut-1){
                if(iIn < nIn)
                    iIn ++;
                if(iIn < nIn && inCounts[iIn] != 0){
                    List<int> inSubSumSet = subSumSet(inSumSet, iIn, inCounts, inSumSetIdx);
                    for(int j=0; j<inSubSumSet.Count(); j++){
                        int inSum = inSubSumSet[j];
                        inSumSet.Add(inSum);
                        minDist = lookAround(inSum, minDist, outMaxSum, outSumSetIdx);
                        if(minDist==0) return 0;
                    }
                }
                if(iOut < nOut)
                    iOut ++;
                if(iOut < nOut && outCounts[iOut] != 0){
                    List<int> outSubSumSet = subSumSet(outSumSet, iOut, outCounts, outSumSetIdx);
                    for(int j=0; j<outSubSumSet.Count(); j++){
                        int outSum = outSubSumSet[j];
                        outSumSet.Add(outSum);
                        minDist = lookAround(outSum, minDist, inMaxSum, inSumSetIdx);
                        if(minDist==0) return 0;
                    }
                }
            }
            return minDist;
        }
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            int minDist = minDistSumSetClean(cashflowIn, cashflowOut);
            return minDist;
        }
    }
}
*/

/*
using System.Collections.Generic;
using System;
namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        class Solution {

            public Dictionary<int, int> dictIn;
            public Dictionary<int, int> dictOut;

            public void GeneratePartitions(int[] cashflowIn, int[] cashflowOut) {
                int lenIn = cashflowIn.Length;
                int lenOut = cashflowOut.Length;
                this.dictIn = new Dictionary<int, int>();
                this.dictOut = new Dictionary<int, int>();
                // Length of smallest cashflow
                int m1 = (lenIn < lenOut) ? lenIn : lenOut;
                // Length of highest cashflow
                int m2 = (m1 == lenIn) ? lenOut : lenIn;
                for (int i = 0 ; i < m1 ; i++) {
                    int t1 = cashflowIn[i];
                    int t2 = cashflowOut[i];
                    if (!dictIn.TryAdd(t1, 1)) {
                        dictIn[t1] += 1;
                    }
                    if (!dictOut.TryAdd(t2, 1)) {
                        dictOut[t2] += 1;
                    }
                }
                if (m1 == lenOut) {
                    for (int i = m1 ; i < m2 ; i++) {
                        int t1 = cashflowIn[i];
                        if (!dictIn.TryAdd(t1, 1)) {
                            dictIn[t1] += 1;
                        }
                    }
                } else {
                    for (int i = m1 ; i < m2 ; i++) {
                    int t2 = cashflowOut[i];
                        if (!dictOut.TryAdd(t2, 1)) {
                            dictOut[t2] += 1;
                        }
                    }
                }
            }

            public List<int> FindAllSum(Dictionary<int,int> dict) {
                List<int> alreadyAdded = new List<int>();
                foreach (KeyValuePair<int,int> kvp in dict) {
                    List<int> tmp = new List<int>();
                    int a = kvp.Key;
                    for (int i = 0 ; i < kvp.Value ; i++) {
                        foreach (int kk in alreadyAdded) {
                            tmp.Add(kk + a);
                        }
                    }
                    a = kvp.Key;
                    for (int i = 0 ; i < kvp.Value ; i++) {
                        tmp.Add(a);
                        a += kvp.Key;
                    }
                    alreadyAdded.AddRange(tmp);
                }
                alreadyAdded.Sort();
                return alreadyAdded;
            }

            public int FindMinDistance(List<int> l1, List<int> l2) {
                int min = (l1[0] < l2[0]) ? l1[0] : l2[0];
                int i = 0;
                int j = 0;
                int n = l1.Count;
                int m = l2.Count;
                while (i < n && j < m) {
                    int a1 = l1[i];
                    int a2 = l2[j];
                    int t;
                    if (a1 < a2) {
                        i++;
                        t = a2 - a1;
                        if (t < min) {
                            min = t;
                        }
                    } else {
                        j++;
                        t = a1 - a2;
                        if (t < min) {
                            min = t;
                        }
                    }
                    if (min == 0) {
                        return 0;
                    }
                }
                return min;

            }

            public int Run(int[] cashflowIn, int[] cashflowOut) {
                this.GeneratePartitions(cashflowIn, cashflowOut);
                return this.FindMinDistance(this.FindAllSum(this.dictIn), this.FindAllSum(this.dictOut));
            }


            public int GetMin(int[] tab) {
                int r = int.MaxValue;
                for (int i = 0 ; i < tab.Length ; i++) {
                    int t = tab[i];
                    if (t < r) {
                        r = t;
                    }
                }
                return r;
            }
        }

        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {
            Solution s = new Solution();
            if (cashflowIn.Length == 0) {
                return s.GetMin(cashflowOut);
            } else if (cashflowOut.Length == 0) {
                return s.GetMin(cashflowIn);
            } else {
                return s.Run(cashflowIn, cashflowOut);
            }
        }
    }
}
*/

// BRUT FORCE
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
