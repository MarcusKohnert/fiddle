using DISample.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DISample
{
    internal class SampleService : ISampleService
    {
        private readonly IRepository<Customer> repo;

        public SampleService(IRepository<Customer> repo)
        {
            this.repo = repo;
        }

        public void Add()
        {
            this.repo.Save(new Customer());
        }

        public List<IIdentifiable> All() 
        { 
            return this.repo
                       .Query()
                       .ToList();
        }

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