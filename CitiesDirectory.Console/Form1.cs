using CitiesDirectory.DataAccess;
using CitiesDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CitiesDirectory.Console
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new CityContext())
            {
                var cities = context.Cities.ToList();
                foreach (var city in cities)
                {
                    comboBox1.Items.Add(city.NameSeed);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Поля пустые, внесите данные в оба поля.");
            }
            else
            {
                Person person = new Person();
                using (var context = new CityContext())
                {
                    var cities = context.Cities.ToList();

                    for (int i = 0; i < cities.Count; i++)
                        if (cities[i].NameSeed == comboBox1.Text)
                            person = new Person { FullName = textBox1.Text, Phone = textBox2.Text, City = cities[i] };

                    context.People.AddRange(new List<Person> { person });
                    context.SaveChanges();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    MessageBox.Show("Контакт внесен!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Внесите данные поле ФИО.");
            }
            else
            {
                using (var context = new CityContext())
                {
                    Person person = context.People.FirstOrDefault(p => p.FullName == textBox1.Text);
                    if (person != null)
                    {
                        context.People.Remove(person);
                        context.SaveChanges();
                    }
                }
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("Контакт удален!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var context = new CityContext())
            {
                Person p1 = context.People.FirstOrDefault(p => p.FullName == textBox1.Text);

                if (textBox1.Text != "" && textBox2.Text == "")
                {
                    if (p1 == null)
                    {
                        MessageBox.Show("Контакт не найден");
                    }
                    else
                    {
                        textBox2.Text = p1.Phone;
                    }
                }

                Person p2 = context.People.FirstOrDefault(p => p.Phone == textBox2.Text);

                if (textBox1.Text == "" && textBox2.Text != "")
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

            }
        }
    }
}
