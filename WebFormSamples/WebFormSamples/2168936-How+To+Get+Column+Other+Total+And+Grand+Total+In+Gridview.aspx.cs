using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSamples
{
    public class Data
    {
        public string Card_No { get; set; }
        public string Day { get; set; }
        public DateTime Dates { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public int Value { get; set; }
    }
    public partial class _2168936_How_To_Get_Column_Other_Total_And_Grand_Total_In_Gridview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = new List<Data>()
            {
                new Data(){ Card_No="A1", Day="D1", Dates=DateTime.Now, ItemName="Item 1", Qty=2, Value=29 },
                new Data(){ Card_No="A1", Day="D2", Dates=DateTime.Now, ItemName="Item 2", Qty=6, Value=9 },
                new Data(){ Card_No="M1", Day="D1", Dates=DateTime.Now, ItemName="Item 4", Qty=2, Value=39 },
                new Data(){ Card_No="M1", Day="D2", Dates=DateTime.Now, ItemName="Item 4", Qty=4, Value=19 },
                new Data(){ Card_No="M1", Day="D3", Dates=DateTime.Now, ItemName="Item 3", Qty=3, Value=59 },
                new Data(){ Card_No="B1", Day="D1", Dates=DateTime.Now, ItemName="Item", Qty=2, Value=29 },
                new Data(){ Card_No="C1", Day="D1", Dates=DateTime.Now, ItemName="Item 5", Qty=2, Value=39 },
                new Data(){ Card_No="K1", Day="D1", Dates=DateTime.Now, ItemName="Item 3", Qty=2, Value=19 },
            };

            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
}