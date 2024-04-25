namespace DungeonCrawler;

public static class FightDialogues
{
    private static string[] _lines =
    {
        "Have you ever heard the definition of insanity?", // 1
        "Did you know that you have rights?", // 2
        "Do you want to play fortnite?", // 3
        "Do you want to play among us?", // 4
        "Do you know what's hiding in the XP?", // 5
        "Press any key to continue...", // 6
        "Go play Fash Catch", // 7
        "Don't drink and drive. But if you do, call me", // 8
    };
    
    private static string[] _answers =
    {
        "No", // 1
        "The constitution says i do", // 2
        "Yes", // 3
        "Yes", // 4
        "Who will say?", // 5
        "Where the hell is any key the button?", // 6
        "Ok", // 7
        "Ok", // 8
    };
    
    private static string[] _outcomes =
    {
        "Enemy didn't know what the definition is. he punched you.", // 1
        "Enemy have rights, like the right to punch you.", // 2
        "You and Enemy played fortnite.", // 3
        "You and Enemy played among us and you was the imposter.", // 4
        "Lior Tzoref and Anat Kalo Lavron entered the room. What's gonna happen?", // 5
        "Enemy didn't find the any key button.", // 6
        "Enemy played Fash Catch. He hated it.", // 7
        "Enemy called you while drinking and driving. He passed out.", // 8
    };

    private static bool[] _shouldSpare =
    {
        false, // 1
        false, // 2
        true, // 3
        false, // 4
        true, // 5
        true, // 6
        false, // 7
        false, // 8
    };

    public static bool RandomDialogue(out string line, out string answer, out string outcome)
    {
        int dialogue = Random.Shared.Next(_lines.Length - 1);

        line = _lines[dialogue];
        answer = _answers[dialogue];
        outcome = _outcomes[dialogue];

        return !_shouldSpare[dialogue];
    }
}