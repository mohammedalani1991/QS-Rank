using System.ComponentModel.DataAnnotations;

namespace WebOS.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "اسم القسم بالعربي")]
        public string ArFacultyName { get; set; }

        [StringLength(100)]
        [Display(Name = "اسم القسم بالانجليزي")]
        public string EnFacultyName { get; set; }

        [Display(Name = "تمنح دراسات عليا؟")]
        public bool HasPostGraduation { get; set; }

        [Display(Name = "الجامعة")]
        public int FacultyId { get; set; }
        [Display(Name = "الجامعة")]
        public Faculty Faculty { get; set; }
        
        [Display(Name = "المدينة")]
        public int CityId { get; set; }
        [Display(Name = "المدينة")]
        public City City { get; set; }

    }
}
