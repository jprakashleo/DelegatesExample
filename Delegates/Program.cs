using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Delegates
{
    internal class Program
    {
        //technically delegates are pointer to funciton
        //main intention is callbacks, Async, communication between 2 threads

        public delegate void Somedalegate(string someval);
        public static Somedalegate theDelegate = null;
        static void Main(string[] args)
        {
            
            ThresholdReachedEventArgs e_args = new ThresholdReachedEventArgs();
            e_args.Threshold = 5;
            e_args.TimeReached = DateTime.Now;
            //create new thread object and start with function on single line command  
            //Thread y = new Thread(new ThreadStart(c_ThresholdReached)); //example of without parameter function

            //create new thread obj and start separatly if pass parameter in fun
            Thread y = new Thread(() => c_ThresholdReached(e_args));
            y.Start();
            Console.WriteLine("main thread is now ending");
            Console.ReadLine();
            //theDelegate = c_ThresholdReached;
            //theDelegate(e_args);
        }

        static void receiver(string s)
        {
            Console.WriteLine(s);
        }
        static void c_ThresholdReached(ThresholdReachedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
                Thread.Sleep(5000);
                theDelegate = receiver;
                theDelegate("now i value is "+i); //callback to main thread

            }
            
            Console.ReadKey(true);          
        }
    }

        

        public class ThresholdReachedEventArgs : EventArgs
        {
            public int Threshold { get; set; }
            public DateTime TimeReached { get; set; }
        }
 }
