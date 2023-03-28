namespace SampleSite.Models
{
    public class Staff
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Duty> Duties { get; set; }

    }
}
