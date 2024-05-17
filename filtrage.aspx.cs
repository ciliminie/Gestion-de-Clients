using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace gestion_de_client
{
    public partial class filtrage : System.Web.UI.Page
    {
       
        static string ch = ConfigurationManager.ConnectionStrings["gestionCmd"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                drpVille.AutoPostBack = true;
                SqlConnection con = new SqlConnection(ch);
                SqlCommand cmd = new SqlCommand("select Distinct Ville FROM Clients", con);
                try
                {
                    con.Open();
                    drpVille.DataSource = cmd.ExecuteReader();
                    drpVille.DataTextField = "Ville";
                    drpVille.DataBind();
                    drpVille.Items.Insert(0, "--Selectionner ne ville--");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ch);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Clients", con);
            try
            {
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            finally
            {
                con.Close();
            }
        }

        protected void drpVille_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ch);
            string sql = "SELECT * FROM Clients WHERE ville=@ville";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ville", drpVille.SelectedItem.Value);
                try
            {
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            finally
            { con.Close();
            }
        }
    }
}