using Newtonsoft.Json;
using System.IO;

namespace Tracker
{
    class UseAbilityNoEnergy : Event
    {
        public int counter;
        public UseAbilityNoEnergy()
        {
            Event_type = "Use_Ability_With_No_Energy";
            counter = 0;
        }
        public void AddEntry()
        {
            counter++;
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
