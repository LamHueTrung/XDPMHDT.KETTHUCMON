using System.ComponentModel.DataAnnotations;

namespace PTMNHDT.KetThucMon.Travel.Models
{
    public class Page
    {
        public int Id { get; set; }  // Khóa chính

        [Required]
        [StringLength(100)]
        public string Title { get; set; }  // Tiêu đề của trang

        [Required]
        [StringLength(100)]
        public string Slug { get; set; }  // Đường dẫn (slug) của trang
    }
}
