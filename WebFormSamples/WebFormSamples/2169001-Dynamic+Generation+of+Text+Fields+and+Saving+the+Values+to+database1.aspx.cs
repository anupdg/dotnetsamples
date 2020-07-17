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
            if (!IsPostBack) {
                Session["ControlGenerated"] = new Dictionary<int, PertnerData> { { 1, new PertnerData() } };
                GenerateControls();
            }
        }
        private void AddLabel(string label, Panel p)
        {
            Label lbl = new Label();
            lbl.Text = label;
            p.Controls.Add(lbl);
        }
        private void AddTextBox(string id, Panel p, string data)
        {
            TextBox box = new TextBox();
            box.ID = id;
            box.Text = data;
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
            Dictionary<int, PertnerData> numberOfControls = (Dictionary<int, PertnerData>)Session["ControlGenerated"];
            container.Controls.Clear();
            foreach (var i in numberOfControls)
            {
                Panel p = new Panel();
                p.ID = $"container{i.Key}";
                p.Style.Add("border", "solid 1px blue");
                p.Style.Add("margin", "5px");
                container.Controls.Add(p);

                AddLabel($"Name {i.Key}", p);
                AddTextBox($"txtPName{i.Key}", p, i.Value.PName);
                AddLabel($"Email {i.Key}", p);
                AddTextBox($"txtPEmail{i.Key}", p, i.Value.PEmail);
                AddLabel($"Designation {i.Key}", p);
                AddTextBox($"txtPDesignation{i.Key}", p, i.Value.PDesignation);
                AddDeleteButton(i.Key, p);
                container.Controls.Add(new LiteralControl("<br />"));
            }
        }

        private void AddDeleteButton(int id, Panel p)
        {
            LinkButton button = new LinkButton();
            button.ID = $"Delete{id}";
            button.Attributes.Add("DataId", id.ToString());
            button.Text = $"Delete {id}";
            button.Style.Add("margin-left", "5px");
            button.Click += new EventHandler(delete_Click);
            p.Controls.Add(button);
        }
        protected void delete_Click(object sender, EventArgs e) {
            var btn = sender as LinkButton;
            var idToDelete = Convert.ToInt32( btn.Attributes["DataId"]);
            Dictionary<int, PertnerData> numberOfControls = (Dictionary<int, PertnerData>)Session["ControlGenerated"];
            numberOfControls = numberOfControls.Where(c => c.Key != idToDelete).ToDictionary(x => x.Key, x => x.Value);
            Session["ControlGenerated"] = numberOfControls;
            GenerateControls();
        }

        protected void btnAddAnother_Click(object sender, EventArgs e)
        {
            Dictionary<int, PertnerData> numberOfControls = (Dictionary<int, PertnerData>)Session["ControlGenerated"];
            numberOfControls.Add(numberOfControls.Keys.Max() + 1, new PertnerData());
            Session["ControlGenerated"] = numberOfControls;
            GenerateControls();
        }

        protected void btnGetValues_Click(object sender, EventArgs e)
        {
            var keys = ((Dictionary<int, PertnerData>)Session["ControlGenerated"]).Keys;

            Dictionary<int, PertnerData> numberOfControls = new Dictionary<int, PertnerData>();
            PertnerData pd;
            foreach (var i in keys)
            {
                pd = new PertnerData();
                pd.PName = GetValue($"txtPName{i}");
                pd.PEmail = GetValue($"txtPEmail{i}");
                pd.PDesignation = GetValue($"txtPDesignation{i}");
                numberOfControls[i] = pd;
            }
            Session["ControlGenerated"] = numberOfControls;
        }
        string GetValue(string id)
        {
            return ((TextBox)container.FindControl(id)).Text;
        }
    }
}