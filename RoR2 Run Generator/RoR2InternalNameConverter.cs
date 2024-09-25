namespace RoR2RunGenerator;

public static class RoR2InternalNameConverter
{
    public static string ConvertArtifactName(string artifactName)
    {
        return artifactName switch
        {
            "EliteOnly" => "Honor",
            "Bomb" => "Spite",
            "FriendlyFire" => "Chaos",
            "MixEnemy" => "Dissonance",
            "MonsterTeamGainsItems" => "Evolution",
            "RandomSurvivorOnRespawn" => "Metamorphosis",
            "ShadowClone" => "Vengeance",
            "SingleMonsterType" => "Kin",
            "TeamDeath" => "Death",
            "WeakAssKnees" => "Frailty",
            "WispOnDeath" => "Soul",
            _ => artifactName
        };
    }

    public static string ConvertCharacterName(string characterName)
    {
        return characterName switch
        {
            "Toolbot" => "MUL-T",
            "Bandit2" => "Bandit",
            "Croco" => "Acrid",
            "VoidSurvivor" => "Void Fiend",
            "Mage" => "Artificer",
            "FalseSon" => "False Son",
            "Treebot" => "REX",
            _ => characterName
        };
    }
}