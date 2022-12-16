using EmailTemplateUI.Models;

namespace EmailTemplateUI.Services
{
    public class TemplatesDB : ITemplatesDB
    {
        private readonly EmailTemplatesContext _context;
        public TemplatesDB(EmailTemplatesContext context)
        {
            _context = context;
        }
        public Template Get(int id)
        {
            // TODO : CLEAN YOUR HTML CODES !
            var header = TemplateResource.TemplateHeaderAndFooter.templateHeader;
            var footer = TemplateResource.TemplateHeaderAndFooter.templateFooter;

            Template _template = _context.Templates.FirstOrDefault(x => x.Id == id) ?? 
                                 new Template() { ErrorMessage = "template not found " };

            if (_template.EmailHtml != null)
            {
                _template.PreviewTemplate = header + _template.EmailHtml + footer;
            }
            return _template;
        }
        public Template Save(Template newHtml, int id)
        {
            Template _template = _context.Templates.FirstOrDefault(x => x.Id == id) ??
                     new Template() { ErrorMessage = "template not found " };
            if (_template.EmailHtml != null)
            {
                _template.EmailHtml = newHtml.EmailHtml;
                _context.SaveChanges();
            }
            return _template;
        }
    }
}
