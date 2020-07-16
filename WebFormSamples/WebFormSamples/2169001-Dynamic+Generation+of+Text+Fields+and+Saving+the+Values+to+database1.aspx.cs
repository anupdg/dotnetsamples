using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSamples
{
    public partial class _2169001_Dynamic_Generation_of_Text_Fields_and_Saving_the_Values_to_database1 : System.Web.UI.Page
    {
        class PertnerData
        {
            public string PName { get; set; }
            public string PEmail { get; set; }
            public string PDesignation { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void AddLabel(string label, Panel p)
        {
            Label lbl = new Label();
            lbl.Text = label;
            p.Controls.Add(lbl);
        }
        private void AddTextBox(string id, Panel p)
        {
            TextBox box = new TextBox();
            box.ID = id;
            p.Controls.Add(box);
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                GenerateControls();
            }
        }

        private void GenerateControls()
        {
            int numberOfControls = Convert.ToInt32(Session["ControlGenerated"]);
            container.Controls.Clear();
            for (int i = 0; i < numberOfControls; i++)
            {
                Panel p = new Panel();
                p.Style.Add("border", "solid 1px blue");
                p.Style.Add("margin", "5px");
                container.Controls.Add(p);

                AddLabel($"Name {i}", p);
                AddTextBox($"txtPName{i}", p);
                AddLabel($"Email {i}", p);
                AddTextBox($"txtPEmail{i}", p);
                AddLabel($"Designation {i}", p);
                AddTextBox($"txtPDesignation{i}", p);
                container.Controls.Add(new LiteralControl("<br />"));
            }

        }
        protected void btnAddAnother_Click(object sender, EventArgs e)
        {
            int numberOfControls = Convert.ToInt32(Session["ControlGenerated"]);
            numberOfControls++;
            Session["ControlGenerated"] = numberOfControls;
            GenerateControls();
        }

        protected void btnGetValues_Click(object sender, EventArgs e)
        {
            int numberOfControls = Convert.ToInt32(Session["ControlGenerated"]);

            List<PertnerData> data = new List<PertnerData>();

            PertnerData pd;
            for (int i = 0; i < numberOfControls; i++)
            {
                pd = new PertnerData();
                pd.PName = GetValue($"txtPName{i}");
                pd.PEmail = GetValue($"txtPEmail{i}");
                pd.PDesignation = GetValue($"txtPDesignation{i}");
                data.Add(pd);
            }
        }
        string GetValue(string id)
        {
            return ((TextBox)container.FindControl(id)).Text;
        }
    }
}