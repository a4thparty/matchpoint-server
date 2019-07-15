using System;
using System.Collections.Generic;
using System.Text;

namespace MatchPoint.Core.Models
{
    public class MatchParticipant
    {
        public int TeamNumber { get; set; }
        public Guid Player { get; set; }
        public int PlayAs { get; set; }
    }
}
