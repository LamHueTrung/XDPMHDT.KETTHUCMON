using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PTMNHDT.KetThucMon.Travel.Models
{
    public class Place
    {
        [Key] // Khóa chính của bảng Place
        public int Id { get; set; }

        [Required] // Trường bắt buộcs
        [MaxLength(100)] // Giới hạn độ dài của tên
        public string Name { get; set; }

        [Required] // Trường bắt buộc
        [MaxLength(500)] // Giới hạn độ dài của mô tả
        public string Description { get; set; }

        public string Location { get; set; } // Địa điểm của Place

        public double Rating { get; set; } // Đánh giá cho Place

        public ICollection<Comment> Comments { get; set; } // Danh sách các bình luận liên kết với Place
    }
}
