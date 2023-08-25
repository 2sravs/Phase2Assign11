using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppOne
{
    public partial class Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("server=SRAVS;database=ArticleDb;trusted_connection=true;");
                SqlCommand cmd = new SqlCommand("select * from Articles", con);
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                GridView.DataSource = ds;
                GridView.DataBind();
                LblMsg.Text = "Number of Articles are:" + ds.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                LblMsg.Text = "Error" + ex.Message;

            }


        }
    }
}
