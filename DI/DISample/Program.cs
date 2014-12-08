using Autofac;
using System;

namespace DISample
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            
            containerBuilder.RegisterType<SampleService>()
                            .As<ISampleService>();

            var resolver = containerBuilder.Build();

            var service = resolver.Resolve<ISampleService>();
            service.DoSomething();

            try
            {
                service.ThrowsException();
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("[Enter to close]");
            Console.ReadLine();
        }
    }
}