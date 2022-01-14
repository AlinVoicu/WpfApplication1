using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.Models;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentContext db = new StudentContext();
        public MainWindow()
        {
            InitializeComponent();
            List<Student> studentilist = db.Studenti.ToList();
            StudentGrid.ItemsSource = studentilist;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Student s = new Student();
            s.Nume = NumetTxt.Text;
            s.Prenume = PrenumeTxt.Text;

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            s.Medie = Double.Parse(MedieTxt.Text, nfi);

            db.Studenti.Add(s);
            db.SaveChanges();

            MessageBox.Show("Student adaugat cu succes!");
            NumetTxt.Text = PrenumeTxt.Text = MedieTxt.Text = "";

            StudentGrid.ItemsSource = db.Studenti.ToList();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Student curentS = (Student)StudentGrid.SelectedItem;
            Student s = db.Studenti.Where(c => c.NrMatricol == curentS.NrMatricol).FirstOrDefault();
            if (s != null)
            {
                s = curentS;
                db.SaveChanges();
                MessageBox.Show("Datele au fost salvate cu succes!");
            }
            StudentGrid.ItemsSource = db.Studenti.ToList();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Student curentS = (Student)StudentGrid.SelectedItem;
            Student s = db.Studenti.Where(c => c.NrMatricol == curentS.NrMatricol).FirstOrDefault();
            if (s != null)
            {
                db.Studenti.Remove(s);
                db.SaveChanges();
                MessageBox.Show("Datele au fost sterse cu succes!");
            }
            StudentGrid.ItemsSource = db.Studenti.ToList();
        }
    }
}
