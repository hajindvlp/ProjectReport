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

        static public void init()
        {
            JObject settingJson = JObject.Parse(File.ReadAllText(settingJsonPath));
            JArray settingArray = (JArray)settingJson["settings"];
            List<Klass> klasses = settingArray.ToObject<List<Klass>>();

            foreach (Klass newKlass in klasses)
            {
                Utils.Log(newKlass.taskJsonPath);
                JObject taskJson = JObject.Parse(File.ReadAllText(newKlass.taskJsonPath));
                JArray taskArray = (JArray)taskJson["tasks"];
                List<Task> Tasks = taskArray.ToObject<List<Task>>();
                newKlass.Tasks = Tasks;

                JObject studentJson = JObject.Parse(File.ReadAllText(newKlass.studentJsonPath));
                JArray studentArray = (JArray)studentJson["students"];
                List<Student> Students = studentArray.ToObject<List<Student>>();
                newKlass.Students = Students;
                Data.KlassDicitonary.Add(newKlass.name, newKlass);
            }
            Data.Klasses = klasses;
        }
    }
}
