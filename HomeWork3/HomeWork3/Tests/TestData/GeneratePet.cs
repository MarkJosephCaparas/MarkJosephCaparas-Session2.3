using HomeWork3.DataModels;



namespace HomeWork3.Tests.TestData
{
    public  class GeneratePet
    {
        public static PetModel demoPet()
        {
            return new PetModel
            {
                id = 1234,
                category = new Category()
                {
                    id = 5678,
                    name = "PetCategory"
                },


                name = "Blacky",
                photoUrls = new string[]
                {
                    "Running", "Sleeping"
                },

                tags = new Tag[]
                {
                    new Tag()
                    {
                     id = 0,
                     name = "PetTag"

                    }


                },
                status = "available"
            };
        }
    }
}
