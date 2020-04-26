using System;

namespace Accenture.Data
{
    public class Operation
    {
        public string Id { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string StartLabel { get; set; }

        public string EndLabel { get; set; }

        public string MainId { get; set; }

        public string TimeLine { get; set; }
    }
}