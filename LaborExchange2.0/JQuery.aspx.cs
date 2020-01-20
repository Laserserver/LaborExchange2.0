using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaborExchange2._0
{
    public partial class JQuery1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyControl control1 = (MyControl)Page.LoadControl(@"~\MyControl.ascx");
            control1.ID = "sas1";
            control1.AlertName = "Кнопка 1";
            control1.MyName = "sas1_btnTest";
            MyControl control2 = (MyControl)Page.LoadControl(@"~\MyControl.ascx");
            control2.ID = "sas2";
            control2.AlertName = "Кнопка 2";
            control2.MyName = "sas2_btnTest";
            PH1.Controls.Add(control1);
            PH2.Controls.Add(control2);
        }
    }
}