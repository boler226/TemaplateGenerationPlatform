namespace TemaplateGenerationPlatform.Domain.Entity
{
    public class TemplateEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string HtmlContent { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
