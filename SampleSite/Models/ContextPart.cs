namespace SampleSite.Models
{
    public partial class SampleContext
    {

        private readonly IConfiguration _configuration;

        public SampleContext(IConfiguration _con)
        {
            _configuration = _con;
        }
    }
}
