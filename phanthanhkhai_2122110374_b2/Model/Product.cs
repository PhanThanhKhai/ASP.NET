using System.ComponentModel.DataAnnotations;

namespace phanthanhkhai_2122110374_b2.Model
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public DateTime Create_at { get; set; }
        public DateTime? Update_at { get; set; }
        public DateTime? Delete_at { get; set; }
    }
}
