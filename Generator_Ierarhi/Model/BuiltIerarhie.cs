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
        private String title;
        private int idAdmin;
        private Ierarhie<Person> ierarhie;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Title
        {
            get { return title; }
            set { title = value; }
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

        public BuiltIerarhie(int id, String title, int idAdmin, Ierarhie<Person> ierarhie)
        {
            this.id = id;
            this.title = title;
            this.idAdmin = idAdmin;
            this.ierarhie = ierarhie;
        }

        public override string ToString()
        {
            return id + "," + title + "," + idAdmin + ierarhie.ToString();
        }


    }
}
