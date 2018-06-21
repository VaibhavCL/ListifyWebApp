using ListifyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ListifyWebApp
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Countries.xml"));
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
        }
    }
}