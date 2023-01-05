using System.ComponentModel.DataAnnotations;

namespace floristWebApi.Dtos
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
    }
}
