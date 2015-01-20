using Autofac;
using DISample.Data;
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

            containerBuilder.RegisterGeneric(typeof(MemoryRepository<>))
                            .As(typeof(IRepository<>));

            containerBuilder.RegisterType<InMemorySession>()
                            .As<IUnitOfWork>();

            var container = containerBuilder.Build();

            //Sample1(container);
            Sample2(container);

            Console.WriteLine("[Enter to close]");
            Console.ReadLine();
        }

        static void Sample1(IContainer container)
        {
            var service = container.Resolve<ISampleService>();
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
        }

        static void Sample2(IContainer container)
        {
            var service = container.Resolve<ISampleService>();
            service.Add();
            service.Add();

            service.All().ForEach(_ => Console.WriteLine(_.Id));
        }
    }
}