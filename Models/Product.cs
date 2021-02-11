using System.ComponentModel.DataAnnotations;

namespace WebGraduationProject.Models
{
    public class Product
    {
        [Key]
        public int productID { get; set; }

        [Required]
        public string productName { get; set; }

        [Required]
        public string productShortDescription { get; set; }

        [Required]
        public string productDetailedDescription { get; set; }

        // Leave that for now
        //public string productPhotoPath { get; set; }
    }
}