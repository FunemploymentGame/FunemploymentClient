using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funemployment.Models
{
    public class TechnicalQuestion
    {
        public int ID { get; set; }

        public string ProblemDomain { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }

        public int Difficulty { get; set; }
        //public string SuggestedAnswer { get; set; }
        //public List<string> Companies { get; set; }
    }
}
