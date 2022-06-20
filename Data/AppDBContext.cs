using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using KKKKPPP.Data.Models;
using KKKKPPP.Data.Models.ClientSide;
using Microsoft.EntityFrameworkCore;
using ISO3166;

namespace KKKKPPP.Data
{
    public class AppDBContext : DbContext
    {
        public static Country[] countries = Country.List;
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Связь_Материал_Картина>()
                .HasKey(c => new { c.Картина, c.Материал });
            modelBuilder.Entity<Связь_Рест_Вид>()
                .HasKey(c => new { c.Код_реставрации, c.Вид_реставрации });
            modelBuilder.Entity<Экспонат>()
                .HasKey(c => new { c.Экспозиция, c.Место });
            modelBuilder.Entity<LikeExpo>()
                .HasKey(c => new { c.ExpoId, c.UserId });
            modelBuilder.Entity<LikeExcur>()
                .HasKey(c => new { c.ExcurId, c.UserId });
        }
        public DbSet<User> User { get; set; }
        public DbSet<CommentExpo> CommentExpo { get; set; }
        public DbSet<CommentExcur> CommentExcur { get; set; }
        public DbSet<LikeExpo> LikeExpo { get; set; }
        public DbSet<LikeExcur> LikeExcur { get; set; }
        public DbSet<Автор> Автор { get; set; }
        public DbSet<Вид_реставрации> Вид_реставрации { get; set; }
        public DbSet<Жанр> Жанр { get; set; }
        public DbSet<Зал> Зал { get; set; }
        public DbSet<Картина> Картина { get; set; }
        public DbSet<Материал> Материал { get; set; }
        public DbSet<Место> Место { get; set; }
        public DbSet<Реставрация> Реставрация { get; set; }
        public DbSet<Связь_Материал_Картина> Связь_Материал_Картина { get; set; }
        public DbSet<Связь_Рест_Вид> Связь_Рест_Вид { get; set; }
        public DbSet<Состояние_картины> Состояние_картины { get; set; }
        public DbSet<Статус_картины> Статус_картины { get; set; }
        //public DbSet<Статус_экспозиции> Статус_экспозиции { get; set; }
        public DbSet<Стиль> Стиль { get; set; }
        public DbSet<Страна> Страна { get; set; }
        public DbSet<Техника> Техника{ get; set; }
        public DbSet<Экскурсия> Экскурсия { get; set; }
        public DbSet<Экспозиция> Экспозиция { get; set; }
        public DbSet<Экспонат> Экспонат { get; set; }
        public DbSet<Аналитический_отчет> Аналитический_отчет { get; set; }

    }
}
