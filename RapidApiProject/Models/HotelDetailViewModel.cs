namespace RapidApiProject.Models
{
    public class HotelDetailViewModel
    {
        public Data data { get; set; }

        public class Data
        {
            public string hotel_name { get; set; }
            public string url { get; set; }
            public string arrival_date { get; set; }
            public string departure_date { get; set; }
            public string city { get; set; }
            public string country_trans { get; set; }
            public int available_rooms { get; set; }
            public int max_rooms_in_reservation { get; set; }
            public Property_Highlight_Strip[] property_highlight_strip { get; set; }
            public class Property_Highlight_Strip
            {
                public string name { get; set; }
            }
        }
    }
}
