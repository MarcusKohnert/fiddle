using EF6.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;

namespace EF6.Test
{
    [TestClass]
    public class ReadWriteTest
    {
        [TestMethod]
        public void WhenReadAndWrittenWithOneSessionOnlyTheChangedPropertyIsWrittenToTheDatabase()
        {
            IUnitOfWork context = new DatabaseContext();

            IRead<Machine> read = new ReadEntity<Machine>(context);

            var entity = read.ById(1);

            var expected = Guid.NewGuid().ToString();
            entity.Name = expected;

            context.Commit();

            var updated = read.ById(1);

            context.Dispose();

            Assert.AreEqual(expected, updated.Name);
        }
    }
}