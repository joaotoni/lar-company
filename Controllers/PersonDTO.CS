namespace TecnicExam.Models
{
    public class PersonDTO
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public string? PhoneType { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
