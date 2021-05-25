using Newtonsoft.Json;
using System.IO;

namespace Tracker
{
    class PlayerHurtedWithShieldOn : Event
    {
        public int counter;
        public PlayerHurtedWithShieldOn()
        {
            Event_type = "Player_Hurt_With_Shield_On";
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
