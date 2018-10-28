using System;
using System.Linq;
using System.Collections.Generic;
﻿namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            //TODO: Please work out the solution;
            int nRows = machineToBeFixed.GetLength(0);
            int lenRow = machineToBeFixed.GetLength(1);

            int answer = 1000000;
            if (nRows == 0 || lenRow == 0 || numOfConsecutiveMachines <= 0 || nRows > 100 || numOfConsecutiveMachines > lenRow || numOfConsecutiveMachines > 100) {
              return 0;
            }

            for(int i = 0; i < nRows; i++) {
              for(int start = 0; start <= lenRow - numOfConsecutiveMachines; start++) {
                List<string> shortRow = new List<string>();
                for(int j = start; j < start + numOfConsecutiveMachines; j++) {
                  shortRow.Add(machineToBeFixed[i, j]);
                }
                if (!shortRow.Contains("X")) {
                  List<int> rowInt = new List<int>();
                  foreach(string elt in shortRow) {
                    rowInt.Add(int.Parse(elt));
                  }
                  answer = Math.Min(answer, rowInt.Sum());
                }
              }
            }

            if (answer == 1000000) {
              return 0;
            }
            else {
              return answer;
            }
        }
    }
}
