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
            List<int> visited = new List<int>();
            return lengthPath(targetServer, connectionTimeMatrix, connectionTimeMatrix[targetServer, 0]);
        }

        public static int lengthPath(int startingNode, int[,] graph, int minValue, List<int> visited)
        {
          for(int i = 0; i < graph.GetLength(0); i++) {
            graph[i, i] = 1000000;
          }
          if(startingNode == 0) {
            return 0;
          }
          visited.Add(startingNode);
          List<int> availableNodes = new List<int>();
          for(int i = 0; i < graph.GetLength(0); i++) {
            if(!availableNodes.Contains(i) && graph[startingNode, i] <= minValue) {
              availableNodes.Add(i);
            }
          }
          foreach(int node in availableNodes) {
            minValue = Math.min(minValue, graph[startingNode, node] + lengthPath(node, graph, minValue, visited));
          }
          return minValue;
        }
    }
}
