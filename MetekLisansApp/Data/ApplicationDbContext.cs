using MetekLisansApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MetekLisansApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Ekran> Ekranlar { get; set; }
        public DbSet<Lisans> Lisanslar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<ProjeDurumu> ProjeDurumu { get; set; }
        public DbSet<Statu> Statu { get; set; }
        public DbSet<LisansSure> LisansSure { get; set; }
        public DbSet<BakimAnlasmasi> BakimAnlasmasi { get; set; }
        public DbSet<BakimPaketi> BakimPaketi { get; set; }
        public DbSet<Sahip> Sahip { get; set; }
    }
}
