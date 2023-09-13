using BossaBox.VUTTR.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BossaBox.VUTTR.Tests.ValueObjects
{
    [TestClass]
    public class TagTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenTagHasTwoCaracteres()
        {
            var tag = new Tag("cd");
            Assert.IsTrue(tag.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenTagIsNullOrEmpty()
        {
            var tag = new Tag("");
            Assert.IsTrue(tag.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenTagIsValid()
        {
            var tag = new Tag("api");
            Assert.IsTrue(tag.Valid);
        }
    }
}
