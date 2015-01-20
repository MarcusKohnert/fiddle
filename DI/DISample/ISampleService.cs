using DISample.Data;
using System.Collections.Generic;

namespace DISample
{
    public interface ISampleService
    {
        void Add();

        List<IIdentifiable> All();

        void DoSomething();

        void ThrowsException();
    }
}