using Newtonsoft.Json;

namespace RoR2RunGenerator;

[JsonObject]
public class Settings
{
    public const string Path = "settings.json";
    [JsonProperty(Order = 0)]
    public string SaveFilePath { get; set; } = string.Empty;
    
    [JsonProperty(Order = 1)]
    public double VoidFieldsProbability { get; set; } = 0.45;
    [JsonProperty(Order = 1)]
    public double VoidlingPostVoidFieldsProbability { get; set; } = 0.2;
    [JsonProperty(Order = 1)]
    public double FalseSonProbability { get; set; } = 0.45;
    
    [JsonProperty(Order = 1)]
    public double RebirthProbability { get; set; } = 0.25;
    [JsonProperty(Order = 1)]
    public double MithrixProbability { get; set; } = 0.65;
    [JsonProperty(Order = 1)]
    public double VoidlingPostMithrixProbability { get; set; } = 0.15;
    [JsonProperty(Order = 1)]
    public double BulwarksAmbryProbability { get; set; } = 0.55;
    [JsonProperty(Order = 1)]
    public double TrueEndingProbability { get; set; } = 0.05;
    [JsonProperty(Order = 1)]
    public double ObliterateProbability { get; set; }
    [JsonProperty(Order = 1)]
    public ArtifactSettings ArtifactRollSettings { get; set; } = ArtifactSettings.RollOne;
    [JsonProperty(Order = 2)]
    public string ARDescription = "1 - Roll one artifact. 2 - Roll multiple artifacts. 3 - Roll pregenerated(by me) artifact lists. 4 - 3, but include pregenerated multiplayer artifact lists";

    
    public enum ArtifactSettings
    {
        RollOne = 1,
        RollMultiple,
        RollGenerated,
        RollMultiplayerGenerated
    }
}