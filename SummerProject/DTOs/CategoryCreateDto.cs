namespace SummerProject.DTOs
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int[] BookIds { get; set; } = Array.Empty<int>();
    }
}
