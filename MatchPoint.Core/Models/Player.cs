using System;

namespace MatchPoint.Core.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Appellation { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public DateTime Registered { get; set; }
    }
}
