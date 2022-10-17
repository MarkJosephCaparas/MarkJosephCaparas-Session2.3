using HomeWork3.DataModels;
using HomeWork3.Resources;
using HomeWork3.Tests.TestData;
using RestSharp;


namespace HomeWork3.Helpers
{
    /// <summary>
    /// helper method for pets
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// POST request to add new pet
        /// </summary>
        ///

        public static async Task<PetModel> AddNewPet(RestClient client)
        {
            var newPetData = GeneratePet.demoPet();
            var postRequest = new RestRequest(Endpoint.PostPet());

            
            postRequest.AddJsonBody(newPetData);
            var postResponse = await client.ExecutePostAsync<PetModel>(postRequest);

            var createdPetData = newPetData;
            return createdPetData;
        }
    }
}
