using PTMNHDT.KetThucMon.Travel.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTMNHDT.KetThucMon.Travel.Models
{ 
    public class Booking
    {
        [Key] // Khóa chính của bảng Booking
        public int Id { get; set; }

        [Required] // Trường bắt buộc
        public DateTime BookingDate { get; set; } // Ngày đặt phòng

        public DateTime? CheckInDate { get; set; } // Ngày check-in (có thể null)

        public DateTime? CheckOutDate { get; set; } // Ngày check-out (có thể null)

        [ForeignKey("User")] // Khóa ngoại liên kết với bảng User
        public string UserId { get; set; }  // Sửa thành string thay vì int
        public User User { get; set; } // Thông tin người dùng liên kết với Booking

        [ForeignKey("Hotel")] // Khóa ngoại liên kết với bảng Hotel
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } // Thông tin khách sạn liên kết với Booking
    }
}
