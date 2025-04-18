using System.ComponentModel.DataAnnotations;

namespace phanthanhkhai_2122110374_b2.DTO
{
    public class OrderDetailDTO
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }  // Khóa ngoại liên kết với Order
        public int ProductId { get; set; } // Khóa ngoại liên kết với Product

        public int Quantity { get; set; }  // Số lượng sản phẩm trong đơn hàng
        public decimal Price { get; set; } // Giá của sản phẩm trong đơn hàng
    }
}
