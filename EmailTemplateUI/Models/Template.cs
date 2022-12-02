using System;
using System.Collections.Generic;

namespace EmailTemplateUI.Models
{
    public partial class Template
    {
        public int Id { get; set; } = 1;
        public string TemplateName { get; set; } = null!;
        public string EmailHtml { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? ErrorMessage { get; set; }
        public string PreviewTemplate { get; set; }
        public TemplateEnum TemplateNamesEnum { get; set; }
    }
}
