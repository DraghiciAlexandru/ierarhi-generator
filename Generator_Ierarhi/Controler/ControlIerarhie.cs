﻿using Generator_Ierarhi.Model;
using Generator_Ierarhi.Servicii;
using Generator_Ierarhi.Template;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Ierarhi.Controler
{
    class ControlIerarhie
    {
        private String path = Application.StartupPath;

        private ControlPerson controlPerson;

        private List<BuiltIerarhie> listIerarhie;

        public List<BuiltIerarhie> ListIerarhie
        {
            get { return listIerarhie; }
            set { listIerarhie = value; }
        }

        public ControlIerarhie()
        {
            listIerarhie = new List<BuiltIerarhie>();
            controlPerson = new ControlPerson();

            open();
        }

        public void open()
        {
            StreamReader reader = new StreamReader(path + @"\ierarhie.txt");
            String linie = "";
            
            while ((linie = reader.ReadLine()) != null)
            {
                Ierarhie<Person> ierarhie = new Ierarhie<Person>(controlPerson.getPerson(int.Parse(linie.Split(',')[2])));

                for (int i = 3; i < linie.Split(',').Length; i++)
                {
                    Person person = controlPerson.getPerson(int.Parse(linie.Split(',')[i]));
                    ierarhie.addSubordinate(controlPerson.getPerson(person.IdUpper), person);
                }

                BuiltIerarhie builtIerarhie = new BuiltIerarhie(int.Parse(linie.Split(',')[0]), int.Parse(linie.Split(',')[1]), ierarhie);

                listIerarhie.Add(builtIerarhie);
            }

            reader.Close();
        }

        public void save()
        {
            StreamWriter writer = new StreamWriter(path + @"\ierarhie.txt");

            foreach(BuiltIerarhie x in listIerarhie)
            {
                writer.WriteLine(x.ToString());
            }

            writer.Close();
        }

        public int getLast()
        {
            if (listIerarhie.Count == 0)
                return 0;
            return listIerarhie.ElementAt(listIerarhie.Count - 1).Id;
        }

        public void add(BuiltIerarhie builtIerarhie)
        {
            builtIerarhie.Id = getLast() + 1;
            listIerarhie.Add(builtIerarhie);
        }

        public void remove(int id)
        {
            foreach(BuiltIerarhie x in listIerarhie)
            {
                if (x.Id == id)
                {
                    listIerarhie.Remove(x);
                    break;
                }
            }
        }

        public BuiltIerarhie GetBuilt(int id)
        {
            foreach(BuiltIerarhie x in listIerarhie)
            {
                if (x.Id == id)
                    return x;
            }
            return null;
        }
    }
}