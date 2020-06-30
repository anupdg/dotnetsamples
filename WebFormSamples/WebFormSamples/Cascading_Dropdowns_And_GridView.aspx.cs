using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSamples
{
    public partial class Cascading_Dropdowns_And_GridView : System.Web.UI.Page
    {
        private List<string> GetStates()
        {
            return new List<string> {
                "Delhi",
                "Karnataka"
            };
        }
        private List<string> GetCities(string stateName)
        {
            List<Tuple<string, string>> cities = new List<Tuple<string, string>>() { 
                new Tuple<string, string>("Delhi", "City 1"),
                new Tuple<string, string>("Delhi", "City 2"),
                new Tuple<string, string>("Delhi", "City 3"),
                new Tuple<string, string>("Karnataka", "City 11"),
                new Tuple<string, string>("Karnataka", "City 12"),
                new Tuple<string, string>("Karnataka", "City 13"),
            };

            return (from c in cities
                    where c.Item1.Equals(stateName)
                    select c.Item2).ToList();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cities.Enabled = false;
                gvData.Visible = false;
                states.DataSource = GetStates();
                states.DataBind();
            }
        }

        protected void states_SelectedIndexChanged(object sender, EventArgs e)
        {
            cities.Enabled = true;
            gvData.Visible = false;
            cities.DataSource = GetCities(states.SelectedValue);
            cities.DataBind();
        }

        protected void cities_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvData.Visible = true;
            gvData.DataSource = GetTable();
            gvData.DataBind();
        }
        DataTable GetTable()
        {
            // Step 2: here we create a DataTable.
            // ... We add 4 columns, each with a Type.
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Step 3: here we add 5 rows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }
    }
}