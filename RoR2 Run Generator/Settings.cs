using Tomlet.Attributes;

namespace RoR2RunGenerator;


public class Settings
{
    [TomlNonSerialized]
    public const string Path = "settings.toml";
    [TomlPrecedingComment("""
                          The path to the savefile. 
                          Usually located at C:\Program Files(x86)\Steam\userdata\[some number]\632360\remote\UserProfiles.
                          """)]
    public string SaveFilePath { get; set; } = string.Empty;
    [TomlPrecedingComment("""
                          List of custom characters.
                          These characters will be added to your unlocked characters pool.
                          """)]
    // ReSharper disable once CollectionNeverUpdated.Global
    public List<string> CustomCharacters { get; set; } = [];
    [TomlPrecedingComment("""
        List of custom artifacts.
        These artifacts will be added to your unlocked artifacts pool.
        Provide the base name of the artifact; for example, to add "Artifact of Prestige", add "Prestige"
        """)]
    // ReSharper disable once CollectionNeverUpdated.Global
    public List<string> CustomArtifacts { get; set; } = [];
    [TomlPrecedingComment("""
                          The probability to go to Void Fields.
                          Should be between 0.0 and 1.0
                          """)]
    public double VoidFieldsProbability { get; set; } = 0.45;
    [TomlPrecedingComment("""
                          The probability to go to Voidling right after Void Fields.
                          Should be between 0.0 and 1.0
                          """)]
    public double VoidlingPostVoidFieldsProbability { get; set; } = 0.2;
    [TomlPrecedingComment("""
                          The probability to go to False Son.
                          Should be between 0.0 and 1.0
                          """)]
    public double FalseSonProbability { get; set; } = 0.45;
    [TomlPrecedingComment("""
                          The probability to end the run by being Reborn.
                          Should be between 0.0 and 1.0
                          """)]
    public double RebirthProbability { get; set; } = 0.25;
    [TomlPrecedingComment("""
                          The probability to go to Mithrix.
                          Should be between 0.0 and 1.0
                          """)]
    public double MithrixProbability { get; set; } = 0.65;
    [TomlPrecedingComment("""
                          The probability to go to Voidling right after Mithrix (via Glass Frog).
                          Should be between 0.0 and 1.0
                          """)]
    public double VoidlingPostMithrixProbability { get; set; } = 0.15;
    [TomlPrecedingComment("""
                          The probability to go to Bulwarks Ambry.
                          Should be between 0.0 and 1.0
                          """)]
    public double BulwarksAmbryProbability { get; set; } = 0.55;
    [TomlPrecedingComment("""
                          The probability to end the run by crashing the game.
                          Should be between 0.0 and 1.0
                          """)]
    public double TrueEndingProbability { get; set; } = 0.05;
    [TomlPrecedingComment("""
                          The probability to end the run by obliterating. 
                          If this and all the other probabilities fail to hit, you will be directed to The Moment, Whole.
                          Should be between 0.0 and 1.0
                          """)]
    public double ObliterateProbability { get; set; }
    [TomlPrecedingComment("""
                          How the artifacts should be rolled.
                          Possible values:
                            RollNone - don't roll artifacts;
                            RollOne - roll one artifact per run;
                            RollMultiple - roll multiple artifacts per run;
                            RollGenerated - roll pregenerated(by me) artifact lists. Carefully crafted to provide most fun utilizing different artifact combos.
                            RollMultiplayerGenerated - RollGenerated, but also include some combos with the Artifact of Death.
                          """)]
    public ArtifactSettings ArtifactRollSettings { get; set; } = ArtifactSettings.RollOne;

    public enum ArtifactSettings
    {
        RollNone,
        RollOne,
        RollMultiple,
        RollGenerated,
        RollMultiplayerGenerated
    }
}