namespace TecnicExam.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public string? PhoneType { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
    }
}