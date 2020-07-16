using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSamples
{
    public partial class _2169072_Create_a_text_delimited_string_of_content_and_display_separated_text_in_control_on_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["Data"] = "Text1|Text2|Text3"; //set initial data
                BindData();
            }
        }

        private void BindData()
        {
            rpt.DataSource = GetData();
            rpt.DataBind();
        }
        private List<string> GetData()
        {
            return Session["Data"].ToString().Split(new char[] { '|' }).ToList();
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            var data = GetData();
            data.Add(txtNewData.Text);
            Session["Data"] = string.Join("|", data);
            BindData();
        }
    }
}