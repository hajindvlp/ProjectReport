using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Didyoudoit
{
    static class Utils
    {
        static public void addColumn(DataTable dtTable, Type dtType, string dtName, string dtCaption, bool readOnly, bool unique)
        {
            DataColumn dtColumn = new DataColumn();

            dtColumn.DataType = dtType;
            dtColumn.ColumnName = dtName;
            dtColumn.Caption = dtCaption;
            dtColumn.ReadOnly = readOnly;
            dtColumn.Unique = unique;

            dtTable.Columns.Add(dtColumn);
        }

        static public void setRow(DataRow dtRow, string name, dynamic data)
        {
            dtRow["name"] = data;
        }

        public const string LogPath = "C:/Users/Tool/Dev/ProjectReport/log.xml";
        static public void Log(string msg)
        {
            using (StreamWriter sw = new StreamWriter(LogPath, true))
            {
                sw.WriteLine(msg);
            }
        }
        
        static public void Log(DataTable dtTable)
        {
            dtTable.WriteXml(LogPath);
        }

        static public void Log(List<Task> tasks)
        {
            foreach (Task task in tasks) 
            {
                Log(task.name + " : " + task.due);
            }
        }

        static public void Log(List<Student> students)
        {
            foreach (Student student in students)
            {
                Log(student.name + " : " + student.id);
                foreach(Task task in student.Tasks)
                {
                    Log("    " + task.name + " : " + task.due);
                }
            }
        }
    }
}
