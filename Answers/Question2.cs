using System;
using System.Linq;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        public static int findMinDist(int[] cashIn, int[] cashOut){
            int n = cashIn.Length;
            int m = cashOut.Length;
            int minDist = -1;
            if(n==1 && m == 1) return int.MaxValue;
            else if(n==1) return cashOut[1];
            else if(m==1) return cashIn[1];
            else minDist = cashIn[1] < cashOut[1] ? cashIn[1] : cashOut[1];
            int i = 1;
            int j = 1;
            int dist;
            while(true){
                dist = Math.Abs(cashIn[i]-cashOut[j]);

                if(dist == 0)
                    return 0;
                else if(dist < minDist)
                    minDist = dist;

                if(cashIn[i] < cashOut[j] && i != n-1)
                    i += 1;
                else if(cashIn[i] >= cashOut[j] && j != m-1)
                    j += 1;
                else
                    break;
            }
            return minDist;
        }
        public static int[] sumSetCust2(int[] cashFlow) {
            int n = cashFlow.Length;
            int maxSum = 0;
            for(int i=0; i<n; ++i)
                maxSum += cashFlow[i];

            bool[] sumSetIdx = new bool[maxSum+1];
            sumSetIdx[0] = true;

            List<int> sumSet = new List<int>();
            sumSet.Add(0);
            for(int i=0; i<n; ++i){
                List<int> newSumSet = new List<int>();
                int lenSumSet = sumSet.Count();
                int cashFlowI = cashFlow[i];
                for(int j=0; j<lenSumSet; j++){
                    int newSum = sumSet[j]+cashFlowI;
                    if(!sumSetIdx[newSum]){
                        sumSetIdx[newSum] = true;
                        newSumSet.Add(newSum);
                    }
                }
                for(int j=0; j<newSumSet.Count(); j++){
                    sumSet.Add(newSumSet[j]);
                }
            }
            sumSet.Sort();
            return sumSet.ToArray();
        }
        public static int Answer(int[] cashflowIn, int[] cashflowOut) {
            int[] cashIn = sumSetCust2(cashflowIn);
            int[] cashOut = sumSetCust2(cashflowOut);
            int minDist = findMinDist(cashIn, cashOut);
            return minDist;
        }
    }
}
