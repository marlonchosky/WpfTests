using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3 {
    class StatusChecker {
        private int numberOfSecondsLeft;

        public StatusChecker(int numberOfSecondsLeft) {
            this.numberOfSecondsLeft = numberOfSecondsLeft;
        }

        public void CountDown(object state) {
            Console.Write($"{this.numberOfSecondsLeft - 1},");

            var autoEvent = (AutoResetEvent)state;
            if (--this.numberOfSecondsLeft == 0) {
                autoEvent.Set();
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            var numberOfSeconds = input();
            var autoEvent = new AutoResetEvent(false);

            var checker = new StatusChecker(numberOfSeconds + 1);
            Console.WriteLine("Time left:");
            var t = new Timer(checker.CountDown, autoEvent, 0, 1000);
            autoEvent.WaitOne();
            t.Dispose();
        }

        public static int input() {
            int numberOfSeconds;
            do {
                Console.WriteLine("How many seconds would you like the test to be? Please type a number divisible by 10!");
                int.TryParse(Console.ReadLine(), out numberOfSeconds);
            } while (numberOfSeconds % 10 != 0);
            return numberOfSeconds;
        }
    }
}
