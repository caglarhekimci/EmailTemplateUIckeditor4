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
            var header = $@"<html xmlns=""http://www.w3.org/1999/xhtml""><head><meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
    <meta name=""googlebot"" content=""noindex"">
    
    <title>[Subject]</title>
    <link rel=""shortcut icon"" href=""favicon.ico"">
    
    <style type=""text/css"">
    table[name='blk_permission'], table[name='blk_footer'] {{display:none;}}
    </style>
    </head>

    <body topmargin=""0"" leftmargin=""0"" marginheight=""0"" marginleft=""0"" style=""height: 100% !important; margin: 0; padding: 0; width: 100% !important;min-width: 100%;"">     
        
        <link rel=""stylesheet"" href=""/style/dhtmlwindow.css"" type=""text/css"">
        <script type=""text/javascript"" src=""/script/dhtmlwindow.js"">
        /***********************************************
        * DHTML Window Widget- © Dynamic Drive (www.dynamicdrive.com)
        * This notice must stay intact for legal use.
        * Visit www.dynamicdrive.com for full source code
        ***********************************************/
        </script><div id=""dhtmlwindowholder""><span style=""display:none"">.</span></div>
        <link rel=""stylesheet"" href=""/style/modal.css"" type=""text/css"">
        <script type=""text/javascript"" src=""/script/modal.js""></script><div id=""interVeil""></div>
        <script type=""text/javascript"">
            function show_popup(popup_name,popup_url,popup_title,width,height)
            {{
                var widthpx = width +  ""px"";
                var heightpx = height +  ""px"";
                emailwindow = dhtmlmodal.open(popup_name , 'iframe', popup_url , popup_title , 'width=' + widthpx + ',height='+ heightpx + ',center=1,resize=0,scrolling=1')					
            }}
            
            function show_modal(popup_name,popup_url,popup_title,width,height)
            {{
                var widthpx = width +  ""px"";
                var heightpx = height +  ""px"";
                emailwindow = dhtmlmodal.open(popup_name , 'iframe', popup_url , popup_title , 'width=' + widthpx + ',height='+ heightpx + ',modal=1,center=1,resize=0,scrolling=1')			
                
            }}
            
            var popUpWin=0;
            function popUpWindow(URLStr,PopUpName, width, height)
            {{
                if(popUpWin) {{ if(!popUpWin.closed) popUpWin.close();}}
                var left = (screen.width - width) / 2;
                var top = (screen.height - height) / 2;
                popUpWin = open(URLStr, PopUpName,	'toolbar=0,location=0,directories=0,status=0,menub	ar=0,scrollbar=0,resizable=0,copyhistory=yes,width='+width+',height='+height+',left='+left+', 	top='+top+',screenX='+left+',screenY='+top+'');
            }}
            
            //onClick=""javascript:show_popup('id','htmlfile','title', w, h); return(false);""	
        </script>
            
            <form method=""post"" action=""/E9C066C"" id=""form1"">
        
        <div class=""aspNetHidden"">
        
            <input type=""hidden"" name=""__VIEWSTATEGENERATOR"" id=""__VIEWSTATEGENERATOR"" value=""0E221FC3"">
        </div>
                <div align=""center"">
                    
            
            
        <meta content=""width=device-width, initial-scale=1.0"" name=""viewport"">    
        <style type=""text/css"">    
        /*** BMEMBF Start ***/    
        /* CMS V4 Editor Test */    
        [name=bmeMainBody]{{min-height:1000px;}}    
        @media only screen and (max-width: 480px){{table.blk, table.tblText, .bmeHolder, .bmeHolder1, table.bmeMainColumn{{width:100% !important;}} }}        
        @media only screen and (max-width: 480px){{.bmeImageCard table.bmeCaptionTable td.tblCell{{padding:0px 20px 20px 20px !important;}} }}        
        @media only screen and (max-width: 480px){{.bmeImageCard table.bmeCaptionTable.bmeCaptionTableMobileTop td.tblCell{{padding:20px 20px 0 20px !important;}} }}        
        @media only screen and (max-width: 480px){{table.bmeCaptionTable td.tblCell{{padding:10px !important;}} }}        
        @media only screen and (max-width: 480px){{table.tblGtr{{ padding-bottom:20px !important;}} }}        
        @media only screen and (max-width: 480px){{td.blk_container, .blk_parent, .bmeLeftColumn, .bmeRightColumn, .bmeColumn1, .bmeColumn2, .bmeColumn3, .bmeBody{{display:table !important;max-width:600px !important;width:100% !important;}} }}        
        @media only screen and (max-width: 480px){{table.container-table, .bmeheadertext, .container-table {{ width: 95% !important; }} }}        
        @media only screen and (max-width: 480px){{.mobile-footer, .mobile-footer a{{ font-size: 13px !important; line-height: 18px !important; }} .mobile-footer{{ text-align: center !important; }} table.share-tbl {{ padding-bottom: 15px; width: 100% !important; }} table.share-tbl td {{ display: block !important; text-align: center !important; width: 100% !important; }} }}        
        @media only screen and (max-width: 480px){{td.bmeShareTD, td.bmeSocialTD{{width: 100% !important; }} }}        
        @media only screen and (max-width: 480px){{td.tdBoxedTextBorder{{width: auto !important;}} }}    
        @media only screen and (max-width: 480px){{th.tdBoxedTextBorder{{width: auto !important;}} }}    
            
        @media only screen and (max-width: 480px){{table.blk, table[name=tblText], .bmeHolder, .bmeHolder1, table[name=bmeMainColumn]{{width:100% !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeImageCard table.bmeCaptionTable td[name=tblCell]{{padding:0px 20px 20px 20px !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeImageCard table.bmeCaptionTable.bmeCaptionTableMobileTop td[name=tblCell]{{padding:20px 20px 0 20px !important;}} }}    
        @media only screen and (max-width: 480px){{table.bmeCaptionTable td[name=tblCell]{{padding:10px !important;}} }}    
        @media only screen and (max-width: 480px){{table[name=tblGtr]{{ padding-bottom:20px !important;}} }}    
        @media only screen and (max-width: 480px){{td.blk_container, .blk_parent, [name=bmeLeftColumn], [name=bmeRightColumn], [name=bmeColumn1], [name=bmeColumn2], [name=bmeColumn3], [name=bmeBody]{{display:table !important;max-width:600px !important;width:100% !important;}} }}    
        @media only screen and (max-width: 480px){{table[class=container-table], .bmeheadertext, .container-table {{ width: 95% !important; }} }}    
        @media only screen and (max-width: 480px){{.mobile-footer, .mobile-footer a{{ font-size: 13px !important; line-height: 18px !important; }} .mobile-footer{{ text-align: center !important; }} table[class=""share-tbl""] {{ padding-bottom: 15px; width: 100% !important; }} table[class=""share-tbl""] td {{ display: block !important; text-align: center !important; width: 100% !important; }} }}    
        @media only screen and (max-width: 480px){{td[name=bmeShareTD], td[name=bmeSocialTD]{{width: 100% !important; }} }}    
        @media only screen and (max-width: 480px){{td[name=tdBoxedTextBorder]{{width: auto !important;}} }}    
        @media only screen and (max-width: 480px){{th[name=tdBoxedTextBorder]{{width: auto !important;}} }}    
                       
        @media only screen and (max-width: 480px){{.bmeImageCard table.bmeImageTable{{height: auto !important; width:100% !important; padding:20px !important;clear:both; float:left !important; border-collapse: separate;}} }}                
        @media only screen and (max-width: 480px){{.bmeMblInline table.bmeImageTable{{height: auto !important; width:100% !important; padding:10px !important;clear:both;}} }}    
        @media only screen and (max-width: 480px){{.bmeMblInline table.bmeCaptionTable{{width:100% !important; clear:both;}} }}    
        @media only screen and (max-width: 480px){{table.bmeImageTable{{height: auto !important; width:100% !important; padding:10px !important;clear:both; }} }}    
        @media only screen and (max-width: 480px){{table.bmeCaptionTable{{width:100% !important;  clear:both;}} }}    
        @media only screen and (max-width: 480px){{table.bmeImageContainer{{width:100% !important; clear:both; float:left !important;}} }}                
        @media only screen and (max-width: 480px){{table.bmeImageTable td{{padding:0px !important; height: auto; }} }}                
        @media only screen and (max-width: 480px){{img.mobile-img-large{{width:100% !important; height:auto !important;}} }}    
        @media only screen and (max-width: 480px){{img.bmeRSSImage{{max-width:320px; height:auto !important;}} }}    
        @media only screen and (min-width: 640px){{img.bmeRSSImage{{max-width:600px !important; height:auto !important;}} }}                
        @media only screen and (max-width: 480px){{.trMargin img{{height:10px;}} }}              
        @media only screen and (max-width: 480px){{div.bmefooter, div.bmeheader{{ display:block !important;}} }}      
        @media only screen and (max-width: 480px){{.tdPart{{ width:100% !important; clear:both; float:left !important; }} }}    
        @media only screen and (max-width: 480px){{table.blk_parent1, table.tblPart {{width: 100% !important; }} }}                
        @media only screen and (max-width: 480px){{.tblLine{{min-width: 100% !important;}} }}                
        @media only screen and (max-width: 480px){{.bmeMblCenter img {{ margin: 0 auto; }} }}       
        @media only screen and (max-width: 480px){{.bmeMblCenter, .bmeMblCenter div, .bmeMblCenter span  {{ text-align: center !important; text-align: -webkit-center !important; }} }}    
        @media only screen and (max-width: 480px){{.bmeNoBr br, .bmeImageGutterRow, .bmeMblStackCenter .bmeShareItem .tdMblHide {{ display: none !important; }} }}    
        @media only screen and (max-width: 480px){{.bmeMblInline table.bmeImageTable, .bmeMblInline table.bmeCaptionTable, .bmeMblInline {{ clear: none !important; width:50% !important; }} }}    
        @media only screen and (max-width: 480px){{.bmeMblInlineHide, .bmeShareItem .trMargin {{ display: none !important; }} }}    
        @media only screen and (max-width: 480px){{.bmeMblInline table.bmeImageTable img, .bmeMblShareCenter.tblContainer.mblSocialContain, .bmeMblFollowCenter.tblContainer.mblSocialContain{{width: 100% !important; }} }}    
        @media only screen and (max-width: 480px){{.bmeMblStack> .bmeShareItem{{width: 100% !important; clear: both !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeShareItem{{padding-top: 10px !important;}} }}                
        @media only screen and (max-width: 480px){{.tdPart.bmeMblStackCenter, .bmeMblStackCenter .bmeFollowItemIcon {{padding:0px !important; text-align: center !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeMblStackCenter> .bmeShareItem{{width: 100% !important;}} }}    
        @media only screen and (max-width: 480px){{ td.bmeMblCenter {{border: 0 none transparent !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeLinkTable.tdPart td{{padding-left:0px !important; padding-right:0px !important; border:0px none transparent !important;padding-bottom:15px !important;height: auto !important;}} }}    
        @media only screen and (max-width: 480px){{.tdMblHide{{width:10px !important;}} }}                
        @media only screen and (max-width: 480px){{.bmeShareItemBtn{{display:table !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeMblStack td {{text-align: left !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeMblStack .bmeFollowItem{{clear:both !important; padding-top: 10px !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeMblStackCenter .bmeFollowItemText{{padding-left: 5px !important;}} }}    
        @media only screen and (max-width: 480px){{.bmeMblStackCenter .bmeFollowItem{{clear:both !important;align-self:center; float:none !important; padding-top:10px;margin: 0 auto;}} }}                
        @media only screen and (max-width: 480px){{    
        .tdPart> table{{width:100% !important;}}    
        }}    
        @media only screen and (max-width: 480px){{.tdPart>table.bmeLinkContainer{{ width:auto !important; }} }}    
        @media only screen and (max-width: 480px){{.tdPart.mblStackCenter>table.bmeLinkContainer{{ width:100% !important;}} }}     
        .blk_parent:first-child, .blk_parent{{float:left;}}                
        .blk_parent:last-child{{float:right;}}                
        </style>
        <table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" name=""bmeMainBody"" style=""background-color: #e6e6e8;"" bgcolor=""#e6e6e8""><tbody><tr>  <td width=""100%"" valign=""top"" align=""center"">    
        <table cellspacing=""0"" cellpadding=""0"" border=""0"" name=""bmeMainColumnParentTable""><tbody><tr><td name=""bmeMainColumnParent"" style=""border-collapse: separate;"">    
        <table name=""bmeMainColumn"" class=""bmeHolder bmeMainColumn"" style=""max-width: 600px; overflow: visible;"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""center"">  <tbody><tr id=""section_1"" class=""flexible-section"" data-columns=""1"" data-section-type=""bmePreHeader""><td width=""100%"" class=""blk_container bmeHolder"" name=""bmePreHeader"" valign=""top"" align=""center"" bgcolor=""#e6e6e8"" style=""background-color: rgb(230, 230, 232); color: rgb(102, 102, 102);   ""></td></tr><tr><td width=""100%"" class=""bmeHolder"" valign=""top"" align=""center"" name=""bmeMainContentParent"" style=""border-color: rgb(128, 128, 128); border-radius: 5px; border-collapse: separate; border-spacing: 0px;"">     
        <table name=""bmeMainContent"" style=""border-radius: 5px; border-collapse: separate;border-spacing: 0px; overflow: hidden;"" width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""center""><tbody><tr id=""section_2"" class=""flexible-section"" data-columns=""1""><td width=""100%"" class=""blk_container bmeHolder"" name=""bmeHeader"" valign=""top"" align=""center"" bgcolor=""#ffffff"" style=""background-color: rgb(255, 255, 255);   ""><div id=""dv_1"" class=""blk_wrapper"" style="""">    
        <table class=""blk"" name=""blk_image"" width=""600"" border=""0"" cellpadding=""0"" cellspacing=""0""><tbody><tr><td>    
        <table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0""><tbody><tr><td class=""bmeImage"" style=""padding: 20px; border-collapse: collapse;"" align=""center""><a href=""https://clt.benchmarkurl.com/c/l?u=E9C124D&amp;e=1548150&amp;c=170BE2&amp;t=0&amp;email=4o2zQqfLDzo6vPNdpl7EN2ri%2BZ%2B9qN7SlQCqSmrsXQ3ClviSQtnhpzqCs0UbU5Lc&amp;seq=1"" target=""_blank""><img src=""https://images.benchmarkemail.com/client1510370/image13110237.png"" width=""142"" style=""max-width: 142px; display: block; border-radius: 0px;"" alt="""" data-radius=""0"" border=""0"" data-original-max-width=""142""></a></td></tr></tbody>    
        </table></td></tr></tbody>    
        </table></div>
        </td></tr> <tr id=""section_5"" class=""flexible-section"" data-columns=""2"" data-columns-ratio=""70/30""><td width=""100%"">     
        <table width=""100%"" class=""bmeHolder"" cellspacing=""0"" cellpadding=""0"" border=""0"" align=""center""> <tbody><tr> <td width=""100%"" valign=""top"" name=""bmeBody"" align=""center"" bgcolor=""#ffffff"" style=""background-color: rgb(255, 255, 255); color: rgb(54, 56, 56); border-color: transparent; border-style: none; border-width: 0px;"">   <div>    
        <table class=""blk_parent1"" cellspacing=""0"" cellpadding=""0"" style=""max-width: 600px;"" width=""600"" align=""center""><tbody><tr><th valign=""top"" align=""center"" class=""tdPart"" width=""70%"">      
        <table cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" class=""blk_parent"" align=""left"" style=""float:left;""><tbody><tr><td valign=""top"" class=""blk_container bmeColumn1"" name=""bmeColumn1"" bgcolor="""" style=""color: rgb(54, 56, 56);   ""><div id=""dv_2"" class=""blk_wrapper"" style="""">    
        <table class=""blk"" name=""blk_text"" width=""420"" border=""0"" cellpadding=""0"" cellspacing=""0""><tbody><tr><td>    
        <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" class=""bmeContainerRow""><tbody><tr><th valign=""top"" align=""center"" class=""tdPart"">    
        <table name=""tblText"" style=""float:left;"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""tblText"" width=""420""><tbody><tr><td name=""tblCell"" style=""padding: 10px; font-size: 14px; font-weight: 400; font-family: Arial, Helvetica, sans-serif; color: rgb(56, 56, 56); text-align: left; word-break: break-word;"" align=""left"" valign=""top"" class=""tblCell""><div style=""line-height: 150%;""><span style=""font-size: 20px; line-height: 150%;""><strong>&nbsp; Dear [Caglar Hekimci],</strong></span></div></td></tr></tbody>    
        </table></th></tr></tbody>    
        </table></td></tr></tbody>    
        </table></div>
        
        <div id=""dv_4"" class=""blk_wrapper"" style="""">    
        <table class=""blk"" name=""blk_text"" width=""420"" border=""0"" cellpadding=""0"" cellspacing=""0""><tbody><tr><td>    
        <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" class=""bmeContainerRow""><tbody><tr><th valign=""top"" align=""center"" class=""tdPart"">    
        <table name=""tblText"" style=""float:left;"" align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""tblText"" width=""420""><tbody><tr><td name=""tblCell"" style=""padding: 10px 20px; font-size: 14px; font-weight: 400; font-family: Arial, Helvetica, sans-serif; color: rgb(56, 56, 56); text-align: left; word-break: break-word;"" align=""left"" valign=""top"" class=""tblCell""><div style=""line-height: 150%;"">
         ";
            var footer = $@"</td></tr></tbody>    
            </table></th></tr></tbody>    
            </table></div></td> </tr></tbody>    
            </table> </td></tr><tr id=""section_3"" class=""flexible-section"" data-columns=""1""><td width=""100%"" class=""blk_container bmeHolder"" name=""bmePreFooter"" valign=""top"" align=""center"" bgcolor=""#ffffff"" style=""background-color: rgb(255, 255, 255);   ""><div id=""dv_9"" class=""blk_wrapper"" style="""">    
            <table cellspacing=""0"" cellpadding=""0"" border=""0"" name=""blk_divider"" width=""600"" class=""blk""><tbody><tr><td style=""padding-top:10px; padding-bottom:10px;padding-left:20px;padding-right:20px;"" class=""tblCellMain"">    
            <table width=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" style=""border-top: 1px solid rgb(225, 225, 225); min-width: 1px;"" class=""tblLine""><tbody><tr><td><span></span></td></tr></tbody>    
            </table></td></tr></tbody>    
            </table></div>
            
            </td></tr> </tbody>    
            </table></td></tr><tr id=""section_4"" class=""flexible-section"" data-columns=""1"" data-section-type=""bmeFooter""><td width=""100%"" class=""blk_container bmeHolder"" name=""bmeFooter"" valign=""top"" align=""center"" bgcolor=""#e6e6e8"" style=""background-color: rgb(230, 230, 232); color: rgb(102, 102, 102);   ""><div id=""dv_7"" class=""blk_wrapper"" style="""">    
            <table width=""600"" cellspacing=""0"" cellpadding=""0"" border=""0"" class=""blk"" name=""blk_text""><tbody><tr><td>    
            <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" class=""bmeContainerRow""><tbody><tr><th class=""tdPart"" valign=""top"" align=""center"">    
            <table cellspacing=""0"" cellpadding=""0"" border=""0"" width=""600"" name=""tblText"" class=""tblText"" style=""float:left; background-color:transparent;"" align=""left""><tbody><tr><td valign=""top"" align=""left"" name=""tblCell"" class=""tblCell"" style=""padding: 10px 20px; font-family: Arial, Helvetica, sans-serif; font-size: 14px; font-weight: 400; color: rgb(56, 56, 56); text-align: left; word-break: break-word;""><div style=""line-height: 150%;"">
                
            <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
            <tbody>
            <tr>
            <td align=""left""><span style=""font-size: 12px; line-height: 150%;""><a href=""https://clt.benchmarkurl.com/c/l?u=E9C0CE1&amp;e=1548150&amp;c=170BE2&amp;t=0&amp;email=4o2zQqfLDzo6vPNdpl7EN2ri%2BZ%2B9qN7SlQCqSmrsXQ3ClviSQtnhpzqCs0UbU5Lc&amp;seq=1"" target=""_blank"">View this email in your browser</a>    
            <br>You are receiving this email because of your relationship with Redmill Solutions. This message was sent to <strong>[caglarhekimci@gmail.com]</strong> by <strong>[gathererservice@redmillsolutions.com]</strong></span></td>
            </tr>
            </tbody>
                
            </table>
            </div></td></tr></tbody>    
            </table></th></tr></tbody>    
            </table></td></tr></tbody>    
            </table></div><div id=""dv_8"" class=""blk_wrapper"" style="""">    
            <table width=""600"" cellspacing=""0"" cellpadding=""0"" border=""0"" class=""blk"" name=""blk_text""><tbody><tr><td>    
            <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" class=""bmeContainerRow""><tbody><tr><th class=""tdPart"" valign=""top"" align=""center"">    
            <table cellspacing=""0"" cellpadding=""0"" border=""0"" width=""600"" name=""tblText"" class=""tblText"" style=""float:left; background-color:transparent;"" align=""left""><tbody><tr><td valign=""top"" align=""left"" name=""tblCell"" class=""tblCell"" style=""padding: 0px 20px; font-family: Arial, Helvetica, sans-serif; font-size: 14px; font-weight: 400; color: rgb(56, 56, 56); text-align: left; word-break: break-word;""><div style=""line-height: 150%;"">
            <p style=""margin-top: 0px; margin-bottom: 0px;""><span style=""font-size: 11px; line-height: 150%;""><u>Statement of Confidentiality</u></span></p>
            <p style=""margin-top: 0px; margin-bottom: 0px;""><span style=""font-size: 11px; line-height: 150%;"">This email and attachments may contain information that is confidential, legally privileged or otherwise protected &nbsp;from disclosure. This transmission is sent in trust, for the sole purpose of delivery to the intended recipient. If you have received this email in error, you are not entitled to copy, disclose, distribute, print, or rely on this email in any way. If you are not the intended recipient, please immediately notify the sender by reply e-mail&nbsp;or phone&nbsp;and&nbsp;delete this email and its attachments (if any) from your system. Redmill Solutions Limited is a private limited company, registered in England and Wales, with the registration number 07193163 and its registered office located at &nbsp;</span></p>
            <p style=""margin-top: 0px; margin-bottom: 0px;""><span style=""font-size: 11px; line-height: 150%;"">Calleo House, 49 Theobald Street, Borehamwood, WD6 4RT.</span></p>
            <p style=""margin-top: 0px; margin-bottom: 0px;"">&nbsp;</p>
            <p style=""margin-top: 0px; margin-bottom: 0px;"">&nbsp;</p>
            </div></td></tr></tbody>    
            </table></th></tr></tbody>    
            </table></td></tr></tbody>    
            </table></div><div id=""dv_10"" class=""blk_wrapper"" style="""">     
            <table width=""600"" cellspacing=""0"" cellpadding=""0"" border=""0"" class=""blk"" name=""blk_footer"" style=""""><tbody><tr><td name=""tblCell"" class=""tblCell"" style=""padding: 20px; word-break: break-word;"" valign=""top"" align=""left"">    
            <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%""><tbody><tr><td name=""bmeBadgeText"" style=""text-align:left; word-break: break-word;"" align=""left""><span id=""spnFooterText"" style=""font-family: Arial, Helvetica, sans-serif; font-weight: normal; font-size: 11px; line-height: 140%;"">    
            <br> 
            
            
            
            
            </span>    
            <br>    
            <br><span style=""font-family: Arial, Helvetica, sans-serif; font-weight: normal; font-size: 11px; line-height: 140%;""><a href=""https://clt.benchmarkurl.com/c/su?e=1548150&amp;c=170BE2&amp;email=4o2zQqfLDzo6vPNdpl7EN2ri%2BZ%2B9qN7SlQCqSmrsXQ3ClviSQtnhpzqCs0UbU5Lc&amp;relid="" style=""color:inherit;text-decoration:underline;"">Update Profile/Email Address</a>     
            <br></span></td></tr><tr><td name=""bmeBadgeImage"" style=""text-align: left; padding-top: 20px; word-break: break-word;"" align=""left""><a href=""https://www.benchmarkemail.com?p=500289"" target=""""><img src=""https://www.benchmarkemail.com/images/web4/misc/emailfooter/opt9.png"" border=""0""></a></td></tr></tbody>    
            </table></td></tr></tbody>    
            </table></div></td></tr> </tbody>    
            </table> </td></tr></tbody>    
            </table></td></tr></tbody>    
            </table>    
                
                    
                    </div>
                </form>
                
            
            <div id=""highlighter--hover-tools"" style=""display: none;"">
                <div id=""highlighter--hover-tools--container"">
                    <div class=""highlighter--icon highlighter--icon-copy"" title=""Copy""></div>
                    <div class=""highlighter--icon highlighter--icon-change-color"" title=""Change Color""></div>
                    <div class=""highlighter--icon highlighter--icon-delete"" title=""Delete""></div>
                </div>
            </div></body></html>";
            try
            {
                sqlCon.Open();
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
