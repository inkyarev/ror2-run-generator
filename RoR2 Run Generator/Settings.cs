using Newtonsoft.Json;

namespace RoR2RunGenerator;


public class Settings
{
    public const string Path = "settings.json";
    [JsonProperty(Order = 0)]
    public string SaveFilePath { get; set; } = string.Empty;
    [JsonProperty(Order = 1)]
    public List<string> CustomCharacters { get; set; } = [];
    [JsonProperty(Order = 2)]
    public double VoidFieldsProbability { get; set; } = 0.45;
    [JsonProperty(Order = 2)]
    public double VoidlingPostVoidFieldsProbability { get; set; } = 0.2;
    [JsonProperty(Order = 2)]
    public double FalseSonProbability { get; set; } = 0.45;
    [JsonProperty(Order = 2)]
    public double RebirthProbability { get; set; } = 0.25;
    [JsonProperty(Order = 2)]
    public double MithrixProbability { get; set; } = 0.65;
    [JsonProperty(Order = 2)]
    public double VoidlingPostMithrixProbability { get; set; } = 0.15;
    [JsonProperty(Order = 2)]
    public double BulwarksAmbryProbability { get; set; } = 0.55;
    [JsonProperty(Order = 2)]
    public double TrueEndingProbability { get; set; } = 0.05;
    [JsonProperty(Order = 2)]
    public double ObliterateProbability { get; set; }
    [JsonProperty(Order = 2)]
    public ArtifactSettings ArtifactRollSettings { get; set; } = ArtifactSettings.RollOne;
    [JsonProperty(Order = 3)]
    public string ArtifactRollDescription = "1 - Roll one artifact. 2 - Roll multiple artifacts. 3 - Roll pregenerated(by me) artifact lists. 4 - 3, but include pregenerated multiplayer artifact lists";

    public enum ArtifactSettings
    {
        RollOne = 1,
        RollMultiple,
        RollGenerated,
        RollMultiplayerGenerated
    }
}