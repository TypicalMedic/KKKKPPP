using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using KKKKPPP.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KKKKPPP.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {
            КартинаEnt = new Картина();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Связь_Материал_Картина>()
                .HasKey(c => new { c.Картина, c.Материал });
            modelBuilder.Entity<Связь_Рест_Вид>()
                .HasKey(c => new { c.Код_реставрации, c.Вид_реставрации });
            modelBuilder.Entity<Экспонат>()
                .HasKey(c => new { c.Экспозиция, c.Место });
        }
        public DbSet<Автор> Автор { get; set; }
        public DbSet<Вид_реставрации> Вид_реставрации { get; set; }
        public DbSet<Жанр> Жанр { get; set; }
        public DbSet<Зал> Зал { get; set; }
        public DbSet<Картина> Картина { get; set; }
        public Картина КартинаEnt { get; set; }
        public DbSet<Материал> Материал { get; set; }
        public DbSet<Место> Место { get; set; }
        public DbSet<Реставрация> Реставрация { get; set; }
        public DbSet<Связь_Материал_Картина> Связь_Материал_Картина { get; set; }
        public DbSet<Связь_Рест_Вид> Связь_Рест_Вид { get; set; }
        public DbSet<Состояние_картины> Состояние_картины { get; set; }
        public DbSet<Статус_картины> Статус_картины { get; set; }
        public DbSet<Статус_экспозиции> Статус_экспозиции { get; set; }
        public DbSet<Стиль> Стиль { get; set; }
        public DbSet<Страна> Страна { get; set; }
        public DbSet<Техника> Техника{ get; set; }
        public DbSet<Экспозиция> Экспозиция { get; set; }
        public DbSet<Экспонат> Экспонат { get; set; }

    }
}
