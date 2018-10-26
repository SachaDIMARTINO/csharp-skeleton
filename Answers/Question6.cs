namespace C_Sharp_Challenge_Skeleton.Answers
using System.Linq;
{
    public class Question6
    {
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            //TODO: Please work out the solution;
            if(numOfServers == 0 || numOfServers > connectionTimeMatrix.rowLength) {
              return -1;
            }
            int[] visited = {};
            return lengthPath(targetServer, connectionTimeMatrix, connectionTimeMatrix[targetServer, 0]);
        }

        public static int lengthPath(int startingNode, int[,] graph, int minValue, int[] visited)
        {
          for(int i = 0; i < graph.rowLength; i++) {
            graph[i, i] = 1000000;
          }
          if(startingNode == 0) {
            return 0;
          }
          visited.add(startingNode);
          int[] availableNodes = {};
          for(int i = 0; i < graph.rowLength; i++) {
            if(!availableNodes.Contains(i) && graph[startingNode, i] <= minValue) {
              availableNodes.add(i);
            }
          }
          foreach(int node in availableNodes) {
            minValue = Math.min(minValue, graph[startingNode, node] + lengthPath(node, graph, minValue, visited)));
          }
          return minValue;
        }
    }
}
