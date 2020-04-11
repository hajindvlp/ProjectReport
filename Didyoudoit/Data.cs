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
    }

    class Klass
    {
        public List<Student> Students;
        public List<Task> Tasks;
        string name;

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
            Utils.addColumn(newTable, typeof(string), "id", "Student ID", false, true);
            Utils.addColumn(newTable, typeof(string), "name", "Student ID", false, true);
            foreach (Task task in Tasks) Utils.addColumn(newTable, typeof(string), task.name, task.due, false, false);

            // Add Rows
            foreach (Student student in Students)
            {
                DataRow dtRow = newTable.NewRow();
                Utils.setRow(dtRow, "id", student.id);
                Utils.setRow(dtRow, "name", student.name);
                foreach (Task task in student.Tasks)
                {
                    Utils.setRow(dtRow, task.name, task.location);
                }
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
