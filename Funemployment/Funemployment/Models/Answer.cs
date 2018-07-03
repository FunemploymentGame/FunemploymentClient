using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funemployment.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public int BQID { get; set; }
        public int TQID { get; set; }
        public int PID { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
