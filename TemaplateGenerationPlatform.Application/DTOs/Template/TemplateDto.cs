namespace TemaplateGenerationPlatform.Application.DTOs.Template
{
    public class TemplateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string HtmlContent { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
