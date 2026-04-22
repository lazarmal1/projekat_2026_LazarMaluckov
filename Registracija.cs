using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projekat_2026_LazarMaluckov
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baza = Program.user;
            if (textBox2.Text == textBox3.Text)
            {
                SqlConnection veza = Konekcija.Connect(baza);
                string provera = "SELECT COUNT(*) FROM Korisnik WHERE ime='" + textBox1.Text + "'";
                SqlCommand komanda = new SqlCommand(provera, veza);
                veza.Open();
                int ima = (int)komanda.ExecuteScalar();
                veza.Close();
                if (ima > 0)
                {
                    MessageBox.Show("Korisnicko ime je zauzeto.");
                }
                else
                {
                    string naredba = "INSERT INTO Korisnik VALUES('";
                    naredba += textBox1.Text + "','";
                    naredba += textBox2.Text + "', 0)";
                    veza.Open();
                    SqlCommand uradi = new SqlCommand(naredba, veza);
                    uradi.ExecuteNonQuery();
                    veza.Close();
                    MessageBox.Show("Vasa regisracija je uspesno zavrsena.");
                }
            }
            else
            {
                MessageBox.Show("Potvrdjena lozinka nije ista kao lozinka.");
            }
        }
    }
}
