namespace DevScienceAdminUI.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Employee>? EmployeeId { get; set; }
        public List<Employee>? RequestId { get; set; }
        public List<Technology> Technology { get; set; }
    }
}
