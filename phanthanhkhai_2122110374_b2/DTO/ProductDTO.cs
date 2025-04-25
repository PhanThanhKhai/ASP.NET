using System.ComponentModel.DataAnnotations;

namespace phanthanhkhai_2122110374_b2.DTO
{
    public class ProductDTO
    {
        [Key]
        public int Product_Id { get; set; }

        public string Product_Name { get; set; }

        // Thêm Cat_Id làm khóa ngoại
        public int Cat_Id { get; set; }

        public string Image { get; set; }
<<<<<<< HEAD
        public string Description { get; set; }
=======
>>>>>>> 089519067c6c5c95a653b64ae86d63b6c8803143

        public int Price { get; set; }

        public DateTime Create_at { get; set; }

        public DateTime? Update_at { get; set; }

        public DateTime? Delete_at { get; set; }
    }
}
