using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab.Models
{
    public partial class TelephoneContext : DbContext
    {
        public TelephoneContext()
        {
        }

        public TelephoneContext(DbContextOptions<TelephoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Звонки> Звонки { get; set; }
        public virtual DbSet<Расценки> Расценки { get; set; }
        public virtual DbSet<Скидки> Скидки { get; set; }
        public virtual DbSet<ЮридЛица> ЮридЛица { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=db_telephone;Username=postgres;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Звонки>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ВремяСуток)
                    .IsRequired()
                    .HasColumnName("Время_суток");

                entity.Property(e => e.Город).IsRequired();

                entity.Property(e => e.Дата).HasColumnType("date");

                entity.Property(e => e.Инн).HasColumnName("ИНН");

                entity.HasOne(d => d.ИннNavigation)
                    .WithMany(p => p.Звонки)
                    .HasForeignKey(d => d.Инн)
                    .HasConstraintName("Юрид_лица_fk");

                entity.HasOne(d => d.Расценки)
                    .WithMany(p => p.Звонки)
                    .HasForeignKey(d => new { d.Город, d.ВремяСуток })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Расценки_fk");
            });

            modelBuilder.Entity<Расценки>(entity =>
            {
                entity.HasKey(e => new { e.Город, e.ВремяСуток })
                    .HasName("Расценки_pk");

                entity.Property(e => e.Город).HasDefaultValueSql("'Неизвестно'::text");

                entity.Property(e => e.ВремяСуток)
                    .HasColumnName("Время_суток")
                    .HasDefaultValueSql("'день'::text");

                entity.Property(e => e.Стоимость).HasDefaultValueSql("10");
            });

            modelBuilder.Entity<Скидки>(entity =>
            {
                entity.HasKey(e => new { e.Город, e.Длительность })
                    .HasName("Скидка_pk");
            });

            modelBuilder.Entity<ЮридЛица>(entity =>
            {
                entity.HasKey(e => e.Инн)
                    .HasName("Юрид_лицо_pk");

                entity.ToTable("Юрид_лица");

                entity.HasIndex(e => e.Наименование)
                    .HasName("Название_фирмы")
                    .IsUnique();

                entity.Property(e => e.Инн)
                    .HasColumnName("ИНН")
                    .ValueGeneratedNever();

                entity.Property(e => e.БанкСчет).HasColumnName("Банк_счет");

                entity.Property(e => e.Город).IsRequired();

                entity.Property(e => e.Наименование).IsRequired();

                entity.Property(e => e.ТелТочка).HasColumnName("Тел_точка");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
