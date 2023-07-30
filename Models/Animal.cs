using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstwebMVC.Models
{
    [Table("Animal")]
    public class Animal 
    {
        [Key]
        public string AnimalID { get; set; }
        public string AnimalName { get; set; }
        public double AnimalWeight { get; set; }
        public double AnimalHeight { get; set; }
    }
}