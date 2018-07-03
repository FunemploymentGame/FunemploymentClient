using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funemployment.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string About { get; set; }
        public int Points { get; set; }
        public List<Answer> MyAnswers { get; set; }
        public string Location { get; set; }
        public string Username { get; set; }
    }
}
