using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class QRCode
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public long DateEnd { get; private set; }
    }
}
