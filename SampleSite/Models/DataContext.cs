namespace SampleSite.Models
{
    public class DataContext
    {
        public static List<Duty> globalDuties { get; set; }

        public DataContext()
        {
            DataContext.globalDuties = new List<Duty>();
        }
    }
}
