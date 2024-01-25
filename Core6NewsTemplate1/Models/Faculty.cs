using System.ComponentModel.DataAnnotations;

namespace WebOS.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "اسم الكلية بالعربي")]
        public string ArFacultyName { get; set; }

        [StringLength(100)]
        [Display(Name = "اسم الكلية بالانجليزي")]
        public string EnFacultyName { get; set; }


        [Display(Name = "الجامعة")]
        public int UniversityId { get; set; }
        public University University { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

    }
}
