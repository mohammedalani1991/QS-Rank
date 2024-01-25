namespace WebOS.Models
{
    public class RankViewModel
    {
        public Department Department { get; set; }
        public IEnumerable<DepartmentRank> DepartmentRanks  { get; set; }
        public IEnumerable<Department> Departments  { get; set; }
    }
}
