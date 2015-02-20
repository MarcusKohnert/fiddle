using System;
using System.Runtime.CompilerServices;

namespace CallerAttributes
{
    class Program
    {
        private readonly ConsoleLogger logger;

        static void Main(string[] args)
        {
            var p = new Program(new ConsoleLogger());
            p.DoThis();
            p.DoThat();

            Console.WriteLine("[ENTER] to exit");
            Console.ReadLine();
        }

        public Program(ConsoleLogger logger)
        {
            this.logger = logger;
        }

        private void DoThis()
        {
            this.logger.Log("I'm here");
        }

        private void DoThat()
        {
            this.logger.Log("I'm here");
        }
    }

    internal class ConsoleLogger
    {
        internal void Log(string message, [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLineNumber = -1)
        {
            Console.WriteLine("{0}:\t{1}\t{2}", callerLineNumber, callerMemberName, message);
        }
    }
}