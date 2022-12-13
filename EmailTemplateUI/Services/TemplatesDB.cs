using EmailTemplateUI.Models;
using Microsoft.Data.SqlClient;
using System.Net;

namespace EmailTemplateUI.Services
{
    public class TemplatesDB : ITemplatesDB
    {
        // TODO : CARRY TO APPSETTINGS

        SqlConnection sqlCon = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmailTemplates;Integrated Security=True");
        SqlCommand sqlCom = null;
        Template _template = new Template();

        public Template Get(int id)
        {
            // TODO : CLEAN YOUR HTML CODES !

            var header = TemplateResource.TemplateHeaderAndFooter.templateHeader;
            var footer = TemplateResource.TemplateHeaderAndFooter.templateFooter;

            try
            {
                sqlCon.Open();
                // TODO : REACH SQL WITH DIFFERENT WAY
                string sql = "SELECT * FROM dbo.templates WHERE id = " + id;
                sqlCom = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    _template.Id = Convert.ToInt32(reader["id"]);
                    _template.TemplateName = WebUtility.HtmlDecode(reader["templateName"].ToString());
                    _template.EmailHtml = WebUtility.HtmlDecode(reader["emailHTML"].ToString());
                    _template.ErrorMessage = WebUtility.HtmlDecode(reader["message"].ToString());
                    _template.CreatedAt = Convert.ToDateTime(reader["created_at"].ToString());
                    _template.PreviewTemplate = WebUtility.HtmlDecode(reader["previewTemplate"].ToString());
                }

                if (_template.EmailHtml != null)
                {
                    _template.PreviewTemplate = header + _template.EmailHtml + footer;
                }
            }
            catch (Exception Ex)
            {
                _template.ErrorMessage = Ex.Message;
            }
            finally
            {
                sqlCom.Dispose();
                sqlCon.Close();
            }
            return _template;
        }

        public string Save(Template newHtml, int id)
        {
            try
            {
                sqlCon.Open();
                string sql = "UPDATE dbo.templates SET emailHTML = '" + newHtml?.EmailHtml + "' WHERE id = " + id;
                sqlCom = new SqlCommand(sql, sqlCon);
                sqlCom.ExecuteReader();
            }
            catch (Exception Ex)
            {
                _template.ErrorMessage = Ex.Message;
                return "SQL Connection Error : " + _template.ErrorMessage;
            }
            finally
            {
                sqlCom.Dispose();
                sqlCon.Close();
            }
            return "Saved !";
        }
    }
}
