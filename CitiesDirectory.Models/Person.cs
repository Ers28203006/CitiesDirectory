namespace CitiesDirectory.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
    }
}
