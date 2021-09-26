using Generator_Ierarhi.Servicii;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator_Ierarhi.Model
{
    class BuiltIerarhie
    {
        private int id;
        private int idAdmin;
        private Ierarhie<Person> ierarhie;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdAdmin
        {
            get { return idAdmin; }
            set { idAdmin = value; }
        }
        public Ierarhie<Person> Ierarhie
        {
            get { return ierarhie; }
            set { ierarhie = value; }
        }

        public BuiltIerarhie(int id, int idAdmin, Ierarhie<Person> ierarhie)
        {
            this.id = id;
            this.idAdmin = idAdmin;
            this.ierarhie = ierarhie;
        }

        public override string ToString()
        {
            return id + "," + idAdmin + ierarhie.ToString();
        }

    }
}
