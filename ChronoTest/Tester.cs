using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChronoProfiler;
using System.Threading;

namespace ChronoTest
{
    public static class Tester
    {
        public static void Go()
        {
            Chrono.Start("Batch procedure");
            
            for (int i = 0; i < 10; i++)
            {
                Chrono.Start("Batch procedure;Cycle");
                Thread.Sleep(100);
                for (int j = 0; j < 10; j++)
                {
                    Chrono.Start("Batch procedure;Cycle;Inner Cycle");
                    
                    Thread.Sleep(10);
                    
                    Chrono.Start("Batch procedure;Cycle;Inner Cycle;Step 1");
                    Thread.Sleep(10);
                    Chrono.Stop("Batch procedure;Cycle;Inner Cycle;Step 1");

                    Chrono.Start("Batch procedure;Cycle;Inner Cycle;Step 2");
                    Thread.Sleep(11);
                    Chrono.Stop("Batch procedure;Cycle;Inner Cycle;Step 2");

                    Chrono.Start("Batch procedure;Cycle;Inner Cycle;Step 3");
                    Thread.Sleep(12);
                    Chrono.Stop("Batch procedure;Cycle;Inner Cycle;Step 3");
                    
                    Chrono.Stop("Batch procedure;Cycle;Inner Cycle");
                }
                Chrono.Stop("Batch procedure;Cycle");
            }

            for (int i = 0; i < 10; i++)
            {
                Chrono.Start("Batch procedure;Cycle2");
                Thread.Sleep(100);
                for (int j = 0; j < 10; j++)
                {
                    Chrono.Start("Batch procedure;Cycle2;Inner Cycle");
                    Thread.Sleep(10);
                    Chrono.Stop("Batch procedure;Cycle2;Inner Cycle");
                }
                Chrono.Stop("Batch procedure;Cycle2");
            }

            Chrono.Stop("Batch procedure");

            Chrono.ShowResults();
        }
    }
}
