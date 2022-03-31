using System.ComponentModel.DataAnnotations;

namespace BookStore.Services.Dto.Book
{
    public class UpdateDto
    {
        [Required(ErrorMessage = "El id es obligatorio.")]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "La categoria es obligatoria.")]
        public string? CategoryId { get; set; }

        [Required(ErrorMessage = "EL nombre es obligatorio.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "EL ISBN es obligatorio.")]
        public string? Isbn { get; set; }

        public string? Author { get; set; }
    }
}
