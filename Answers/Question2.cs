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
