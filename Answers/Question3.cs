using System;
using C_Sharp_Challenge_Skeleton.Beans;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{

    public class GraphArr {
        public int nbNodes {
            get;
            set;
        }
        public int[] edges {
            get;
        }
        public GraphArr(int nbNodes, int[] edges) {
            this.nbNodes = nbNodes;
            this.edges = edges;
        }

        public int GetEdge(int i, int j) {
            return this.edges[i * this.nbNodes + j];
        }
    }

    class Solution {
        GraphArr graph;
        int k;
        int sizeTmp;
        int size;
        public Solution(GraphArr g) {
            this.graph = g;
            this.k = 0;
        }
        public int[] RunK(int[] listK, int k) {
            int[] result = new int[this.graph.nbNodes * this.sizeTmp];
            int s = 0;
            for (int i = 0 ; i < this.sizeTmp ; i = i + k) {
                int n = listK[i+k-1] + 1;
                for (int j = n ; j < this.graph.nbNodes; j += 1) {
                    bool pred = true;
                    for (int l = i ; l < i + k; l += 1) {
                        if (this.graph.GetEdge(listK[l], j) == 1) {
                            pred = false;
                            break;
                        }
                    }
                    if (pred) {
                        for (int l = i ; l < i + k ; l += 1) {
                            result[s + (l - i)] = listK[l];
                        }
                        result[s + k] = j;
                        s += (k+1);
                    }
                }
            }
            this.sizeTmp = s;
            return result;
        }
        public int[] FindStables() {
            int[] result = null;
            if (this.graph.nbNodes != 0) {
                result = new int[this.graph.nbNodes];
                for (int i = 0 ; i < this.graph.nbNodes ; i = i + 1) {
                    result[i] = i;
                }
                this.sizeTmp = this.graph.nbNodes;
                this.size = this.sizeTmp;
                this.k = 0;
                int[] tmp = result;
                do {
                    this.size = this.sizeTmp;
                    this.k += 1;
                    result = tmp;
                    tmp = this.RunK(result, this.k);
                } while (this.sizeTmp != 0);
            }
            return result;
        }

        public int FindSolution() {
            int[] stables = this.FindStables();
            int n = this.size;
            if (n == 0) {
                return 0;
            } else {
                int a = 0;
                for (int i = 0 ; i < n ; i = i + this.k) {
                    int b = 0;
                    for (int j = 0 ; j < this.graph.nbNodes ; j += 1) {
                        for (int l = i ; l < i + this.k; l += 1) {
                            int t = stables[l];
                            if (t == j) {
                                break;
                            } else if (this.graph.GetEdge(t, j) == 1) {
                                b += 1;
                                break;
                            }
                        }
                    }
                    if (a < this.k-b) {
                      a = this.k-b;
                    }
                }
                return a;
            }
        }
    }
    public class Question3
    {
        public static int Answer(int numOfNodes, Edge[] edgeLists)
        {
            if (numOfNodes == 1) {
                return 1;
            }
            int n2 = numOfNodes * numOfNodes;
            int[] edges = new int[n2];
            foreach(Edge t in edgeLists) {
                int a = t.EdgeA - 1 ;
                int b = t.EdgeB - 1;
                edges[a * numOfNodes + b] = 1;
                edges[b * numOfNodes + a] = 1;
            }
            GraphArr g = new GraphArr(numOfNodes, edges);
            Solution solution = new Solution(g);
            return solution.FindSolution();
        }
    }
}
