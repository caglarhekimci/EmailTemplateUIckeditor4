using EmailTemplateUI.Models;
using EmailTemplateUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace EmailTemplateUI.Controllers
{
    public class TemplateController : Controller
    {
        public static Template _template;
        private readonly ITemplatesDB _dbContext;
        public TemplateController(ITemplatesDB dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Get(int id)
        {
            try
            {
                _template = _dbContext.Get(id);
            }
            catch (Exception Ex)
            {

                _template.ErrorMessage = Ex.Message;
            }
            ViewData["templateInfo"] = _template;
            return Json(_template);
        }

        [HttpPost]
        public IActionResult Save(Template newHtml, int id)
        {
            try
            {
                _template.ErrorMessage = _dbContext.Save(newHtml, id);
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