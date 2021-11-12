using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        static Dictionary<int, QRCode> codes = new Dictionary<int, QRCode>();
        static int autoincrement = 1;

        [HttpGet]
        public IEnumerable<QRCode> Get()
        {
            return codes.Values;
        }

        [HttpPost]
        public QRCode Post(QRCode code)
        {
            code.ID = autoincrement++;
            codes.Add(code.ID, code);
            return code;
        }

        [HttpPut]
        public bool Put(QRCode code)
        {
            if (codes.ContainsKey(code.ID))
            {
                codes[code.ID] = code;
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool Delete(QRCode code)
        {
            if (codes.ContainsKey(code.ID))
            {
                codes.Remove(code.ID);
                return true;
            }
            return false;
        }
    }
}
