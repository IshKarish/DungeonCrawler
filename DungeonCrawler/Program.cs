using System.Collections.ObjectModel;
using System.Speech.Synthesis;

namespace DungeonCrawler;

class Program
{
    private static Player _player = new Player(9, 1, new Graphics('*', ConsoleColor.White));
    private static SkeletalMesh _dorBenDor = new SkeletalMesh("Dor Ben Dor", "tfjnygvh", "Microsoft George");
    private static SkeletalMesh _ofirKatz = new SkeletalMesh("Ofir Katz", "tfjnygvh", "Microsoft David Desktop", 80);

    private static GameManager _gameManager = new GameManager();
    
    public static void Main(string[] args)
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        
        ReadOnlyCollection<InstalledVoice> a = s.GetInstalledVoices();
        //Console.WriteLine(s.GetInstalledVoices().Count);
        
        foreach (var t in a)
        {
            Console.WriteLine($"{t.VoiceInfo.Name} = {t.Enabled}");
            s.Rate = -2;
            s.Volume = 100;
            //s.SelectVoice(t.VoiceInfo.Name);
            //s.Speak("Lol");
        }

        Console.ReadLine();
        
        Console.CursorVisible = false;
        Console.SetWindowSize(350, 40);
        
        _gameManager.StartGame(StudioClassroom2017());
    }

    static Level StudioClassroom()
    {
        TriggerBox ofirCallTrigger = new TriggerBox(9, 1);
        Cutscene ofirCall = new Cutscene();
        ofirCall.AddLine("Rise and shine Dor Ben Dor, Rise and shine. It is me, Your friend, Ofir Katz, calling you. Listen, Can you come to dizingof center in 1 am? tiltan is probably closed now so i left you the classroom key by your desk, in the green chest with the dollars. as for tiltan's key, i forgot where it is.. so you better find it", _ofirKatz); 
        ofirCall.AddLine("On my way!", _dorBenDor);
        ofirCallTrigger.AddCutscene(ofirCall);
        
        Graphics deskGraphics = new Graphics('.', ConsoleColor.Gray);
        
        // Teacher side
        Actor whiteboard = new Actor(20, 0, 20, 1, new Graphics('|', ConsoleColor.White));
        Actor monitor = new Actor(34, 1, 10, 1, new Graphics('-', ConsoleColor.Black));
        Actor desk = new Actor(7, 2, 7, 1, deskGraphics);
        Actor desk2 = new Actor(6, 0, 1, 3, deskGraphics);
        
        // Students side
        Vector2 deskSize = new Vector2(8, 2);
        Vector2 chairSize = new Vector2(1, 1);

        Graphics chairGraphics = new Graphics('#', ConsoleColor.Blue);

        #region Row1

        Actor desk3 = new Actor(6, 6, deskSize, deskGraphics);
        Actor desk4 = new Actor(16, 6, deskSize, deskGraphics);
        Actor desk5 = new Actor(26, 6, deskSize, deskGraphics);
        Actor desk6 = new Actor(36, 6, deskSize, deskGraphics);
        Actor desk7 = new Actor(46, 6, deskSize, deskGraphics);
        Actor desk8 = new Actor(56, 6, deskSize, deskGraphics);

        #endregion

        #region Row2

        Actor desk9 = new Actor(6, 10, deskSize, deskGraphics);
        Actor desk10 = new Actor(16, 10, deskSize, deskGraphics);
        Actor desk11 = new Actor(26, 10, deskSize, deskGraphics);
        Actor desk12 = new Actor(36, 10, deskSize, deskGraphics);
        Actor desk13 = new Actor(46, 10, deskSize, deskGraphics);
        Actor desk14 = new Actor(56, 10, deskSize, deskGraphics);

        #endregion

        #region Row3

        Actor desk15 = new Actor(6, 14, deskSize, deskGraphics);
        Actor desk16 = new Actor(16, 14, deskSize, deskGraphics);
        Actor desk17 = new Actor(26, 14, deskSize, deskGraphics);
        Actor desk18 = new Actor(36, 14, deskSize, deskGraphics);
        Actor desk19 = new Actor(46, 14, deskSize, deskGraphics);
        Actor desk20 = new Actor(56, 14, deskSize, deskGraphics);

        #endregion

        // Chairs

        #region Row1

        Actor chair1 = new Actor(8, 8, chairSize, chairGraphics);
        Actor chair2 = new Actor(11, 8, chairSize, chairGraphics);
        
        Actor chair3 = new Actor(18, 8, chairSize, chairGraphics);
        Actor chair4 = new Actor(21, 8, chairSize, chairGraphics);
        
        Actor chair6 = new Actor(28, 8, chairSize, chairGraphics);
        Actor chair7 = new Actor(31, 8, chairSize, chairGraphics);
        
        Actor chair8 = new Actor(38, 8, chairSize, chairGraphics);
        Actor chair9 = new Actor(41, 8, chairSize, chairGraphics);
        
        Actor chair10 = new Actor(48, 8, chairSize, chairGraphics);
        Actor chair11 = new Actor(51, 8, chairSize, chairGraphics);
        
        Actor chair12 = new Actor(58, 8, chairSize, chairGraphics);
        Actor chair13 = new Actor(61, 8, chairSize, chairGraphics);

        #endregion
        
        #region Row2

        Actor chair14 = new Actor(8, 12, chairSize, chairGraphics);
        Actor chair15 = new Actor(11, 12, chairSize, chairGraphics);
        
        Actor chair16 = new Actor(18, 12, chairSize, chairGraphics);
        Actor chair17 = new Actor(21, 12, chairSize, chairGraphics);
        
        Actor chair18 = new Actor(28, 12, chairSize, chairGraphics);
        Actor chair19 = new Actor(31, 12, chairSize, chairGraphics);
        
        Actor chair20 = new Actor(38, 12, chairSize, chairGraphics);
        Actor chair21 = new Actor(41, 12, chairSize, chairGraphics);
        
        Actor chair22 = new Actor(48, 12, chairSize, chairGraphics);
        Actor chair23 = new Actor(51, 12, chairSize, chairGraphics);
        
        Actor chair24 = new Actor(58, 12, chairSize, chairGraphics);
        Actor chair25 = new Actor(61, 12, chairSize, chairGraphics);

        #endregion
        
        #region Row3

        Actor chair26 = new Actor(8, 16, chairSize, chairGraphics);
        Actor chair27 = new Actor(11, 16, chairSize, chairGraphics);
        
        Actor chair28 = new Actor(18, 16, chairSize, chairGraphics);
        Actor chair29 = new Actor(21, 16, chairSize, chairGraphics);
        
        Actor chair30 = new Actor(28, 16, chairSize, chairGraphics);
        Actor chair31 = new Actor(31, 16, chairSize, chairGraphics);
        
        Actor chair32 = new Actor(38, 16, chairSize, chairGraphics);
        Actor chair33 = new Actor(41, 16, chairSize, chairGraphics);
        
        Actor chair34 = new Actor(48, 16, chairSize, chairGraphics);
        Actor chair35 = new Actor(51, 16, chairSize, chairGraphics);
        
        Actor chair36 = new Actor(58, 16, chairSize, chairGraphics);
        Actor chair37 = new Actor(61, 16, chairSize, chairGraphics);

        #endregion
        
        // Exit
        Door exitDoor = new Door(62, 0, DoorDirection.Down, Hallway());
        Chest keyChest = new Chest(new Key("The key to the studio class door."), 1, 0);

        Actor[] actors =
        {
            whiteboard, monitor, desk, desk2, desk3, desk4, desk5, desk6, desk7, desk8, desk9, desk10, desk11, desk12, desk13, desk14, desk15, desk16, desk17, desk18, desk19, desk20,
            chair1, chair2, chair3, chair4, chair6, chair7, chair8, chair9, chair10, chair11, chair12, chair13, chair14, chair15, chair16, chair17, chair18, chair19, chair20, chair21, chair22,
            chair23, chair24, chair25, chair26, chair27, chair28, chair29, chair30, chair31, chair32, chair33, chair34, chair35, chair36, chair37, exitDoor, keyChest, ofirCallTrigger
        };

        Level level = Utilities.CreateLevel("Studio class - Tiltan", new Vector2(65, 17), _player, actors);
        return level;
    } // Level 1

    static Level Hallway()
    {
        Graphics wallGraphics = new Graphics('|', ConsoleColor.Black);
        
        Actor wall = new Actor(3, 0, 19, 2, wallGraphics);
        Actor bottomWall = new Actor(0, 4, 17, 2, wallGraphics);
        Actor sideWall = new Actor(19, 4, 3, 2, wallGraphics);
        
        Door studioDoor = new Door(16, 4, DoorDirection.Up, true);
        Door campusDoor = new Door(0, 0, DoorDirection.Down, Tiltan(), false, true);
        
        Actor[] actors = { wall, bottomWall, sideWall, campusDoor, studioDoor };
        
        Level level = Utilities.CreateLevel("Tiltan hallway", new Vector2(22, 6), _player, actors);
        return level;
    } //Level 2

    static Level Tiltan()
    {
        Graphics doorGraphics = new Graphics('&', ConsoleColor.Red);
        Graphics tableGraphics = new Graphics('#', ConsoleColor.Blue);
        Graphics couchGraphics = new Graphics('^', ConsoleColor.Cyan);
        Graphics wallGraphics = new Graphics('|', ConsoleColor.Black);
        
        Door hallwayDoor = new Door(7, 6, DoorDirection.Up, true);
        Door exitDoor = new Door(57, 0, DoorDirection.Down, Train());
        Actor lockedDoor = new Actor(0, 8, 3, 2, doorGraphics);
        Actor lockedDoor2 = new Actor(0, 0, 2, 3, doorGraphics);
        Actor lockedDoor3 = new Actor(12, 8, 3, 2, doorGraphics);
        Actor lockedDoor4 = new Actor(57, 8, 3, 2, doorGraphics);
        
        Actor wall = new Actor(10, 3, 36, 1, wallGraphics);
        Actor wall2 = new Actor(50, 3, 5, 1, wallGraphics);
        Actor wall3 = new Actor(3, 3, 4, 7, wallGraphics);
        Actor wall4 = new Actor(10, 6, 2, 4, wallGraphics);
        Actor wall5 = new Actor(54, 3, 2, 3, wallGraphics);
        Actor wall6 = new Actor(54, 7, 2, 3, wallGraphics);
        Actor wall7 = new Actor(15, 6, 1, 4, wallGraphics);
        Actor wall8 = new Actor(7, 8, 3, 3, wallGraphics);
        Actor wall9 = new Actor(27, 3, 2, 4, wallGraphics);
        Actor wall10 = new Actor(18, 3, 2, 4, wallGraphics);

        Chest vendingMachine = new Chest(new Healing("Pesek Zman", 7, "A nut cream chocolate bar with waffle by Elite (restores 7 HP)."), 45, 8); 
        Chest vendingMachine2 = new Chest(new Key("Who left this key in the vending machine?????????????????????"), 39, 8);

        Actor table = new Actor(33, 6, 1, 1, tableGraphics);
        Actor table2 = new Actor(38, 5, 1, 1, tableGraphics);
        Actor table3 = new Actor(29, 5, 1, 1, tableGraphics);
        Actor table4 = new Actor(35, 7, 1, 1, tableGraphics);
        Actor table5 = new Actor(16, 8, 8, 2, tableGraphics);
        Actor table6 = new Actor(24, 4, 2, 2, tableGraphics);

        Actor couch = new Actor(53, 4, 1, 2, couchGraphics);
        Actor couch2 = new Actor(52, 9, 2, 1, couchGraphics);
        Actor couch3 = new Actor(49, 9, 2, 1, couchGraphics);
        Actor couch4 = new Actor(30, 9, 5, 1, couchGraphics);
        Actor couch5 = new Actor(21, 4, 1, 2, couchGraphics);
        
        Actor[] actors =
        {
            hallwayDoor, exitDoor, wall, wall2, wall3, lockedDoor, lockedDoor2, wall4, lockedDoor3, wall5, wall6, lockedDoor4, vendingMachine, vendingMachine2, table, table2, table3, table4, couch,
            couch2, couch3, couch4, table5, wall7, wall8, wall9, wall10, table6, couch5
        };
        
        Level level = Utilities.CreateLevel("Tiltan Campus (Floor 3)", new Vector2(60, 10), _player, actors);
        return level;
    } //Level 3

    static Level Train()
    {
        TriggerBox trainAnnouncementTrigger = new TriggerBox(38, 2);
        Cutscene trainAnnouncement = new Cutscene();
        trainAnnouncement.AddLine("The next train to Modiiiin Merkaz will enter right away", new SkeletalMesh("Train lady", "a", "Microsoft Zira"));
        trainAnnouncementTrigger.AddCutscene(trainAnnouncement);

        TriggerBox ravPassTrigger = new TriggerBox(5, 4, 10, 1);
        Cutscene ravPass = new Cutscene();
        ravPass.AddLine("Oh. I can't believe it. The gps is gone and saying im in beirut so i can't come in. I will call Ofir to ask what to do", _dorBenDor);
        ravPass.AddLine("Ring Ring... Ring Ring... Ring Ring", new SkeletalMesh("a", "a", "Microsoft Susan"));
        ravPass.AddLine("Hello", _ofirKatz);
        ravPass.AddLine("Ofir, I can't enter the station. What should i do?", _dorBenDor);
        ravPass.AddLine("Try to find a way without the guard seeing you. He looks like red question mark. If he sees you, you will enter a fight. Luckily, most people are dumb, and can only see you from a straight line. So if you are coming diagonally they will not see you. Almost like you are the only real person, and all of the others are just NPCs, Hahahaha, Just kidding.", _ofirKatz);
        ravPass.AddLine("I will call you when i'm there", _dorBenDor);
        
        ravPassTrigger.AddCutscene(ravPass);
        
        Graphics wallGraphics = new Graphics('|', ConsoleColor.Black);
        
        Door entrance = new Door(37, 0, DoorDirection.Down, true);
        Actor exit = new Actor(46, 0, 3, 2, new Graphics('&', ConsoleColor.Red));
        
        Actor train = new Actor(5, 12, 30, 3, new Graphics('-', ConsoleColor.Red));
        Door trainDoor = new Door(7, 12, DoorDirection.Up, Dizingof(), false, true);
        Door trainDoor2 = new Door(17, 12, DoorDirection.Up, Dizingof(), false, true);
        Door trainDoor3 = new Door(27, 12, DoorDirection.Up, Dizingof(), false, true);
        
        Actor train2 = new Actor(5, 17, 30, 3, new Graphics('-', ConsoleColor.Red));

        Actor wall = new Actor(0, 15, 40, 2, wallGraphics);
        Actor wall2 = new Actor(40, 4, 10, 2, wallGraphics);
        Actor wall3 = new Actor(42, 0, 3, 4, wallGraphics);
        Actor wall4 = new Actor(13, 5, 30, 1, wallGraphics);
        Actor wall5 = new Actor(0, 0, 5, 8, wallGraphics);
        Actor wall6 = new Actor(5, 7, 12, 1, wallGraphics);
        Actor wall7 = new Actor(18, 5, 1, 3, wallGraphics);
        Actor wall8 = new Actor(0, 11, 8, 1, wallGraphics);
        Actor wall9 = new Actor(9, 11, 9, 1, wallGraphics);
        Actor wall10 = new Actor(19, 11, 9, 1, wallGraphics);
        Actor wall11 = new Actor(29, 11, 21, 1, wallGraphics);
        Actor wall12 = new Actor(29, 7, 21, 1, wallGraphics);
        Actor wall13 = new Actor(29, 8, 1, 1, wallGraphics);
        
        Chest vending = new Chest(new Healing("cornflakes milk-flavored Crunch", 80, "Limited edition Crunch!!!!!!!! Restores 80 HP!!!!!!!!!!!!!!!!!"), 5, 0);
        Chest vending2 = new Chest(new Healing("Orange juice", 10, "An orange juice by Tapuzina (restores 10 HP)."), 36, 8);
        Chest vending3 = new Chest(new Weapon("Expired food", 20, "An expired food that gives a food poisoning and 20 HP damage"), 0, 9);
        
        Actor[] actors =
        {
            entrance, train, train2, trainDoor, trainDoor2, trainDoor3, wall, wall2, exit, wall3, wall4, wall5, wall6, wall7, wall8, wall9, wall10, wall11, 
            wall12, wall13, vending, vending2, vending3, trainAnnouncementTrigger, ravPassTrigger
        };
        
        Level level = Utilities.CreateLevel("Train station Haifa merkaz hashmona", new Vector2(50, 20), _player, actors);
        return level;
    } //Level 4

    static Level Dizingof()
    {
        TriggerBox callTrigger = new TriggerBox(97, 1);
        Cutscene call = new Cutscene();
        call.AddLine("Ring Ring... Ring Ring... Ring Ring", new SkeletalMesh("a", "a", "Microsoft Susan"));
        call.AddLine("Hello", _ofirKatz);
        call.AddLine("Ofir, I got to dizingof center. Where are you?", _dorBenDor);
        call.AddLine("I'm outside", _ofirKatz);
        call.AddLine("Where is the exit?", _dorBenDor);
        call.AddLine("I literally have no idea", _ofirKatz);
        call.AddLine("I will try to find it", _dorBenDor);
        call.AddLine("Watch out. There are a lot of Center kids there", _ofirKatz);
        call.AddLine("Don't worry", _dorBenDor);
        //callTrigger.AddCutscene(call);
        
        Graphics graphics = new Graphics('#', ConsoleColor.Blue);
        
        Actor actor = new Actor(7, 3, 24, 2, graphics);
        Actor actor2 = new Actor(6, 6, 4, 10, graphics);
        Actor actor3 = new Actor(2, 1, 3, 7, graphics);
        Actor actor4 = new Actor(3, 11, 5, 3, graphics);
        Actor actor5 = new Actor(1, 13, 4, 6, graphics);
        Actor actor6 = new Actor(6, 17, 3, 10, graphics);
        Actor actor7 = new Actor(7, 10, 35, 2, graphics);
        Actor actor8 = new Actor(13, 6, 3, 7, graphics);
        Actor actor9 = new Actor(17, 3, 6, 14, graphics);
        Actor actor10 = new Actor(67, 3, 7, 7, graphics);
        Actor actor11 = new Actor(21, 8, 4, 12, graphics);
        Actor actor12 = new Actor(43, 5, 5, 10, graphics);
        Actor actor13 = new Actor(78, 3, 18, 2, graphics);
        Actor actor14 = new Actor(82, 3, 3, 8, graphics);
        Actor actor15 = new Actor(68, 5, 32, 1, graphics);
        Actor actor16 = new Actor(45, 7, 29, 6, graphics);
        Actor actor17 = new Actor(52, 9, 23, 4, graphics);
        Actor actor18 = new Actor(37, 14, 39, 4, graphics);
        Actor actor19 = new Actor(81, 15, 13, 4, graphics);
        Actor actor20 = new Actor(57, 19, 26, 3, graphics);
        Actor actor21 = new Actor(77, 8, 20, 4, graphics);
        Actor actor22 = new Actor(0, 5, 2, 5, graphics);
        Actor actor23 = new Actor(21, 0, 64, 2, graphics);
        Actor actor24 = new Actor(43, 5, 5, 10, graphics);

        Door doorBenDoor = new Door(97, 17, DoorDirection.Up, TelAviv(), false, true);
        Door door2 = new Door(98, 6, DoorDirection.Left, BooksCrossroad(), false, true);
        Door door3 = new Door(25, 18, DoorDirection.Up, TheThirdEar(), false, true);
        Door exitDoor = new Door(18, 18, DoorDirection.Up, AnimeStore(), false, true);
        Door door5 = new Door(23, 5, DoorDirection.Right, NintendoStore(), false, true);
        Door door6 = new Door(41, 6, DoorDirection.Left, DoctorBack(), false, true);
        Door entrance = new Door(98, 0, DoorDirection.Left, true, true);

        Actor[] actors =
        {
            actor, actor2, actor3, actor4, actor5, actor6, actor7, actor8, actor9, actor10, actor11, actor12, actor13, actor14, actor15, actor16, actor17, actor18, actor19, actor20,
            actor21, actor22, actor23, actor24, doorBenDoor, door2, door3, exitDoor, door5, door6, entrance, callTrigger
        };
        
        Level level = Utilities.CreateLevel("Dizingof Center", new Vector2(100, 20), _player, actors);
        return level;
    } // Level 5

    static Level TelAviv() // Level 6
    {
        TriggerBox entranceTrigger = new TriggerBox(2, 1);
        Cutscene ofir = new Cutscene();
        ofir.AddLine("Dor Ben Dor! You Came! it is me, Ofir Katz! Look what i build! It's a time machine by the way", Program._ofirKatz);
        ofir.AddLine("Wait a minute Ofir, Are you telling me you built a time machine out of a Delorean?", _dorBenDor);
        ofir.AddLine("Well i figured if you gonna build a time machine into a car, Why not do it with some style?", Program._ofirKatz);
        entranceTrigger.AddCutscene(ofir);
        
        Door entrance = new Door(0, 0, DoorDirection.Right, true);
        Door obanKobanDoor = new Door(5, 4, DoorDirection.Up, ObanKoban(), false, true);

        Mesh delorean = new Mesh("                                                                                          \n                                                                      .                   \n                                                                                          \n                                                                  =#*: =.     .::..       \n                                                            ..  .+##=---=    =#####*      \n                                                  ..--:....-:...:-=++=@%%:.-*#####%#-     \n                                             ...:::::---::----::==-*=-=*+--=**+**+%#*     \n                                       .:-====-----::::::::---::---===+-:-+*+******++:    \n                                   .:--:...::--===========-:--=+++**#+=++:=+=*+++**+==-   \n                             .++===-::::::---=====-----=++:=#######%%%#+*#=-+==-------=:  \n                            :=+=-==----============---=*+:=#####%%#*###+++*+---===+*#+:+. \n                        ...:-===++=+#===+++=-----===-=*=:+#####***++===+===+*+-+#%%#+#-:  \n                 . ..::::::::::::::-===+*##%%#+==+===*=:+##%%%%*=========-==*+*#**#%*%*   \n              .:::::::::::::::::::::::::::::--====++++-=+***+++========++=++%##++++#++:   \n        .:.:::::::::::::::::::::::::::::::::::::------============+++++====*#%*==+=#      \n     .=+===------::::::::::::::::::::::::::::--=--------+====++++========+##%%*=++*=      \n   .:*==*+*#*++=====----:::::::::::::::..:-+++=+*#*=--=++*++=--====++**#%%@@@%#****..     \n  .=-=+*++%%%%+*###**++===----:-::.... .==:.:+#%%####+=--=+===+**##%%#%%#**#@@%%#=..      \n   .::.:-+-+###*#%%%%@#++#+++-::.  ::*++.--*%%%#%%@%#=-==+*#%%%%#++==+++======-:...       \n     .*++=-..:--+-+*##*++#+=+::.-..=*%%%#*%%#*+*+*%@###%%%@@%*==+*++=--:::.........       \n     .+*%%%%#*+=-:...:-===+++===*#%%=#%%#@%#*-==+=%%%%%%%%%#**+=--::..........            \n         .:-+*#%@@%#*+=--...:..:%#%%-***@%%*+-+=++%%%%#*++==--::.........                 \n     .....:::-+*##%%%@@@%%#***##%%%%%##%@@%*+++++##*+==--:::.......                       \n    ......:::-==+++***###%%%%%@#**##%%@@@@%%####%*=--::........                           \n      ....::::---====+++++***#####%%%%%%%%%%%#*=-:.........                               \n        ......::::-----=================---::........                                     \n              .......:::::::::::::::::.......                                             \n");
        Teleporter carDoor = new Teleporter(17, 4, 5, 1, new CutsceneLevel(delorean, "F:\\Tiltan\\DungeonCrawler\\DungeonCrawler\\MIDI\\BTTF.mid", TelAviv2017(), _gameManager), new Graphics('_', ConsoleColor.Black));

        Actor ofirKatz = new Actor(13, 5, 1, 1, new Graphics('!', ConsoleColor.DarkRed));

        Actor carWheel = new Actor(17, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carWheel2 = new Actor(21, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        
        Actor[] actors = { entrance, obanKobanDoor, ofirKatz, entranceTrigger, carWheel, carWheel2, carDoor };
        
        Level level = Utilities.CreateLevel("Tel Aviv", new Vector2(22, 6), _player, actors);
        return level;
    }

    static Level TelAviv2017()
    {
        SkeletalMesh randomManSM = new SkeletalMesh("Random Man", "a", "Microsoft Asaf");
        
        TriggerBox entranceTrigger = new TriggerBox(15, 4);
        Cutscene dialog = new Cutscene();
        dialog.AddLine("Wow, I traveled back in time! Excuse me kind sir, what year is it?", _dorBenDor);
        dialog.AddLine("2017", randomManSM);
        dialog.AddLine("And what are those boxes?", _dorBenDor);
        dialog.AddLine("In the left box, some bitcoins. In the right box, all of the stocks of E A, the gaming company.", randomManSM);
        dialog.AddLine("Oh my god! I can buy bitcoins here in the past, and be reach when i go back to the future!", _dorBenDor);
        entranceTrigger.AddCutscene(dialog);
        
        Door door = new Door(5, 4, DoorDirection.Up, NotKoban(), false, true);

        Actor randomMan = new Actor(13, 5, 1, 1, new Graphics('!', ConsoleColor.DarkRed));

        Actor carWheel = new Actor(17, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carWheel2 = new Actor(21, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carBase = new Actor(17, 4, 5, 1, new Graphics('_', ConsoleColor.Black));

        Chest chest = new Chest(new Item("Bitcoin"), 3, 0);
        Cutscene cutscene = new Cutscene();
        cutscene.AddLine("haha i am rich now lol", _dorBenDor);
        chest.AddCutscene(cutscene);
        
        Chest chest2 = new Chest(new Item("EA stocks"), 10, 0);
        Cutscene cutscene2 = new Cutscene();
        cutscene2.AddLine("Oh no. I accidentally took all of the stocks of EA. I guess i am the CEO now", _dorBenDor);
        chest2.AddCutscene(cutscene2);
        
        Actor[] actors = { door, randomMan, entranceTrigger, carWheel, carWheel2, carBase, chest, chest2 };
        
        Level level = Utilities.CreateLevel("Tel Aviv", new Vector2(22, 6), _player, actors, new Vector2(15, 4));
        return level;
    } // Level 7

    static Level NotKoban() // Level 8
    {
        SkeletalMesh managerSM = new SkeletalMesh("Master Koban", "a", "Microsoft Susan");
        
        TriggerBox entranceTrigger = new TriggerBox(34, 4);
        Cutscene entranceCutscene = new Cutscene();
        entranceCutscene.AddLine("Hello!", managerSM);
        entranceCutscene.AddLine("Hi, What happened here?", _dorBenDor);
        entranceCutscene.AddLine("Oh, i am just building a new restaurant called Oban Koban", managerSM);
        entranceCutscene.AddLine("Hey i know this restaurant. i ate there", _dorBenDor);
        entranceCutscene.AddLine("What do you mean you ate there? It's brand new!", managerSM);
        entranceCutscene.AddLine("Anyway, How can i arrive to tiltan?", _dorBenDor);
        entranceCutscene.AddLine("What's tiltan?", managerSM);
        entranceCutscene.AddLine("Sorry i meant mac and learn", _dorBenDor);
        entranceCutscene.AddLine("Oh it's in haifa right pass the back door", managerSM);
        entranceCutscene.AddLine("Thank you", _dorBenDor);
        entranceTrigger.AddCutscene(entranceCutscene);
        
        Graphics tableGraphics = new Graphics('#', ConsoleColor.Blue);
        
        Door door = new Door(35, 3, DoorDirection.Left, true, true);
        Door backDoor = new Door(0, 3, DoorDirection.Right, Tiltan2017(), false, true);
        
        Actor doorCover = new Actor(37, 3, 3, 3, new Graphics('&', ConsoleColor.Red));
        
        Actor cashier = new Actor(20, 2, 16, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(17, 1, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Actor table = new Actor(8, 1, 2, 2, tableGraphics);
        Actor table2 = new Actor(13, 2, 2, 2, tableGraphics);
        Actor table3 = new Actor(17, 4, 2, 2, tableGraphics);
        Actor table4 = new Actor(20, 3, 2, 2, tableGraphics);

        Actor wall = new Actor(35, 2, 5, 1, new Graphics('|', ConsoleColor.Black));
        Actor wall2 = new Actor(0, 0, 6, 2, new Graphics('|', ConsoleColor.Black));

        Actor manager = new Actor(24, 1, 1, 1 , new Graphics('!', ConsoleColor.DarkRed));
        
        Actor[] actors =
        {
            door, cashier, cashier2, table, table2, table3, table4, wall, doorCover, wall2, entranceTrigger, manager, backDoor
        };
        
        Level level = Utilities.CreateLevel("Not Oban Koban", 40, 6, _player, actors);
        
        return level;
    }

    static Level Tiltan2017()
    {
        TriggerBox entranceTrigger = new TriggerBox(58, 2);
        Cutscene entranceCutscene = new Cutscene();
        entranceCutscene.AddLine("Wow, how empty was this place in 2017", _dorBenDor);
        entranceCutscene.AddLine("I'll go search Ofir Katz now, He is probably in the studio classroom", _dorBenDor);
        entranceTrigger.AddCutscene(entranceCutscene);
        
        Graphics doorGraphics = new Graphics('&', ConsoleColor.Red);
        Graphics wallGraphics = new Graphics('|', ConsoleColor.Black);
        
        Door hallwayDoor = new Door(7, 6, DoorDirection.Up, Hallway2017(), false, true);
        Door exitDoor = new Door(57, 0, DoorDirection.Down, true);
        Actor lockedDoor = new Actor(0, 8, 3, 2, doorGraphics);
        Actor lockedDoor2 = new Actor(0, 0, 2, 3, doorGraphics);
        Actor lockedDoor3 = new Actor(12, 8, 3, 2, doorGraphics);
        Actor lockedDoor4 = new Actor(57, 8, 3, 2, doorGraphics);
        
        Actor wall = new Actor(10, 3, 36, 1, wallGraphics);
        Actor wall2 = new Actor(50, 3, 5, 1, wallGraphics);
        Actor wall3 = new Actor(3, 3, 4, 7, wallGraphics);
        Actor wall4 = new Actor(10, 6, 2, 4, wallGraphics);
        Actor wall5 = new Actor(54, 3, 2, 3, wallGraphics);
        Actor wall6 = new Actor(54, 7, 2, 3, wallGraphics);
        Actor wall7 = new Actor(15, 6, 1, 4, wallGraphics);
        Actor wall8 = new Actor(7, 8, 3, 3, wallGraphics);
        Actor wall9 = new Actor(27, 3, 2, 4, wallGraphics);
        Actor wall10 = new Actor(18, 3, 2, 4, wallGraphics);
        
        Actor[] actors =
        {
            hallwayDoor, exitDoor, wall, wall2, wall3, lockedDoor, lockedDoor2, wall4, lockedDoor3, wall5, wall6, lockedDoor4, wall7, wall8, wall9, wall10, entranceTrigger
        };
        
        Level level = Utilities.CreateLevel("Mac and learn Campus (Floor 3)", new Vector2(60, 10), _player, actors);
        return level;
    } // Level 9
    
    static Level Hallway2017()
    {
        Graphics wallGraphics = new Graphics('|', ConsoleColor.Black);
        
        Actor wall = new Actor(3, 0, 19, 2, wallGraphics);
        Actor bottomWall = new Actor(0, 4, 17, 2, wallGraphics);
        Actor sideWall = new Actor(19, 4, 3, 2, wallGraphics);
        
        Door studioDoor = new Door(16, 4, DoorDirection.Up, StudioClassroom2017(), false, true);
        Door campusDoor = new Door(0, 0, DoorDirection.Down, true, true);
        
        Actor[] actors = { wall, bottomWall, sideWall, campusDoor, studioDoor };
        
        Level level = Utilities.CreateLevel("Mac and learn hallway", new Vector2(22, 6), _player, actors);
        return level;
    } //Level 10
    
    static Level StudioClassroom2017()
    {
        TriggerBox entranceTrigger = new TriggerBox(63, 2);
        Cutscene entranceCutscene = new Cutscene();
        entranceCutscene.AddLine("Hello Ofir", _dorBenDor);
        entranceCutscene.AddLine("Who the hell are you?", _ofirKatz);
        entranceCutscene.AddLine("Your friend, Dor Ben Dor. I'm from the future, and i came here in a time machine that you invented", _dorBenDor);
        entranceCutscene.AddLine("Your lying", _ofirKatz);
        entranceCutscene.AddLine("No i dont", _dorBenDor);
        entranceCutscene.AddLine("Prove it", _ofirKatz);
        entranceCutscene.AddLine("Grime is currently in development", _dorBenDor);
        entranceCutscene.AddLine("Holy shit. I haven't told anyone about grime yet.", _ofirKatz);
        entranceCutscene.AddLine("Do you know what that means?", _ofirKatz);
        entranceCutscene.AddLine("What?", _dorBenDor);
        entranceCutscene.AddLine("I finally invented something that works!", _ofirKatz);
        entranceCutscene.AddLine("Yes here's a picture of mine from the future", _dorBenDor);
        entranceCutscene.AddLine("Can you come and show me this?", _ofirKatz);
        entranceCutscene.AddLine("Coming", _dorBenDor);
        entranceTrigger.AddCutscene(entranceCutscene);

        Mesh Dor = new Mesh("$$\\      $$\\  $$$$$$\\  $$$$$$$\\  $$$$$$$$\\       $$\\      $$\\ $$$$$$\\ $$$$$$$$\\ $$\\   $$\\        $$$$$$\\    $$\\ $$\\   \n$$$\\    $$$ |$$  __$$\\ $$  __$$\\ $$  _____|      $$ | $\\  $$ |\\_$$  _|\\__$$  __|$$ |  $$ |      $$  __$$\\   $$ \\$$ \\  \n$$$$\\  $$$$ |$$ /  $$ |$$ |  $$ |$$ |            $$ |$$$\\ $$ |  $$ |     $$ |   $$ |  $$ |      $$ /  \\__|$$$$$$$$$$\\ \n$$\\$$\\$$ $$ |$$$$$$$$ |$$ |  $$ |$$$$$\\          $$ $$ $$\\$$ |  $$ |     $$ |   $$$$$$$$ |      $$ |      \\_$$  $$   |\n$$ \\$$$  $$ |$$  __$$ |$$ |  $$ |$$  __|         $$$$  _$$$$ |  $$ |     $$ |   $$  __$$ |      $$ |      $$$$$$$$$$\\ \n$$ |\\$  /$$ |$$ |  $$ |$$ |  $$ |$$ |            $$$  / \\$$$ |  $$ |     $$ |   $$ |  $$ |      $$ |  $$\\ \\_$$  $$  _|\n$$ | \\_/ $$ |$$ |  $$ |$$$$$$$  |$$$$$$$$\\       $$  /   \\$$ |$$$$$$\\    $$ |   $$ |  $$ |      \\$$$$$$  |  $$ |$$ |  \n\\__|     \\__|\\__|  \\__|\\_______/ \\________|      \\__/     \\__|\\______|   \\__|   \\__|  \\__|       \\______/   \\__|\\__|  \n                                                                                                                     \n**************************************************\n**************************************************\n*****************##*******************************\n***************#%%%%%##%##************************\n**************%%%%@%%%%%%%%#**********************\n**************#%%++===+#%%%@%*********************\n*****************=+**++*%%#%%*********************\n****************+=##*+**%%#%%*********************\n***************==+#====#%%%**###******************\n***************##****##%@%*+*++**##***************\n***************#*=+*%%@%%+=++==+++**#*************\n***************#%%%%%%%*+++===+#+=+**#************\n***************+#%#**+++====++#%#++=+*#***********\n**************=-+*#*++++++***###%*+++=*#**********\n**************-=*#*#+===+++***###**=-=+#**********\n**************-+#****+=====+*###****++##**********\n**************-+##***%%+*+#%%%%%****++*#**********\n**************=+*#****#%###%###%#**=-==#**********\n********************##%%###**###%#**+##***********\n********************##%*******##%*****************\n********************#%%#*****####*****************\n***************#%#***##%%%%%%#***#%%#*************\n****************####################**************\n**************************************************\n**************************************************\n\n");
        Teleporter pictureTrigger = new Teleporter(10, 0, new CutsceneLevel(Dor, StudioClassroom20172(), _gameManager));
        
        Graphics deskGraphics = new Graphics('.', ConsoleColor.Gray);
        
        // Teacher side
        Actor whiteboard = new Actor(20, 0, 20, 1, new Graphics('|', ConsoleColor.White));
        Actor monitor = new Actor(34, 1, 10, 1, new Graphics('-', ConsoleColor.Black));
        Actor desk = new Actor(7, 2, 7, 1, deskGraphics);
        Actor desk2 = new Actor(6, 0, 1, 3, deskGraphics);
        
        // Students side
        Vector2 deskSize = new Vector2(8, 2);
        Vector2 chairSize = new Vector2(1, 1);

        Graphics chairGraphics = new Graphics('#', ConsoleColor.Blue);

        #region Row1

        Actor desk3 = new Actor(6, 6, deskSize, deskGraphics);
        Actor desk4 = new Actor(16, 6, deskSize, deskGraphics);
        Actor desk5 = new Actor(26, 6, deskSize, deskGraphics);
        Actor desk6 = new Actor(36, 6, deskSize, deskGraphics);
        Actor desk7 = new Actor(46, 6, deskSize, deskGraphics);
        Actor desk8 = new Actor(56, 6, deskSize, deskGraphics);

        #endregion

        #region Row2

        Actor desk9 = new Actor(6, 10, deskSize, deskGraphics);
        Actor desk10 = new Actor(16, 10, deskSize, deskGraphics);
        Actor desk11 = new Actor(26, 10, deskSize, deskGraphics);
        Actor desk12 = new Actor(36, 10, deskSize, deskGraphics);
        Actor desk13 = new Actor(46, 10, deskSize, deskGraphics);
        Actor desk14 = new Actor(56, 10, deskSize, deskGraphics);

        #endregion

        #region Row3

        Actor desk15 = new Actor(6, 14, deskSize, deskGraphics);
        Actor desk16 = new Actor(16, 14, deskSize, deskGraphics);
        Actor desk17 = new Actor(26, 14, deskSize, deskGraphics);
        Actor desk18 = new Actor(36, 14, deskSize, deskGraphics);
        Actor desk19 = new Actor(46, 14, deskSize, deskGraphics);
        Actor desk20 = new Actor(56, 14, deskSize, deskGraphics);

        #endregion

        // Chairs

        #region Row1

        Actor chair1 = new Actor(8, 8, chairSize, chairGraphics);
        Actor chair2 = new Actor(11, 8, chairSize, chairGraphics);
        
        Actor chair3 = new Actor(18, 8, chairSize, chairGraphics);
        Actor chair4 = new Actor(21, 8, chairSize, chairGraphics);
        
        Actor chair6 = new Actor(28, 8, chairSize, chairGraphics);
        Actor chair7 = new Actor(31, 8, chairSize, chairGraphics);
        
        Actor chair8 = new Actor(38, 8, chairSize, chairGraphics);
        Actor chair9 = new Actor(41, 8, chairSize, chairGraphics);
        
        Actor chair10 = new Actor(48, 8, chairSize, chairGraphics);
        Actor chair11 = new Actor(51, 8, chairSize, chairGraphics);
        
        Actor chair12 = new Actor(58, 8, chairSize, chairGraphics);
        Actor chair13 = new Actor(61, 8, chairSize, chairGraphics);

        #endregion
        
        #region Row2

        Actor chair14 = new Actor(8, 12, chairSize, chairGraphics);
        Actor chair15 = new Actor(11, 12, chairSize, chairGraphics);
        
        Actor chair16 = new Actor(18, 12, chairSize, chairGraphics);
        Actor chair17 = new Actor(21, 12, chairSize, chairGraphics);
        
        Actor chair18 = new Actor(28, 12, chairSize, chairGraphics);
        Actor chair19 = new Actor(31, 12, chairSize, chairGraphics);
        
        Actor chair20 = new Actor(38, 12, chairSize, chairGraphics);
        Actor chair21 = new Actor(41, 12, chairSize, chairGraphics);
        
        Actor chair22 = new Actor(48, 12, chairSize, chairGraphics);
        Actor chair23 = new Actor(51, 12, chairSize, chairGraphics);
        
        Actor chair24 = new Actor(58, 12, chairSize, chairGraphics);
        Actor chair25 = new Actor(61, 12, chairSize, chairGraphics);

        #endregion
        
        #region Row3

        Actor chair26 = new Actor(8, 16, chairSize, chairGraphics);
        Actor chair27 = new Actor(11, 16, chairSize, chairGraphics);
        
        Actor chair28 = new Actor(18, 16, chairSize, chairGraphics);
        Actor chair29 = new Actor(21, 16, chairSize, chairGraphics);
        
        Actor chair30 = new Actor(28, 16, chairSize, chairGraphics);
        Actor chair31 = new Actor(31, 16, chairSize, chairGraphics);
        
        Actor chair32 = new Actor(38, 16, chairSize, chairGraphics);
        Actor chair33 = new Actor(41, 16, chairSize, chairGraphics);
        
        Actor chair34 = new Actor(48, 16, chairSize, chairGraphics);
        Actor chair35 = new Actor(51, 16, chairSize, chairGraphics);
        
        Actor chair36 = new Actor(58, 16, chairSize, chairGraphics);
        Actor chair37 = new Actor(61, 16, chairSize, chairGraphics);

        #endregion
        
        // Exit
        Door exitDoor = new Door(62, 0, DoorDirection.Down, true, true);

        Enemy ofirKatz = new Enemy(new Vector2(9, 1), "Ofir Katz");

        Actor[] actors =
        {
            whiteboard, monitor, desk, desk2, desk3, desk4, desk5, desk6, desk7, desk8, desk9, desk10, desk11, desk12, desk13, desk14, desk15, desk16, desk17, desk18, desk19, desk20,
            chair1, chair2, chair3, chair4, chair6, chair7, chair8, chair9, chair10, chair11, chair12, chair13, chair14, chair15, chair16, chair17, chair18, chair19, chair20, chair21, chair22,
            chair23, chair24, chair25, chair26, chair27, chair28, chair29, chair30, chair31, chair32, chair33, chair34, chair35, chair36, chair37, exitDoor, entranceTrigger, ofirKatz, pictureTrigger
        };

        Level level = Utilities.CreateLevel("Studio class - Mac and learn", new Vector2(65, 17), _player, actors);
        return level;
    } // Level 11
    
    static Level StudioClassroom20172()
    {
        TriggerBox entranceTrigger = new TriggerBox(63, 2);
        Cutscene entranceCutscene = new Cutscene();
        entranceCutscene.AddLine("Wow very cool", _ofirKatz);
        entranceCutscene.AddLine("Anyway, We need to get you back to the future", _ofirKatz);
        entranceCutscene.AddLine("Yes we just need 1.21 gigawatts", _dorBenDor);
        entranceCutscene.AddLine("Ok never mind you stuck here", _ofirKatz);
        entranceCutscene.AddLine("Next week Apple are introducing the Vision Pro with 1.21 gigawatts battery", _dorBenDor);
        entranceCutscene.AddLine("Great so we will use that.", _ofirKatz);
        entranceCutscene.AddLine("I'll wait for you at floor 0. Come when you ready", _ofirKatz);
        entranceTrigger.AddCutscene(entranceCutscene);
        
        Graphics deskGraphics = new Graphics('.', ConsoleColor.Gray);
        
        // Teacher side
        Actor whiteboard = new Actor(20, 0, 20, 1, new Graphics('|', ConsoleColor.White));
        Actor monitor = new Actor(34, 1, 10, 1, new Graphics('-', ConsoleColor.Black));
        Actor desk = new Actor(7, 2, 7, 1, deskGraphics);
        Actor desk2 = new Actor(6, 0, 1, 3, deskGraphics);
        
        // Students side
        Vector2 deskSize = new Vector2(8, 2);
        Vector2 chairSize = new Vector2(1, 1);

        Graphics chairGraphics = new Graphics('#', ConsoleColor.Blue);

        #region Row1

        Actor desk3 = new Actor(6, 6, deskSize, deskGraphics);
        Actor desk4 = new Actor(16, 6, deskSize, deskGraphics);
        Actor desk5 = new Actor(26, 6, deskSize, deskGraphics);
        Actor desk6 = new Actor(36, 6, deskSize, deskGraphics);
        Actor desk7 = new Actor(46, 6, deskSize, deskGraphics);
        Actor desk8 = new Actor(56, 6, deskSize, deskGraphics);

        #endregion

        #region Row2

        Actor desk9 = new Actor(6, 10, deskSize, deskGraphics);
        Actor desk10 = new Actor(16, 10, deskSize, deskGraphics);
        Actor desk11 = new Actor(26, 10, deskSize, deskGraphics);
        Actor desk12 = new Actor(36, 10, deskSize, deskGraphics);
        Actor desk13 = new Actor(46, 10, deskSize, deskGraphics);
        Actor desk14 = new Actor(56, 10, deskSize, deskGraphics);

        #endregion

        #region Row3

        Actor desk15 = new Actor(6, 14, deskSize, deskGraphics);
        Actor desk16 = new Actor(16, 14, deskSize, deskGraphics);
        Actor desk17 = new Actor(26, 14, deskSize, deskGraphics);
        Actor desk18 = new Actor(36, 14, deskSize, deskGraphics);
        Actor desk19 = new Actor(46, 14, deskSize, deskGraphics);
        Actor desk20 = new Actor(56, 14, deskSize, deskGraphics);

        #endregion

        // Chairs

        #region Row1

        Actor chair1 = new Actor(8, 8, chairSize, chairGraphics);
        Actor chair2 = new Actor(11, 8, chairSize, chairGraphics);
        
        Actor chair3 = new Actor(18, 8, chairSize, chairGraphics);
        Actor chair4 = new Actor(21, 8, chairSize, chairGraphics);
        
        Actor chair6 = new Actor(28, 8, chairSize, chairGraphics);
        Actor chair7 = new Actor(31, 8, chairSize, chairGraphics);
        
        Actor chair8 = new Actor(38, 8, chairSize, chairGraphics);
        Actor chair9 = new Actor(41, 8, chairSize, chairGraphics);
        
        Actor chair10 = new Actor(48, 8, chairSize, chairGraphics);
        Actor chair11 = new Actor(51, 8, chairSize, chairGraphics);
        
        Actor chair12 = new Actor(58, 8, chairSize, chairGraphics);
        Actor chair13 = new Actor(61, 8, chairSize, chairGraphics);

        #endregion
        
        #region Row2

        Actor chair14 = new Actor(8, 12, chairSize, chairGraphics);
        Actor chair15 = new Actor(11, 12, chairSize, chairGraphics);
        
        Actor chair16 = new Actor(18, 12, chairSize, chairGraphics);
        Actor chair17 = new Actor(21, 12, chairSize, chairGraphics);
        
        Actor chair18 = new Actor(28, 12, chairSize, chairGraphics);
        Actor chair19 = new Actor(31, 12, chairSize, chairGraphics);
        
        Actor chair20 = new Actor(38, 12, chairSize, chairGraphics);
        Actor chair21 = new Actor(41, 12, chairSize, chairGraphics);
        
        Actor chair22 = new Actor(48, 12, chairSize, chairGraphics);
        Actor chair23 = new Actor(51, 12, chairSize, chairGraphics);
        
        Actor chair24 = new Actor(58, 12, chairSize, chairGraphics);
        Actor chair25 = new Actor(61, 12, chairSize, chairGraphics);

        #endregion
        
        #region Row3

        Actor chair26 = new Actor(8, 16, chairSize, chairGraphics);
        Actor chair27 = new Actor(11, 16, chairSize, chairGraphics);
        
        Actor chair28 = new Actor(18, 16, chairSize, chairGraphics);
        Actor chair29 = new Actor(21, 16, chairSize, chairGraphics);
        
        Actor chair30 = new Actor(28, 16, chairSize, chairGraphics);
        Actor chair31 = new Actor(31, 16, chairSize, chairGraphics);
        
        Actor chair32 = new Actor(38, 16, chairSize, chairGraphics);
        Actor chair33 = new Actor(41, 16, chairSize, chairGraphics);
        
        Actor chair34 = new Actor(48, 16, chairSize, chairGraphics);
        Actor chair35 = new Actor(51, 16, chairSize, chairGraphics);
        
        Actor chair36 = new Actor(58, 16, chairSize, chairGraphics);
        Actor chair37 = new Actor(61, 16, chairSize, chairGraphics);

        #endregion
        
        // Exit
        Door exitDoor = new Door(62, 0, DoorDirection.Down, Floor0(), false, true);

        Enemy ofirKatz = new Enemy(new Vector2(9, 1), "Ofir Katz");

        Actor[] actors =
        {
            whiteboard, monitor, desk, desk2, desk3, desk4, desk5, desk6, desk7, desk8, desk9, desk10, desk11, desk12, desk13, desk14, desk15, desk16, desk17, desk18, desk19, desk20,
            chair1, chair2, chair3, chair4, chair6, chair7, chair8, chair9, chair10, chair11, chair12, chair13, chair14, chair15, chair16, chair17, chair18, chair19, chair20, chair21, chair22,
            chair23, chair24, chair25, chair26, chair27, chair28, chair29, chair30, chair31, chair32, chair33, chair34, chair35, chair36, chair37, exitDoor, entranceTrigger, ofirKatz
        };

        Level level = Utilities.CreateLevel("Studio class - Mac and learn", new Vector2(65, 17), _player, actors);
        return level;
    } // Level 12
    
    static Level Floor0() // Level 13
    {
        TriggerBox entranceTrigger = new TriggerBox(1, 3);
        Cutscene ofir = new Cutscene();
        ofir.AddLine("Dor Ben Dor! You Came! it is me, Ofir Katz! Look what i build! It's a time machine by the way", Program._ofirKatz);
        ofir.AddLine("Wait a minute Ofir, Are you telling me you built a time machine out of a Delorean?", _dorBenDor);
        ofir.AddLine("Well i figured if you gonna build a time machine into a car, Why not do it with some style?", Program._ofirKatz);
        entranceTrigger.AddCutscene(ofir);
        
        Door entrance = new Door(0, 0, DoorDirection.Up, false, true);
        Door exit = new Door(3, 4, DoorDirection.Left, true, true);

        Mesh delorean = new Mesh("                                                                                          \n                                                                      .                   \n                                                                                          \n                                                                  =#*: =.     .::..       \n                                                            ..  .+##=---=    =#####*      \n                                                  ..--:....-:...:-=++=@%%:.-*#####%#-     \n                                             ...:::::---::----::==-*=-=*+--=**+**+%#*     \n                                       .:-====-----::::::::---::---===+-:-+*+******++:    \n                                   .:--:...::--===========-:--=+++**#+=++:=+=*+++**+==-   \n                             .++===-::::::---=====-----=++:=#######%%%#+*#=-+==-------=:  \n                            :=+=-==----============---=*+:=#####%%#*###+++*+---===+*#+:+. \n                        ...:-===++=+#===+++=-----===-=*=:+#####***++===+===+*+-+#%%#+#-:  \n                 . ..::::::::::::::-===+*##%%#+==+===*=:+##%%%%*=========-==*+*#**#%*%*   \n              .:::::::::::::::::::::::::::::--====++++-=+***+++========++=++%##++++#++:   \n        .:.:::::::::::::::::::::::::::::::::::::------============+++++====*#%*==+=#      \n     .=+===------::::::::::::::::::::::::::::--=--------+====++++========+##%%*=++*=      \n   .:*==*+*#*++=====----:::::::::::::::..:-+++=+*#*=--=++*++=--====++**#%%@@@%#****..     \n  .=-=+*++%%%%+*###**++===----:-::.... .==:.:+#%%####+=--=+===+**##%%#%%#**#@@%%#=..      \n   .::.:-+-+###*#%%%%@#++#+++-::.  ::*++.--*%%%#%%@%#=-==+*#%%%%#++==+++======-:...       \n     .*++=-..:--+-+*##*++#+=+::.-..=*%%%#*%%#*+*+*%@###%%%@@%*==+*++=--:::.........       \n     .+*%%%%#*+=-:...:-===+++===*#%%=#%%#@%#*-==+=%%%%%%%%%#**+=--::..........            \n         .:-+*#%@@%#*+=--...:..:%#%%-***@%%*+-+=++%%%%#*++==--::.........                 \n     .....:::-+*##%%%@@@%%#***##%%%%%##%@@%*+++++##*+==--:::.......                       \n    ......:::-==+++***###%%%%%@#**##%%@@@@%%####%*=--::........                           \n      ....::::---====+++++***#####%%%%%%%%%%%#*=-:.........                               \n        ......::::-----=================---::........                                     \n              .......:::::::::::::::::.......                                             \n");
        //Teleporter carDoor = new Teleporter(17, 4, 5, 1, new CutsceneLevel(delorean, "F:\\Tiltan\\DungeonCrawler\\DungeonCrawler\\MIDI\\BTTF.mid", TelAviv2017(), _gameManager), new Graphics('_', ConsoleColor.Black));

        Actor ofirKatz = new Actor(1, 6, 1, 1, new Graphics('!', ConsoleColor.DarkRed));
        
        Actor[] actors = { entrance, ofirKatz, entranceTrigger};
        
        Level level = Utilities.CreateLevel("Mac and learn (Floor 0)", 5, _player, actors);
        return level;
    }

    static Level ObanKoban()
    {
        Graphics tableGraphics = new Graphics('#', ConsoleColor.Blue);
        
        Door door = new Door(35, 3, DoorDirection.Left, true, true);
        Actor doorCover = new Actor(37, 3, 3, 3, new Graphics('&', ConsoleColor.Red));
        
        Actor cashier = new Actor(6, 1, 16, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(22, 0, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Actor table = new Actor(2, 4, 2, 2, tableGraphics);
        Actor table2 = new Actor(8, 4, 2, 2, tableGraphics);
        Actor table3 = new Actor(14, 4, 2, 2, tableGraphics);
        Actor table4 = new Actor(20, 4, 2, 2, tableGraphics);
        Actor table5 = new Actor(26, 4, 2, 2, tableGraphics);
        Actor table6 = new Actor(25, 0, 2, 2, tableGraphics);
        Actor table7 = new Actor(30, 0, 2, 2, tableGraphics);
        Actor table8 = new Actor(35, 0, 4, 1, tableGraphics);

        Actor wall = new Actor(35, 2, 5, 1, new Graphics('|', ConsoleColor.Black));
        Actor wall2 = new Actor(0, 0, 6, 2, new Graphics('|', ConsoleColor.Black));
        
        Chest chest = new Chest(new Healing("Shibuia Ramen", 76, "Delicate fish and pork stock, Japanese spices, sesame, ramen noodles, a piece of pork, Half an egg, bamboo shoots, shiitake mushrooms, spinach, sprouts, green onions."), 0, 1);
        
        Actor[] actors =
        {
            door, cashier, cashier2, table, table2, table3, table4, table5, table6, table7, table8, wall, doorCover, wall2, chest
            
        };
        
        Level level = Utilities.CreateLevel("Oban Koban", 40, 6, _player, actors);
        
        Enemy enemy = Utilities.GenerateEnemy(level, "Angry customer (He got napkin in 2 minutes instead of 1 minute)");
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
    
    static Level AnimeStore()
    {
        Door door = new Door(0, 0, DoorDirection.Down, true, true);
        
        Actor cashier = new Actor(0, 7, 4, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(4, 7, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Chest chest = new Chest(new Item("Anime", "A series about people who die and reborn as Noa Kirel's children."), 17, 2);
        Chest chest2 = new Chest(new Weapon("Death note", 100, "The human whose name is written in this note shall die."), 17, 5);
        
        Actor[] actors =
        {
            door, cashier, cashier2, chest, chest2
        };
        
        Level level = Utilities.CreateLevel("Anime Store", 10, _player, actors);
        
        Enemy enemy = Utilities.GenerateEnemy(level, "Store's manager");
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
    
    static Level NintendoStore()
    {
        Door door = new Door(0, 0, DoorDirection.Down, true, true);
        
        Actor cashier = new Actor(0, 7, 4, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(4, 7, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Chest chest = new Chest(new Item("Joy con with drift", "This is useless"), 17, 2);
        Chest chest2 = new Chest(new Weapon("Fireball", 42, "They made mario's fire ball in real life and he can deal 42 HP damage holy shit!!!!!!!"), 17, 5);
        
        Actor[] actors =
        {
            door, cashier, cashier2, chest, chest2
        };
        
        Level level = Utilities.CreateLevel("Nintendo Store", 10, _player, actors);
        
        Enemy enemy = Utilities.GenerateEnemy(level, "Store's manager");
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
    
    static Level DoctorBack()
    {
        Door door = new Door(0, 0, DoorDirection.Down, true, true);
        
        Actor cashier = new Actor(0, 7, 4, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(4, 7, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Chest chest = new Chest(new Item("Chair", "I can sit on this"), 17, 2);
        Chest chest2 = new Chest(new Weapon("Gaming bad", 42, "This bad gives me gaming skills! I can now deal 69 damage to others!!!!!!!!!"), 17, 5);
        
        Actor[] actors =
        {
            door, cashier, cashier2, chest, chest2
        };
        
        Level level = Utilities.CreateLevel("Doctor Gav", 10, _player, actors);
        
        Enemy enemy = Utilities.GenerateEnemy(level, "Doctor Gav");
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
    
    static Level TheThirdEar()
    {
        Door door = new Door(0, 0, DoorDirection.Down, true, true);
        
        Actor cashier = new Actor(0, 7, 4, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(4, 7, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Chest chest = new Chest(new Item("Vinyl", "A vinyl of \"Sex Bob-Omb\". I heard the bass player had to fight 7 evil exes."), 17, 2);
        Chest chest2 = new Chest(new Weapon("Small bag", 34, "The small bag from the song \"Small bag\". This song is so bad... Everyone who hears this gets an 30 HP damage."), 17, 5);
        
        Actor[] actors =
        {
            door, cashier, cashier2, chest, chest2
        };
        
        Level level = Utilities.CreateLevel("The third ear", 10, _player, actors);
        
        Enemy enemy = Utilities.GenerateEnemy(level, "A guy with 3 ears");
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
    
    static Level BooksCrossroad()
    {
        Door door = new Door(0, 0, DoorDirection.Down, true, true);
        
        Actor cashier = new Actor(0, 7, 4, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(4, 7, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Chest chest = new Chest(new Item("Ready Player One", "VR is crazy these days."), 17, 2);
        Chest chest2 = new Chest(new Item("Ready Player Two", "VR is crazier these days."), 17, 5);
        
        Actor[] actors =
        {
            door, cashier, cashier2, chest, chest2
        };
        
        Level level = Utilities.CreateLevel("Nintendo Store", 10, _player, actors);
        
        Enemy enemy = Utilities.GenerateEnemy(level, "Store's manager");
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
}