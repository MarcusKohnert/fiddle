using EF6.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace EF6.Test
{
    [TestClass]
    public class ReadTest
    {
        [TestMethod]
        public void ReadByIdTest()
        {
            IUnitOfWork uow = new DatabaseContext();
            IRead<Machine> read = new ReadEntity<Machine>(uow);
            var machine = read.ById(1);

            Assert.IsNotNull(machine);
        }
    }
}