using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Ierarhi.Model
{
    public class Person : IComparable<Person>
    {
        private String path = Application.StartupPath;

        private int id;
        private int idUpper;
        private String nume;
        private String password;
        private String email;
        private String telefon;
        private String tip;
        private String picFile;
        private Image picture;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdUpper
        {
            get { return idUpper; }
            set { idUpper = value; }
        }
        public String Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
        public String Tip
        {
            get { return tip; }
            set { tip = value; }
        }
        public String PicFile
        {
            get { return picFile; }
            set
            {
                picFile = value;
            }
        }
        public Image Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public Person(int ID, int IdUpper, String Nume, String Password, String Email, String Telefon, String Tip, String picFile)
        {
            this.id = ID;
            this.idUpper = IdUpper;
            this.nume = Nume;
            this.password = Password;
            this.email = Email;
            this.telefon = Telefon;
            this.tip = Tip;
            this.picFile = picFile;
            this.picture = Image.FromFile(path + "\\pic\\" + picFile);
        }

        public Person(String client) : this(int.Parse(client.Split(',')[0]), int.Parse(client.Split(',')[1]), client.Split(',')[2], client.Split(',')[3], client.Split(',')[4], client.Split(',')[5], client.Split(',')[6], client.Split(',')[7])
        {

        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (this.id == other.id) 
                return true;
            return false;
        }

        public override string ToString()
        {
            return id + "," + idUpper + "," + nume + "," + password + "," + email + "," + telefon + "," + tip + "," + picFile;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public int CompareTo(Person other)
        {
            if (this.tip == "admin" && other.tip != "admin")
                return 1;

            if (this.tip != "admin" && other.tip == "admin")
                return -1;

            return 0;
        }
    }
}
