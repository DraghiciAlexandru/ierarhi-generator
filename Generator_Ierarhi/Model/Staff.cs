using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator_Ierarhi.Model
{
    class Staff : Person
    {
        public Staff(int ID, int IdUpper, String Nume, String Password, String Email, String Telefon, String picFile, int Salary) : base(ID, IdUpper, Nume, Password, Email, Telefon, "Staff", picFile, Salary)
        {

        }

        public Staff(String staff) : base(staff)
        {

        }

    }
}
