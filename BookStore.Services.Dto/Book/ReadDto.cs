namespace BookStore.Services.Dto.Book
{
    public class ReadDto
    {
        public string Id { get; set; } = null!;
        public string? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Isbn { get; set; }
        public string? Author { get; set; }
        public string? PathImage { get; set; }
    }
}
