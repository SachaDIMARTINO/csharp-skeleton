using System;
using System.Linq;
using System.Collections.Generic;
﻿namespace C_Sharp_Challenge_Skeleton.Answers

{
    public class Question6
    {
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            //TODO: Please work out the solution;
            if(numOfServers == 0 || numOfServers > connectionTimeMatrix.GetLength(0)) {
              return -1;
            }
            int infinity = 1000000;
            List<int> sommetList = new List<int>();
            List<int> djikstra = new List<int>();
            for(int i = 0; i < connectionTimeMatrix.GetLength(0); i++) {
              sommetList.Add(i);
              djikstra.Add(infinity);
            }
            // Lets visit the first node
            djikstra[0] = connectionTimeMatrix[0, 0];
            List<int> visited = new List<int>();
            visited.Add(0);
            foreach(int node in sommetList) {
              if (!visited.Contains(node)) {
                djikstra[node] = Math.Min(djikstra[node], djikstra[0] + connectionTimeMatrix[0, node]);
              }
            }
            List<int> newDjikstra = djikstra.GetRange(0, djikstra.Count);
            while (visited.Count < numOfServers) {
              int nextNode = findNextNode(newDjikstra, visited, infinity); //TODO
              visited.Add(nextNode);
              foreach(int node in sommetList) {
                if (!visited.Contains(node)) {
                  djikstra[node] = Math.Min(djikstra[node], djikstra[nextNode] + connectionTimeMatrix[nextNode, node]);
                }
              }
            }
            return djikstra[targetServer];
        }

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
    }
}
