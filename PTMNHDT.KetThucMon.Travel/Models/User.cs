using Microsoft.AspNetCore.Identity;

namespace PTMNHDT.KetThucMon.Travel.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } // Tên đầy đủ của người dùng

        public ICollection<Booking>? Bookings { get; set; } // Danh sách các Booking của người dùng
        public ICollection<Comment>? Comments { get; set; } // Danh sách các Comment của người dùng
    }
}
