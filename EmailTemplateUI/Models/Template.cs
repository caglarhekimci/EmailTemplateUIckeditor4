using System;
using System.Collections.Generic;

namespace EmailTemplateUI.Models
{
    public partial class Template
    {
        public int Id { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public string EmailHtml { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? ErrorMessage { get; set; }
        public string? PreviewTemplate { get; set; }
    }
}
