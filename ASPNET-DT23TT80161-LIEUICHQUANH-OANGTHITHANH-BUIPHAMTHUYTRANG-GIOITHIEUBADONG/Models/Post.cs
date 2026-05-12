using System.ComponentModel.DataAnnotations;

namespace BaDongTourism.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tiêu đề bài viết")]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string? Summary { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung bài viết")]
        public string Content { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
