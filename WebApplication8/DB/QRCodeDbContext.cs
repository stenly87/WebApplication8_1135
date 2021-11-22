using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.DB
{
    public class QRCodeDbContext : DbContext
    {
        public DbSet<QRCode> codes { get; set; }
        public DbSet<Client> clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = @"192.168.1.14\sqlexpress";
            sb.InitialCatalog = "1135_qrcode";
            sb.UserID = "student";
            sb.Password = "student";
            optionsBuilder.UseSqlServer(sb.ToString());
            base.OnConfiguring(optionsBuilder);
        }

        public QRCodeDbContext()
        {
            // для пересоздания бд
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
