using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTMNHDT.KetThucMon.Travel.Models
{
    public class Hotel
    {
        [Key] // Khóa chính của bảng Hotel
        public int Id { get; set; }

        [Required] // Trường bắt buộc
        [MaxLength(100)] // Giới hạn độ dài của tên khách sạn
        public string Name { get; set; }

        public string Address { get; set; } // Địa chỉ khách sạn

        public double Rating { get; set; } // Đánh giá khách sạn

        public ICollection<Booking> Bookings { get; set; } // Danh sách các đặt phòng liên kết với khách sạn
    }
}
