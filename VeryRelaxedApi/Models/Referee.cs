namespace VeryRelaxedApi.Models
{
    public class Referee
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Nationality { get; set; }

    }
}
