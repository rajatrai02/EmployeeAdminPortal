namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }  // "required" is added to act as a mandatory field
        public required string Email { get; set; }  
        public  string? Phone { get; set; } // questionmark is added after the string is to accept either phone as a string value or can also have NULL values
        public string Salary { get; set; }  // optional field 
    }
}
