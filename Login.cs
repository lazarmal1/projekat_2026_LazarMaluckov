using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projekat_2026_LazarMaluckov
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Lazar Maluckov 
            // drugi red
            comboBox1.SelectedItem = "skola";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtIme.Text == "" || txtSifra.Text == "")
            {
                MessageBox.Show("Morate uneti korisnicko ime i lozinku!");
            }
            else
            {
                string lokacija = comboBox1.SelectedItem.ToString();
                SqlConnection veza = Konekcija.Connect(lokacija);
                DataTable podaci = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM korisnik WHERE ime='" + txtIme.Text + "'", veza);
                adapter.Fill(podaci);
                int count = podaci.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("Korisnicko ime ne postoji. Registrujte se na dugme REGISTER.");
                }
                else
                {

                    if (podaci.Rows[0]["pass"].ToString() == txtSifra.Text)
                    {
                        MessageBox.Show("Uspesno ste se ulogovali.");
                        this.Hide();
                        Glavna forma = new Glavna();
                        forma.Show();
                    }
                    else
                    {
                        MessageBox.Show("Pogresna lozinka.");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.user = comboBox1.SelectedItem.ToString();
            Registracija nova = new Registracija();
            nova.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
