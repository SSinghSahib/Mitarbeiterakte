
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using MySqlConnector;

namespace Mitarbeiterakte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        
       private void Form1_Load_Load(object sender, EventArgs e)
        {
              
        }
        // Insert(eingeben)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //"server=localhost;user id=root;password=;database=mitarbeiterakte";
            //string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=mitarbeiterakte;";
            string connection = "server=localhost;user id=root;password=;database=mitarbeiterakte";
            string query = "INSERT INTO tbl_mitarbeiter(vorname,nachname,geschlecht,stadt,telefon)" + 
                           "VALUES('"+ this.Vorname.Text + "', '" + this.Nachname.Text + "','" + this.Geschlecht.Text + "','"+ this.Stadt.Text + "','" + this.Telefon.Text + "')";
            
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;  
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Erfolgreich Gespeichert");
            conn.Close();
        }
        // Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=mitarbeiterakte";
            string query = "UPDATE tbl_mitarbeiter SET vorname='"+ this.Vorname.Text +"', nachname='"+ this.Nachname.Text +"', geschlecht='"+ this.Geschlecht.Text +"'," +
                           "stadt='"+ this.Stadt.Text +"', telefon='"+ this.Telefon.Text +"' WHERE id ='"+this.ID.Text +"'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Erfolgreich Aktualisiert");
            conn.Close();
        }
        // Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            string connection = "server=localhost;user id=root;password=;database=mitarbeiterakte";
            string query = "DELETE FROM tbl_mitarbeiter WHERE id='" + this.ID.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection); 
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Erfolgreich Gelöscht");
            conn.Close();
        }
        // Select(Data Laden)
        private void btnLadeDaten_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=mitarbeiterakte";
            string query = "SELECT * From tbl_mitarbeiter";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
            
        }  
    }
}
