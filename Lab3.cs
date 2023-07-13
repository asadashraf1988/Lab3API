using System.ComponentModel.DataAnnotations;

namespace Lab3API
{
    public class Lab3
    {
        [Key]
        public int studentId { get; set; }
        public string name { get; set; } = string.Empty;
        public Lab3(){ }
    }
}
