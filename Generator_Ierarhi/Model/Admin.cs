using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator_Ierarhi.Model
{
    class Admin : Person
    {
        public Admin(int ID, int IdUpper, String Nume, String Password, String Email, String Telefon, String picFile, int Salary) : base(ID, IdUpper, Nume, Password, Email, Telefon, "Admin", picFile, Salary)
        {

        }

        public Admin(String admin) : base(admin)
        {

        }
    }
}
