using BossaBox.VUTTR.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BossaBox.VUTTR.Tests.ValueObjects
{
    [TestClass]
    public class LinkTests
    {
        private const string URL_INVALID = "htp://google.com";
        private const string URL_VALID = "https://google.com";

        [TestMethod]
        public void ShouldReturnErrorWhenUrlIsInvalid()
        {
            var link = new Link(URL_INVALID);
            Assert.IsTrue(link.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenUrlIsNullOrEmpty()
        {
            var link = new Link("");
            Assert.IsTrue(link.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenUrlIsValid()
        {
            var link = new Link(URL_VALID);
            Assert.IsTrue(link.Valid);
        }
    }
}
