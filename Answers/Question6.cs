using System;
using System.Linq;
using System.Collections.Generic;
﻿namespace C_Sharp_Challenge_Skeleton.Answers

{
    public class Question6
    {

        public static int findNextNode(int[] djikstra, int length, int[] visited, int infinity) {
          int nextNode = -1;
          int tmp = infinity;
          for(int i = 0; i < length; i++) {
            if(djikstra[i] < tmp && (Array.IndexOf(visited, i) == -1)) {
              tmp = djikstra[i];
              nextNode = i;
            }
          }
          return nextNode;
        }

        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            //TODO: Please work out the solution;
            int nRow = connectionTimeMatrix.GetLength(0);
            if(numOfServers == 0 || numOfServers > nRow || targetServer == 0) {
              return 0;
            }
            int infinity = int.MaxValue - 1;
            int[] djikstra = new int[nRow];
            int[] visited = new int[nRow];
            int nbVisitedNodes = 0;
            for(int i = 0; i < nRow; i++) {
              djikstra[i] = infinity;
              visited[i] = -1;
            }
            // Lets visit the first node
            djikstra[0] = connectionTimeMatrix[0, 0];
            visited[0] = 0;
            nbVisitedNodes++;
            for(int node = 0; node < nRow; node++) {
              if (Array.IndexOf(visited, node) == -1) {
                //djikstra[node] = Math.Min(djikstra[node], djikstra[0] + connectionTimeMatrix[0, node]);
                int x = djikstra[0] + connectionTimeMatrix[0, node];
                if(x < djikstra[node]) {
                  djikstra[node] = x;
                }
              }
            }
            while (Array.IndexOf(visited, -1) != -1) {
              //List<int> newDjikstra = djikstra.ToList();
              int nextNode = Question6.findNextNode(djikstra, nRow, visited, infinity);
              visited[nbVisitedNodes] = nextNode;
              nbVisitedNodes++;
              for(int node = 0; node < nRow; node++) {
                if (Array.IndexOf(visited, node) == -1) {
                  //djikstra[node] = Math.Min(djikstra[node], djikstra[nextNode] + connectionTimeMatrix[nextNode, node]);
                  int y = djikstra[nextNode] + connectionTimeMatrix[nextNode, node];
                  if(y < djikstra[node]) {
                    djikstra[node] = y;
                  }
                }
              }
            }
            return djikstra[targetServer];
        }
    }
}
