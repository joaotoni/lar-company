namespace TecnicExam.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty; 
        public double Price { get; set; } 
        public int CategoryId { get; set; } 
    }
}
