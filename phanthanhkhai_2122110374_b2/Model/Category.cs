using System.ComponentModel.DataAnnotations;

namespace phanthanhkhai_2122110374_b2.Model
{
    public class Category
    {
        [Key]
        public int Cat_Id { get; set; }
        public string Cat_Name { get; set; }
        public string Image { get; set; }
    }
}
