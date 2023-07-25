namespace Web2Lab7.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Employee>? Employee { get; set; }
    }
}
