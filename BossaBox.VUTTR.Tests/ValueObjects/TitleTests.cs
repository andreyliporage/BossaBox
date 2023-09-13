using BossaBox.VUTTR.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BossaBox.VUTTR.Tests.ValueObjects
{
    [TestClass]
    public class TitleTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenTitleNameIsNullOrEmpty()
        {
            var title = new Title("");
            Assert.IsTrue(title.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenTitleNameIsValid()
        {
            var title = new Title("Notion");
            Assert.IsTrue(title.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenTitleNameHasFourCharacters()
        {
            var title = new Title("Noti");
            Assert.IsTrue(title.Invalid);
        }
    }
}
