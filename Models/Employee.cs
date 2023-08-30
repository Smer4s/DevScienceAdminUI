namespace DevScienceAdminUI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Telegram { get; set; }
        public List<Technology> Technology { get; set; }
    }
}
