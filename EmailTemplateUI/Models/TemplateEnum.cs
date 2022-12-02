using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmailTemplateUI.Models
{
    public enum TemplateEnum
    {
        [Display(Name = "Select a template")]
        Select_a_template = 0,
        [Display(Name = "Error No Attachment")]
        Error_No_Attachment = 1,
        [Display(Name = "Error Invalid Token")]
        Error_Invalid_Token = 2,
        [Display(Name = "Succeeded Default")]
        Succeeded_Default = 3
    }
}
