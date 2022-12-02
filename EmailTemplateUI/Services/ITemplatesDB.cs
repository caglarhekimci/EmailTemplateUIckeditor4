using EmailTemplateUI.Models;

namespace EmailTemplateUI.Services
{
    public interface ITemplatesDB
    {
        public Template Get(int id);
        public string Save(Template newHtml, int id);
    }
}
