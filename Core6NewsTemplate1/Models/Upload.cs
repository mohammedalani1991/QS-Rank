using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static WebOS.Models.Common;

namespace WebOS.Models
{
    public class Upload
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل ضروري")]
        [Display(Name = "الملف")]
        [StringLength(100, ErrorMessage = "MinMaxTextFieldError", MinimumLength = 0)]
        public string FileName { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "اسم ووصف الملف")]
        public string NameDescription { get; set; }

        [Display(Name = "الباحث")]
        [StringLength(450)]
        public string ApplicationUserId { get; set; }
        [Display(Name = "الباحث")]
        public ApplicationUser ApplicationUser { get; set; }


        [Display(Name = "تاريخ الرفع")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "مجلد التخزين")]
        public FolderDestination FolderDestination { get; set; } //1 holding balance, 2 = current balance
    }
}
