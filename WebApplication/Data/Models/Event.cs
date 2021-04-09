using System;

namespace WebApplication.Data.Models
{
    public class Event
    {
        public int eventId { set; get; }

        public string subject { set; get; }

        public string? description { set; get; }

        public DateTime start { set; get; }

        public DateTime? end { set; get; }

        public string? themeColor { set; get; }

        public bool isFullDay { set; get; }

    }
}
