namespace TecnicExam.Models
{
    public class PersonDTO
    {
        public string Name { get; set; } = string.Empty; 
        public string CPF { get; set; } = string.Empty; 
        public DateTime DateOfBirth { get; set; }
        public string active { get; set; } = string.Empty; 
        public string PhoneType { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
