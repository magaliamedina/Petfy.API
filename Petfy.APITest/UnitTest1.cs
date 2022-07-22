using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Petfy.APITest
{
    [TestClass]
    public class PetServiceTest
    {
        [TestMethod]
        public void DeletePet_When_ID_Is_Negative()
        {
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive();
        }

        [TestMethod]
        public void DeletePet_When_ID_Is_Positive()
        {
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive();
        }

        [TestMethod]
        public void DeletePet_Throw_Exception_When_Not_Found()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive();
        }

        [TestMethod]
        public void DeletePet_Throw_Exception_When_Owner_is_Null()
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive();
        }

    }
}