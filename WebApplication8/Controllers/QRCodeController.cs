using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.DB;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        private readonly QRCodeDbContext db;

        public QRCodeController(QRCodeDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<QRCode> Get()
        {
            return db.codes;
        }

        [HttpPost]
        public QRCode Post(QRCode code)
        {
            db.codes.Add(code);
            db.SaveChanges();
            return code;
        }

        [HttpPut]
        public bool Put(QRCode code)
        {
            var update = db.codes.FirstOrDefault(s => s.ID == code.ID);
            if (update == null)
                return false;
            db.Entry(update).CurrentValues.SetValues(code);
            db.SaveChanges();
            return true;
        }

        [HttpDelete]
        public bool Delete(QRCode code)
        {
            var delete = db.codes.FirstOrDefault(s => s.ID == code.ID);
            if (delete == null)
                return false;
            db.codes.Remove(delete);
            db.SaveChanges();
            return true;
        }
    }
}
