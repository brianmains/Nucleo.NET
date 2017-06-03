using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nucleo.Data
{
    [TestClass]
    public class ObjectsTest
    {
        protected class TestClass
        {
            public int Key { get; set; }

            public string Name { get; set; }
        }

        [TestMethod]
        public void CreatingNewEntityWithBooleanReturnsTrue()
        {
            TestClass entity = null;
            bool created;

            entity = Objects.CreateOrUpdate(entity, (e) =>
            {
                e.Name = "Test";
            }, out created);

            Assert.AreEqual(true, created);
        }

        [TestMethod]
        public void CreatingNewEntityWithBooleanWorksOK()
        {
            TestClass entity = null;
            bool created;

            entity = Objects.CreateOrUpdate(entity, (e) =>
            {
                e.Name = "Test";
            }, out created);

            Assert.IsNotNull(entity);
            Assert.AreEqual("Test", entity.Name);
        }

        [TestMethod]
        public void CreatingNewEntityWorksOK()
        {
            TestClass entity = null;

            entity = Objects.CreateOrUpdate(entity, (e) =>
                {
                    e.Name = "Test";
                });


            Assert.IsNotNull(entity);
            Assert.AreEqual("Test", entity.Name);
        }

        [TestMethod]
        public void UpdatingExistingEntityWithBooleanReturnsFalse()
        {
            TestClass entity = new TestClass { Key = 1, Name = "A" };
            bool created;

            entity = Objects.CreateOrUpdate(entity, (e) =>
            {
                e.Name = "Test";
            }, out created);


            Assert.IsFalse(created);
        }

        [TestMethod]
        public void UpdatingExistingEntityWithBooleanWorksOK()
        {
            TestClass entity = new TestClass { Key = 1, Name = "A" };
            bool created;

            entity = Objects.CreateOrUpdate(entity, (e) =>
            {
                e.Name = "Test";
            }, out created);


            Assert.IsNotNull(entity);
            Assert.AreEqual(1, entity.Key);
            Assert.AreEqual("Test", entity.Name);
        }

        [TestMethod]
        public void UpdatingExistingEntityWorksOK()
        {
            TestClass entity = new TestClass { Key = 1, Name = "A" };
            
            entity = Objects.CreateOrUpdate(entity, (e) =>
            {
                e.Name = "Test";
            });


            Assert.IsNotNull(entity);
            Assert.AreEqual(1, entity.Key);
            Assert.AreEqual("Test", entity.Name);
        }
    }
}
