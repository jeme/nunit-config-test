using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitConfigTests
{
    [TestFixture]
    public class MyTests
    {
        [Test]
        public void Test_should_access_config()
        {
            // appSettings
            var someValue = ConfigurationManager.AppSettings["SomeValue"];
            Assert.AreEqual("Hello, config!", someValue);

            // connectionStrings
            var connString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            Assert.AreEqual("Server=(local);user=John", connString);
        }
    }
}
