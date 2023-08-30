namespace DevScienceAdminUI.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int>? EmployeeId { get; set; }
        public List<int>? RequestId { get; set; }
        public List<Technology> Technology { get; set;}
    }
    public enum Technology
    {
        NodeJs,
        DotNet,
        Python,
        PHP,
        Java,
        Go,
        SQL,
        Ruby,
        React,
        Angular,
        Vue,
        Swift,
        ReactNative,
        AWS,
        Azure,
        GoogleCloud,
        MathLab,
        Shopify,
        Unity,
        Kotlin
    }
}
