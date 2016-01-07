using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace NUnitConfigTests
{
    [TestFixture]
    public class TestUsingMoq
    {
        [Test]
        public void TestMoqVersionRedirect()
        {
            var mocker = new AutoMocker();
            mocker.Setup<IMockableThing>(mock => mock.SayHello(It.IsAny<string>())).Returns("Hello Peter");

            var sut = mocker.CreateInstance<Fake>();

            Assert.That(sut.SayHello("Peter"), Is.EqualTo("Hello Peter"));
        }

    }

    public interface IMockableThing
    {
        string SayHello(string name);
    }

    public class Fake
    {
        private readonly IMockableThing mockable;

        public Fake(IMockableThing mockable)
        {
            this.mockable = mockable;
        }

        public string SayHello(string name)
        {
            return mockable.SayHello(name);
        }
    }
}
