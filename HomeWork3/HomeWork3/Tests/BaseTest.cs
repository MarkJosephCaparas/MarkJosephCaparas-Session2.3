using HomeWork3.DataModels;
using RestSharp;


namespace HomeWork3.Tests
{
    public  class BaseTest
    {
        public RestClient RestClient { get; set; }

        public PetModel petDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
