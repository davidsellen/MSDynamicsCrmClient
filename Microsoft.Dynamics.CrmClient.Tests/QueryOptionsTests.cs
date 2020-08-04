using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Dynamics.CrmClient.Tests
{
    [TestClass]
    public class QueryOptionsTests
    {
        [TestMethod]
        public void CanGenerateComparisonOperators()
        {
            var equal = new QueryOptions()
                .Equal("fullname", "David Santos")
                .Top(1)
                .ToString();

            Assert.AreEqual(equal, "$filter=fullname eq 'David Santos'&$top=1");
         
            var notEqual = new QueryOptions()
                .NotEqual("fullname", "David Santos")
                .Top(1)
                .ToString();

            Assert.AreEqual(notEqual, "$filter=fullname ne 'David Santos'&$top=1");

            var greaterThan = new QueryOptions()
                .GreaterThan("fullname", "David Santos")
                .Top(1)
                .ToString();

            Assert.AreEqual(greaterThan, "$filter=fullname gt 'David Santos'&$top=1");

            var greaterThanOrEqual = new QueryOptions()
                .GreaterThanOrEqual("fullname", "David Santos")
                .Top(1)
                .ToString();

            Assert.AreEqual(greaterThanOrEqual, "$filter=fullname ge 'David Santos'&$top=1");

            var lessThan = new QueryOptions()
                .LessThan("fullname", "David Santos")
                .Top(1)
                .ToString();

            Assert.AreEqual(lessThan, "$filter=fullname lt 'David Santos'&$top=1");

            var lessThanOrEqual = new QueryOptions()
                .LessThanOrEqual("fullname", "David Santos")
                .Top(1)
                .ToString();

            Assert.AreEqual(lessThanOrEqual, "$filter=fullname le 'David Santos'&$top=1");

            var equalWithInteger = new QueryOptions()
                .Equal("id", 1)
                .ToString();

            Assert.AreEqual(equalWithInteger, "$filter=id eq 1&$top=10");

            var greaterThanWithDate = new QueryOptions()
                .GreaterThan("modifiedon", new DateTime(2020, 6, 22, 2, 30, 1, DateTimeKind.Utc))
                .ToString();
            
            Assert.AreEqual(greaterThanWithDate, "$filter=modifiedon gt datetime'2020-06-22T02:30:01.0000000Z'&$top=10");

            
        }

        [TestMethod]
        public void CanGenerateCompositeOperators()
        {
            var age = new QueryOptions()
               .Equal("age", 18);

            var height = new QueryOptions()
                .Equal("height", 75);

            var and = age.And(height).ToString();

            Assert.AreEqual(and, "$filter=age eq 18 and height eq 75&$top=10");

            var one = new QueryOptions()
              .Equal("one", 1);

            var two = new QueryOptions()
                .Equal("two", 2);

            var or = one.Or(two).ToString();

            Assert.AreEqual(or, "$filter=one eq 1 or two eq 2&$top=10");
             
        }
    }
}
