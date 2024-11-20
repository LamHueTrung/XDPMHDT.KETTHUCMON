using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PTMNHDT.KetThucMon.Travel.Models;

namespace PTMNHDT.KetThucMon.Travel.Data
{
    public class TravelDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options)
        : base(options)
        {
        }
        public DbSet<Page> Pages { get; set; } // Bảng Page
        public DbSet<Setting> Settings { get; set; } // Bảng Settings
        public DbSet<Place> Places { get; set; } // Bảng Places
        public DbSet<Hotel> Hotels { get; set; } // Bảng Hotels
        public DbSet<Booking> Bookings { get; set; } // Bảng Bookings
        public DbSet<Comment> Comments { get; set; } // Bảng Comments

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ 1-N: Một User có nhiều Comment, một Comment chỉ thuộc một User
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            // Cấu hình quan hệ 1-N: Một Place có nhiều Comment, một Comment chỉ thuộc một Place
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Place)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PlaceId);

            // Cấu hình quan hệ 1-N: Một User có nhiều Booking, một Booking chỉ thuộc một User
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            // Cấu hình quan hệ 1-N: Một Hotel có nhiều Booking, một Booking chỉ thuộc một Hotel
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Hotel)
                .WithMany(h => h.Bookings)
                .HasForeignKey(b => b.HotelId);
        }
    }
}
