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
              int counter = 0;
              int sumTmp = 0;
              for(int j = 0; j < lenRow; j++) {
                if (machineToBeFixed[i,j] == "X") {
                  counter = 0;
                  sumTmp = 0;
                  if (numOfConsecutiveMachines >= lenRow - j) {
                    break;
                  }
                }
                else {
                  int elt = int.Parse(machineToBeFixed[i,j]);
                  counter++;
                  sumTmp += elt;
                  if (counter == numOfConsecutiveMachines + 1) {
                    sumTmp -= int.Parse(machineToBeFixed[i, j - numOfConsecutiveMachines]);
                    counter -= 1;
                  }
                  if (counter == numOfConsecutiveMachines) {
                    if (sumTmp < answer) {
                      answer = sumTmp;
                    }
                  }
                }
              }
            }

            return (answer == 1000000) ? 0 : answer;
        }
    }
}
