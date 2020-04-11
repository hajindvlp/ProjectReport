using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Didyoudoit
{
    static class Load
    {
        static string settingJsonPath = "C:/Users/Tool/Dev/ProjectReport/settings.json";
        static string studentJsonPath;
        static string taskJsonPath;

        static public void init()
        {
            JObject settingJson = JObject.Parse(File.ReadAllText(settingJsonPath));

            studentJsonPath = (string)settingJson["studentData"];
            taskJsonPath = (string)settingJson["taskData"];

            Klass klass = new Klass("main");

            JObject taskJson = JObject.Parse(File.ReadAllText(taskJsonPath));
            JArray taskArray = (JArray)taskJson["tasks"];
            List<Task> Tasks = taskArray.ToObject<List<Task>>();
            klass.Tasks = Tasks;

            JObject studentJson = JObject.Parse(File.ReadAllText(studentJsonPath));
            JArray studentArray = (JArray)studentJson["students"];
            List<Student> Students = studentArray.ToObject<List<Student>>();
            klass.Students = Students;

            Data.Klasses = klass;
        }
    }
}
