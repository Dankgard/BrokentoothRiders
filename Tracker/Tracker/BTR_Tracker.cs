

using Newtonsoft.Json;
using System.IO;

namespace Tracker
{
    public class BTR_Tracker
    {
        public enum EventType
        {
            SESSION_START,
            LEVEL_START,
            LEVEL_END,
            SESSION_END,
            LEVEL_TIME,
            DAMAGE_FREQUENCY,
            HIT_FREQUENCY,
            WEAPON_USAGE_FREQUENCY,
            WEAPON_ACCURACY
        }
        private string filePath;
        // Un elemento de cada tipo de evento
        private StartSession startSession;
        private EndSession endSession;
        private StartLevel startLevel;
        private EndLevel endLevel;
        private LevelTime levelTime;
        public DamageFrequency damageFrequency;
        private HitFrequency hitFrequency;
        private WeaponUsageFrequency weaponUsageFrequency;
        private WeaponAccuracy weaponAccuracy;

        //public List<Event> events { get; }

        public BTR_Tracker()
        {
            //events = new List<Event>();
        }

        public void SetFilePath(string path)
        {
            filePath = path;
        }

        public void RegisterEvent(EventType event_type, string[] args = null)
        {
            switch (event_type)
            {
                case EventType.SESSION_START:
                    if (startSession == null)
                    {
                        startSession = new StartSession();
                    }
                    startSession.ToJson(filePath);
                    break;
                case EventType.SESSION_END:
                    if (endSession == null)
                    {
                        endSession = new EndSession();
                    }
                    endSession.ToJson(filePath);
                    break;
                case EventType.LEVEL_START:
                    if (startLevel == null)
                    {
                        startLevel = new StartLevel(args[0]);
                    }
                    startLevel.ToJson(filePath);
                    break;
                case EventType.LEVEL_END:
                    if (endLevel == null)
                    {
                        endLevel = new EndLevel();
                    }
                    endLevel.ToJson(filePath);
                    damageFrequency.ToJson(filePath);
                    hitFrequency.ToJson(filePath);
                    weaponUsageFrequency.ToJson(filePath);
                    weaponAccuracy.ToJson(filePath);
                    levelTime.ToJson(filePath);
                    /*string jsonFile = JsonConvert.SerializeObject(damageFrequency, Formatting.Indented);
                    if (File.Exists(filePath))
                    {
                        string temp = File.ReadAllText(filePath);
                        temp += jsonFile;
                        File.WriteAllText(filePath, temp);
                    }
                    else
                        File.WriteAllText(filePath, jsonFile);*/

                    break;
                case EventType.LEVEL_TIME:
                    if (levelTime == null)
                    {
                        levelTime = new LevelTime();
                    }
                    //levelTime.ToJson(filePath);
                    break;
                case EventType.DAMAGE_FREQUENCY:
                    if (damageFrequency == null)
                    {
                        damageFrequency = new DamageFrequency();
                    }
                    damageFrequency.AddPosition(float.Parse(args[0]), float.Parse(args[1]));
                    //damageFrequency.ToJson(filePath);
                    break;
                case EventType.HIT_FREQUENCY:
                    if (hitFrequency == null)
                    {
                        hitFrequency = new HitFrequency();
                    }
                    hitFrequency.AddEntry(args[0]);
                    //hitFrequency.ToJson(filePath);
                    break;
                case EventType.WEAPON_USAGE_FREQUENCY:
                    if (weaponUsageFrequency == null)
                    {
                        weaponUsageFrequency = new WeaponUsageFrequency();
                    }
                    weaponUsageFrequency.AddEntry(args[0], float.Parse(args[1]));
                    //weaponUsageFrequency.ToJson(filePath);
                    break;
                case EventType.WEAPON_ACCURACY:
                    if (weaponAccuracy == null)
                    {
                        weaponAccuracy = new WeaponAccuracy();
                    }
                    weaponAccuracy.AddHitEntry(args[0], bool.Parse(args[1]));
                    weaponAccuracy.CalculateAccuracy();
                    //weaponAccuracy.ToJson(filePath);
                    break;
                default:
                    break;
            }
        }
    }
}
