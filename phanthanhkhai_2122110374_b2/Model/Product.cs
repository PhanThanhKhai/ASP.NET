<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

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
=======
﻿namespace phanthanhkhai_2122110374_b2.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }

>>>>>>> d39b22ae12239411158412d3a5fbfc8c635d7abf
    }
}
