﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrtgAPI.Tests.UnitTests.ObjectTests.CSharp.Query.Linq
{
    [TestClass]
    public class AnyTests : BaseQueryTests
    {
        [TestMethod]
        public void Query_Any_NoPredicate()
        {
            ExecuteNow(q => q.Any(), string.Empty, Assert.IsTrue);
        }

        [TestMethod]
        public void Query_Any_WithPredicate()
        {
            ExecuteNow(q => q.Any(s => s.Name == "Volume IO _Total0"), "filter_name=Volume+IO+_Total0", Assert.IsTrue);
        }

        [TestMethod]
        public void Query_Any_WithPredicate_AfterWhere()
        {
            ExecuteNow(q => q.Where(s => s.Id == 4001).Any(s => s.Name == "Volume IO _Total0"), "filter_objid=4001", Assert.IsFalse);
        }
    }
}
