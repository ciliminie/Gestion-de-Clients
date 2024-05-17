using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace gestion_de_client
{
    public partial class GestionClients : System.Web.UI.Page
    {
       
        static string ch = ConfigurationManager.ConnectionStrings["gestionCmd"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                DrpClients.AutoPostBack = true;
                rempirListeClients();
            }
            lblMsg.Text = "";

        }
        //Procédure qui remplit le DropDownList avec la liste des clients
        protected void rempirListeClients()
        {
            DrpClients.Items.Clear();
            SqlConnection con = new SqlConnection(ch);
            string sql = "select id , Nom+''+ Prenom as NomPrenom From Clients Order by NomPrenom";
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                DrpClients.DataSource = cmd.ExecuteReader();
                DrpClients.DataTextField = "NomPrenom";
                DrpClients.DataValueField = "id";
                DrpClients.DataBind();
                DrpClients.Items.Insert(0, "--selectionner un Client--");
            }
            finally
            {
                con.Close();
            }
        }

        protected void drpClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpClients.SelectedIndex > 0)
            {
                SqlConnection con = new SqlConnection(ch);
                string req = "SELECT*FROM Clients WHERE id=@id";
                SqlCommand cmd = new SqlCommand(req, con);
                cmd.Parameters.AddWithValue("@id", DrpClients.SelectedValue);
                SqlDataReader dr;
                try
                {
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtNom.Text = dr["Nom"].ToString();
                        txtPrenom.Text = dr["Prenom"].ToString();
                        txtAdresse.Text = dr["Adresse"].ToString();
                        txtVille.Text = dr["Ville"].ToString();
                    }
                    dr.Close();
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                ViderTextBox();
            }
        }
        //Procédure qui vide les zones de texte
        protected void ViderTextBox()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtAdresse.Text = "";
            txtVille.Text = "";
            txtNom.Focus();
        }

        protected void btnNouveau_Click(object sender, EventArgs e)
        {
            ViderTextBox();
        }

        protected void btnMiseAJour_Click(object sender, EventArgs e)
        {
            //Tester si un client est selectionne
            if (DrpClients.SelectedIndex > 0)
            {
                string sql = "UPDATE clients Set Nom=@nom,Prenom=@prenom,adr=@adr, Ville=@ville WHERE id=@id";
                SqlConnection con = new SqlConnection(ch);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", DrpClients.SelectedValue);
                cmd.Parameters.AddWithValue("@nom", txtNom.Text);
                cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text);
                cmd.Parameters.AddWithValue("@adr", txtAdresse.Text);
                cmd.Parameters.AddWithValue("@ville", txtVille.Text);

                int modification = 0;
                try
                {
                    con.Open();
                    modification = cmd.ExecuteNonQuery();
                }
                finally
                {
                    con.Close();
                }
                //Actualiser la list des clients apre modification
                if (modification > 0)
                {
                    rempirListeClients();
                    lblMsg.Text = "Modification effectuée avec succès";
                }
            }
            else
            {
                lblMsg.Text = "Veillez selectionner un client!";
            }
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            //Tester si un client est Selectionne
            if (DrpClients.SelectedIndex > 0)
            {
                string sql = "DELETE FROM Clients WHERE id=@id";
                SqlConnection con = new SqlConnection(ch);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", DrpClients.SelectedValue);
                int suppression = 0;
                try
                {
                    con.Open();
                    suppression = cmd.ExecuteNonQuery();

                }
                finally
                {
                    con.Close();
                }
                //Cider les zones de text et actualiser la list des clients apre suppression
                if (suppression > 0)
                {
                    ViderTextBox();
                    rempirListeClients();
                    lblMsg.Text = "Client supprime avec succes";
                }
            }
            else
            {
                lblMsg.Text = "Veuillez selectionner in client!";
            }
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string sql = "Insert INTO clients(Nom,Prenom,Adr,Ville)Values(@nom,@prenom,@adr,@ville)";
            SqlConnection con = new SqlConnection(ch);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nom", txtNom.Text); 
            cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text); 
            cmd.Parameters.AddWithValue("@adr", txtAdresse.Text); 
            cmd.Parameters.AddWithValue("@ville", txtVille.Text);
            int ajout = 0;
            try
            {
                con.Open();
                ajout = cmd.ExecuteNonQuery();

            }
            finally 
            {
                con.Close();
            }
            if(ajout>0)
            {
                ViderTextBox();
                rempirListeClients();
                lblMsg.Text = "Client ajoute avec succes";

                    }
        }

      
    }
}