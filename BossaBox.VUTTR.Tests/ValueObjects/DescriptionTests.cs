using BossaBox.VUTTR.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BossaBox.VUTTR.Tests.ValueObjects
{
    [TestClass]
    public class DescriptionTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDescriptionIsNullOrEmpty()
        {
            var description = new Description("");
            Assert.IsTrue(description.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenDescriptionIsValid()
        {
            var description = new Description("All in one tool to organize teams and ideas.");
            Assert.IsTrue(description.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDescriptionHasLess10Caracters()
        {
            var description = new Description("ABCDERORT");
            Assert.IsTrue(description.Invalid);
        }
    }
}
