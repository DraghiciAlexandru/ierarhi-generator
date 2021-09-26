using Generator_Ierarhi.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Ierarhi.Controler
{
    class ControlPerson
    {
        private String path = Application.StartupPath;

        private List<Person> people;

        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public ControlPerson()
        {
            people = new List<Person>();

            open();
        }

        public void open()
        {
            StreamReader reader = new StreamReader(path + @"\user.txt");
            String linie = "";

            while ((linie = reader.ReadLine()) != null)
            {
                if (linie.Split(',')[5] == "admin")
                {
                    people.Add(new Admin(linie));
                }
                else if (linie.Split(',')[5] == "staff")
                {
                    people.Add(new Staff(linie));
                }
                else
                {
                    people.Add(new Person(linie));
                }
            }

            reader.Close();
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + @"\user.txt");

            foreach (Person x in people) 
            {
                writer.WriteLine(x.ToString());
            }

            writer.Close();
        }

        public void updatePersonNume(int idPers, String nume)
        {
            foreach (Person x in people)
            {
                if (x.Id == idPers)
                {
                    x.Nume = nume;
                    break;
                }
            }
        }

        public void updatePersonPassword(int idPers, String password)
        {
            foreach (Person x in people)
            {
                if (x.Id == idPers)
                {
                    x.Password = password;
                    break;
                }
            }
        }

        public void updatePersonEmail(int idPers, String email)
        {
            foreach (Person x in people)
            {
                if (x.Id == idPers)
                {
                    x.Email = email;
                    break;
                }
            }
        }

        public void updatePersonTelefon(int idPers, String telefon)
        {
            foreach (Person x in people)
            {
                if (x.Id == idPers)
                {
                    x.Telefon = telefon;
                    break;
                }
            }
        }

        public void updatePersonTip(int idPers, String tip)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].Id == idPers)
                {
                    if (tip == "staff")
                        people[i] = people[i] as Staff;
                    else if (tip == "admin")
                    {
                        people[i] = people[i] as Admin;
                    }
                    else
                    {
                        people[i] = people[i] as Person;
                    }
                }
            }
        }

        public void updatePersonPic(int idPers, String picFile)
        {
            foreach (Person x in people)
            {
                if (x.Id == idPers)
                {
                    x.PicFile = picFile;
                    break;
                }
            }
        }

        public Person getPerson(int idPers)
        {
            foreach (Person x in people)
            {
                if (x.Id == idPers)
                {
                    return x;
                }
            }
            return null;
        }
    }
}
