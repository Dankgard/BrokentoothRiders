using Tracker;

namespace Final_Tracker
{
    public class PracticaFinalTracker
    {
        PlayerHurtedWithShieldOn playerHurtedWithShieldOn;
        GrenadeHurtsEnemy grenadeHurtsEnemy;
        GrenadeHurtsPlayer grenadeHurtsPlayer;
        UseAbilityNoEnergy useAbilityNoEnergy;
        GrenadeUsage grenadeUsage;
        StartSession startSession;
        EndSession endSession;

        public string filepath;
        public enum EventType
        {
            PLAYER_HURTED_WITH_SHIELD_ON,
            GRENADE_HURTS_ENEMY,
            GRENADE_HURTS_PLAYER,
            USE_ABILITY_NO_ENERGY,
            GRENADE_USAGES,
            START_SESSION,
            END_SESSION
        }

        public void RegisterEvent(EventType event_type, string[] args = null)
        {
            switch (event_type)
            {
                case EventType.PLAYER_HURTED_WITH_SHIELD_ON:
                    if (playerHurtedWithShieldOn == null) playerHurtedWithShieldOn = new PlayerHurtedWithShieldOn();
                    playerHurtedWithShieldOn.addCurrency();
                    break;
                case EventType.GRENADE_HURTS_ENEMY:
                    if (grenadeHurtsEnemy == null) grenadeHurtsEnemy = new GrenadeHurtsEnemy();
                    grenadeHurtsEnemy.addCurrency();
                    break;
                case EventType.GRENADE_HURTS_PLAYER:
                    if (grenadeHurtsPlayer == null) grenadeHurtsPlayer = new GrenadeHurtsPlayer();
                    grenadeHurtsPlayer.addCurrency();
                    break;
                case EventType.USE_ABILITY_NO_ENERGY:
                    if (useAbilityNoEnergy == null) useAbilityNoEnergy = new UseAbilityNoEnergy();
                    useAbilityNoEnergy.addCurrency();
                    break;
                case EventType.GRENADE_USAGES:
                    if (grenadeUsage == null) grenadeUsage = new GrenadeUsage();
                    grenadeUsage.addCurrency();
                    break;
                case EventType.START_SESSION:
                    if(startSession == null) startSession = new StartSession();
                    break;
                case EventType.END_SESSION:
                    if(endSession == null) endSession = new EndSession();
                    WriteInJson();                   
                    break;
                default:
                    break;
            }
        }

        void WriteInJson()
        {
            if (startSession != null)
                startSession.ToJson(filepath);
            if (playerHurtedWithShieldOn != null)
                playerHurtedWithShieldOn.ToJson(filepath);
            if (grenadeHurtsEnemy != null)
                grenadeHurtsEnemy.ToJson(filepath);
            if (grenadeHurtsPlayer != null)
                grenadeHurtsPlayer.ToJson(filepath);
            if (useAbilityNoEnergy != null)
                useAbilityNoEnergy.ToJson(filepath);
            if (grenadeUsage != null)
                grenadeUsage.ToJson(filepath);
            if (endSession != null)
                endSession.ToJson(filepath);
        }
    }
}
