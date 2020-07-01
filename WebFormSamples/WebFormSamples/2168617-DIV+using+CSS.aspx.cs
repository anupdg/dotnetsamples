using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSamples
{
    public partial class _2168617_DIV_using_CSS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Currently these are hardcoded. You can get these from db
                string label = @"We can create as many div as many we want side by 
                    side with the same height and also with the
                    different heights. ";
                string btn1Label = "Button 1";
                string btn2Label = "Button 2";
                string btn3Label = "Button 3";

                lbl.Text = label;
                Button1.Text = btn1Label;
                Button2.Text = btn2Label;
                Button3.Text = btn3Label;
            }
            



        }
    }
}