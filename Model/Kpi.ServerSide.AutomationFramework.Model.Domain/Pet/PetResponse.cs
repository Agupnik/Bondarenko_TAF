namespace Kpi.ServerSide.AutomationFramework.Model.Domain.Pet
{
    public class PetResponse
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public string[] PhotoUrls { get; set; }

        public Tag[] Tags { get; set; }

        public string Status { get; set; }
    }
}
