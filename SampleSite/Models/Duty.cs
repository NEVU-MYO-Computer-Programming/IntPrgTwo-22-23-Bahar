namespace SampleSite.Models
{
    public class Duty
    {
        private static int _counter = 0;

        private int _id;
        public int ID
        {
            get
            {
                return _id;
            }
            private set { _id = value; }
        }
        public string Name { get; set; }
        public int TimeInDays { get; set; }

        public Duty()
        {
            _counter++;
            this._id = _counter;
        }


    }
}
