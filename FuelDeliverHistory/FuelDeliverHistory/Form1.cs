using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelDeliverHistory
{
    public partial class Form1 : Form
    {
        public List<Dostawy> listaDostaw = new List<Dostawy>();
        public Form1()
        {
            InitializeComponent();
            Funkcje.OdczytDanych(ref listaDostaw);
            Funkcje.AktualizacjaListy(listaDostaw, ref checkedListBox1);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yy HH:mm";
            dateTimePicker1.Value = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, 0, dateTimePicker1.Value.Kind);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //przycisk dodawania objektów do listy
        private void button3_Click(object sender, EventArgs e)
        {
            Dostawy dostawa = new Dostawy();
            try { dostawa.data = dateTimePicker1.Value; }
            catch { MessageBox.Show("Brak wprowadzonej daty!", "Błąd!"); return; }
            try { dostawa.iloscPaliwa = int.Parse(iloscLitrow.Text); }
            catch { MessageBox.Show("Brak podanych litrów!", "Błąd!"); return; }
            try { dostawa.nettoLitr = double.Parse(nettoLitr.Text); }
            catch { MessageBox.Show("Brak podanej ceny netto za litr!", "Błąd!"); return; }
            dostawa.cenaNetto = dostawa.iloscPaliwa * dostawa.nettoLitr;
            try { dostawa.bruttoLitr = double.Parse(bruttoLitr.Text); }
            catch { MessageBox.Show("Brak podanej ceny brutto za litr!", "Błąd!"); return; }
            dostawa.cenaBrutto = dostawa.iloscPaliwa * dostawa.bruttoLitr;
            try { dostawa.dostawca = dostawca.Text; }
            catch { MessageBox.Show("Brak podanego dostawcy!", "Błąd!"); return; }
            try { dostawa.uwagi = uwagi.Text; }
            catch { dostawa.uwagi = "-BRAK-"; }
            listaDostaw.Add(dostawa);
            
            Funkcje.AktualizacjaListy(listaDostaw, ref checkedListBox1);
            MessageBox.Show("Dodano nowy wpis!");

        }

        private void iloscLitrow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!(Char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void iloscLitrow_TextChanged(object sender, EventArgs e)
        {

        }

        private void nettoLitr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            if (nettoLitr.Text.Contains(',') && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = ',';
                return;
            }
            if (!(Char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
        }

        private void bruttoLitr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            if (bruttoLitr.Text.Contains(',') && (e.KeyChar == '.' || e.KeyChar == ','))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = ',';
                return;
            }
            if (!(Char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć te wpisy?", "Uwaga!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = checkedListBox1.Items.Count-1; i >= 0; i--)
                {
                    if(checkedListBox1.GetItemChecked(i) == true)
                    {
                        listaDostaw.Remove(listaDostaw[listaDostaw.Count-1-i]);
                    }
                }
                Funkcje.AktualizacjaListy(listaDostaw,ref  checkedListBox1);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void nettoLitr_KeyUp(object sender, KeyEventArgs e)
        {
            if (nettoLitr.Text.Count() > 0)
            {
                bruttoLitr.Text = Math.Round(double.Parse(nettoLitr.Text) * ((double.Parse(numericUpDown1.Text) / 100) + 1),2).ToString();
            }
            else
            {
                bruttoLitr.Text = "";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            if (nettoLitr.Text.Count() > 0)
            {
                bruttoLitr.Text = Math.Round(double.Parse(nettoLitr.Text) * ((double.Parse(numericUpDown1.Text) / 100) + 1), 2).ToString();
            }
        }
    }
}
