using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    public class LevelsBoxes
    {
        public string levelName;
        public string percentage;

        public LevelsBoxes(string n, string p)
        {
            levelName = n;
            percentage = p;
        }
    }

    class TotalBoxesDestroyed : Event
    {
        private int numeroCajasTotal;
        private string porcentajeCajasDestruidas;

        public List<LevelsBoxes> porcentajes;

        public TotalBoxesDestroyed()
        {
            Event_type = "Total_Boxes_Destroyed";
            porcentajes = new List<LevelsBoxes>();
        }

        public void StartLevel(int cantidad)
        {
            numeroCajasTotal = cantidad;
        }

        public void EndLevel(int cantidad, string levelName)
        {
            // Calcular el porcentaje
            porcentajeCajasDestruidas = (((float)(numeroCajasTotal - cantidad) / (float)numeroCajasTotal) * 100).ToString() + "%";
            LevelsBoxes levelsBoxes = new LevelsBoxes(levelName, porcentajeCajasDestruidas);
            porcentajes.Add(levelsBoxes);
        }

        public void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += jsonFile;
                File.WriteAllText(path, temp);
            }
            else
                File.WriteAllText(path, jsonFile);
        }
    }
}
