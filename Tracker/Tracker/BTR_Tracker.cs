﻿

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

        private bool print = false;

        public BTR_Tracker() {
            damageFrequency = new DamageFrequency();
            hitFrequency = new HitFrequency();
            weaponUsageFrequency = new WeaponUsageFrequency();
            weaponAccuracy = new WeaponAccuracy();
            levelTime = new LevelTime();
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
                    if (!print)
                    {
                        damageFrequency.ToJson(filePath);
                        // Hit Frequency
                        hitFrequency.ToJson(filePath);
                        // Weapon Usage Frequency
                        weaponUsageFrequency.ToJson(filePath);
                        // Weapon Accuracy
                        weaponAccuracy.CalculateAccuracy();
                        weaponAccuracy.ToJson(filePath);
                    }

                    endSession.ToJson(filePath);                    
                    break;
                case EventType.LEVEL_START:
                    startLevel = new StartLevel(args[0]);
                    startLevel.ToJson(filePath);
                    print = false;
                    break;
                case EventType.LEVEL_END:
                    if (endLevel == null)
                    {
                        endLevel = new EndLevel();
                    }
                    damageFrequency.ToJson(filePath);
                    // Hit Frequency
                    hitFrequency.ToJson(filePath);
                    // Weapon Usage Frequency
                    weaponUsageFrequency.ToJson(filePath);
                    // Weapon Accuracy
                    weaponAccuracy.CalculateAccuracy();
                    weaponAccuracy.ToJson(filePath);
                    // End Level
                    levelTime.TotalTime(float.Parse(args[0]));
                    levelTime.ToJson(filePath);
                    endLevel.ToJson(filePath);

                    print = true;
                    break;
                case EventType.LEVEL_TIME:
                    levelTime.StartTimer(float.Parse(args[0]));
                    break;
                case EventType.DAMAGE_FREQUENCY:
                    damageFrequency.AddPosition(float.Parse(args[0]), float.Parse(args[1]));
                    break;
                case EventType.HIT_FREQUENCY:
                    hitFrequency.AddEntry(args[0]);
                    break;
                case EventType.WEAPON_USAGE_FREQUENCY:
                    weaponUsageFrequency.AddEntry(args[0], float.Parse(args[1]));
                    break;
                case EventType.WEAPON_ACCURACY:
                    weaponAccuracy.AddHitEntry(args[0], bool.Parse(args[1]));
                    break;
                default:
                    break;
            }
        }
    }
}
