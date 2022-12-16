using EmailTemplateUI.Models;

namespace EmailTemplateUI.Services
{
    public interface ITemplatesDB
    {
        public Template Get(int id);
        public Template Save(Template newHtml, int id);
    }
}
