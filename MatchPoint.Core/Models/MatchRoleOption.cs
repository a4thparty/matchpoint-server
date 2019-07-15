using System;
using System.Collections.Generic;
using System.Text;

namespace MatchPoint.Core.Models
{
    public class MatchRoleOption
    {
        public Guid Id { get; set; }
        public MatchTemplate Template { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}
