using Newtonsoft.Json;
using RoR2RunGenerator.Extensions;

namespace RoR2RunGenerator;

public static class RunGen
{
    public static Settings Settings { get; private set; } = new();
    private static List<string> _lockedCharacters = [];
    private static List<string> _unlockedCharacters = [];
    private static readonly List<string> DefaultCharacters = 
    [
        "Commando",
        "Huntress",
        "Railgunner",
        "Seeker"
    ];

    private static readonly List<string> Characters =
    [
        "Commando",
        "Huntress",
        "Bandit",
        "MUL-T",
        "Engineer",
        "Artificer",
        "Mercenary",
        "REX",
        "Loader",
        "Acrid",
        "Captain",
        "Railgunner",
        "Void Fiend",
        "Seeker",
        "False Son",
        "Chef"
    ];

    private static List<string> _lockedArtifacts = [];
    private static List<string> _unlockedArtifacts = [];

    private static readonly List<string> Artifacts =
    [
        "Honor",
        "Rebirth",
        "Sacrifice",
        "Spite",
        "Command",
        "Delusion",
        "Devotion",
        "Enigma",
        "Chaos",
        "Glass",
        "Dissonance",
        "Evolution",
        "Metamorphosis",
        "Vengeance",
        "Kin",
        "Swarms",
        "Death",
        "Frailty",
        "Soul"
    ];

    private static readonly List<List<string>> GeneratedArtifacts =
    [
        [
            "Sacrifice",
            "Swarms"
        ],
        [
            "Honor",
            "Glass"
        ],
        [
            "Glass",
            "Frailty"
        ],
        [
            "Spite",
            "Chaos"
        ],
        [
            "Spite",
            "Evolution"
        ],
        [
            "Command",
            "Metamorphosis"
        ],
        [
            "Vengeance",
            "Swarms"
        ],
        [
            "Delusion",
            "Devotion"
        ],
        [
            "Devotion",
            "Chaos"
        ],
        [
            "Enigma",
            "Metamorphosis"
        ],
        [
            "Dissonance",
            "Kin"
        ],
        [
            "Metamorphosis",
            "Vengeance"
        ],
        [
            "Spite",
            "Swarms",
            "Soul"
        ],
        [
            "Chaos",
            "Swarms",
            "Soul"
        ],
        [
            "Honor",
            "Chaos",
            "Evolution"
        ],
        [
            "Dissonance",
            "Evolution",
            "Swarms"
        ],
        [
            "Chaos",
            "Vengeance",
            "Swarms"
        ],
    ];

    private static List<List<string>> _unlockedGeneratedArtifacts = [];

    private static readonly List<List<string>> MultiplayerGeneratedArtifacts =
    [
        [
            "Chaos",
            "Death"
        ],
        [
            "Death",
            "Frailty"
        ],
        [
            "Vengeance",
            "Death"
        ],
        [
            "Chaos",
            "Vengeance",
            "Death"
        ],
        [
            "Chaos",
            "Enigma",
            "Death"
        ],
    ];
    
    private static List<List<string>> _unlockedMultiplayerGeneratedArtifacts = [];

    public static string GetCharacter()
    {
        return _unlockedCharacters.Random();
    }

    public static string GetArtifactList()
    {
        switch (Settings.ArtifactRollSettings)
        {
            case Settings.ArtifactSettings.RollOne:
                return $"Artifact of {_unlockedArtifacts.Random()}";
            
            case Settings.ArtifactSettings.RollMultiple:
                var artifacts = string.Empty;
                for (var i = 0; i <= Random.Shared.Next(0, _unlockedArtifacts.Count); i++)
                {
                    artifacts += $"Artifact of {_unlockedArtifacts.Random()}, ";
                }
                return artifacts.TrimEnd(", ");
            
            case Settings.ArtifactSettings.RollGenerated:
                if (_unlockedGeneratedArtifacts.Count == 0) return "Not enough artifacts unlocked to use pregen lists";
                return _unlockedGeneratedArtifacts.Random()
                    .Aggregate(string.Empty, (current, artifact) => current + $"Artifact of {artifact}, ").TrimEnd(", ");
            
            case Settings.ArtifactSettings.RollMultiplayerGenerated:
                var newList = _unlockedGeneratedArtifacts.Concat(_unlockedMultiplayerGeneratedArtifacts)
                    .ToList();
                if (newList.Count == 0) return "Not enough artifacts unlocked to use pregen lists";
                return newList.Random()
                    .Aggregate(string.Empty, (current, artifact) => current + $"Artifact of {artifact}, ").TrimEnd(", ");
            default:
                return string.Empty;
        }
    }

    public static string GetRoute()
    {
        var returnValue = string.Empty;
        if (Random.Shared.IsProbabilityHit(Settings.VoidFieldsProbability))
        {
            returnValue += "Void Fields -> ";
            if (Random.Shared.IsProbabilityHit(Settings.VoidlingPostVoidFieldsProbability))
            {
                returnValue += "Voidling -> ";
                returnValue += "End";
                return returnValue;
            }
        }

        if (Random.Shared.IsProbabilityHit(Settings.FalseSonProbability))
        {
            returnValue += "False Son -> ";
            if (Random.Shared.IsProbabilityHit(Settings.RebirthProbability))
            {
                returnValue += "End";
                return returnValue;
            }
        }

        if (Random.Shared.IsProbabilityHit(Settings.MithrixProbability))
        {
            returnValue += "Mithrix -> ";
            if (Random.Shared.IsProbabilityHit(Settings.VoidlingPostMithrixProbability))
            {
                returnValue += "Voidling -> ";
                returnValue += "End";
                return returnValue;
            }
            returnValue += "End";
            return returnValue;
        }

        if (Random.Shared.IsProbabilityHit(Settings.BulwarksAmbryProbability) && _lockedArtifacts.Count != 0)
        {
            returnValue += $"Unlock Artifact of {_lockedArtifacts.Random()} -> ";
        }
        else
        {
            returnValue += "Loop -> ";
        }

        if (Random.Shared.IsProbabilityHit(Settings.TrueEndingProbability))
        {
            returnValue += "Crash the game -> ";
            returnValue += "End";
            return returnValue;
        }


        returnValue += Random.Shared.IsProbabilityHit(Settings.ObliterateProbability)
            ? "Obliterate -> "
            : "Twisted Scavenger -> ";

        returnValue += "End";
        return returnValue;
    }

    public static void ImportSettings()
    {
        if (!File.Exists(Settings.Path))
        {
            File.WriteAllText(Settings.Path, JsonConvert.SerializeObject(new Settings(), Formatting.Indented));
        }
        var jsonString = File.ReadAllText(Settings.Path);
        Settings = JsonConvert.DeserializeObject<Settings>(jsonString)!;
    }

    public static void UpdateSaveFileData()
    {
        if(!(File.Exists(Settings.SaveFilePath) && Settings.SaveFilePath.EndsWith(".xml"))) return;
        var unlockedArtifacts = File.ReadAllText(Settings.SaveFilePath)
            .Split("</unlock>")
            .Where(unlock => unlock.Contains("Artifacts"))
            .Select(artifact => artifact.Split("Artifacts.")[1])
            .Select(RoR2InternalNameConverter.ConvertArtifactName)
            .ToList();
        _unlockedArtifacts = unlockedArtifacts;
        _lockedArtifacts = Artifacts.Except(unlockedArtifacts).ToList();
        _unlockedGeneratedArtifacts = GeneratedArtifacts.Where(list => !list.Any(_lockedArtifacts.Contains)).ToList();
        _unlockedMultiplayerGeneratedArtifacts = MultiplayerGeneratedArtifacts.Where(list => !list.Any(_lockedArtifacts.Contains)).ToList();

        var characters = File.ReadAllText(Settings.SaveFilePath)
            .Split("</unlock>")
            .Where(unlock => unlock.Contains("Characters"))
            .Select(artifact => artifact.Split("Characters.")[1])
            .Select(RoR2InternalNameConverter.ConvertCharacterName);
        _unlockedCharacters = DefaultCharacters.Concat(characters).Concat(Settings.CustomCharacters).ToList();
        _lockedCharacters = Characters.Except(_unlockedCharacters).ToList();
    }

    public static void ExportSettings()
    {
        File.WriteAllText(Settings.Path, JsonConvert.SerializeObject(Settings, Formatting.Indented));
    }
}