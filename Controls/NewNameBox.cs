using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:NewNameBox runat=server></{0}:NewNameBox >")]
    public class NewNameBox : TextBox
    {
        private string _name;

        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public List<string> Names
        {
            private get;
            set;
        }

        [Bindable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        public string NewName
        {
            get => Names.Contains(_name) ? null : _name;
            set
            {
                //BackColor = Names.Contains(_name) ? Color.IndianRed : Color.ForestGreen;
                _name = value;
                this.Text = _name;
            }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            String csName = $"{ClientID} script";
            Type csType = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            //ClientScriptManager cs = Page.ClientScript;

            // Check to see if the client script is already registered.
            //if (cs.IsClientScriptBlockRegistered(csType, csName))
                //return;
            StringBuilder csText = new StringBuilder();
            csText.Append("<script type=\"text/javascript\"> " +
                          "$(document).ready(function () { $(\"#" +
                          ID + "\").on(\"click\", function(e) { " +
                          "alert(\"Было вызвано событие серверного" +
                          " контрола \"); }); }); </script> ");
            writer.Write(csText);
            //cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
            base.Render(writer);
        }

    }
}
