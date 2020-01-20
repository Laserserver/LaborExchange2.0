using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaborExchange2._0
{
    public partial class MyControl : System.Web.UI.UserControl
    {
        public string MyName { get; set; }

        public string AlertName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                Refresh();
        }

        protected void timeTest_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        void Refresh()
        {
            btnTest.Text =  $"{AlertName}: {DateTime.Now.ToString()}";
        }
    }
}