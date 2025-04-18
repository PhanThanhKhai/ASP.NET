using AutoMapper;
using phanthanhkhai_2122110374_b2.DTO;
using phanthanhkhai_2122110374_b2.Model;

namespace phanthanhkhai_2122110374_b2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Ánh xạ từ ProductDTO sang Product
            CreateMap<ProductDTO, Product>();

            // Ánh xạ từ Product sang ProductDTO
            CreateMap<Product, ProductDTO>();

            // Ánh xạ từ OrderDTO sang Order
            CreateMap<OrderDTO, Order>();

            // Ánh xạ từ Order sang OrderDTO
            CreateMap<Order, OrderDTO>();

            // Ánh xạ từ UserDTO sang User
            CreateMap<UserDTO, User>();

            // Ánh xạ từ User sang UserDTO
            CreateMap<User, UserDTO>();

            // Ánh xạ từ OrderDetailDTO sang OrderDetail
            CreateMap<OrderDetailDTO, OrderDetail>();

            // Ánh xạ từ OrderDetail sang OrderDetailDTO
            CreateMap<OrderDetail, OrderDetailDTO>();
        }
    }
}
