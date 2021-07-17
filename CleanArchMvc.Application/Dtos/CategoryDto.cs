using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
