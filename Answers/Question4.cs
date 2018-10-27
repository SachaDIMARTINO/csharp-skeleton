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
            string[][] newMachineToBeFixed = new string[machineToBeFixed.GetLength(0)][];
            for(int i = 0; i < machineToBeFixed.GetLength(0); i++) {
              string[] newLine = new string[machineToBeFixed.GetLength(1)];
              for(int j = 0; j < machineToBeFixed.GetLength(1); j++) {
                newLine[j] = machineToBeFixed[i,j];
              }
              newMachineToBeFixed[i] = newLine;
            }
            int answer = 1000000;
            if (machineToBeFixed.GetLength(0) == 0 || numOfConsecutiveMachines <= 0 || numOfConsecutiveMachines > 100) {
              return 0;
            }
            foreach(string[] row in newMachineToBeFixed) {
              for(int start = 0; start < row.Count() - numOfConsecutiveMachines; start++) {
                string[] shortRow = new string[numOfConsecutiveMachines];
                Array.Copy(row, start, shortRow, 0, numOfConsecutiveMachines);
                //rowInt = row.GetRange(start, numOfConsecutiveMachines);
                List<int> rowInt = new List<int>();
                if (!shortRow.Contains("X")) {
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
