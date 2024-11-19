using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2425_MP2_DinersAlgorithm
{
    internal class Table
    {
        private Diner[] diners = new Diner[5];
        private Fork[] forks = new Fork[5];
        

        public Table() 
        {
            for(int x = 0; x < 5; x++)
            {
                diners[x] = new Diner();
                forks[x] = new Fork();
            }

            BeginCycle();
        }

        private void BeginCycle()
        {
            int dinerCount = 0;
            bool allActivated = false;
            int adjFork = 0;
            int cycleCount = 1;

            while(!allActivated)
            {
                Console.WriteLine($"Cycle {cycleCount}:");

                if (dinerCount + 1 < 5)
                    adjFork = dinerCount + 1;
                else
                    adjFork = 0;

                if (diners[dinerCount].getStatus() == 0)
                {

                    Console.WriteLine($"\tDiner {dinerCount} will attempt to eat!");
                    if (forks[dinerCount].getForkStatus() && forks[adjFork].getForkStatus())
                    {
                        diners[dinerCount].changeStatus();
                        forks[dinerCount].setStatus(true);
                        forks[adjFork].setStatus(true);
                        Console.WriteLine($"\tDiner {dinerCount} is eating for {diners[dinerCount].getTimer()} cycles!");
                    }
                    else
                        Console.WriteLine($"\tDiner {dinerCount} attempt failed!");
                }
                else
                {
                    switch(diners[dinerCount].getStatus())
                    {
                        case -1:
                            Console.WriteLine($"\tDiner {dinerCount} is still resting for {diners[dinerCount].getTimer()} cycles!");
                            break;
                        case 1:
                            Console.WriteLine($"\tDiner {dinerCount} is still eating for {diners[dinerCount].getTimer()} cycles!");
                            break;
                    }
                    if(diners[dinerCount].Tick())
                    {
                        forks[dinerCount].setStatus(false);
                        forks[adjFork].setStatus(false);
                    }
                }

                dinerCount++;
                if (dinerCount >= 5)
                {
                    dinerCount = 0;
                    cycleCount++;
                    Console.ReadKey();
                }

                allActivated = checkAllDiners();
                
            }
            Console.WriteLine("All diners have eaten at least once.");
        }

        private bool checkAllDiners()
        {
            bool response = true;
            for(int x = 0; x < diners.Length; x++)
            {
                if(!diners[x].getHasActivated())
                {
                    response = false; 
                    break;
                }
            }

            return response;
        }
    }
}
