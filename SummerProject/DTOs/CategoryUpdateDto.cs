namespace SummerProject.DTOs
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int[] BookIds { get; set; } = Array.Empty<int>();
    }
}
