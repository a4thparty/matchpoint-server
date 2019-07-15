using System;
using System.Collections.Generic;
using System.Text;

namespace MatchPoint.Core.Models
{
    public class Match
    {
        public Guid Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
        public MatchTemplate Template { get; set; }
        public MatchParticipant[] Participants { get; set; }
        public int TeamWon { get; set; }

    }
}
