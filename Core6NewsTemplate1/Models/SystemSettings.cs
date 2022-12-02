namespace WebOS.Models
{
    using System.ComponentModel.DataAnnotations;
    public class SystemSettings
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "يجب ان يكون عدد الحروف بين 5 و 50 حرف")]
        [Display(Name = "الاسم العربي")]
        public string AraName { get; set; }
       
        [StringLength(50, MinimumLength = 5, ErrorMessage = "يجب ان يكون عدد الحروف بين 5 و 50 حرف")]
        [Display(Name = "الهاتف")]
        public string Phone { get; set; }
       
        [StringLength(50, MinimumLength = 5, ErrorMessage = "يجب ان يكون عدد الحروف بين 5 و 50 حرف")]
        [Display(Name = "العنوان بالعربي")]
        public string Address { get; set; }
       
        [StringLength(50, MinimumLength = 5, ErrorMessage = "يجب ان يكون عدد الحروف بين 5 و 50 حرف")]
        [Display(Name = "Address")]
        public string EnAddress { get; set; }
       
        [StringLength(200,MinimumLength =20,ErrorMessage ="يجب ان يكون عدد الحروف بين 20 و 50 حرف")]
        [Display(Name = "الشعار النصي")]
        public string About { get; set; }
       
        [StringLength(5000,MinimumLength =20,ErrorMessage ="يجب ان يكون عدد الحروف بين 20 و 50 حرف")]
        [Display(Name = "نبذة تعريفية بالعربي")]
        public string LongAbout { get; set; }
       
        [StringLength(5000,MinimumLength =20,ErrorMessage ="يجب ان يكون عدد الحروف بين 20 و 50 حرف")]
        [Display(Name = "About")]
        public string EnLongAbout { get; set; }
       
        [StringLength(200,MinimumLength =20,ErrorMessage ="يجب ان يكون عدد الحروف بين 20 و 50 حرف")]
        [Display(Name = "Motto")]
        public string EnAbout { get; set; }
       
        [StringLength(200,MinimumLength =20,ErrorMessage ="يجب ان يكون عدد الحروف بين 20 و 50 حرف")]
        [Display(Name = "الرؤية")]
        public string Vision { get; set; }
       
        [StringLength(200,MinimumLength =20,ErrorMessage ="يجب ان يكون عدد الحروف بين 20 و 50 حرف")]
        [Display(Name = "Vision")]
        public string EnVision { get; set; }
       
        [StringLength(50)]
        [Display(Name = "Name")]
        public string EngName { get; set; }

        [StringLength(50)]
        [Display(Name = "الشعار")]
        public string SmallLogo { get; set; }

        [StringLength(50)]
        [Display(Name = "شعار كبير")]
        public string LargeLogo { get; set; }

        [StringLength(50)]
        [Display(Name = "favicon")]
        public string FavIcon { get; set; }

        [StringLength(50)]
        [Display(Name = "صورة التذييل السفلي")]
        public string Footer { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string AdminEmail { get; set; }

        [Display(Name = "تاريخ الانطلاق")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime LaunchDate { get; set; }

        [StringLength(50)]
        [Display(Name = "فيسبوك")]
        public string FB { get; set; }

        [StringLength(50)]
        [Display(Name = "تويتر")]
        public string Twitter { get; set; }

        [StringLength(50)]
        [Display(Name = "Linkedin")]
        public string Linkedin { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "يجب ان يكون عدد الحروف بين 5 و 50 حرف")]
        [Display(Name = "الكلمات المفتاحية")]
        public string Keywords { get; set; }

        [StringLength(50)]
        [Display(Name = "Youtube")]
        public string Youtube { get; set; }

        [StringLength(50)]
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }

        [Display(Name = "عدد المشاريع")]
        public int ProjectsNumber { get; set; }

        [Display(Name = "عدد الموظفين")]
        public int EmployeesNumber { get; set; }

        [Display(Name = "عدد المتطوعين")]
        public int VolunteersNumber { get; set; }

        [Display(Name = "عدد المستفيدين")]
        public int BeneficiariesNumber { get; set; }


        [Display(Name = "تاريخ اخر تعديل")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime LastUpate { get; set; }
    }
}
