namespace RapidApiProject.Models
{
    public class HotelDestinationViewModel
    {
        public Data[] data { get; set; }

        public class Data
        {
            public string dest_id { get; set; }
        }
    }
}
