namespace VeryRelaxedApi.Models
{
    public class Footballer
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string PrefferedFoot {  get; set; }
        public required string Nationality { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
