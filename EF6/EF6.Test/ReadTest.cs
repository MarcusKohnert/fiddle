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
            IRead<Machine> dbContext = new ReadModel<Machine>();
            var machine = dbContext.By(1);

            Assert.IsNotNull(machine);
        }
    }
}