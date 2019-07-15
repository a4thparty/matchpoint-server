using System;
using System.Collections.Generic;
using System.Text;

namespace MatchPoint.Core.Models
{
    public class MatchTemplate
    {
        public int TemplateId { get; set; }
        public string Title { get; set; }

        public static MatchTemplate Badminton { get; } = new MatchTemplate
        {
            TemplateId = 1,
            Title = "Badminton"
        };

        public static MatchTemplate Warcraft { get; } = new MatchTemplate
        {
            TemplateId = 2,
            Title = "Warcraft 3"
        };


    }
}
