using ASPNET_DT23TT80161_LIEUICHQUANH_OANGTHITHANH_BUIPHAMTHUYTRANG_GIOITHIEUBADONG.Models;
using System.ComponentModel.DataAnnotations;

namespace BaDongTourism.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public ICollection<Post>? Posts { get; set; }
    }
}
