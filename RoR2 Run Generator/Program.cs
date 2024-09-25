// See https://aka.ms/new-console-template for more information

using RoR2RunGenerator;

try
{
    RunGen.ImportSettings();
    while (RunGen.Settings.SaveFilePath == string.Empty)
    {
        Console.WriteLine(
            @"Enter the full path to your savefile. (should be in C:\Program Files(x86)\Steam\userdata\[some number]\632360\remote\UserProfiles)");
        var saveFilePath = Console.ReadLine()!.Trim('"');
        if (!(File.Exists(saveFilePath) && saveFilePath.EndsWith(".xml")))
        {
            Console.WriteLine("Couldn't find a savefile at the provided location. Try again");
        }
        else
        {
            RunGen.Settings.SaveFilePath = saveFilePath;
        }
    }

    RunGen.ExportSettings();

    while (true)
    {
        RunGen.UpdateSaveFileData();
        Console.WriteLine(RunGen.GetCharacter());
        Console.WriteLine(RunGen.GetArtifactList());
        Console.WriteLine(RunGen.GetRoute());
        Console.ReadKey();
    }
}
catch (Exception exception)
{
    File.WriteAllText("errors.log", exception+"\r\n");
    Console.WriteLine("Something wrong happened. Contact me and provide your errors.log file");
    Console.ReadKey();
}
