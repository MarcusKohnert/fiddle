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
        public void WhenReadAndWrittenWithOnSessionOnlyTheChangedPropertyIsWrittenToTheDatabase()
        {
            var context = new DatabaseContext();

            IRead<Machine> read = new ReadModel<Machine>(context);

            var entity = read.By(1);

            entity.Name = Guid.NewGuid().ToString();

            context.SaveChanges();

            var entity2 = read.By(1);

            context.Dispose();

            Assert.AreNotEqual(entity.Version, entity2.Version);
        }

        [TestMethod]
        public void Do()
        {
            using (var context = new DatabaseContext())
            {
                var entity = context.Set<Machine>().Find(1);
                var actual = entity.Name;

                entity.Name = "New machine name";
                
                context.SaveChanges();

                Assert.AreNotEqual(actual, entity.Name);
            }
        }
    }
}