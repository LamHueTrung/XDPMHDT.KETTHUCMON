using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTMNHDT.KetThucMon.Travel.Models
{
    public class Comment
    {
        [Key] // Khóa chính của bảng Comment
        public int Id { get; set; }

        [Required] // Trường bắt buộc
        [MaxLength(500)] // Giới hạn độ dài của nội dung bình luận
        public string Content { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now; // Ngày đăng bình luận, mặc định là ngày hiện tại

        [ForeignKey("User")] // Khóa ngoại liên kết với bảng User
        public string UserId { get; set; }
        public User User { get; set; } // Thông tin người dùng đã đăng bình luận

        [ForeignKey("Place")] // Khóa ngoại liên kết với bảng Place
        public int PlaceId { get; set; }
        public Place Place { get; set; } // Thông tin về địa điểm mà bình luận nhắm đến
    }
}
