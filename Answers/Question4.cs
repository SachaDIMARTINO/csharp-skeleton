using System;
using System.Linq;
using System.Collections.Generic;
﻿namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Parse(string str) {
            int y = 0;
            int n = str.Length;
            for (int i = 0 ; i < n; i++) {
                y = y * 10 + (str[i] - '0');
            }
            return y;
        }
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            //TODO: Please work out the solution;
            int nRows = machineToBeFixed.GetLength(0);
            int lenRow = machineToBeFixed.GetLength(1);

            int answer = 1000000;
            if (numOfConsecutiveMachines > lenRow) {
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
                  int elt = Question4.Parse(machineToBeFixed[i,j]);
                  counter += 1;
                  sumTmp += elt;
                  if (counter == numOfConsecutiveMachines + 1) {
                    sumTmp -= Question4.Parse(machineToBeFixed[i, j - numOfConsecutiveMachines]);
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
            if(answer == 1000000) {
              return 0;
            }
            return answer;
        }
    }
}
