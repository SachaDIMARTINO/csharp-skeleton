using System;
using System.Linq;
using System.Collections.Generic;
﻿namespace C_Sharp_Challenge_Skeleton.Answers

{
    public class Question6
    {

        public static int findNextNode(List<int> djikstra, List<int> visited, int infinity) {
          int nextNode = djikstra.IndexOf(djikstra.Min());
          if (!visited.Contains(nextNode)) {
            return nextNode;
          }
          else {
            djikstra[nextNode] = infinity;
            return findNextNode(djikstra, visited, infinity);
          }
        }

        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            //TODO: Please work out the solution;
            int nRow = connectionTimeMatrix.GetLength(0);
            if(numOfServers == 0 || numOfServers > nRow || targetServer == 0) {
              return 0;
            }
            int infinity = int.MaxValue - 1;
            List<int> djikstra = new List<int>();
            for(int i = 0; i < nRow; i++) {
              djikstra.Add(infinity);
            }
            // Lets visit the first node
            djikstra[0] = connectionTimeMatrix[0, 0];
            List<int> visited = new List<int>();
            visited.Add(0);
            for(int node = 0; node < nRow; node++) {
              if (!visited.Contains(node)) {
                //djikstra[node] = Math.Min(djikstra[node], djikstra[0] + connectionTimeMatrix[0, node]);
                int x = djikstra[0] + connectionTimeMatrix[0, node];
                if(x < djikstra[node]) {
                  djikstra[node] = x;
                }
              }
            }
            //List<int> newDjikstra = djikstra.GetRange(0, djikstra.Count);
            while (visited.Count < numOfServers) {
              List<int> newDjikstra = djikstra.ToList();
              int nextNode = Question6.findNextNode(newDjikstra, visited, infinity);
              visited.Add(nextNode);
              for(int node = 0; node < nRow; node++) {
                if (!visited.Contains(node)) {
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
