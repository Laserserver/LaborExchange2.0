using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            String csName = $"{MyName} script";
            Type csType = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the client script is already registered.
            if (cs.IsClientScriptBlockRegistered(csType, csName)) 
                return;
            StringBuilder csText = new StringBuilder();
            csText.Append("<script type=\"text/javascript\"> " +
                          "$(document).ready(function () { $(\"#" +
                          MyName + "\").on(\"click\", function(e) { " +
                          "alert(\"Было вызвано событие пользовательского" +
                          " контрола " + AlertName +"\"); }); }); </script> ");
            cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
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