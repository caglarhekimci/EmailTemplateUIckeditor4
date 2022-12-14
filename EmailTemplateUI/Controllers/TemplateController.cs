using EmailTemplateUI.Models;
using EmailTemplateUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailTemplateUI.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplatesDB _templateService;
        private readonly EmailTemplatesContext _context;
        public TemplateController(ITemplatesDB templateService, EmailTemplatesContext context)
        {
            _templateService = templateService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Get(int id)
        {
            Template _template = _context.Templates.FirstOrDefault(x => x.Id == id) ?? 
                                 new Template() { ErrorMessage = "template not found " };

            ViewData["templateInfo"] = _template;
            return Json(_template);
        }

        [HttpPost]
        public IActionResult Save(Template newHtml, int id)
        {
            Template _template = new Template();
            try
            {
                _template.ErrorMessage = _templateService.Save(newHtml, id);
            }
            catch (Exception Ex)
            {

                _template.ErrorMessage = "Another Error : " + Ex.Message;
            }
            ViewData["templateInfo"] = _template;
            return Json(_template);
        }
    }
}