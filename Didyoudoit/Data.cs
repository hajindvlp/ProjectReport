using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Didyoudoit
{
    static class Data
    {
        static public List<Klass> Klasses;
        static public Dictionary<string, Klass> KlassDicitonary = new Dictionary<string, Klass>();
    }

    class Klass
    {
        public List<Student> Students;
        public List<Task> Tasks;
        public string name { get; set; }
        public string studentJsonPath { get; set; }
        public string taskJsonPath { get; set; }

        public Klass(string name)
        {
            Students = new List<Student>();
            Tasks = new List<Task>();
            this.name = name;
        }

        public DataTable getTable()
        {
            DataTable newTable = new DataTable(this.name);

            // Add Columns
            Utils.addColumn(newTable, typeof(string), "학번", "Student ID", false, true);
            Utils.addColumn(newTable, typeof(string), "이름", "Student ID", false, true);
            foreach (Task task in Tasks) Utils.addColumn(newTable, typeof(string), task.name, task.due, false, false);

            // Add Rows
            foreach (Student student in Students)
            {
                DataRow dtRow = newTable.NewRow();
                Utils.setRow(dtRow, "학번", student.id);
                Utils.setRow(dtRow, "이름", student.name);
                foreach (Task task in student.Tasks)
                {
                    Utils.setRow(dtRow, task.name, task.location);
                }
                newTable.Rows.Add(dtRow);
            }

            return newTable;
        }
    }

    class Student
    {
        public List<Task> Tasks { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    class Task
    {
        public string name { get; set; }
        public string location { get; set; }
        public string due { get; set; }
    }
}
