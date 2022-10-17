using HomeWork3.DataModels;
using HomeWork3.Helpers;
using HomeWork3.Resources;
using RestSharp;
using System.Net;

namespace HomeWork3.Tests
{
    [TestClass]
    public class Test : BaseTest
    {
        private static List<PetModel> petCleanUpList = new List<PetModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            petDetails = await Helper.AddNewPet(RestClient);
        }

        [TestMethod]
        public async Task GetPet()
        {
            //Arrange
            var getPetRequest = new RestRequest(Endpoint.GetPetById(petDetails.id));
            petCleanUpList.Add(petDetails);

            //Act
            var petResponse = await RestClient.ExecuteGetAsync<PetModel>(getPetRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, petResponse.StatusCode, "status code is not matching.");
            Assert.AreEqual(petDetails.name, petResponse.Data.name, "Name did not matched");
            Assert.AreEqual(petDetails.category.id, petResponse.Data.category.id, "Category id did not matched");
            Assert.AreEqual(petDetails.category.name, petResponse.Data.category.name, "Category did not matched");
            Assert.AreEqual(petDetails.photoUrls[0], petResponse.Data.photoUrls[0], "Photo url did not matched");
            Assert.AreEqual(petDetails.tags[0].id, petResponse.Data.tags[0].id, "Tag id did not matched");
            Assert.AreEqual(petDetails.tags[0].name, petResponse.Data.tags[0].name, "Tag did not matched");
            Assert.AreEqual(petDetails.status, petResponse.Data.status, "Status  did not matched");
        }

        /// <summary>
        /// Cleaning up 
        /// </summary>
        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in petCleanUpList)
            {
                var deletePetRequest = new RestRequest(Endpoint.GetPetById(petDetails.id));
                await RestClient.DeleteAsync(deletePetRequest);
            }
        }
    }
}