namespace VeryRelaxedApi.Models
{
    public class Coach
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Nationality { get; set; }
        public required int Age { get; set; }
        public required string StyleDescription { get; set; }

    }
}
