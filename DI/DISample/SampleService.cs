using System;

namespace DISample
{
    internal class SampleService : ISampleService
    {
        public void DoSomething()
        {
            Console.WriteLine("SampleService says Hello World");
        }

        public void ThrowsException()
        {
            throw new ApplicationException("I told you I'm throwing an execption.");
        }
    }
}