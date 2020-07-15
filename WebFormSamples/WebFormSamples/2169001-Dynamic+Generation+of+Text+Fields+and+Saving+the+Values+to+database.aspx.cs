using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSamples
{
    public partial class _2169001_Dynamic_Generation_of_Text_Fields_and_Saving_the_Values_to_database : System.Web.UI.Page
    {
        class PertnerData
        {
            public string PName { get; set; }
            public string PEmail { get; set; }
            public string PDesignation { get; set; }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Page.IsPostBack) {
                GenerateControls();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void GenerateControls()
        {
            int numberOfControls = Convert.ToInt32(Session["ControlGenerated"]);
            
            for (int i = 0; i < numberOfControls; i++)
            {
                AddLabel($"Name {i}");
                AddTextBox($"txtPName{i}");
                AddLabel($"Email {i}");
                AddTextBox($"txtPEmail{i}");
                AddLabel($"Designation {i}");
                AddTextBox($"txtPDesignation{i}");
                container.Controls.Add(new LiteralControl("<br />"));
            }
        }
        protected void btnGenerateControls_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            Session["ControlGenerated"] = Convert.ToInt32(txtNimberOfGroup.Text);
            GenerateControls();
        }

        private void AddLabel(string label)
        {
            Label lbl = new Label();
            lbl.Text = label;
            container.Controls.Add(lbl);
        }
        private void AddTextBox(string id)
        {
            TextBox box = new TextBox();
            box.ID = id;
            container.Controls.Add(box);
        }

        protected void btnGetValues_Click(object sender, EventArgs e)
        {
            int numberOfControls = Convert.ToInt32(txtNimberOfGroup.Text);

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