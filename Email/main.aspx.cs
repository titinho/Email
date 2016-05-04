using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Email
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["my_connection_string"].ConnectionString;
            //string cs = "Server=tcp:titinho2.database.windows.net,1433;Database=Email;User ID=titinho2@titinho2;Password={your_password_here};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection con = new SqlConnection(cs))
            try
            { 
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from People WHERE Performance > 60", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TextBox1.Text += reader[0] + "\t";
                    TextBox1.Text += reader[1] + "\t";
                    TextBox1.Text += reader[2] + "\t";
                    TextBox1.Text += reader[3] + "\t";
                    }
                    reader.Close();

                    MailMessage mail = new MailMessage(
                        "titusz90@hotmail.hu",
                        "titusz90@vipmail.hu",
                        "Hello Titusz!",
                        "Üdv Titusz");
                    SmtpClient client = new SmtpClient("smtp.live.com");
                    client.Port = 25;
                    client.Credentials = new System.Net.NetworkCredential("titusz90@hotmail.hu", "titinho90");
                    client.EnableSsl = true;
                    client.Send(mail);
            }
            catch(Exception ex)
            {
                    TextBox1.Text = ex.ToString();
            }
        }
    }
}