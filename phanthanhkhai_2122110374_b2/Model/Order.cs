using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace phanthanhkhai_2122110374_b2.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        // FK to User
        public int UserId { get; set; }

        // Mối quan hệ nhiều-một với User
        [ForeignKey("UserId")]
        public User User { get; set; }
        public OrderDetail Detail { get; set; }
    }
}
