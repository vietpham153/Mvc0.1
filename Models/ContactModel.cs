using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class ContactModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} phai duoc nhap")]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Ho va ten")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="{0} phai duoc nhap")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="{0} khong hop le")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public DateTime? DateSent { get; set; }
        [Display(Name = "Bao cao")]
        public string? Message { get; set; }

        [StringLength(50)]
        [Phone(ErrorMessage ="{0} khong hop le")]
        [Display(Name = "So dien thoai")]
        public string? Phone { get; set; }
    }
}
