<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

namespace phanthanhkhai_2122110374_b2.Model
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        public string Product_Name { get; set; }

        // Thêm Cat_Id làm khóa ngoại
        public int Cat_Id { get; set; }

        public string Image { get; set; }

        public int Price { get; set; }

        public DateTime Create_at { get; set; }

        public DateTime? Update_at { get; set; }

        public DateTime? Delete_at { get; set; }

        // Liên kết với Category thông qua khóa ngoại Cat_Id
        public Category Category { get; set; }
=======
﻿namespace phanthanhkhai_2122110374_b2.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }

>>>>>>> a1f9e34a94f441d7bab6de9059b0ebd972d3cb80
    }
}
