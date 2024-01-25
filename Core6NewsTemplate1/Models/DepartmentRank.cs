using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WebOS.Models
{
    public class DepartmentRank
    {
        [Key]
        public int Id { get; set; }
        [Range(0,100, ErrorMessage = "الرقم يجب ان يكون بين 100 و صفر")]
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        [Display(Name ="السمعة الاكاديمية من 100")]
        public int AcademicReputation { get; set; }

        [Range(0, 100, ErrorMessage = "الرقم يجب ان يكون بين 100 و صفر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "سمعة صاحب العمل من 100")]
        public int EmployerReputation { get; set; }

        [Range(0, 100, ErrorMessage = "الرقم يجب ان يكون بين 100 و صفر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الاستشهادات لكل كلية من 100")]
        public int Citations { get; set; }

        [Range(0, 100, ErrorMessage = "الرقم يجب ان يكون بين 100 و صفر")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "نسبة الطلاب الدوليين من 100")]
        public int InternationalStudentRatio { get; set; }

        [Display(Name = "القسم")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
