using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Blog
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Danh mục cha")]
        public int? ParentId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(100, ErrorMessage = "{0} phải dài hơn {2} ký tự và không được vượt quá {1} ký tự",MinimumLength =3)]
        [DisplayName("Tên danh mục")]
        public string Title { get; set; }
        [DataType(DataType.Text)]
        [DisplayName("Mô tả")]
        public string Content { get; set; }
        [Required(ErrorMessage ="Phải tạo URL")]
        [StringLength(100, ErrorMessage = "{0} phải dài hơn {2} ký tự và không được vượt quá {1} ký tự", MinimumLength = 3)]
        [DisplayName("Url hiển thị")]
        [RegularExpression(@"^[a-z0-9-]*$", ErrorMessage = "{0} chỉ được dùng các chữ cái thường, chữ số và dấu \"-\" ")]
        public string Slug { get; set; }
        public ICollection<Category> CategoryChildren { get; set; }
        [ForeignKey("ParentId")]
        [DisplayName("Danh mục cha")]
        public Category ParentCategory { get; set; }
    }
}
