using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
﻿namespace C_Sharp_Challenge_Skeleton.Answers

{

    public class Graph {
        public int nbNodes {
            get;
            set;
        }
        public int[,] edges {
            get;
        }
        public Graph(int nbNodes, int[,] edges) {
            this.nbNodes = nbNodes;
            this.edges = edges;
        }
        public int GetEdge(int i, int j) {
            return this.edges[i,j];
        }
    }

    class Dijkstra {
        public Graph graph;
        bool[] visited;
        int[] distance;
        int finalNode;
        int indiceMin;
        int valueIndiceMin;

        public Dijkstra(Graph graph, int finalNode) {
            this.graph = graph;
            this.visited = new bool[this.graph.nbNodes];
            this.distance = new int[this.graph.nbNodes];
            this.finalNode = finalNode;
            this.indiceMin = - 1;
            this.InitValues();
        }
        public void InitValues() {
            this.distance[0] = 0;
            this.visited[0] = false;
            this.indiceMin = 0;
            this.valueIndiceMin = 0;
            for (int i = 1 ; i < this.graph.nbNodes ; i++) {
                this.distance[i] = int.MaxValue;
                this.visited[i] = false;
            }
        }
        public int FindIndexMin() {
            return this.indiceMin;
        }

        public int majDistance(int s1, int s2, int d1, int d2) {
            if (d2 > d1) {
                this.distance[s2] = d1;
                return d1;
            } else {
                return d2;
            }
        }

        public int RunDijkstra() {
            int ind = 0;
            while(ind != this.finalNode) {
              ind = this.FindIndexMin();
              this.visited[ind] = true;
              if (ind != this.finalNode) {
                  this.indiceMin = this.finalNode;
                  this.valueIndiceMin = this.distance[this.finalNode];
                  int i = 0;
                  foreach(bool v in this.visited) {
                      if (!v) {
                          int edge = this.graph.GetEdge(ind, i);
                          int d2 = this.distance[i];
                          int d1 = this.distance[ind] + edge;
                          d2 = this.majDistance(ind, i, d1, d2);
                          if (d2 < this.valueIndiceMin) {
                              this.indiceMin = i;
                              this.valueIndiceMin = d2;
                          }
                      }
                      i += 1;
                  }
              }
            }
            return this.distance[ind];
        }
    }

    public class Question6
    {



      public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
      {
          //TODO: Please work out the solution;
          if (targetServer == 0 || numOfServers < 2) {
              return 0;
          }
          Graph g = new Graph(numOfServers, connectionTimeMatrix);
          Dijkstra dijkstra = new Dijkstra(g, targetServer);
          return dijkstra.RunDijkstra();
      }
    }
}
