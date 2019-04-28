using CitiesDirectory.DataAccess;
using CitiesDirectory.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CitiesDirectory.Console
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new CityContext())
            {
                Person p2 = context.People.FirstOrDefault(p => p.Phone == textBox3.Text || p.FullName == textBox1.Text);

                p2.FullName = textBox2.Text;
                p2.Phone = textBox4.Text;
                context.SaveChanges();
            }
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new CityContext())
            {
                Person p1 = context.People.FirstOrDefault(p => p.FullName == textBox1.Text);

                if (textBox1.Text != "" && textBox3.Text == "")
                {
                    if (p1 == null)
                    {
                        MessageBox.Show("Контакт не найден");
                    }
                    else
                    {
                        textBox3.Text = p1.Phone;
                    }
                }

                Person p2 = context.People.FirstOrDefault(p => p.Phone == textBox3.Text);

                if (textBox1.Text == "" && textBox3.Text != "")
                {
                    if (p2 == null)
                    {
                        MessageBox.Show("Контакт не найден");
                    }
                    else
                    {
                        textBox1.Text = p2.FullName;
                    }
                }

                p2.FullName = textBox2.Text;
                p2.Phone = textBox4.Text;
                context.SaveChanges();

            }
        }
    }
}
