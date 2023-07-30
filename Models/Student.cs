using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FirstWebMVC.Models;

namespace FirstwebMVC.Models
{
    [Table("Student")]
    public class Student 
    {
        [Key]
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string FacultyID { get; set; }
        [ForeignKey("FacultyID")]
        public Faculty? Faculty { get; set; }
    }
}