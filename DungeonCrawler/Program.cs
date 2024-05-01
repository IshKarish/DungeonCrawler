namespace DungeonCrawler;

class Program
{
    private static Player _player = new Player(new Graphics('*', ConsoleColor.White));
    //private static SkeletalMesh _dorBenDor = new SkeletalMesh("Dor Ben Dor", "tfjnygvh", "Microsoft George");
    //private static SkeletalMesh _ofirKatz = new SkeletalMesh("Ofir Katz", "tfjnygvh", "Microsoft David Desktop", 80);

    private static GameManager _gameManager = new GameManager();
    
    public static void Main(string[] args)
    {
        ConsoleHelperLibrary.Classes.WindowUtility.SetConsoleWindowPosition(ConsoleHelperLibrary.Classes.WindowUtility.AnchorWindow.Fill);
        Console.CursorVisible = false;
        
        Start();
    }

    public static void Start()
    { 
        Console.Clear();
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("$$\\   $$\\  $$$$$$\\  $$\\       $$$$$$$$\\       $$\\       $$$$$$\\ $$$$$$$$\\ $$$$$$$$\\        $$$$$$\\  \n$$ |  $$ |$$  __$$\\ $$ |      $$  _____|      $$ |      \\_$$  _|$$  _____|$$  _____|      $$ ___$$\\ \n$$ |  $$ |$$ /  $$ |$$ |      $$ |            $$ |        $$ |  $$ |      $$ |            \\_/   $$ |\n$$$$$$$$ |$$$$$$$$ |$$ |      $$$$$\\          $$ |        $$ |  $$$$$\\    $$$$$\\            $$$$$ / \n$$  __$$ |$$  __$$ |$$ |      $$  __|         $$ |        $$ |  $$  __|   $$  __|           \\___$$\\ \n$$ |  $$ |$$ |  $$ |$$ |      $$ |            $$ |        $$ |  $$ |      $$ |            $$\\   $$ |\n$$ |  $$ |$$ |  $$ |$$$$$$$$\\ $$ |            $$$$$$$$\\ $$$$$$\\ $$ |      $$$$$$$$\\       \\$$$$$$  |\n\\__|  \\__|\\__|  \\__|\\________|\\__|            \\________|\\______|\\__|      \\________|       \\______/ ");
        Console.WriteLine();
        Console.WriteLine("A game by The Banana Project");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press T to play the tutorial");
        Console.WriteLine("Press any other key to start the game.");

        ConsoleKey c = Console.ReadKey(true).Key;
        if (c == ConsoleKey.T) _gameManager.StartGame(Tutorial());
        else
        {
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("     ");
            Renderer.Write("There once was a Dor... \n     His name was Ben Dor.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(2000);
            Console.WriteLine("     Press Any Key to continue...");
            
            Console.ReadKey();
                    
            _gameManager.StartGame(Floor0());
        }
    }

    #region Tutorial Levels

    static Level Tutorial()
    {
        TriggerBox tutorialTrigger = new TriggerBox(1, 0);
        Sequence tutorial = new Sequence();
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial\\WelcomeToTheTutorialOfHalfLife3.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial\\UseWASDToWalkFToInteractWithStuffAndTabToOpenYourInventory.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial\\YouNeedToWalkThroughThatDoorToContinueButToOpenItYouNeedAKey.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial\\LuckilyThatGreenChestHasAKeyInsideOfIt.wav");
        tutorialTrigger.AddSequance(tutorial);
        
        Door door = new Door(1, 8, DoorDirection.Up, Tutorial2());
        
        Chest chest = new Chest(new Key(), 10, 2);
        
        Actor[] actors =
        {
            door, tutorialTrigger, chest
        };
        
        Level level = Utilities.CreateLevel("Test", 10, _player, actors, new Vector2(1, 0));
        
        return level;
    }
    
    static Level Tutorial2()
    {
        TriggerBox tutorialTrigger = new TriggerBox(2, 2);
        Sequence tutorial = new Sequence();
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial2\\TheNextRoomHasAFightInItSoGearUpWithTheEquipmentFromThoseBoxes.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial2\\AlsoYouCantCarryMoreThen9Items.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial2\\ToDropAnItemJustOpenYourInventoryAndPressOnTheCorrespondingNumber.wav");
        tutorialTrigger.AddSequance(tutorial);

        Door entrance = new Door(1, 0, DoorDirection.Down, true);
        Door door = new Door(1, 8, DoorDirection.Up, Tutorial3(), false, true);
        
        Chest chest = new Chest(new Item("Dor Ben Dor figure", "Comes with the collectors edition"), 17, 2);
        Chest chest2 = new Chest(new Weapon("Sword", 16, "But it's made from plastic so it won't really hurt anyone"), 17, 5);
        Chest chest3 = new Chest(new Healing("Meth", "La ciudad se llama DukeNuevo Mexico, el estado (Heals you bu 69 HP)", 69), 10, 2);
        chest3.AddMidi($"{Environment.CurrentDirectory}\\MIDI\\BreakingBad.mid");
        
        Chest chest4 = new Chest(new Item("Shahar Chocolate", "Das Eina Gutte Kremaev"), 10, 5);
        Chest chest5 = new Chest(new RickRoll(), 3, 2);
        
        Actor[] actors =
        {
            tutorialTrigger, entrance, chest, chest2, chest3, chest4, door, chest5
        };
        
        Level level = Utilities.CreateLevel("Tutorial", 10, _player, actors);
        
        return level;
    }
    
    static Level Tutorial3()
    {
        TriggerBox tutorialTrigger = new TriggerBox(2, 2);
        Sequence tutorial = new Sequence();
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial3\\WhenYouEnterTheFightYouCanChooseToPunchTalkUseKillYourselfOrCheatAndKillTheEnemyRightAway.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial3\\ThePunchOptionHasAChanceOfDamagingTheEnemyButYouMightMiss.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial3\\YouCanTryToReasonWithTheEnemyByTalkingToHim.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial3\\YouCanUseStuffYouCollectedInTheLevelsToHealYourselfOrHurtTheEnemy.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial3\\AndTheOtherOptionsArePrettySelfExplanatory.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial3\\WhenYouCollideWithAnEnemyYouWillEnterAFightOrYouCanJustBeAChickenAndRun.wav");
        tutorialTrigger.AddSequance(tutorial);
        
        Door entrance = new Door(1, 0, DoorDirection.Down, true);
        Door door = new Door(1, 8, DoorDirection.Up, Tutorial4(), false, true);
        
        Actor[] actors =
        {
            door, tutorialTrigger, entrance
        };
        
        Level level = Utilities.CreateLevel("Tutorial", 10, _player, actors, new Vector2(1, 0));
        
        Enemy enemy = Utilities.GenerateEnemy(level);
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
    
    static Level Tutorial4()
    {
        Graphics graphics = new Graphics('%', ConsoleColor.Cyan);
        
        TriggerBox tutorialTrigger = new TriggerBox(2, 2);
        Sequence tutorial = new Sequence();
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial4\\AlsoTheBriefSaidINeedToCreateTrapsButTheyDontFitInTheActualGame.wav");
        tutorial.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tutorial4\\SoJustWalkOnThoseUntilYouDie.wav");
        tutorialTrigger.AddSequance(tutorial);
        
        Door entrance = new Door(1, 0, DoorDirection.Down, true);

        Actor actor = new Actor(5, 2, 2, 5, graphics);
        Actor actor2 = new Actor(13, 4, 1, 6, graphics);
        Actor actor3 = new Actor(10, 4, 3, 1, graphics);
        
        Trap trap3 = new Trap(TrapDirection.Right, 4, actor);
        Trap trap4 = new Trap(TrapDirection.Left, 4, actor2);
        Trap trap5 = new Trap(TrapDirection.Right, 0, actor3);
        
        Actor[] actors =
        {
            tutorialTrigger, entrance, trap3, trap4, trap5, actor, actor2, actor3
        };
        
        Level level = Utilities.CreateLevel("Tutorial", 10, _player, actors, new Vector2(1, 0));
        
        Trap trap = new Trap(TrapDirection.Right, 4, level.Map);
        Trap trap2 = new Trap(TrapDirection.Left, 7, level.Map);
        level.Map.AddActors(new[] {trap, trap2});
        
        return level;
    }

    #endregion

    #region Levels

    static Level StudioClassroom()
    {
        TriggerBox ofirCallTrigger = new TriggerBox(9, 0);
        Sequence ofirCall = new Sequence();
        ofirCall.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\RiseAndShineDorBenDor.wav"); 
        ofirCall.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\RiseAndShine.wav");
        ofirCall.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\ItIsMeYourFriendOfirKatz.wav");
        ofirCall.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\CanYouComeToDizingofCenter.wav");
        ofirCall.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\TiltanIsProbablyClosedNowSoILeftYouTheClassroomKeyByYourDeskInTheGreenChestWithTheDollars.wav");
        ofirCall.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\AsForTiltansKeyIForgotWhereItIs.wav");
        ofirCall.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\SoYouBetterFindIt.wav");
        ofirCall.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\OnMyWay.wav");
        ofirCallTrigger.AddSequance(ofirCall);
        
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
        
        TriggerBox meTrigger = new TriggerBox(61, 8, 3, 2);
        Sequence withoutMe = new Sequence();
        withoutMe.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom\\PlayingWithoutMe.wav");
        meTrigger.AddSequance(withoutMe);

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
        Actor chair13 = new Actor(61, 8, chairSize, new Graphics('!', ConsoleColor.DarkRed));

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
            meTrigger, whiteboard, monitor, desk, desk2, desk3, desk4, desk5, desk6, desk7, desk8, desk9, desk10, desk11, desk12, desk13, desk14, desk15, desk16, desk17, desk18, desk19, desk20,
            chair1, chair2, chair3, chair4, chair6, chair7, chair8, chair9, chair10, chair11, chair12, chair13, chair14, chair15, chair16, chair17, chair18, chair19, chair20, chair21, chair22,
            chair23, chair24, chair25, chair26, chair27, chair28, chair29, chair30, chair31, chair32, chair33, chair34, chair35, chair36, chair37, exitDoor, keyChest, ofirCallTrigger
        };

        Level level = Utilities.CreateLevel("Studio class - Tiltan", new Vector2(65, 17), _player, actors, new Vector2(9, 0));
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
        Door exitDoor = new Door(57, 0, DoorDirection.Down, TrainStation());
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

        Actor erez = new Actor(7, 2, 1, 1, new Graphics('!', ConsoleColor.DarkRed));
        TriggerBox erezTrigger = new TriggerBox(8, 2, 2, 1);
        Sequence erezSequence = new Sequence();
        erezSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tiltan\\שלוםלךדורבןדורזהאניחאברךהארזיסאחארובמנכלתלתן.wav");
        erezSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tiltan\\הידעתהזמןרבלפנישלתלתןהיהShemמאסטרהספינגיטסוהראשוןיצראתחיפה.wav");
        erezSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tiltan\\והשםהראשוןשחשבנועליולמכללההיהמאקולמדעלשםמערכתההפעלההמצליחההמשומשתבידירביםלעריכותעיצוביםושללאומנויותאחרותהלאהיאמאק.wav");
        erezTrigger.AddSequance(erezSequence);
        
        Actor[] actors =
        {
            hallwayDoor, exitDoor, wall, wall2, wall3, lockedDoor, lockedDoor2, wall4, lockedDoor3, wall5, wall6, lockedDoor4, vendingMachine, vendingMachine2, table, table2, table3, table4, couch,
            couch2, couch3, couch4, table5, wall7, wall8, wall9, wall10, table6, couch5, erez, erezTrigger
        };
        
        Level level = Utilities.CreateLevel("Tiltan Campus (Floor 3)", new Vector2(60, 10), _player, actors);
        return level;
    } //Level 3

    static Level TrainStation()
    {
        TriggerBox trainAnnouncementTrigger = new TriggerBox(38, 2);
        Sequence trainAnnouncement = new Sequence();
        trainAnnouncement.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\TheNextTrainToModiiiinMerkazWillEnterRightAway.wav");
        trainAnnouncementTrigger.AddSequance(trainAnnouncement);

        TriggerBox ravPassTrigger = new TriggerBox(5, 4, 10, 1);
        Sequence ravPass = new Sequence();
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\OhICantBelieveItTheGpsIsGoneAndSayingImInBeirutSoICantComeInIWillCallOfirToAskWhatToDo.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\RingRingRingRingRingRing.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\Hello.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\OfirICantEnterTheStationWhatShouldIDo.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\TryToFindAWayWithoutTheGuardSeeingYou.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\HeLooksLikeRedQuestionMark.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\IfHeSeesYouYouWillEnterAFight.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\AndIfYouDoPressTheScreenWithYourMouseToContinue.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\ItsNotABugItsAFeature.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\LuckilyMostPeopleAreDumbAndCanOnlySeeYouFromAStraightLine.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\SoIfYouAreComingDiagonallyTheyWillNotSeeYou.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\AlmostLikeYouAreTheOnlyRealPersonAndAllOfTheOthersAreJustNPCs.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\HahahahaJustKidding.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TrainStation\\OfirCall\\IWillCallYouWhenImThere.wav");
        
        ravPassTrigger.AddSequance(ravPass);
        
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

        Enemy guard = new Enemy(22, 6, "Security guard");
        Enemy[] enemies = { guard };
        level.SetEnemies(enemies);
        
        return level;
    } //Level 4

    static Level Dizingof()
    {
        TriggerBox callTrigger = new TriggerBox(97, 1);
        Sequence call = new Sequence();
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\RingRingRingRingRingRing.wav");
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\Hello.wav");
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\OfirIGotToDizingofCenterWhereAreYou.wav");
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\ImOutside.wav");
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\WhereIsTheExit.wav");
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\ILiterallyHaveNoIdea.wav");
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\IWillTryToFindIt.wav");
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\WatchOutThereAreALotOfCenterKidsThere.wav");
        call.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Dizingof\\DontWorry.wav");
        callTrigger.AddSequance(call);
        
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
        Door door7 = new Door(30, 18, DoorDirection.Up, DMC(), false, true);
        Door entrance = new Door(98, 0, DoorDirection.Left, true, true);

        Actor[] actors =
        {
            actor, actor2, actor3, actor4, actor5, actor6, actor7, actor8, actor9, actor10, actor11, actor12, actor13, actor14, actor15, actor16, actor17, actor18, actor19, actor20,
            actor21, actor22, actor23, actor24, doorBenDoor, door2, door3, exitDoor, door5, door6, entrance, callTrigger, door7
        };
        
        Level level = Utilities.CreateLevel("Dizingof Center", new Vector2(100, 20), _player, actors);

        string[] names =
        {
            "Center kid (They/Them)", "Center kid (Gay)", "Center kid (Furry)", "Center kid (Ze/Zem)", "Center kid (He/Her)", "Center kid (She/Him)", "Center kid (Transgender)",
            "Center kid (Refrigerator)", "Center kid (Who/He/Remains)", "Center kid (Ori/Meir)"
        };
        
        Enemy[] enemies = Utilities.GenerateEnemies(10, level, names);
        level.SetEnemies(enemies);
        
        return level;
    } // Level 5

    static Level TelAviv() // Level 6
    {
        TriggerBox entranceTrigger = new TriggerBox(2, 2);
        Sequence ofir = new Sequence();
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv\\DorBenDorYouCameItIsMeOfirKatzLookWhatIBuildItsATimeMachineByTheWay.wav");
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv\\WaitAMinuteOfirAreYouTellingMeYouBuiltATimeMachineOutOfADelorean.wav");
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv\\WellIFiguredIfYouGonnaBuildATimeMachineIntoACarWhyNotDoItWithSomeStyle.wav");
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv\\CanITry.wav");
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv\\OfCourseJustStepIntoTheCar.wav");
        entranceTrigger.AddSequance(ofir);
        
        Door entrance = new Door(0, 1, DoorDirection.Right, true);
        Door obanKobanDoor = new Door(5, 4, DoorDirection.Up, ObanKoban(), false, true);

        Mesh delorean = new Mesh("                                                                                          \n                                                                      .                   \n                                                                                          \n                                                                  =#*: =.     .::..       \n                                                            ..  .+##=---=    =#####*      \n                                                  ..--:....-:...:-=++=@%%:.-*#####%#-     \n                                             ...:::::---::----::==-*=-=*+--=**+**+%#*     \n                                       .:-====-----::::::::---::---===+-:-+*+******++:    \n                                   .:--:...::--===========-:--=+++**#+=++:=+=*+++**+==-   \n                             .++===-::::::---=====-----=++:=#######%%%#+*#=-+==-------=:  \n                            :=+=-==----============---=*+:=#####%%#*###+++*+---===+*#+:+. \n                        ...:-===++=+#===+++=-----===-=*=:+#####***++===+===+*+-+#%%#+#-:  \n                 . ..::::::::::::::-===+*##%%#+==+===*=:+##%%%%*=========-==*+*#**#%*%*   \n              .:::::::::::::::::::::::::::::--====++++-=+***+++========++=++%##++++#++:   \n        .:.:::::::::::::::::::::::::::::::::::::------============+++++====*#%*==+=#      \n     .=+===------::::::::::::::::::::::::::::--=--------+====++++========+##%%*=++*=      \n   .:*==*+*#*++=====----:::::::::::::::..:-+++=+*#*=--=++*++=--====++**#%%@@@%#****..     \n  .=-=+*++%%%%+*###**++===----:-::.... .==:.:+#%%####+=--=+===+**##%%#%%#**#@@%%#=..      \n   .::.:-+-+###*#%%%%@#++#+++-::.  ::*++.--*%%%#%%@%#=-==+*#%%%%#++==+++======-:...       \n     .*++=-..:--+-+*##*++#+=+::.-..=*%%%#*%%#*+*+*%@###%%%@@%*==+*++=--:::.........       \n     .+*%%%%#*+=-:...:-===+++===*#%%=#%%#@%#*-==+=%%%%%%%%%#**+=--::..........            \n         .:-+*#%@@%#*+=--...:..:%#%%-***@%%*+-+=++%%%%#*++==--::.........                 \n     .....:::-+*##%%%@@@%%#***##%%%%%##%@@%*+++++##*+==--:::.......                       \n    ......:::-==+++***###%%%%%@#**##%%@@@@%%####%*=--::........                           \n      ....::::---====+++++***#####%%%%%%%%%%%#*=-:.........                               \n        ......::::-----=================---::........                                     \n              .......:::::::::::::::::.......                                             \n");
        Teleporter carDoor = new Teleporter(17, 4, 5, 1, new CutsceneLevel(delorean, $"{Environment.CurrentDirectory}\\MIDI\\BTTF.mid", TelAviv2017(), _gameManager), new Graphics('_', ConsoleColor.Black));

        Actor ofirKatz = new Actor(13, 5, 1, 1, new Graphics('!', ConsoleColor.DarkRed));

        Actor carWheel = new Actor(17, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carWheel2 = new Actor(21, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        
        Actor[] actors = { entrance, obanKobanDoor, ofirKatz, entranceTrigger, carWheel, carWheel2, carDoor };
        
        Level level = Utilities.CreateLevel("Tel Aviv", new Vector2(22, 6), _player, actors);
        return level;
    }

    static Level TelAviv2017()
    {
        TriggerBox entranceTrigger = new TriggerBox(15, 4);
        Sequence dialog = new Sequence();
        dialog.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\WowITraveledBackInTimeExcuseMeKindSirWhatYearIsIt.wav");
        dialog.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\2017.wav");
        dialog.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\AndWhatAreThoseBoxes.wav");
        dialog.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\InTheLeftBoxSomeBitcoins.wav");
        dialog.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\InTheRightBoxAllOfTheStocksOfEATheGamingCompany.wav");
        dialog.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\OhMyGodICanBuyBitcoinsHereInThePastAndBeReachWhenIGoBackToTheFuture.wav");
        entranceTrigger.AddSequance(dialog);
        
        Door door = new Door(5, 4, DoorDirection.Up, NotKoban(), false, true);

        Actor randomMan = new Actor(13, 5, 1, 1, new Graphics('!', ConsoleColor.DarkRed));

        Actor carWheel = new Actor(17, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carWheel2 = new Actor(21, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carBase = new Actor(17, 4, 5, 1, new Graphics('_', ConsoleColor.Black));

        Chest chest = new Chest(new Item("EA stocks"), 3, 0);
        Sequence sequence = new Sequence();
        sequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\Box2\\WhatTheFuck.wav");
        sequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\Box2\\ThatBoxHasNoBitcoins.wav");
        sequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\Box2\\JustEAStocks.wav");
        chest.AddCutscene(sequence);
        
        Chest chest2 = new Chest(new Item("EA stocks"), 10, 0);
        Sequence cutscene2 = new Sequence();
        cutscene2.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\Box1\\OhNoIAccidentallyTookAllOfTheStocksOfEA.wav");
        cutscene2.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TelAviv2017\\Box1\\IGuessIAmTheCEONow.wav");
        chest2.AddCutscene(cutscene2);
        
        Actor[] actors = { door, randomMan, entranceTrigger, carWheel, carWheel2, carBase, chest, chest2 };
        
        Level level = Utilities.CreateLevel("Tel Aviv", new Vector2(22, 6), _player, actors, new Vector2(15, 4));
        return level;
    } // Level 7

    static Level NotKoban() // Level 8
    {
        TriggerBox entranceTrigger = new TriggerBox(34, 4);
        Sequence entranceSequence = new Sequence();
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\Hello.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\HiWhatHappenedHere.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\OhIAmJustBuildingANewRestaurantCalledObanKoban.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\HeyIKnowThisRestaurantIAteThere.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\WhatDoYouMeanYouAteThereItsBrandNew.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\AnywayHowCanIArriveToTiltan.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\WhatsTiltan.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\SorryIMeantMacAndLearn.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\OhItsInHaifaRightPassTheBackDoor.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\NotKoban\\ThankYou.wav");
        entranceTrigger.AddSequance(entranceSequence);
        
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
        Sequence entranceSequence = new Sequence();
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tiltan2017\\WowHowEmptyWasThisPlaceIn2.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Tiltan2017\\IllGoSearchOfirKatzNowHeIsProbablyInTheStudioClassroom.wav");
        entranceTrigger.AddSequance(entranceSequence);
        
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
        Sequence entranceSequence = new Sequence();
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\HelloOfir.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\WhoTheHellAreYou.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\YourFriendDorBenDorImFromTheFutureAndICameHereInATimeMachineThatYouInvented.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\YourLying.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\NoIDont.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\ProveIt.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\GrimeIsCurrentlyInDevelopment.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\HolyShitIHaventToldAnyoneAboutGrimeYet.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\DoYouKnowWhatThatMeans.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\What.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\IFinallyInventedSomethingThatWorks.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\YesHeresAPictureOfMineFromTheFuture.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\CanYouComeAndShowMeThis.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017\\Coming.wav");
        entranceTrigger.AddSequance(entranceSequence);

        Mesh dor = new Mesh("$$\\      $$\\  $$$$$$\\  $$$$$$$\\  $$$$$$$$\\       $$\\      $$\\ $$$$$$\\ $$$$$$$$\\ $$\\   $$\\        $$$$$$\\    $$\\ $$\\   \n$$$\\    $$$ |$$  __$$\\ $$  __$$\\ $$  _____|      $$ | $\\  $$ |\\_$$  _|\\__$$  __|$$ |  $$ |      $$  __$$\\   $$ \\$$ \\  \n$$$$\\  $$$$ |$$ /  $$ |$$ |  $$ |$$ |            $$ |$$$\\ $$ |  $$ |     $$ |   $$ |  $$ |      $$ /  \\__|$$$$$$$$$$\\ \n$$\\$$\\$$ $$ |$$$$$$$$ |$$ |  $$ |$$$$$\\          $$ $$ $$\\$$ |  $$ |     $$ |   $$$$$$$$ |      $$ |      \\_$$  $$   |\n$$ \\$$$  $$ |$$  __$$ |$$ |  $$ |$$  __|         $$$$  _$$$$ |  $$ |     $$ |   $$  __$$ |      $$ |      $$$$$$$$$$\\ \n$$ |\\$  /$$ |$$ |  $$ |$$ |  $$ |$$ |            $$$  / \\$$$ |  $$ |     $$ |   $$ |  $$ |      $$ |  $$\\ \\_$$  $$  _|\n$$ | \\_/ $$ |$$ |  $$ |$$$$$$$  |$$$$$$$$\\       $$  /   \\$$ |$$$$$$\\    $$ |   $$ |  $$ |      \\$$$$$$  |  $$ |$$ |  \n\\__|     \\__|\\__|  \\__|\\_______/ \\________|      \\__/     \\__|\\______|   \\__|   \\__|  \\__|       \\______/   \\__|\\__|  \n                                                                                                                     \n**************************************************\n**************************************************\n*****************##*******************************\n***************#%%%%%##%##************************\n**************%%%%@%%%%%%%%#**********************\n**************#%%++===+#%%%@%*********************\n*****************=+**++*%%#%%*********************\n****************+=##*+**%%#%%*********************\n***************==+#====#%%%**###******************\n***************##****##%@%*+*++**##***************\n***************#*=+*%%@%%+=++==+++**#*************\n***************#%%%%%%%*+++===+#+=+**#************\n***************+#%#**+++====++#%#++=+*#***********\n**************=-+*#*++++++***###%*+++=*#**********\n**************-=*#*#+===+++***###**=-=+#**********\n**************-+#****+=====+*###****++##**********\n**************-+##***%%+*+#%%%%%****++*#**********\n**************=+*#****#%###%###%#**=-==#**********\n********************##%%###**###%#**+##***********\n********************##%*******##%*****************\n********************#%%#*****####*****************\n***************#%#***##%%%%%%#***#%%#*************\n****************####################**************\n**************************************************\n**************************************************\n\n");
        Teleporter pictureTrigger = new Teleporter(10, 0, 1, 2, new CutsceneLevel(dor, StudioClassroom20172(), _gameManager), new Graphics(' ', ConsoleColor.Black));
        
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
        TriggerBox entranceTrigger = new TriggerBox(10, 0, 1, 2);
        Sequence entranceSequence = new Sequence();
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017(2)\\WowVeryCool.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017(2)\\AnywayWeNeedToGetYouBackToTheFuture.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017(2)\\YesWeJustNeed1Gigawatts.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017(2)\\OkNeverMindYouStuckHere.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017(2)\\NextWeekAppleAreIntroducingTheVisionProWith1GigawattsBattery.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017(2)\\GreatSoWeWillUseThat.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\StudioClassroom2017(2)\\IllWaitForYouAtFloor0ComeWhenYouReady.wav");
        entranceTrigger.AddSequance(entranceSequence);
        
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

        Level level = Utilities.CreateLevel("Studio class - Mac and learn", new Vector2(65, 17), _player, actors, new Vector2(10, 1));
        return level;
    } // Level 12
    
    static Level Floor0() // Level 13
    {
        TriggerBox entranceTrigger = new TriggerBox(11, 3);
        Sequence ofir = new Sequence();
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0\\ByTheWayHaveYouChangedAnythingWhileYouWereHere.wav");
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0\\IAccidentallyBoughtAllOfEAStocksSoIOwnTheCompanyNow.wav");
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0\\WhatShowMeYourPictureAgain.wav");
        entranceTrigger.AddSequance(ofir);
        
        Door exit = new Door(1, 0, DoorDirection.Down, false, true);
        Door elevator = new Door(12, 2, DoorDirection.Left, true);

        Mesh dor = new Mesh("$$\\      $$\\  $$$$$$\\  $$$$$$$\\  $$$$$$$$\\       $$\\      $$\\ $$$$$$\\ $$$$$$$$\\ $$\\   $$\\       $$\\   $$\\ $$\\   $$\\ $$$$$$\\ $$$$$$$$\\ $$\\     $$\\ \n$$$\\    $$$ |$$  __$$\\ $$  __$$\\ $$  _____|      $$ | $\\  $$ |\\_$$  _|\\__$$  __|$$ |  $$ |      $$ |  $$ |$$$\\  $$ |\\_$$  _|\\__$$  __|\\$$\\   $$  |\n$$$$\\  $$$$ |$$ /  $$ |$$ |  $$ |$$ |            $$ |$$$\\ $$ |  $$ |     $$ |   $$ |  $$ |      $$ |  $$ |$$$$\\ $$ |  $$ |     $$ |    \\$$\\ $$  / \n$$\\$$\\$$ $$ |$$$$$$$$ |$$ |  $$ |$$$$$\\          $$ $$ $$\\$$ |  $$ |     $$ |   $$$$$$$$ |      $$ |  $$ |$$ $$\\$$ |  $$ |     $$ |     \\$$$$  /  \n$$ \\$$$  $$ |$$  __$$ |$$ |  $$ |$$  __|         $$$$  _$$$$ |  $$ |     $$ |   $$  __$$ |      $$ |  $$ |$$ \\$$$$ |  $$ |     $$ |      \\$$  /   \n$$ |\\$  /$$ |$$ |  $$ |$$ |  $$ |$$ |            $$$  / \\$$$ |  $$ |     $$ |   $$ |  $$ |      $$ |  $$ |$$ |\\$$$ |  $$ |     $$ |       $$ |    \n$$ | \\_/ $$ |$$ |  $$ |$$$$$$$  |$$$$$$$$\\       $$  /   \\$$ |$$$$$$\\    $$ |   $$ |  $$ |      \\$$$$$$  |$$ | \\$$ |$$$$$$\\    $$ |       $$ |    \n\\__|     \\__|\\__|  \\__|\\_______/ \\________|      \\__/     \\__|\\______|   \\__|   \\__|  \\__|       \\______/ \\__|  \\__|\\______|   \\__|       \\__|    \n**************************************************\n**************************************************\n*****************##*******************************\n***************#%%%%%##%##************************\n**************%%%%@%%%%%%%%#**********************\n**************#%%++===+#%%%@%*********************\n*****************=+**++*%%#%%*********************\n****************+=##*+**%%#%%*********************\n***************==+#====#%%%**###******************\n***************##****##%@%*+*++**##***************\n***************#*=+*%%@%%+=++==+++**#*************\n***************#%%%%%%%*+++===+#+=+**#************\n***************+#%#**+++====++#%#++=+*#***********\n**************=-+*#*++++++***###%*+++=*#**********\n**************-=*#*#+===+++***###**=-=+#**********\n**************-+#****+=====+*###****++##**********\n**************-+##***%%+*+#%%%%%****++*#**********\n**************=+*#****#%###%###%#**=-==#**********\n********************##%%###**###%#**+##***********\n********************##%*******##%*****************\n********************#%%#*****####*****************\n***************#%#***##%%%%%%#***#%%#*************\n****************####################**************\n**************************************************\n**************************************************\n\n");
        Teleporter pictureTrigger = new Teleporter(0, 3, 3, 3, new CutsceneLevel(dor, Floor02(), _gameManager), new Graphics(' ', ConsoleColor.Black));
        
        Actor ofirKatz = new Actor(1, 4, 1, 1, new Graphics('!', ConsoleColor.DarkRed));
        
        Actor[] actors = { elevator, exit, entranceTrigger, pictureTrigger, ofirKatz };
        
        Level level = Utilities.CreateLevel("Floor 0", 7, _player, actors);
        return level;
    }
    
    static Level Floor02() // Level 13
    {
        TriggerBox entranceTrigger = new TriggerBox(2, 4);
        Sequence greatScott = new Sequence();
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\OhNo.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\WhatHappened.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\IsThereAChanceSomethingHappenedWithTheUnityEngineInTheFuture.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\YesTheyTook2CentsForEveryDownloadSoManyPeopleLeftTheEngine.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\WasThatRelatedToEASomehow.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\UnityCEOWasFormerEACeo.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\GreatScott.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\What.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\IGuessYourStocksExchangeCreatedAChainReaction.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\andYouEndedUpBeingCreatedInUnityInsteadOfPlainCConsoleApplication.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\AndYouAreGoingToBe.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\ErasedFromExistence.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\WowThisIsHeavy.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\TheresThatWordAgain.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\Heavy.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\WhyAreThingsSoHeavyInTheFuture.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\IsThereAProblemWithTheEarthsGravitationalPull.wav");
        greatScott.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Floor0(2)\\LetsGoOutAndFigureWhatToDo.wav");
        entranceTrigger.AddSequance(greatScott);
        
        Door exit = new Door(1, 0, DoorDirection.Down, Train2017(), false, true);
        Door elevator = new Door(12, 2, DoorDirection.Left, false, true);
        
        Actor ofirKatz = new Actor(0, 4, 1, 1, new Graphics('!', ConsoleColor.DarkRed));
        
        Actor[] actors = { exit, ofirKatz, entranceTrigger, elevator };
        
        Level level = Utilities.CreateLevel("Floor 0", 7, _player, actors, new Vector2(2, 4));
        return level;
    }
    
    static Level Train2017()
    {
        TriggerBox trainAnnouncementTrigger = new TriggerBox(38, 2);
        Sequence trainAnnouncement = new Sequence();
        trainAnnouncement.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train2017\\TheNextTrainToTheUnitedStatesWillEnterRightAway.wav");
        trainAnnouncementTrigger.AddSequance(trainAnnouncement);

        TriggerBox ravPassTrigger = new TriggerBox(5, 4, 10, 1);
        Sequence ravPass = new Sequence();
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train2017\\RavPass\\WaitYouAreFromTheFutureSoTheRavKavWillNotWork.wav");
        ravPass.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train2017\\RavPass\\DontWorryIKnowWhatToDo.wav");
        ravPassTrigger.AddSequance(ravPass);
        
        Graphics wallGraphics = new Graphics('|', ConsoleColor.Black);
        
        Door entrance = new Door(37, 0, DoorDirection.Down, true);
        Actor exit = new Actor(46, 0, 3, 2, new Graphics('&', ConsoleColor.Red));
        
        Actor train = new Actor(5, 12, 30, 3, new Graphics('-', ConsoleColor.Red));
        Door trainDoor = new Door(7, 12, DoorDirection.Up, Train(), false, true);
        Door trainDoor2 = new Door(17, 12, DoorDirection.Up, Train(), false, true);
        Door trainDoor3 = new Door(27, 12, DoorDirection.Up, Train(), false, true);
        
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

        Actor ofirKatz = new Actor(35, 4, 1, 1, new Graphics('!', ConsoleColor.DarkRed));
        
        Actor[] actors =
        {
            entrance, train, train2, trainDoor, trainDoor2, trainDoor3, wall, wall2, exit, wall3, wall4, wall5, wall6, wall7, wall8, wall9, wall10, wall11, 
            wall12, wall13, trainAnnouncementTrigger, ravPassTrigger, ofirKatz
        };
        
        Level level = Utilities.CreateLevel("Train station Haifa merkaz hashmona 2017", new Vector2(50, 20), _player, actors);
        
        Enemy guard = new Enemy(22, 6, "Security guard");
        Enemy[] enemies = { guard };
        level.SetEnemies(enemies);
        
        return level;
    } //Level 14

    static Level Train()
    {
        TriggerBox entranceTrigger = new TriggerBox(30, 3);
        Sequence sell = new Sequence();
        sell.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\IHaveAnIdeaTheWholeThingHappenedBecauseIBoughtTheStocksRight.wav");
        sell.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\Yes.wav");
        sell.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\WhatIfIJustSellThemBack.wav");
        sell.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\ThatWillWorkIThink.wav");
        sell.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\WhereIsMyPhone.wav");
        sell.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\HereComeAndIWillGiveYou.wav");
        entranceTrigger.AddSequance(sell);
        
        Graphics chairGraphics = new Graphics('#', ConsoleColor.Blue);
        Graphics tableGraphics = new Graphics('-', ConsoleColor.Gray);
        Graphics wallGraphics = new Graphics('|', ConsoleColor.Black);
        
        Door exit = new Door(0, 3, DoorDirection.Right);
        
        #region Seats

        Actor chair = new Actor(1, 0, 1, 2, chairGraphics);
        Actor chair2 = new Actor(5, 0, 1, 2, chairGraphics);
        Actor table = new Actor(3, 0, 1, 1, tableGraphics);
        
        Actor chair3 = new Actor(1, 4, 1, 2, chairGraphics);
        Actor chair4 = new Actor(5, 4, 1, 2, chairGraphics);
        Actor table2 = new Actor(3, 5, 1, 1, tableGraphics);

        Actor wall = new Actor(6, 0, 1, 2, wallGraphics);
        Actor wall2 = new Actor(6, 4, 1, 2, wallGraphics);
        
        Actor chair5 = new Actor(7, 0, 1, 2, chairGraphics);
        Actor chair6 = new Actor(11, 0, 1, 2, chairGraphics);
        Actor table3 = new Actor(9, 0, 1, 1, tableGraphics);
        
        Actor chair7 = new Actor(7, 4, 1, 2, chairGraphics);
        Actor chair8 = new Actor(11, 4, 1, 2, chairGraphics);
        Actor table4 = new Actor(9, 5, 1, 1, tableGraphics);
        
        Actor wall3 = new Actor(12, 0, 1, 2, wallGraphics);
        Actor wall4 = new Actor(12, 4, 1, 2, wallGraphics);
        
        Actor chair9 = new Actor(13, 0, 1, 2, chairGraphics);
        Actor chair10 = new Actor(17, 0, 1, 2, chairGraphics);
        Actor table5 = new Actor(15, 0, 1, 1, tableGraphics);
        
        Actor chair11 = new Actor(13, 4, 1, 2, chairGraphics);
        Actor chair12 = new Actor(17, 4, 1, 2, chairGraphics);
        Actor table6 = new Actor(15, 5, 1, 1, tableGraphics);
        
        Actor wall5 = new Actor(18, 0, 1, 2, wallGraphics);
        Actor wall6 = new Actor(18, 4, 1, 2, wallGraphics);
        
        Actor chair13 = new Actor(19, 0, 1, 2, chairGraphics);
        Actor chair14 = new Actor(23, 0, 1, 2, chairGraphics);
        Actor table7 = new Actor(21, 0, 1, 1, tableGraphics);
        
        Actor chair15 = new Actor(19, 4, 1, 2, chairGraphics);
        Actor chair16 = new Actor(23, 4, 1, 2, chairGraphics);
        Actor table8 = new Actor(21, 5, 1, 1, tableGraphics);
        
        Actor wall7 = new Actor(24, 0, 1, 2, wallGraphics);
        Actor wall8 = new Actor(24, 4, 1, 2, wallGraphics);
        
        Actor chair18 = new Actor(25, 0, 1, 2, chairGraphics);
        Actor chair19 = new Actor(29, 0, 1, 2, chairGraphics);
        Actor table9 = new Actor(27, 0, 1, 1, tableGraphics);
        
        Actor chair20 = new Actor(25, 4, 1, 2, chairGraphics);
        Actor chair21 = new Actor(29, 4, 1, 2, chairGraphics);
        Actor table10 = new Actor(27, 5, 1, 1, tableGraphics);

        #endregion

        Actor ofirKatz = new Actor(8, 3, 1, 1, new Graphics('!', ConsoleColor.DarkRed));

        Mesh anyKey = new Mesh("$$$$$$$\\  $$$$$$$\\  $$$$$$$$\\  $$$$$$\\   $$$$$$\\         $$$$$$\\  $$\\   $$\\ $$\\     $$\\       $$\\   $$\\ $$$$$$$$\\ $$\\     $$\\                       \n$$  __$$\\ $$  __$$\\ $$  _____|$$  __$$\\ $$  __$$\\       $$  __$$\\ $$$\\  $$ |\\$$\\   $$  |      $$ | $$  |$$  _____|\\$$\\   $$  |                      \n$$ |  $$ |$$ |  $$ |$$ |      $$ /  \\__|$$ /  \\__|      $$ /  $$ |$$$$\\ $$ | \\$$\\ $$  /       $$ |$$  / $$ |       \\$$\\ $$  /                       \n$$$$$$$  |$$$$$$$  |$$$$$\\    \\$$$$$$\\  \\$$$$$$\\        $$$$$$$$ |$$ $$\\$$ |  \\$$$$  /        $$$$$  /  $$$$$\\      \\$$$$  /                        \n$$  ____/ $$  __$$< $$  __|    \\____$$\\  \\____$$\\       $$  __$$ |$$ \\$$$$ |   \\$$  /         $$  $$<   $$  __|      \\$$  /                         \n$$ |      $$ |  $$ |$$ |      $$\\   $$ |$$\\   $$ |      $$ |  $$ |$$ |\\$$$ |    $$ |          $$ |\\$$\\  $$ |          $$ |                          \n$$ |      $$ |  $$ |$$$$$$$$\\ \\$$$$$$  |\\$$$$$$  |      $$ |  $$ |$$ | \\$$ |    $$ |          $$ | \\$$\\ $$$$$$$$\\     $$ |                          \n\\__|      \\__|  \\__|\\________| \\______/  \\______/       \\__|  \\__|\\__|  \\__|    \\__|          \\__|  \\__|\\________|    \\__|                          \n                                                                                                                                                    \n                                                                                                                                                    \n                                                                                                                                                    \n$$$$$$$$\\  $$$$$$\\        $$$$$$$$\\ $$$$$$$\\   $$$$$$\\  $$\\   $$\\  $$$$$$\\  $$$$$$$$\\ $$$$$$$$\\ $$$$$$$\\        $$$$$$$$\\ $$\\   $$\\ $$$$$$$$\\       \n\\__$$  __|$$  __$$\\       \\__$$  __|$$  __$$\\ $$  __$$\\ $$$\\  $$ |$$  __$$\\ $$  _____|$$  _____|$$  __$$\\       \\__$$  __|$$ |  $$ |$$  _____|      \n   $$ |   $$ /  $$ |         $$ |   $$ |  $$ |$$ /  $$ |$$$$\\ $$ |$$ /  \\__|$$ |      $$ |      $$ |  $$ |         $$ |   $$ |  $$ |$$ |            \n   $$ |   $$ |  $$ |         $$ |   $$$$$$$  |$$$$$$$$ |$$ $$\\$$ |\\$$$$$$\\  $$$$$\\    $$$$$\\    $$$$$$$  |         $$ |   $$$$$$$$ |$$$$$\\          \n   $$ |   $$ |  $$ |         $$ |   $$  __$$< $$  __$$ |$$ \\$$$$ | \\____$$\\ $$  __|   $$  __|   $$  __$$<          $$ |   $$  __$$ |$$  __|         \n   $$ |   $$ |  $$ |         $$ |   $$ |  $$ |$$ |  $$ |$$ |\\$$$ |$$\\   $$ |$$ |      $$ |      $$ |  $$ |         $$ |   $$ |  $$ |$$ |            \n   $$ |    $$$$$$  |         $$ |   $$ |  $$ |$$ |  $$ |$$ | \\$$ |\\$$$$$$  |$$ |      $$$$$$$$\\ $$ |  $$ |         $$ |   $$ |  $$ |$$$$$$$$\\       \n   \\__|    \\______/          \\__|   \\__|  \\__|\\__|  \\__|\\__|  \\__| \\______/ \\__|      \\________|\\__|  \\__|         \\__|   \\__|  \\__|\\________|      \n                                                                                                                                                    \n                                                                                                                                                    \n                                                                                                                                                    \n $$$$$$\\ $$$$$$$$\\  $$$$$$\\   $$$$$$\\  $$\\   $$\\  $$$$$$\\        $$$$$$$$\\  $$$$$$\\        $$$$$$$$\\  $$$$$$\\                                       \n$$  __$$\\\\__$$  __|$$  __$$\\ $$  __$$\\ $$ | $$  |$$  __$$\\       \\__$$  __|$$  __$$\\       $$  _____|$$  __$$\\                                      \n$$ /  \\__|  $$ |   $$ /  $$ |$$ /  \\__|$$ |$$  / $$ /  \\__|         $$ |   $$ /  $$ |      $$ |      $$ /  $$ |                                     \n\\$$$$$$\\    $$ |   $$ |  $$ |$$ |      $$$$$  /  \\$$$$$$\\           $$ |   $$ |  $$ |      $$$$$\\    $$$$$$$$ |                                     \n \\____$$\\   $$ |   $$ |  $$ |$$ |      $$  $$<    \\____$$\\          $$ |   $$ |  $$ |      $$  __|   $$  __$$ |                                     \n$$\\   $$ |  $$ |   $$ |  $$ |$$ |  $$\\ $$ |\\$$\\  $$\\   $$ |         $$ |   $$ |  $$ |      $$ |      $$ |  $$ |                                     \n\\$$$$$$  |  $$ |    $$$$$$  |\\$$$$$$  |$$ | \\$$\\ \\$$$$$$  |         $$ |    $$$$$$  |      $$$$$$$$\\ $$ |  $$ |                                     \n \\______/   \\__|    \\______/  \\______/ \\__|  \\__| \\______/          \\__|    \\______/       \\________|\\__|  \\__|                                     \n                                                                                                                                                    \n                                                                                                                                   ");
        Sequence anySequence = new Sequence();
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\DammitWhereIsThatAnyKeyButton.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\ItsNotByTheF.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\NotByTheF.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\EvenNotByTheF.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\WhatToDo.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\HelloCanSomebodyHereMeINeedHelp.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\Hello.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\MMMMMMMMMMMMSupportiveMan.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\HowCanIHelpYou.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\ASupportiveAndKindManMmmmm.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\IveAlwaysCountedOnTheKindnessOfStrangers.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\OHOHOHOOHOHOHOHOHANYKEYYEEEEEEEEEEEEEEEEEEEEEEEEEEAHHHHHHHHHHHHHHHHHHHHHHHHHHH.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\ShutUpIllJustPressItMyself.wav");
        anySequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train\\AnyCutscene\\Click.wav");
        
        Teleporter anyKeyTrigger = new Teleporter(9, 2, 1, 2, new CutsceneLevel(anyKey, anySequence, Train2(), _gameManager), new Graphics(' ', ConsoleColor.Black));
        
        Actor[] actors =
        {
            chair, chair2, table, chair3, chair4, table2, chair5, chair6, table3, chair7, chair8, table4, chair9, chair10, table5, chair11, chair12, table6, chair13, chair14, table7, chair15, chair16, table8,
            chair18, chair19, table9, chair20, chair21, table10, wall, wall2, wall3, wall4, wall5, wall6, wall7, wall8, ofirKatz, entranceTrigger, anyKeyTrigger, exit
        };
        
        Level level = Utilities.CreateLevel("Train", new Vector2(31, 6), _player, actors, new Vector2(30, 3));
        return level;
    } // Level 15
    
    static Level Train2()
    {
        TriggerBox entranceTrigger = new TriggerBox(9, 3);
        Sequence arrived = new Sequence();
        arrived.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train(2)\\WowThatWorked.wav");
        arrived.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train(2)\\AlsoWeArrivedToTheAppleStore.wav");
        arrived.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Train(2)\\LetsStealTheBatteryAndGetOut.wav");
        entranceTrigger.AddSequance(arrived);
        
        Graphics chairGraphics = new Graphics('#', ConsoleColor.Blue);
        Graphics tableGraphics = new Graphics('-', ConsoleColor.Gray);
        Graphics wallGraphics = new Graphics('|', ConsoleColor.Black);
        
        #region Seats

        Actor chair = new Actor(1, 0, 1, 2, chairGraphics);
        Actor chair2 = new Actor(5, 0, 1, 2, chairGraphics);
        Actor table = new Actor(3, 0, 1, 1, tableGraphics);
        
        Actor chair3 = new Actor(1, 4, 1, 2, chairGraphics);
        Actor chair4 = new Actor(5, 4, 1, 2, chairGraphics);
        Actor table2 = new Actor(3, 5, 1, 1, tableGraphics);

        Actor wall = new Actor(6, 0, 1, 2, wallGraphics);
        Actor wall2 = new Actor(6, 4, 1, 2, wallGraphics);
        
        Actor chair5 = new Actor(7, 0, 1, 2, chairGraphics);
        Actor chair6 = new Actor(11, 0, 1, 2, chairGraphics);
        Actor table3 = new Actor(9, 0, 1, 1, tableGraphics);
        
        Actor chair7 = new Actor(7, 4, 1, 2, chairGraphics);
        Actor chair8 = new Actor(11, 4, 1, 2, chairGraphics);
        Actor table4 = new Actor(9, 5, 1, 1, tableGraphics);
        
        Actor wall3 = new Actor(12, 0, 1, 2, wallGraphics);
        Actor wall4 = new Actor(12, 4, 1, 2, wallGraphics);
        
        Actor chair9 = new Actor(13, 0, 1, 2, chairGraphics);
        Actor chair10 = new Actor(17, 0, 1, 2, chairGraphics);
        Actor table5 = new Actor(15, 0, 1, 1, tableGraphics);
        
        Actor chair11 = new Actor(13, 4, 1, 2, chairGraphics);
        Actor chair12 = new Actor(17, 4, 1, 2, chairGraphics);
        Actor table6 = new Actor(15, 5, 1, 1, tableGraphics);
        
        Actor wall5 = new Actor(18, 0, 1, 2, wallGraphics);
        Actor wall6 = new Actor(18, 4, 1, 2, wallGraphics);
        
        Actor chair13 = new Actor(19, 0, 1, 2, chairGraphics);
        Actor chair14 = new Actor(23, 0, 1, 2, chairGraphics);
        Actor table7 = new Actor(21, 0, 1, 1, tableGraphics);
        
        Actor chair15 = new Actor(19, 4, 1, 2, chairGraphics);
        Actor chair16 = new Actor(23, 4, 1, 2, chairGraphics);
        Actor table8 = new Actor(21, 5, 1, 1, tableGraphics);
        
        Actor wall7 = new Actor(24, 0, 1, 2, wallGraphics);
        Actor wall8 = new Actor(24, 4, 1, 2, wallGraphics);
        
        Actor chair18 = new Actor(25, 0, 1, 2, chairGraphics);
        Actor chair19 = new Actor(29, 0, 1, 2, chairGraphics);
        Actor table9 = new Actor(27, 0, 1, 1, tableGraphics);
        
        Actor chair20 = new Actor(25, 4, 1, 2, chairGraphics);
        Actor chair21 = new Actor(29, 4, 1, 2, chairGraphics);
        Actor table10 = new Actor(27, 5, 1, 1, tableGraphics);

        #endregion

        Actor ofirKatz = new Actor(7, 3, 1, 1, new Graphics('!', ConsoleColor.DarkRed));

        Door exit = new Door(0, 3, DoorDirection.Right, AppleStoreEntrance(), false, true);
        
        Actor[] actors =
        {
            chair, chair2, table, chair3, chair4, table2, chair5, chair6, table3, chair7, chair8, table4, chair9, chair10, table5, chair11, chair12, table6, chair13, chair14, table7, chair15, chair16, table8,
            chair18, chair19, table9, chair20, chair21, table10, wall, wall2, wall3, wall4, wall5, wall6, wall7, wall8, ofirKatz, entranceTrigger, exit
        };
        
        Level level = Utilities.CreateLevel("Train", new Vector2(31, 6), _player, actors, new Vector2(9, 3));
        return level;
    }// Level 16
     
    static Level AppleStoreEntrance() // Level 17
    {
        TriggerBox entranceTrigger = new TriggerBox(6, 5);
        Sequence ofir = new Sequence();
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\AppleStoreEntrance\\IllWaitHereAndPrepareTheThing.wav");
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\AppleStoreEntrance\\IllGoToTakeTheBattery.wav");
        ofir.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\AppleStoreEntrance\\WatchOutForTheSecurityWhenYouHaveTheVisionProJustConnectItToTheCarIBuiltASpecialDoorForThis.wav");
        entranceTrigger.AddSequance(ofir);
        
        Door entrance = new Door(7, 0, DoorDirection.Down, AppleStore(), false, true);
        
        Actor ofirKatz = new Actor(8, 5, 1, 1, new Graphics('!', ConsoleColor.DarkRed));

        Actor carWheel = new Actor(10, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carWheel2 = new Actor(14, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carBase = new Actor(10, 4, 5, 1, new Graphics('_', ConsoleColor.Black));
        
        Mesh delorean = new Mesh("                                                                                          \n                   .                                                                      \n                                                                                          \n       ..::.     .= :*#=                                                                  \n      +#####+.   =---=##*:  ..                                                            \n     :#%######-.:#%@+=+=-::..:-....:--.:                                                  \n     *#%+**+**+=-+*+-=*-==::----::----::::...                                             \n    .=+******+*+-:-++==---::---::::::::-----====-:.                                       \n   :==+**+++*=+=:++=+##*+++=--:-===========--::...:--:.                                   \n  .=-------==+--#*=#%%%#######=:++=------====---::::::-===++.                             \n .+:+#*+==----=*+++###*#%%#####=:=*=---============----==-=+=:                            \n  :-#+#%%#+-+*+===+===++***#####+:=*=====-----=++++==*+=++====:...                        \n   *%+%#**#*+*==-=========*%%%%##*:=*======+#%%%#*++==-::::::::::::::.. .                 \n   .+=#++++##%++=++========+++****=-++++====--:::::::::::::::::::::::::::::.              \n      *++==*%#*====++++++===========-----::::::::::::::::::::::::::::::::::::::.:.        \n      -*+==+%%##+========++++====+=-------=--:::::::::::::::::::::::::::::-----===+=:     \n     ..+**+#%@@@%%#**++====--=++*++=--=*#*+=+++=:..::::::::::::::::---=====++*#*++==*:.   \n      ..=#%%@@%**#%%##%%##*+=====--=+####%%#+:.:==. ....:::-----===++**###*+%%%%++*+=-+.  \n       ...:-======+++==++*%%%%##+====##@%%#%%%#=-.=+*::  .-:-+++#++#@%%%%#*###+-+-:.::.   \n       .........:::--=++*+=+*%@@%%%###@%#+*+**%%**%%%*=..-.::+=+#++*##*+-+--:..:=++*.     \n            ..........::--=+**#%%%%%%%@%=+==-*#%@#%%%-%%%*===+++===-:...:-=+*#%%%%*+:     \n                 .........:::-==++*##%%%++==-+*%%@**#-%%#%-..:...:-=+*#%%@%%*+=:.         \n                       .......:::--==+*#%+++++*%%@%##%%%%%##***#%%@@@%%%##*+-:::.....     \n                           ........:::-=+%####%%@@@@%%##**#@%%%%%%###**+++==-:::......    \n                               .........::=*#%%%%%%%%%%%#####***+++++====---::::....      \n                                     .........:---=================-----::::......        \n                                             .......:::::::::::::::::.......              \n");
        Door carDoor = new Door(12, 3, DoorDirection.Up, new CutsceneLevel(delorean, $"{Environment.CurrentDirectory}\\MIDI\\BTTF.mid", Future(), _gameManager));
        
        Actor[] actors = { entrance, ofirKatz, entranceTrigger, carWheel, carWheel2, carBase, carDoor };
        
        Level level = Utilities.CreateLevel("Somewhere in USA", new Vector2(16, 6), _player, actors, new Vector2(6, 5));
        return level;
    }

    static Level AppleStore()
    {
        TriggerBox entranceTrigger = new TriggerBox(2, 2);
        Sequence sequence = new Sequence();
        sequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\AppleStore\\OhNoWhereIsThatBattery.wav");
        sequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\AppleStore\\IShouldStartSearching.wav");
        entranceTrigger.AddSequance(sequence);
        
        Door entrance = new Door(1, 0, DoorDirection.Down, true, true);

        Chest chest = new Chest(new RickRoll(), 1, 5);
        Chest chest2 = new Chest(new Item("Macbook Air", "Now i can publish Fash Catch for Iphone!!!!!!!!!!"), 1, 10);
        Chest chest3 = new Chest(new Item("Macbook M1", "Why this crap costs 6000 USD?"), 1, 15);
        Chest chest4 = new Chest(new Item("Shahar Chocolate", "Das Eina Gutte Kremaev"), 1, 20);
        Chest chest5 = new Chest(new Item("Icloth", "THE APPLE CLOTH!!!!!!!"), 1, 25);
        Chest chest6 = new Chest(new RickRoll(), 6, 5);
        Chest chest7 = new Chest(new Item("Wire for Airpods", "Now this is good product"), 6, 10);
        Chest chest8 = new Chest(new Item("Charger", "Charger for 596048 USD"), 6, 15);
        Chest chest9 = new Chest(new RickRoll(), 6, 20);
        Chest chest10 = new Chest(new Weapon("Apple", "Pink lady apple that gives 49 HP", 49), 6, 25);
        Chest chest11 = new Chest(new Item("Shahar Chocolate", "Das Eina Gutte Kremaev"), 11, 5);
        Chest chest12 = new Chest(new Weapon("Android", "Apple workers hate this so much. If you use it they just die.", 100), 11, 10);
        Chest chest13 = new Chest(new Item("Shahar Chocolate", "Das Eina Gutte Kremaev"), 11, 15);
        Chest chest14 = new Chest(new Key("Apple Vision Pro", "Quest 3 is better. Oh wait that's what i need to start the car"), 11, 20);
        Chest chest15 = new Chest(new Healing("Los pollos hermanos", "he's name is gustavo but you can call him gus?", 17), 11, 25);
        Chest chest16 = new Chest(new Weapon("Petah Tikva", "This place is real???????????????? so it just kills everyone who touches it?", 100), 16, 5);
        Chest chest17 = new Chest(new RickRoll(), 16, 10);
        Chest chest18 = new Chest(new Item("Better Call Finger", "https://www.youtube.com/watch?v=At0kaXY36Xc&t=56s"), 16, 15);
        Chest chest19 = new Chest(new Item("Kishke", "Kishke from Maroom Golan"), 16, 20);
        Chest chest20 = new Chest(new Item("A body", "Some costumer died here"), 16, 25);
        
        Actor[] actors =
        {
            entrance, entranceTrigger, chest2, chest3, chest4, chest5, chest, chest6, chest7, chest8, chest9, chest10, chest11, chest12, chest13, chest14, chest15, chest16,
            chest17, chest18, chest19, chest20
        };
        
        Level level = Utilities.CreateLevel("Apple Store", new Vector2(20, 30), _player, actors);
        Enemy[] enemies = Utilities.GenerateEnemies(10, level, "Apple guy");
        level.SetEnemies(enemies);
            
        return level;
    } // Level 18

    static Level Future()
    {
        TriggerBox entranceTrigger = new TriggerBox(15, 4);
        Sequence dani = new Sequence();
        dani.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Future\\WowItWorkedImBack.wav");
        dani.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Future\\HiImDaniKushmaro.wav");
        dani.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Future\\WowImInAnEpisodeOfNews.wav");
        dani.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Future\\NoTheyFiredMeSinceUnityTookAllOfMyMoneySoNowImBroke.wav");
        dani.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Future\\justLikeAppleThatLostAllOfItsMoneyAfterTheVisionProDiedWhenItWasLaunchByTheWay.wav");
        dani.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Future\\LolQuest3IsBetter.wav");
        dani.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Future\\AnywayHaveYouSeenOfirKatz.wav");
        dani.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Future\\IThinkHeIsInObanKoban.wav");
        entranceTrigger.AddSequance(dani);
        
        Actor carWheel = new Actor(17, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carWheel2 = new Actor(21, 5, 1, 1, new Graphics('@', ConsoleColor.Black));
        Actor carBase = new Actor(17, 4, 5, 1, new Graphics('_', ConsoleColor.Black));
        
        Door centerDoor = new Door(0, 1, DoorDirection.Right);
        Door obanKobanDoor = new Door(5, 4, DoorDirection.Up, FutureKoban(), false, true);
        
        Actor Kushmaro = new Actor(13, 5, 1, 1, new Graphics('!', ConsoleColor.DarkRed));
        
        Actor[] actors = { entranceTrigger, carWheel, carWheel2, carBase, obanKobanDoor, centerDoor, Kushmaro };
        
        Level level = Utilities.CreateLevel("Tel Aviv", new Vector2(22, 6), _player, actors, new Vector2(15, 4));
        return level;
    } // Level 19
    
    static Level FutureKoban()
    {
        TriggerBox entranceTrigger = new TriggerBox(34, 4);
        Sequence entranceSequence = new Sequence();
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\FutureKoban\\Roads\\DORYOUGOTTACOMEBACKWITHME.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\FutureKoban\\Roads\\Where.wav");
        entranceSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\FutureKoban\\Roads\\BackToTheFuture.wav");
        entranceTrigger.AddSequance(entranceSequence);
        
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
        
        Chest chest = new Chest(new Healing("TanTan Ramen", 76, "Mild fish stock, miso, sesame, tubanjan, chili, ramen noodles, chopped beef in miso, Half an egg, bamboo shoots, shiitake mushrooms, spinach, sprouts and green onions"), 0, 1);

        Actor ofirKatz = new Actor(6, 3, 1, 1, new Graphics('!', ConsoleColor.DarkRed));
        
        Sequence roadsSequence = new Sequence();
        roadsSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\FutureKoban\\Roads\\HiOfirYouMightWantToGetBackWeDontHaveEnoughRoadToGetTo8.wav");
        roadsSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\FutureKoban\\Roads\\RoadsWhereWeGoingWeDontNeedRoads.wav");

        Mesh mesh = new Mesh(".-==-***#%%%%+.        .:-+==-: ....  . ..::.*********************************************\n  .::+**#%%%%+.  . .=*****##***=:.:.....:--+=*********************************************\n    .+**##%%%+. -#**####%##%%%%%%**##########***************##*####***********************\n    .+**##%%%*..+***##**+***##%%#*-=---=-====*************#%%%%%%%%%#*********************\n    .+**###%%*.-=**=++====+++++*++==-=---====************#%%%%#**#%%%%#*******************\n     +**#*#%%*:-======-====++++++=----------=**************#+-===+#%%%%*******************\n     =**#*#%%#-====+=--=+++++++++=---------=-**************#+*%#**#%##%*******************\n. ...=**###%%#+=+-==-==+**##*+*##=-:::::::---*************+-+*=--=%%%#*###****************\n.....=*####%%#--+--=-==+++++==*#*::::::=+*##%**************#****##@@#+****###*************\n.  ..=*##%%%%#.:==---====+++==++=:---=*#%%%%%**************%++*%%@%#==+==+++*##***********\n     =*##%%%%#..::---==+*****#*+=-=*#%%%%%%%%**************#%%%%%%*++===+#==**##**********\n.   .=*#%%%%%#..:-=+==++*****##+:-#%%%%%%%%%%*************++##**+=====+*#%#+=++##*********\n     =*#%%%%%#..-==++****+*****-=#%%%%%%%%%##************+-=*##*+++****####*===+#*********\n     =*#%%%%%+.:-====+*+++*#*=-=#%%%%%%%%%%%%************+=+#**+=====++*##***=-+#*********\n     +*#%###=:::-=+=++**###+---*%%%%%*++##***************+=##***#*=++*#%%%****###*********\n     +*###%%%#+-==++++++***#%#*##%%%#+#+**=++************+=*#***#%#*#%%%%%#*+===#*********\n..-+#%%%%%%%%%%%#*+++++++*#@%@@%%%%%#***%####***************#***#%%###*###%**+**#*********\n*#%%%%%%%%%%%%%%%%%%#*++#%@@@%@@@@@@%%%%%%%%%******************##%******###***************\n#%#%%%%%%%%%%%%%%%%%@@%%@@%%%%%%@%%@%@%%%%%%%******************#%%*****####***************\n%%%%@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@@%**+**************#%%#**#%%%%%%%***#%%************\n%%%%%@@%%%%%%%%%%%%%%%%@@%%%%%%%%%%@%@@@@#+##*********************************************\n%%%%%@@@%%%%%%%%%%%%%@@@%###%%%%%%%@%@@@@%=*%*********************************************\n");
        Teleporter roadsTrigger = new Teleporter(7, 2, 1, 3, new CutsceneLevel(mesh, roadsSequence, Credits(), _gameManager), new Graphics(' ', ConsoleColor.Black));
        
        Actor[] actors =
        {
            door, cashier, cashier2, table, table2, table3, table4, table5, table6, table7, table8, wall, doorCover, wall2, chest, entranceTrigger, ofirKatz, roadsTrigger
        };
        
        Level level = Utilities.CreateLevel("Oban Koban", 40, 6, _player, actors);
        
        return level;
    } // Level 20

    #endregion

    static CutsceneLevel Credits()
    {
        Mesh none = new Mesh(" ");
        Mesh title = new Mesh("$$\\   $$\\  $$$$$$\\  $$\\       $$$$$$$$\\       $$\\       $$$$$$\\ $$$$$$$$\\ $$$$$$$$\\        $$$$$$\\  \n$$ |  $$ |$$  __$$\\ $$ |      $$  _____|      $$ |      \\_$$  _|$$  _____|$$  _____|      $$ ___$$\\ \n$$ |  $$ |$$ /  $$ |$$ |      $$ |            $$ |        $$ |  $$ |      $$ |            \\_/   $$ |\n$$$$$$$$ |$$$$$$$$ |$$ |      $$$$$\\          $$ |        $$ |  $$$$$\\    $$$$$\\            $$$$$ / \n$$  __$$ |$$  __$$ |$$ |      $$  __|         $$ |        $$ |  $$  __|   $$  __|           \\___$$\\ \n$$ |  $$ |$$ |  $$ |$$ |      $$ |            $$ |        $$ |  $$ |      $$ |            $$\\   $$ |\n$$ |  $$ |$$ |  $$ |$$$$$$$$\\ $$ |            $$$$$$$$\\ $$$$$$\\ $$ |      $$$$$$$$\\       \\$$$$$$  |\n\\__|  \\__|\\__|  \\__|\\________|\\__|            \\________|\\______|\\__|      \\________|       \\______/ \n                                                                                                    \n                                                                                                    \n                                                                                                    ");
        Mesh author = new Mesh(" $$$$$$\\         $$$$$$\\   $$$$$$\\  $$\\      $$\\ $$$$$$$$\\       $$$$$$$\\ $$\\     $$\\                              \n$$  __$$\\       $$  __$$\\ $$  __$$\\ $$$\\    $$$ |$$  _____|      $$  __$$\\\\$$\\   $$  |                             \n$$ /  $$ |      $$ /  \\__|$$ /  $$ |$$$$\\  $$$$ |$$ |            $$ |  $$ |\\$$\\ $$  /$$\\                           \n$$$$$$$$ |      $$ |$$$$\\ $$$$$$$$ |$$\\$$\\$$ $$ |$$$$$\\          $$$$$$$\\ | \\$$$$  / \\__|                          \n$$  __$$ |      $$ |\\_$$ |$$  __$$ |$$ \\$$$  $$ |$$  __|         $$  __$$\\   \\$$  /                                \n$$ |  $$ |      $$ |  $$ |$$ |  $$ |$$ |\\$  /$$ |$$ |            $$ |  $$ |   $$ |   $$\\                           \n$$ |  $$ |      \\$$$$$$  |$$ |  $$ |$$ | \\_/ $$ |$$$$$$$$\\       $$$$$$$  |   $$ |   \\__|                          \n\\__|  \\__|       \\______/ \\__|  \\__|\\__|     \\__|\\________|      \\_______/    \\__|                                 \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|\n                                                                                                                   \n                                                                                                                   \n                                                                                                                   ");
        Mesh director = new Mesh("$$$$$$$\\  $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\ $$$$$$$$\\ $$$$$$$$\\ $$$$$$$\\        $$$$$$$\\ $$\\     $$\\            \n$$  __$$\\ \\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\\\__$$  __|$$  _____|$$  __$$\\       $$  __$$\\\\$$\\   $$  |           \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  \\__|  $$ |   $$ |      $$ |  $$ |      $$ |  $$ |\\$$\\ $$  /$$\\         \n$$ |  $$ |  $$ |  $$$$$$$  |$$$$$\\    $$ |        $$ |   $$$$$\\    $$ |  $$ |      $$$$$$$\\ | \\$$$$  / \\__|        \n$$ |  $$ |  $$ |  $$  __$$< $$  __|   $$ |        $$ |   $$  __|   $$ |  $$ |      $$  __$$\\   \\$$  /              \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$\\   $$ |   $$ |      $$ |  $$ |      $$ |  $$ |   $$ |   $$\\         \n$$$$$$$  |$$$$$$\\ $$ |  $$ |$$$$$$$$\\ \\$$$$$$  |  $$ |   $$$$$$$$\\ $$$$$$$  |      $$$$$$$  |   $$ |   \\__|        \n\\_______/ \\______|\\__|  \\__|\\________| \\______/   \\__|   \\________|\\_______/       \\_______/    \\__|               \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|\n                                                                                                                   \n                                                                                                                   \n                                                                                                                  ");
        Mesh written = new Mesh("$$\\      $$\\ $$$$$$$\\  $$$$$$\\ $$$$$$$$\\ $$$$$$$$\\ $$$$$$$$\\ $$\\   $$\\       $$$$$$$\\ $$\\     $$\\                  \n$$ | $\\  $$ |$$  __$$\\ \\_$$  _|\\__$$  __|\\__$$  __|$$  _____|$$$\\  $$ |      $$  __$$\\\\$$\\   $$  |                 \n$$ |$$$\\ $$ |$$ |  $$ |  $$ |     $$ |      $$ |   $$ |      $$$$\\ $$ |      $$ |  $$ |\\$$\\ $$  /$$\\               \n$$ $$ $$\\$$ |$$$$$$$  |  $$ |     $$ |      $$ |   $$$$$\\    $$ $$\\$$ |      $$$$$$$\\ | \\$$$$  / \\__|              \n$$$$  _$$$$ |$$  __$$<   $$ |     $$ |      $$ |   $$  __|   $$ \\$$$$ |      $$  __$$\\   \\$$  /                    \n$$$  / \\$$$ |$$ |  $$ |  $$ |     $$ |      $$ |   $$ |      $$ |\\$$$ |      $$ |  $$ |   $$ |   $$\\               \n$$  /   \\$$ |$$ |  $$ |$$$$$$\\    $$ |      $$ |   $$$$$$$$\\ $$ | \\$$ |      $$$$$$$  |   $$ |   \\__|              \n\\__/     \\__|\\__|  \\__|\\______|   \\__|      \\__|   \\________|\\__|  \\__|      \\_______/    \\__|                     \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|\n                                                                                                                   \n                                                                                                                   ");
        Mesh program = new Mesh("$$$$$$$\\  $$$$$$$\\   $$$$$$\\   $$$$$$\\  $$$$$$$\\   $$$$$$\\  $$\\      $$\\ $$$$$$\\ $$\\   $$\\  $$$$$$\\                \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$$\\    $$$ |\\_$$  _|$$$\\  $$ |$$  __$$\\               \n$$ |  $$ |$$ |  $$ |$$ /  $$ |$$ /  \\__|$$ |  $$ |$$ /  $$ |$$$$\\  $$$$ |  $$ |  $$$$\\ $$ |$$ /  \\__|$$\\           \n$$$$$$$  |$$$$$$$  |$$ |  $$ |$$ |$$$$\\ $$$$$$$  |$$$$$$$$ |$$\\$$\\$$ $$ |  $$ |  $$ $$\\$$ |$$ |$$$$\\ \\__|          \n$$  ____/ $$  __$$< $$ |  $$ |$$ |\\_$$ |$$  __$$< $$  __$$ |$$ \\$$$  $$ |  $$ |  $$ \\$$$$ |$$ |\\_$$ |              \n$$ |      $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |\\$  /$$ |  $$ |  $$ |\\$$$ |$$ |  $$ |$$\\           \n$$ |      $$ |  $$ | $$$$$$  |\\$$$$$$  |$$ |  $$ |$$ |  $$ |$$ | \\_/ $$ |$$$$$$\\ $$ | \\$$ |\\$$$$$$  |\\__|          \n\\__|      \\__|  \\__| \\______/  \\______/ \\__|  \\__|\\__|  \\__|\\__|     \\__|\\______|\\__|  \\__| \\______/               \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|\n                                                                                                                   \n                                                                                                                   \n                                                                                                                   ");
        Mesh design = new Mesh(" $$$$$$\\   $$$$$$\\  $$\\      $$\\ $$$$$$$$\\       $$$$$$$\\  $$$$$$$$\\  $$$$$$\\  $$$$$$\\  $$$$$$\\  $$\\   $$\\         \n$$  __$$\\ $$  __$$\\ $$$\\    $$$ |$$  _____|      $$  __$$\\ $$  _____|$$  __$$\\ \\_$$  _|$$  __$$\\ $$$\\  $$ |        \n$$ /  \\__|$$ /  $$ |$$$$\\  $$$$ |$$ |            $$ |  $$ |$$ |      $$ /  \\__|  $$ |  $$ /  \\__|$$$$\\ $$ |$$\\     \n$$ |$$$$\\ $$$$$$$$ |$$\\$$\\$$ $$ |$$$$$\\          $$ |  $$ |$$$$$\\    \\$$$$$$\\    $$ |  $$ |$$$$\\ $$ $$\\$$ |\\__|    \n$$ |\\_$$ |$$  __$$ |$$ \\$$$  $$ |$$  __|         $$ |  $$ |$$  __|    \\____$$\\   $$ |  $$ |\\_$$ |$$ \\$$$$ |        \n$$ |  $$ |$$ |  $$ |$$ |\\$  /$$ |$$ |            $$ |  $$ |$$ |      $$\\   $$ |  $$ |  $$ |  $$ |$$ |\\$$$ |$$\\     \n\\$$$$$$  |$$ |  $$ |$$ | \\_/ $$ |$$$$$$$$\\       $$$$$$$  |$$$$$$$$\\ \\$$$$$$  |$$$$$$\\ \\$$$$$$  |$$ | \\$$ |\\__|    \n \\______/ \\__|  \\__|\\__|     \\__|\\________|      \\_______/ \\________| \\______/ \\______| \\______/ \\__|  \\__|        \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|\n                                                                                                                   ");
        Mesh art = new Mesh(" $$$$$$\\  $$$$$$$\\ $$$$$$$$\\                                                                                       \n$$  __$$\\ $$  __$$\\\\__$$  __|                                                                                      \n$$ /  $$ |$$ |  $$ |  $$ |$$\\                                                                                      \n$$$$$$$$ |$$$$$$$  |  $$ |\\__|                                                                                     \n$$  __$$ |$$  __$$<   $$ |                                                                                         \n$$ |  $$ |$$ |  $$ |  $$ |$$\\                                                                                      \n$$ |  $$ |$$ |  $$ |  $$ |\\__|                                                                                     \n\\__|  \\__|\\__|  \\__|  \\__|                                                                                         \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|");
        Mesh model = new Mesh(" $$$$$$\\  $$$$$$$\\        $$\\      $$\\  $$$$$$\\  $$$$$$$\\  $$$$$$$$\\ $$\\       $$$$$$\\ $$\\   $$\\  $$$$$$\\          \n$$ ___$$\\ $$  __$$\\       $$$\\    $$$ |$$  __$$\\ $$  __$$\\ $$  _____|$$ |      \\_$$  _|$$$\\  $$ |$$  __$$\\         \n\\_/   $$ |$$ |  $$ |      $$$$\\  $$$$ |$$ /  $$ |$$ |  $$ |$$ |      $$ |        $$ |  $$$$\\ $$ |$$ /  \\__|$$\\     \n  $$$$$ / $$ |  $$ |      $$\\$$\\$$ $$ |$$ |  $$ |$$ |  $$ |$$$$$\\    $$ |        $$ |  $$ $$\\$$ |$$ |$$$$\\ \\__|    \n  \\___$$\\ $$ |  $$ |      $$ \\$$$  $$ |$$ |  $$ |$$ |  $$ |$$  __|   $$ |        $$ |  $$ \\$$$$ |$$ |\\_$$ |        \n$$\\   $$ |$$ |  $$ |      $$ |\\$  /$$ |$$ |  $$ |$$ |  $$ |$$ |      $$ |        $$ |  $$ |\\$$$ |$$ |  $$ |$$\\     \n\\$$$$$$  |$$$$$$$  |      $$ | \\_/ $$ | $$$$$$  |$$$$$$$  |$$$$$$$$\\ $$$$$$$$\\ $$$$$$\\ $$ | \\$$ |\\$$$$$$  |\\__|    \n \\______/ \\_______/       \\__|     \\__| \\______/ \\_______/ \\________|\\________|\\______|\\__|  \\__| \\______/         \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|\n                                                                                                                   ");
        Mesh concept = new Mesh(" $$$$$$\\   $$$$$$\\  $$\\   $$\\  $$$$$$\\  $$$$$$$$\\ $$$$$$$\\ $$$$$$$$\\        $$$$$$\\  $$$$$$$\\ $$$$$$$$\\            \n$$  __$$\\ $$  __$$\\ $$$\\  $$ |$$  __$$\\ $$  _____|$$  __$$\\\\__$$  __|      $$  __$$\\ $$  __$$\\\\__$$  __|           \n$$ /  \\__|$$ /  $$ |$$$$\\ $$ |$$ /  \\__|$$ |      $$ |  $$ |  $$ |         $$ /  $$ |$$ |  $$ |  $$ |$$\\           \n$$ |      $$ |  $$ |$$ $$\\$$ |$$ |      $$$$$\\    $$$$$$$  |  $$ |         $$$$$$$$ |$$$$$$$  |  $$ |\\__|          \n$$ |      $$ |  $$ |$$ \\$$$$ |$$ |      $$  __|   $$  ____/   $$ |         $$  __$$ |$$  __$$<   $$ |              \n$$ |  $$\\ $$ |  $$ |$$ |\\$$$ |$$ |  $$\\ $$ |      $$ |        $$ |         $$ |  $$ |$$ |  $$ |  $$ |$$\\           \n\\$$$$$$  | $$$$$$  |$$ | \\$$ |\\$$$$$$  |$$$$$$$$\\ $$ |        $$ |         $$ |  $$ |$$ |  $$ |  $$ |\\__|          \n \\______/  \\______/ \\__|  \\__| \\______/ \\________|\\__|        \\__|         \\__|  \\__|\\__|  \\__|  \\__|              \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|\n                                                                                                                   ");
        Mesh tech = new Mesh("$$$$$$$$\\ $$$$$$$$\\  $$$$$$\\  $$\\   $$\\        $$$$$$\\  $$$$$$$\\ $$$$$$$$\\                                         \n\\__$$  __|$$  _____|$$  __$$\\ $$ |  $$ |      $$  __$$\\ $$  __$$\\\\__$$  __|                                        \n   $$ |   $$ |      $$ /  \\__|$$ |  $$ |      $$ /  $$ |$$ |  $$ |  $$ |$$\\                                        \n   $$ |   $$$$$\\    $$ |      $$$$$$$$ |      $$$$$$$$ |$$$$$$$  |  $$ |\\__|                                       \n   $$ |   $$  __|   $$ |      $$  __$$ |      $$  __$$ |$$  __$$<   $$ |                                           \n   $$ |   $$ |      $$ |  $$\\ $$ |  $$ |      $$ |  $$ |$$ |  $$ |  $$ |$$\\                                        \n   $$ |   $$$$$$$$\\ \\$$$$$$  |$$ |  $$ |      $$ |  $$ |$$ |  $$ |  $$ |\\__|                                       \n   \\__|   \\________| \\______/ \\__|  \\__|      \\__|  \\__|\\__|  \\__|  \\__|                                           \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|");
        Mesh music = new Mesh("$$\\      $$\\ $$\\   $$\\  $$$$$$\\  $$$$$$\\  $$$$$$\\                                                                  \n$$$\\    $$$ |$$ |  $$ |$$  __$$\\ \\_$$  _|$$  __$$\\                                                                 \n$$$$\\  $$$$ |$$ |  $$ |$$ /  \\__|  $$ |  $$ /  \\__|$$\\                                                             \n$$\\$$\\$$ $$ |$$ |  $$ |\\$$$$$$\\    $$ |  $$ |      \\__|                                                            \n$$ \\$$$  $$ |$$ |  $$ | \\____$$\\   $$ |  $$ |                                                                      \n$$ |\\$  /$$ |$$ |  $$ |$$\\   $$ |  $$ |  $$ |  $$\\ $$\\                                                             \n$$ | \\_/ $$ |\\$$$$$$  |\\$$$$$$  |$$$$$$\\ \\$$$$$$  |\\__|                                                            \n\\__|     \\__| \\______/  \\______/ \\______| \\______/                                                                 \n                                                                                                                   \n                                                                                                                   \n                                                                                                                   \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\  \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\ \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ |\n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ |\n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ |\n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ |\n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ |\n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__|\n                                                                                                                   ");
        Mesh voice = new Mesh("$$\\    $$\\  $$$$$$\\  $$$$$$\\  $$$$$$\\  $$$$$$$$\\        $$$$$$\\   $$$$$$\\ $$$$$$$$\\ $$$$$$\\ $$\\   $$\\  $$$$$$\\      \n$$ |   $$ |$$  __$$\\ \\_$$  _|$$  __$$\\ $$  _____|      $$  __$$\\ $$  __$$\\\\__$$  __|\\_$$  _|$$$\\  $$ |$$  __$$\\     \n$$ |   $$ |$$ /  $$ |  $$ |  $$ /  \\__|$$ |            $$ /  $$ |$$ /  \\__|  $$ |     $$ |  $$$$\\ $$ |$$ /  \\__|$$\\ \n\\$$\\  $$  |$$ |  $$ |  $$ |  $$ |      $$$$$\\          $$$$$$$$ |$$ |        $$ |     $$ |  $$ $$\\$$ |$$ |$$$$\\ \\__|\n \\$$\\$$  / $$ |  $$ |  $$ |  $$ |      $$  __|         $$  __$$ |$$ |        $$ |     $$ |  $$ \\$$$$ |$$ |\\_$$ |    \n  \\$$$  /  $$ |  $$ |  $$ |  $$ |  $$\\ $$ |            $$ |  $$ |$$ |  $$\\   $$ |     $$ |  $$ |\\$$$ |$$ |  $$ |$$\\ \n   \\$  /    $$$$$$  |$$$$$$\\ \\$$$$$$  |$$$$$$$$\\       $$ |  $$ |\\$$$$$$  |  $$ |   $$$$$$\\ $$ | \\$$ |\\$$$$$$  |\\__|\n    \\_/     \\______/ \\______| \\______/ \\________|      \\__|  \\__| \\______/   \\__|   \\______|\\__|  \\__| \\______/     \n                                                                                                                    \n                                                                                                                    \n                                                                                                                    \n$$$$$$$\\   $$$$$$\\  $$$$$$$\\        $$$$$$$\\  $$$$$$$$\\ $$\\   $$\\       $$$$$$$\\   $$$$$$\\  $$$$$$$\\                \n$$  __$$\\ $$  __$$\\ $$  __$$\\       $$  __$$\\ $$  _____|$$$\\  $$ |      $$  __$$\\ $$  __$$\\ $$  __$$\\               \n$$ |  $$ |$$ /  $$ |$$ |  $$ |      $$ |  $$ |$$ |      $$$$\\ $$ |      $$ |  $$ |$$ /  $$ |$$ |  $$ |              \n$$ |  $$ |$$ |  $$ |$$$$$$$  |      $$$$$$$\\ |$$$$$\\    $$ $$\\$$ |      $$ |  $$ |$$ |  $$ |$$$$$$$  |              \n$$ |  $$ |$$ |  $$ |$$  __$$<       $$  __$$\\ $$  __|   $$ \\$$$$ |      $$ |  $$ |$$ |  $$ |$$  __$$<               \n$$ |  $$ |$$ |  $$ |$$ |  $$ |      $$ |  $$ |$$ |      $$ |\\$$$ |      $$ |  $$ |$$ |  $$ |$$ |  $$ |              \n$$$$$$$  | $$$$$$  |$$ |  $$ |      $$$$$$$  |$$$$$$$$\\ $$ | \\$$ |      $$$$$$$  | $$$$$$  |$$ |  $$ |              \n\\_______/  \\______/ \\__|  \\__|      \\_______/ \\________|\\__|  \\__|      \\_______/  \\______/ \\__|  \\__|              \n                                                                                                                    \n                                                                                                                    \n                                                                                                                    \n $$$$$$\\  $$$$$$$$\\ $$$$$$\\ $$$$$$$\\        $$\\   $$\\  $$$$$$\\ $$$$$$$$\\ $$$$$$$$\\                                  \n$$  __$$\\ $$  _____|\\_$$  _|$$  __$$\\       $$ | $$  |$$  __$$\\\\__$$  __|\\____$$  |                                 \n$$ /  $$ |$$ |        $$ |  $$ |  $$ |      $$ |$$  / $$ /  $$ |  $$ |       $$  /                                  \n$$ |  $$ |$$$$$\\      $$ |  $$$$$$$  |      $$$$$  /  $$$$$$$$ |  $$ |      $$  /                                   \n$$ |  $$ |$$  __|     $$ |  $$  __$$<       $$  $$<   $$  __$$ |  $$ |     $$  /                                    \n$$ |  $$ |$$ |        $$ |  $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |  $$ |    $$  /                                     \n $$$$$$  |$$ |      $$$$$$\\ $$ |  $$ |      $$ | \\$$\\ $$ |  $$ |  $$ |   $$$$$$$$\\                                  \n \\______/ \\__|      \\______|\\__|  \\__|      \\__|  \\__|\\__|  \\__|  \\__|   \\________|                                 \n                                                                                                                    \n                                                                                                                    \n                                                                                                                    \n$$\\   $$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\        $$\\   $$\\  $$$$$$\\     $$$$$\\ $$$$$$\\ $$\\      $$\\  $$$$$$\\   \n$$ |  $$ |\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\       $$ | $$  |$$  __$$\\    \\__$$ |\\_$$  _|$$$\\    $$$ |$$  __$$\\  \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ /  $$ |      $$ |$$  / $$ /  $$ |      $$ |  $$ |  $$$$\\  $$$$ |$$ /  $$ | \n$$$$$$$$ |  $$ |  $$ |  $$ |$$$$$\\    $$ |  $$ |      $$$$$  /  $$ |  $$ |      $$ |  $$ |  $$\\$$\\$$ $$ |$$$$$$$$ | \n$$  __$$ |  $$ |  $$ |  $$ |$$  __|   $$ |  $$ |      $$  $$<   $$ |  $$ |$$\\   $$ |  $$ |  $$ \\$$$  $$ |$$  __$$ | \n$$ |  $$ |  $$ |  $$ |  $$ |$$ |      $$ |  $$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |  $$ |  $$ |\\$  /$$ |$$ |  $$ | \n$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\  $$$$$$  |      $$ | \\$$\\  $$$$$$  |\\$$$$$$  |$$$$$$\\ $$ | \\_/ $$ |$$ |  $$ | \n\\__|  \\__|\\______|\\_______/ \\________| \\______/       \\__|  \\__| \\______/  \\______/ \\______|\\__|     \\__|\\__|  \\__| ");
        Mesh koban = new Mesh(" $$$$$$\\   $$$$$$\\   $$$$$$\\  $$$$$$$\\        $$$$$$$\\  $$$$$$$$\\  $$$$$$\\ $$$$$$$$\\ $$\\   $$\\ $$$$$$$\\   $$$$$$\\  $$\\   $$\\ $$$$$$$$\\  \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\       $$  __$$\\ $$  _____|$$  __$$\\\\__$$  __|$$ |  $$ |$$  __$$\\ $$  __$$\\ $$$\\  $$ |\\__$$  __| \n$$ /  \\__|$$ /  $$ |$$ /  $$ |$$ |  $$ |      $$ |  $$ |$$ |      $$ /  \\__|  $$ |   $$ |  $$ |$$ |  $$ |$$ /  $$ |$$$$\\ $$ |   $$ |$$\\ \n$$ |$$$$\\ $$ |  $$ |$$ |  $$ |$$ |  $$ |      $$$$$$$  |$$$$$\\    \\$$$$$$\\    $$ |   $$ |  $$ |$$$$$$$  |$$$$$$$$ |$$ $$\\$$ |   $$ |\\__|\n$$ |\\_$$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |      $$  __$$< $$  __|    \\____$$\\   $$ |   $$ |  $$ |$$  __$$< $$  __$$ |$$ \\$$$$ |   $$ |    \n$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |      $$ |  $$ |$$ |      $$\\   $$ |  $$ |   $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |\\$$$ |   $$ |$$\\ \n\\$$$$$$  | $$$$$$  | $$$$$$  |$$$$$$$  |      $$ |  $$ |$$$$$$$$\\ \\$$$$$$  |  $$ |   \\$$$$$$  |$$ |  $$ |$$ |  $$ |$$ | \\$$ |   $$ |\\__|\n \\______/  \\______/  \\______/ \\_______/       \\__|  \\__|\\________| \\______/   \\__|    \\______/ \\__|  \\__|\\__|  \\__|\\__|  \\__|   \\__|    \n                                                                                                                                        \n                                                                                                                                        \n                                                                                                                                        \n $$$$$$\\  $$$$$$$\\   $$$$$$\\  $$\\   $$\\       $$\\   $$\\  $$$$$$\\  $$$$$$$\\   $$$$$$\\  $$\\   $$\\                                         \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$$\\  $$ |      $$ | $$  |$$  __$$\\ $$  __$$\\ $$  __$$\\ $$$\\  $$ |                                        \n$$ /  $$ |$$ |  $$ |$$ /  $$ |$$$$\\ $$ |      $$ |$$  / $$ /  $$ |$$ |  $$ |$$ /  $$ |$$$$\\ $$ |                                        \n$$ |  $$ |$$$$$$$\\ |$$$$$$$$ |$$ $$\\$$ |      $$$$$  /  $$ |  $$ |$$$$$$$\\ |$$$$$$$$ |$$ $$\\$$ |                                        \n$$ |  $$ |$$  __$$\\ $$  __$$ |$$ \\$$$$ |      $$  $$<   $$ |  $$ |$$  __$$\\ $$  __$$ |$$ \\$$$$ |                                        \n$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |\\$$$ |      $$ |\\$$\\  $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |\\$$$ |                                        \n $$$$$$  |$$$$$$$  |$$ |  $$ |$$ | \\$$ |      $$ | \\$$\\  $$$$$$  |$$$$$$$  |$$ |  $$ |$$ | \\$$ |                                        \n \\______/ \\_______/ \\__|  \\__|\\__|  \\__|      \\__|  \\__| \\______/ \\_______/ \\__|  \\__|\\__|  \\__|                                        \n                                                                                                                                        \n                                                                                                     ");
        Mesh cucumber = new Mesh(" $$$$$$\\  $$\\   $$\\  $$$$$$\\  $$\\   $$\\ $$\\      $$\\ $$$$$$$\\  $$$$$$$$\\ $$$$$$$\\        \n$$  __$$\\ $$ |  $$ |$$  __$$\\ $$ |  $$ |$$$\\    $$$ |$$  __$$\\ $$  _____|$$  __$$\\       \n$$ /  \\__|$$ |  $$ |$$ /  \\__|$$ |  $$ |$$$$\\  $$$$ |$$ |  $$ |$$ |      $$ |  $$ |      \n$$ |      $$ |  $$ |$$ |      $$ |  $$ |$$\\$$\\$$ $$ |$$$$$$$\\ |$$$$$\\    $$$$$$$  |      \n$$ |      $$ |  $$ |$$ |      $$ |  $$ |$$ \\$$$  $$ |$$  __$$\\ $$  __|   $$  __$$<       \n$$ |  $$\\ $$ |  $$ |$$ |  $$\\ $$ |  $$ |$$ |\\$  /$$ |$$ |  $$ |$$ |      $$ |  $$ |      \n\\$$$$$$  |\\$$$$$$  |\\$$$$$$  |\\$$$$$$  |$$ | \\_/ $$ |$$$$$$$  |$$$$$$$$\\ $$ |  $$ |      \n \\______/  \\______/  \\______/  \\______/ \\__|     \\__|\\_______/ \\________|\\__|  \\__|      \n                                                                                         \n                                                                                      ");
        Mesh dontKnow = new Mesh("$$$$$$\\       $$\\   $$\\  $$$$$$\\  $$\\    $$\\ $$$$$$$$\\       $$\\   $$\\  $$$$$$\\        $$$$$$\\ $$$$$$$\\  $$$$$$$$\\  $$$$$$\\  \n\\_$$  _|      $$ |  $$ |$$  __$$\\ $$ |   $$ |$$  _____|      $$$\\  $$ |$$  __$$\\       \\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\ \n  $$ |        $$ |  $$ |$$ /  $$ |$$ |   $$ |$$ |            $$$$\\ $$ |$$ /  $$ |        $$ |  $$ |  $$ |$$ |      $$ /  $$ |\n  $$ |        $$$$$$$$ |$$$$$$$$ |\\$$\\  $$  |$$$$$\\          $$ $$\\$$ |$$ |  $$ |        $$ |  $$ |  $$ |$$$$$\\    $$$$$$$$ |\n  $$ |        $$  __$$ |$$  __$$ | \\$$\\$$  / $$  __|         $$ \\$$$$ |$$ |  $$ |        $$ |  $$ |  $$ |$$  __|   $$  __$$ |\n  $$ |        $$ |  $$ |$$ |  $$ |  \\$$$  /  $$ |            $$ |\\$$$ |$$ |  $$ |        $$ |  $$ |  $$ |$$ |      $$ |  $$ |\n$$$$$$\\       $$ |  $$ |$$ |  $$ |   \\$  /   $$$$$$$$\\       $$ | \\$$ | $$$$$$  |      $$$$$$\\ $$$$$$$  |$$$$$$$$\\ $$ |  $$ |\n\\______|      \\__|  \\__|\\__|  \\__|    \\_/    \\________|      \\__|  \\__| \\______/       \\______|\\_______/ \\________|\\__|  \\__|\n                                                                                                                             \n                                                                                                                             \n                                                                                                                             \n$$\\      $$\\ $$\\   $$\\ $$\\     $$\\       $$$$$$\\        $$$$$$\\   $$$$$$\\  $$$$$$\\ $$$$$$$\\                                  \n$$ | $\\  $$ |$$ |  $$ |\\$$\\   $$  |      \\_$$  _|      $$  __$$\\ $$  __$$\\ \\_$$  _|$$  __$$\\                                 \n$$ |$$$\\ $$ |$$ |  $$ | \\$$\\ $$  /         $$ |        $$ /  \\__|$$ /  $$ |  $$ |  $$ |  $$ |                                \n$$ $$ $$\\$$ |$$$$$$$$ |  \\$$$$  /          $$ |        \\$$$$$$\\  $$$$$$$$ |  $$ |  $$ |  $$ |                                \n$$$$  _$$$$ |$$  __$$ |   \\$$  /           $$ |         \\____$$\\ $$  __$$ |  $$ |  $$ |  $$ |                                \n$$$  / \\$$$ |$$ |  $$ |    $$ |            $$ |        $$\\   $$ |$$ |  $$ |  $$ |  $$ |  $$ |                                \n$$  /   \\$$ |$$ |  $$ |    $$ |          $$$$$$\\       \\$$$$$$  |$$ |  $$ |$$$$$$\\ $$$$$$$  |                                \n\\__/     \\__|\\__|  \\__|    \\__|          \\______|       \\______/ \\__|  \\__|\\______|\\_______/                                 \n                                                                                                                             \n                                                                                                                             \n                                                                                                                             \n $$$$$$\\  $$\\   $$\\  $$$$$$\\  $$\\   $$\\ $$\\      $$\\ $$$$$$$\\  $$$$$$$$\\ $$$$$$$\\                                            \n$$  __$$\\ $$ |  $$ |$$  __$$\\ $$ |  $$ |$$$\\    $$$ |$$  __$$\\ $$  _____|$$  __$$\\                                           \n$$ /  \\__|$$ |  $$ |$$ /  \\__|$$ |  $$ |$$$$\\  $$$$ |$$ |  $$ |$$ |      $$ |  $$ |                                          \n$$ |      $$ |  $$ |$$ |      $$ |  $$ |$$\\$$\\$$ $$ |$$$$$$$\\ |$$$$$\\    $$$$$$$  |                                          \n$$ |      $$ |  $$ |$$ |      $$ |  $$ |$$ \\$$$  $$ |$$  __$$\\ $$  __|   $$  __$$<                                           \n$$ |  $$\\ $$ |  $$ |$$ |  $$\\ $$ |  $$ |$$ |\\$  /$$ |$$ |  $$ |$$ |      $$ |  $$ |                                          \n\\$$$$$$  |\\$$$$$$  |\\$$$$$$  |\\$$$$$$  |$$ | \\_/ $$ |$$$$$$$  |$$$$$$$$\\ $$ |  $$ |                                          \n \\______/  \\______/  \\______/  \\______/ \\__|     \\__|\\_______/ \\________|\\__|  \\__|                                          \n                                                                                                                             \n                                                                                                                             \n                                                                                            ");
        Mesh cool = new Mesh("$$$$$$\\        $$$$$$\\  $$\\   $$\\ $$$$$$$$\\  $$$$$$\\   $$$$$$\\        $$$$$$\\          $$$$$\\ $$\\   $$\\  $$$$$$\\ $$$$$$$$\\ \n\\_$$  _|      $$  __$$\\ $$ |  $$ |$$  _____|$$  __$$\\ $$  __$$\\       \\_$$  _|         \\__$$ |$$ |  $$ |$$  __$$\\\\__$$  __|\n  $$ |        $$ /  \\__|$$ |  $$ |$$ |      $$ /  \\__|$$ /  \\__|        $$ |              $$ |$$ |  $$ |$$ /  \\__|  $$ |   \n  $$ |        $$ |$$$$\\ $$ |  $$ |$$$$$\\    \\$$$$$$\\  \\$$$$$$\\          $$ |              $$ |$$ |  $$ |\\$$$$$$\\    $$ |   \n  $$ |        $$ |\\_$$ |$$ |  $$ |$$  __|    \\____$$\\  \\____$$\\         $$ |        $$\\   $$ |$$ |  $$ | \\____$$\\   $$ |   \n  $$ |        $$ |  $$ |$$ |  $$ |$$ |      $$\\   $$ |$$\\   $$ |        $$ |        $$ |  $$ |$$ |  $$ |$$\\   $$ |  $$ |   \n$$$$$$\\       \\$$$$$$  |\\$$$$$$  |$$$$$$$$\\ \\$$$$$$  |\\$$$$$$  |      $$$$$$\\       \\$$$$$$  |\\$$$$$$  |\\$$$$$$  |  $$ |   \n\\______|       \\______/  \\______/ \\________| \\______/  \\______/       \\______|       \\______/  \\______/  \\______/   \\__|   \n                                                                                                                           \n                                                                                                                           \n                                                                                                                           \n$$\\      $$\\  $$$$$$\\  $$\\   $$\\ $$$$$$$$\\ $$$$$$$$\\ $$$$$$$\\        $$$$$$$$\\  $$$$$$\\        $$$$$$$\\  $$$$$$$$\\         \n$$ | $\\  $$ |$$  __$$\\ $$$\\  $$ |\\__$$  __|$$  _____|$$  __$$\\       \\__$$  __|$$  __$$\\       $$  __$$\\ $$  _____|        \n$$ |$$$\\ $$ |$$ /  $$ |$$$$\\ $$ |   $$ |   $$ |      $$ |  $$ |         $$ |   $$ /  $$ |      $$ |  $$ |$$ |              \n$$ $$ $$\\$$ |$$$$$$$$ |$$ $$\\$$ |   $$ |   $$$$$\\    $$ |  $$ |         $$ |   $$ |  $$ |      $$$$$$$\\ |$$$$$\\            \n$$$$  _$$$$ |$$  __$$ |$$ \\$$$$ |   $$ |   $$  __|   $$ |  $$ |         $$ |   $$ |  $$ |      $$  __$$\\ $$  __|           \n$$$  / \\$$$ |$$ |  $$ |$$ |\\$$$ |   $$ |   $$ |      $$ |  $$ |         $$ |   $$ |  $$ |      $$ |  $$ |$$ |              \n$$  /   \\$$ |$$ |  $$ |$$ | \\$$ |   $$ |   $$$$$$$$\\ $$$$$$$  |         $$ |    $$$$$$  |      $$$$$$$  |$$$$$$$$\\         \n\\__/     \\__|\\__|  \\__|\\__|  \\__|   \\__|   \\________|\\_______/          \\__|    \\______/       \\_______/ \\________|        \n                                                                                                                           \n                                                                                                                           \n                                                                                                                           \n $$$$$$\\   $$$$$$\\   $$$$$$\\  $$\\                                                                                          \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$ |                                                                                         \n$$ /  \\__|$$ /  $$ |$$ /  $$ |$$ |                                                                                         \n$$ |      $$ |  $$ |$$ |  $$ |$$ |                                                                                         \n$$ |      $$ |  $$ |$$ |  $$ |$$ |                                                                                         \n$$ |  $$\\ $$ |  $$ |$$ |  $$ |$$ |                                                                                         \n\\$$$$$$  | $$$$$$  | $$$$$$  |$$$$$$$$\\                                                                                    \n \\______/  \\______/  \\______/ \\________|                                                                                   \n                                         ");
        Mesh asCucumber = new Mesh(" $$$$$$\\   $$$$$$\\   $$$$$$\\  $$\\              $$$$$$\\   $$$$$$\\         $$$$$$\\   \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$ |            $$  __$$\\ $$  __$$\\       $$  __$$\\  \n$$ /  \\__|$$ /  $$ |$$ /  $$ |$$ |            $$ /  $$ |$$ /  \\__|      $$ /  $$ | \n$$ |      $$ |  $$ |$$ |  $$ |$$ |            $$$$$$$$ |\\$$$$$$\\        $$$$$$$$ | \n$$ |      $$ |  $$ |$$ |  $$ |$$ |            $$  __$$ | \\____$$\\       $$  __$$ | \n$$ |  $$\\ $$ |  $$ |$$ |  $$ |$$ |            $$ |  $$ |$$\\   $$ |      $$ |  $$ | \n\\$$$$$$  | $$$$$$  | $$$$$$  |$$$$$$$$\\       $$ |  $$ |\\$$$$$$  |      $$ |  $$ | \n \\______/  \\______/  \\______/ \\________|      \\__|  \\__| \\______/       \\__|  \\__| \n                                                                                   \n                                                                                   \n                                                                                   \n $$$$$$\\  $$\\   $$\\  $$$$$$\\  $$\\   $$\\ $$\\      $$\\ $$$$$$$\\  $$$$$$$$\\ $$$$$$$\\  \n$$  __$$\\ $$ |  $$ |$$  __$$\\ $$ |  $$ |$$$\\    $$$ |$$  __$$\\ $$  _____|$$  __$$\\ \n$$ /  \\__|$$ |  $$ |$$ /  \\__|$$ |  $$ |$$$$\\  $$$$ |$$ |  $$ |$$ |      $$ |  $$ |\n$$ |      $$ |  $$ |$$ |      $$ |  $$ |$$\\$$\\$$ $$ |$$$$$$$\\ |$$$$$\\    $$$$$$$  |\n$$ |      $$ |  $$ |$$ |      $$ |  $$ |$$ \\$$$  $$ |$$  __$$\\ $$  __|   $$  __$$< \n$$ |  $$\\ $$ |  $$ |$$ |  $$\\ $$ |  $$ |$$ |\\$  /$$ |$$ |  $$ |$$ |      $$ |  $$ |\n\\$$$$$$  |\\$$$$$$  |\\$$$$$$  |\\$$$$$$  |$$ | \\_/ $$ |$$$$$$$  |$$$$$$$$\\ $$ |  $$ |\n \\______/  \\______/  \\______/  \\______/ \\__|     \\__|\\_______/ \\________|\\__|  \\__|\n                                                                                   ");
        Mesh anyway = new Mesh(" $$$$$$\\  $$\\   $$\\ $$\\     $$\\ $$\\      $$\\  $$$$$$\\ $$\\     $$\\ \n$$  __$$\\ $$$\\  $$ |\\$$\\   $$  |$$ | $\\  $$ |$$  __$$\\\\$$\\   $$  |\n$$ /  $$ |$$$$\\ $$ | \\$$\\ $$  / $$ |$$$\\ $$ |$$ /  $$ |\\$$\\ $$  / \n$$$$$$$$ |$$ $$\\$$ |  \\$$$$  /  $$ $$ $$\\$$ |$$$$$$$$ | \\$$$$  /  \n$$  __$$ |$$ \\$$$$ |   \\$$  /   $$$$  _$$$$ |$$  __$$ |  \\$$  /   \n$$ |  $$ |$$ |\\$$$ |    $$ |    $$$  / \\$$$ |$$ |  $$ |   $$ |    \n$$ |  $$ |$$ | \\$$ |    $$ |    $$  /   \\$$ |$$ |  $$ |   $$ |    \n\\__|  \\__|\\__|  \\__|    \\__|    \\__/     \\__|\\__|  \\__|   \\__|    ");
        Mesh stalling = new Mesh("$$$$$$\\ $$\\      $$\\        $$$$$$\\  $$$$$$$$\\ $$$$$$$$\\ $$$$$$$$\\ $$$$$$\\ $$\\   $$\\  $$$$$$\\        \n\\_$$  _|$$$\\    $$$ |      $$  __$$\\ $$  _____|\\__$$  __|\\__$$  __|\\_$$  _|$$$\\  $$ |$$  __$$\\       \n  $$ |  $$$$\\  $$$$ |      $$ /  \\__|$$ |         $$ |      $$ |     $$ |  $$$$\\ $$ |$$ /  \\__|      \n  $$ |  $$\\$$\\$$ $$ |      $$ |$$$$\\ $$$$$\\       $$ |      $$ |     $$ |  $$ $$\\$$ |$$ |$$$$\\       \n  $$ |  $$ \\$$$  $$ |      $$ |\\_$$ |$$  __|      $$ |      $$ |     $$ |  $$ \\$$$$ |$$ |\\_$$ |      \n  $$ |  $$ |\\$  /$$ |      $$ |  $$ |$$ |         $$ |      $$ |     $$ |  $$ |\\$$$ |$$ |  $$ |      \n$$$$$$\\ $$ | \\_/ $$ |      \\$$$$$$  |$$$$$$$$\\    $$ |      $$ |   $$$$$$\\ $$ | \\$$ |\\$$$$$$  |      \n\\______|\\__|     \\__|       \\______/ \\________|   \\__|      \\__|   \\______|\\__|  \\__| \\______/       \n                                                                                                     \n                                                                                                     \n                                                                                                     \n$$$$$$$\\   $$$$$$\\  $$$$$$$\\  $$$$$$$$\\ $$$$$$$\\                                                     \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  _____|$$  __$$\\                                                    \n$$ |  $$ |$$ /  $$ |$$ |  $$ |$$ |      $$ |  $$ |                                                   \n$$$$$$$\\ |$$ |  $$ |$$$$$$$  |$$$$$\\    $$ |  $$ |                                                   \n$$  __$$\\ $$ |  $$ |$$  __$$< $$  __|   $$ |  $$ |                                                   \n$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      $$ |  $$ |                                                   \n$$$$$$$  | $$$$$$  |$$ |  $$ |$$$$$$$$\\ $$$$$$$  |                                                   \n\\_______/  \\______/ \\__|  \\__|\\________|\\_______/ ");
        Mesh so = new Mesh(" $$$$$$\\   $$$$$$\\              \n$$  __$$\\ $$  __$$\\             \n$$ /  \\__|$$ /  $$ |            \n\\$$$$$$\\  $$ |  $$ |            \n \\____$$\\ $$ |  $$ |            \n$$\\   $$ |$$ |  $$ |            \n\\$$$$$$  | $$$$$$  |$$\\ $$\\ $$\\ \n \\______/  \\______/ \\__|\\__|\\__|\n                                ");
        Mesh what = new Mesh("$$\\      $$\\ $$\\   $$\\  $$$$$$\\ $$$$$$$$\\  $$$$$$\\        $$\\   $$\\ $$$$$$$\\   $$$$\\  \n$$ | $\\  $$ |$$ |  $$ |$$  __$$\\\\__$$  __|$$  __$$\\       $$ |  $$ |$$  __$$\\ $$  $$\\ \n$$ |$$$\\ $$ |$$ |  $$ |$$ /  $$ |  $$ |   $$ /  \\__|      $$ |  $$ |$$ |  $$ |\\__/$$ |\n$$ $$ $$\\$$ |$$$$$$$$ |$$$$$$$$ |  $$ |   \\$$$$$$\\        $$ |  $$ |$$$$$$$  |   $$  |\n$$$$  _$$$$ |$$  __$$ |$$  __$$ |  $$ |    \\____$$\\       $$ |  $$ |$$  ____/   $$  / \n$$$  / \\$$$ |$$ |  $$ |$$ |  $$ |  $$ |   $$\\   $$ |      $$ |  $$ |$$ |        \\__/  \n$$  /   \\$$ |$$ |  $$ |$$ |  $$ |  $$ |   \\$$$$$$  |      \\$$$$$$  |$$ |        $$\\   \n\\__/     \\__|\\__|  \\__|\\__|  \\__|  \\__|    \\______/        \\______/ \\__|        \\__|  \n                                                                                      ");
        Mesh care = new Mesh("$$$$$$\\       $$$$$$$\\   $$$$$$\\  $$\\   $$\\ $$$$$$$$\\       $$$$$$$\\  $$$$$$$$\\  $$$$$$\\  $$\\       $$\\   $$\\     $$\\       \n\\_$$  _|      $$  __$$\\ $$  __$$\\ $$$\\  $$ |\\__$$  __|      $$  __$$\\ $$  _____|$$  __$$\\ $$ |      $$ |  \\$$\\   $$  |      \n  $$ |        $$ |  $$ |$$ /  $$ |$$$$\\ $$ |   $$ |         $$ |  $$ |$$ |      $$ /  $$ |$$ |      $$ |   \\$$\\ $$  /       \n  $$ |        $$ |  $$ |$$ |  $$ |$$ $$\\$$ |   $$ |         $$$$$$$  |$$$$$\\    $$$$$$$$ |$$ |      $$ |    \\$$$$  /        \n  $$ |        $$ |  $$ |$$ |  $$ |$$ \\$$$$ |   $$ |         $$  __$$< $$  __|   $$  __$$ |$$ |      $$ |     \\$$  /         \n  $$ |        $$ |  $$ |$$ |  $$ |$$ |\\$$$ |   $$ |         $$ |  $$ |$$ |      $$ |  $$ |$$ |      $$ |      $$ |          \n$$$$$$\\       $$$$$$$  | $$$$$$  |$$ | \\$$ |   $$ |         $$ |  $$ |$$$$$$$$\\ $$ |  $$ |$$$$$$$$\\ $$$$$$$$\\ $$ |          \n\\______|      \\_______/  \\______/ \\__|  \\__|   \\__|         \\__|  \\__|\\________|\\__|  \\__|\\________|\\________|\\__|          \n                                                                                                                            \n                                                                                                                            \n                                                                                                                            \n $$$$$$\\   $$$$$$\\  $$$$$$$\\  $$$$$$$$\\                                                                                     \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  _____|                                                                                    \n$$ /  \\__|$$ /  $$ |$$ |  $$ |$$ |                                                                                          \n$$ |      $$$$$$$$ |$$$$$$$  |$$$$$\\                                                                                        \n$$ |      $$  __$$ |$$  __$$< $$  __|                                                                                       \n$$ |  $$\\ $$ |  $$ |$$ |  $$ |$$ |                                                                                          \n\\$$$$$$  |$$ |  $$ |$$ |  $$ |$$$$$$$$\\                                                                                     \n \\______/ \\__|  \\__|\\__|  \\__|\\________|  ");
        Mesh even = new Mesh("$$$$$$$$\\ $$\\    $$\\ $$$$$$$$\\ $$\\   $$\\       $$$$$$\\ $$$$$$$$\\       \n$$  _____|$$ |   $$ |$$  _____|$$$\\  $$ |      \\_$$  _|$$  _____|      \n$$ |      $$ |   $$ |$$ |      $$$$\\ $$ |        $$ |  $$ |            \n$$$$$\\    \\$$\\  $$  |$$$$$\\    $$ $$\\$$ |        $$ |  $$$$$\\          \n$$  __|    \\$$\\$$  / $$  __|   $$ \\$$$$ |        $$ |  $$  __|         \n$$ |        \\$$$  /  $$ |      $$ |\\$$$ |        $$ |  $$ |            \n$$$$$$$$\\    \\$  /   $$$$$$$$\\ $$ | \\$$ |      $$$$$$\\ $$ |            \n\\________|    \\_/    \\________|\\__|  \\__|      \\______|\\__|            \n                                                                       \n                                                                       \n                                                                       \n$$$$$$\\       $$$$$$$\\   $$$$$$\\                                       \n\\_$$  _|      $$  __$$\\ $$  __$$\\                                      \n  $$ |        $$ |  $$ |$$ /  $$ |                                     \n  $$ |        $$ |  $$ |$$ |  $$ |                                     \n  $$ |        $$ |  $$ |$$ |  $$ |                                     \n  $$ |        $$ |  $$ |$$ |  $$ |                                     \n$$$$$$\\       $$$$$$$  | $$$$$$  |                                     \n\\______|      \\_______/  \\______/ ");
        Mesh computer = new Mesh("$$$$$$\\ $$\\      $$\\        $$$$$$\\         $$$$$$\\   $$$$$$\\  $$\\      $$\\ $$$$$$$\\  $$\\   $$\\ $$$$$$$$\\ $$$$$$$$\\ $$$$$$$\\  \n\\_$$  _|$$$\\    $$$ |      $$  __$$\\       $$  __$$\\ $$  __$$\\ $$$\\    $$$ |$$  __$$\\ $$ |  $$ |\\__$$  __|$$  _____|$$  __$$\\ \n  $$ |  $$$$\\  $$$$ |      $$ /  $$ |      $$ /  \\__|$$ /  $$ |$$$$\\  $$$$ |$$ |  $$ |$$ |  $$ |   $$ |   $$ |      $$ |  $$ |\n  $$ |  $$\\$$\\$$ $$ |      $$$$$$$$ |      $$ |      $$ |  $$ |$$\\$$\\$$ $$ |$$$$$$$  |$$ |  $$ |   $$ |   $$$$$\\    $$$$$$$  |\n  $$ |  $$ \\$$$  $$ |      $$  __$$ |      $$ |      $$ |  $$ |$$ \\$$$  $$ |$$  ____/ $$ |  $$ |   $$ |   $$  __|   $$  __$$< \n  $$ |  $$ |\\$  /$$ |      $$ |  $$ |      $$ |  $$\\ $$ |  $$ |$$ |\\$  /$$ |$$ |      $$ |  $$ |   $$ |   $$ |      $$ |  $$ |\n$$$$$$\\ $$ | \\_/ $$ |      $$ |  $$ |      \\$$$$$$  | $$$$$$  |$$ | \\_/ $$ |$$ |      \\$$$$$$  |   $$ |   $$$$$$$$\\ $$ |  $$ |\n\\______|\\__|     \\__|      \\__|  \\__|       \\______/  \\______/ \\__|     \\__|\\__|       \\______/    \\__|   \\________|\\__|  \\__|\n                                                                                                                              \n                                                                                                                              \n                                                                                                                              \n$$$$$$$\\  $$$$$$$\\   $$$$$$\\   $$$$$$\\  $$$$$$$\\   $$$$$$\\  $$\\      $$\\                                                      \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ $$$\\    $$$ |                                                     \n$$ |  $$ |$$ |  $$ |$$ /  $$ |$$ /  \\__|$$ |  $$ |$$ /  $$ |$$$$\\  $$$$ |                                                     \n$$$$$$$  |$$$$$$$  |$$ |  $$ |$$ |$$$$\\ $$$$$$$  |$$$$$$$$ |$$\\$$\\$$ $$ |                                                     \n$$  ____/ $$  __$$< $$ |  $$ |$$ |\\_$$ |$$  __$$< $$  __$$ |$$ \\$$$  $$ |                                                     \n$$ |      $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |\\$  /$$ |                                                     \n$$ |      $$ |  $$ | $$$$$$  |\\$$$$$$  |$$ |  $$ |$$ |  $$ |$$ | \\_/ $$ |                                                     \n\\__|      \\__|  \\__| \\______/  \\______/ \\__|  \\__|\\__|  \\__|\\__|     \\__|                                                     \n                                                                           ");
        Mesh anything = new Mesh(" $$$$$$\\   $$$$$$\\        $$$$$$\\       $$$$$$$\\   $$$$$$\\  $$\\   $$\\ $$$$$$$$\\       $$\\   $$\\  $$$$$$\\  $$\\    $$\\ $$$$$$$$\\      \n$$  __$$\\ $$  __$$\\       \\_$$  _|      $$  __$$\\ $$  __$$\\ $$$\\  $$ |\\__$$  __|      $$ |  $$ |$$  __$$\\ $$ |   $$ |$$  _____|     \n$$ /  \\__|$$ /  $$ |        $$ |        $$ |  $$ |$$ /  $$ |$$$$\\ $$ |   $$ |         $$ |  $$ |$$ /  $$ |$$ |   $$ |$$ |           \n\\$$$$$$\\  $$ |  $$ |        $$ |        $$ |  $$ |$$ |  $$ |$$ $$\\$$ |   $$ |         $$$$$$$$ |$$$$$$$$ |\\$$\\  $$  |$$$$$\\         \n \\____$$\\ $$ |  $$ |        $$ |        $$ |  $$ |$$ |  $$ |$$ \\$$$$ |   $$ |         $$  __$$ |$$  __$$ | \\$$\\$$  / $$  __|        \n$$\\   $$ |$$ |  $$ |        $$ |        $$ |  $$ |$$ |  $$ |$$ |\\$$$ |   $$ |         $$ |  $$ |$$ |  $$ |  \\$$$  /  $$ |           \n\\$$$$$$  | $$$$$$  |      $$$$$$\\       $$$$$$$  | $$$$$$  |$$ | \\$$ |   $$ |         $$ |  $$ |$$ |  $$ |   \\$  /   $$$$$$$$\\      \n \\______/  \\______/       \\______|      \\_______/  \\______/ \\__|  \\__|   \\__|         \\__|  \\__|\\__|  \\__|    \\_/    \\________|     \n                                                                                                                                    \n                                                                                                                                    \n                                                                                                                                    \n $$$$$$\\  $$\\   $$\\ $$\\     $$\\ $$$$$$$$\\ $$\\   $$\\ $$$$$$\\ $$\\   $$\\  $$$$$$\\        $$$$$$$$\\  $$$$$$\\        $$$$$$$\\   $$$$$$\\  \n$$  __$$\\ $$$\\  $$ |\\$$\\   $$  |\\__$$  __|$$ |  $$ |\\_$$  _|$$$\\  $$ |$$  __$$\\       \\__$$  __|$$  __$$\\       $$  __$$\\ $$  __$$\\ \n$$ /  $$ |$$$$\\ $$ | \\$$\\ $$  /    $$ |   $$ |  $$ |  $$ |  $$$$\\ $$ |$$ /  \\__|         $$ |   $$ /  $$ |      $$ |  $$ |$$ /  $$ |\n$$$$$$$$ |$$ $$\\$$ |  \\$$$$  /     $$ |   $$$$$$$$ |  $$ |  $$ $$\\$$ |$$ |$$$$\\          $$ |   $$ |  $$ |      $$ |  $$ |$$ |  $$ |\n$$  __$$ |$$ \\$$$$ |   \\$$  /      $$ |   $$  __$$ |  $$ |  $$ \\$$$$ |$$ |\\_$$ |         $$ |   $$ |  $$ |      $$ |  $$ |$$ |  $$ |\n$$ |  $$ |$$ |\\$$$ |    $$ |       $$ |   $$ |  $$ |  $$ |  $$ |\\$$$ |$$ |  $$ |         $$ |   $$ |  $$ |      $$ |  $$ |$$ |  $$ |\n$$ |  $$ |$$ | \\$$ |    $$ |       $$ |   $$ |  $$ |$$$$$$\\ $$ | \\$$ |\\$$$$$$  |         $$ |    $$$$$$  |      $$$$$$$  | $$$$$$  |\n\\__|  \\__|\\__|  \\__|    \\__|       \\__|   \\__|  \\__|\\______|\\__|  \\__| \\______/          \\__|    \\______/       \\_______/  \\______/ \n                                                                                                                                    \n                                                                                                                                    \n                                                                                                                                    \n$$\\      $$\\ $$$$$$\\ $$$$$$$$\\ $$\\   $$\\       $$$$$$$$\\ $$\\   $$\\ $$$$$$\\  $$$$$$\\        $$$$$$\\ $$\\   $$\\ $$$$$$$$\\  $$$$$$\\     \n$$ | $\\  $$ |\\_$$  _|\\__$$  __|$$ |  $$ |      \\__$$  __|$$ |  $$ |\\_$$  _|$$  __$$\\       \\_$$  _|$$$\\  $$ |$$  _____|$$  __$$\\    \n$$ |$$$\\ $$ |  $$ |     $$ |   $$ |  $$ |         $$ |   $$ |  $$ |  $$ |  $$ /  \\__|        $$ |  $$$$\\ $$ |$$ |      $$ /  $$ |   \n$$ $$ $$\\$$ |  $$ |     $$ |   $$$$$$$$ |         $$ |   $$$$$$$$ |  $$ |  \\$$$$$$\\          $$ |  $$ $$\\$$ |$$$$$\\    $$ |  $$ |   \n$$$$  _$$$$ |  $$ |     $$ |   $$  __$$ |         $$ |   $$  __$$ |  $$ |   \\____$$\\         $$ |  $$ \\$$$$ |$$  __|   $$ |  $$ |   \n$$$  / \\$$$ |  $$ |     $$ |   $$ |  $$ |         $$ |   $$ |  $$ |  $$ |  $$\\   $$ |        $$ |  $$ |\\$$$ |$$ |      $$ |  $$ |   \n$$  /   \\$$ |$$$$$$\\    $$ |   $$ |  $$ |         $$ |   $$ |  $$ |$$$$$$\\ \\$$$$$$  |      $$$$$$\\ $$ | \\$$ |$$ |       $$$$$$  |   \n\\__/     \\__|\\______|   \\__|   \\__|  \\__|         \\__|   \\__|  \\__|\\______| \\______/       \\______|\\__|  \\__|\\__|       \\______/ ");
        Mesh tired = new Mesh("$$$$$$\\ $$\\      $$\\        $$$$$$\\  $$$$$$$$\\ $$$$$$$$\\ $$$$$$$$\\ $$$$$$\\ $$\\   $$\\  $$$$$$\\  \n\\_$$  _|$$$\\    $$$ |      $$  __$$\\ $$  _____|\\__$$  __|\\__$$  __|\\_$$  _|$$$\\  $$ |$$  __$$\\ \n  $$ |  $$$$\\  $$$$ |      $$ /  \\__|$$ |         $$ |      $$ |     $$ |  $$$$\\ $$ |$$ /  \\__|\n  $$ |  $$\\$$\\$$ $$ |      $$ |$$$$\\ $$$$$\\       $$ |      $$ |     $$ |  $$ $$\\$$ |$$ |$$$$\\ \n  $$ |  $$ \\$$$  $$ |      $$ |\\_$$ |$$  __|      $$ |      $$ |     $$ |  $$ \\$$$$ |$$ |\\_$$ |\n  $$ |  $$ |\\$  /$$ |      $$ |  $$ |$$ |         $$ |      $$ |     $$ |  $$ |\\$$$ |$$ |  $$ |\n$$$$$$\\ $$ | \\_/ $$ |      \\$$$$$$  |$$$$$$$$\\    $$ |      $$ |   $$$$$$\\ $$ | \\$$ |\\$$$$$$  |\n\\______|\\__|     \\__|       \\______/ \\________|   \\__|      \\__|   \\______|\\__|  \\__| \\______/ \n                                                                                               \n                                                                                               \n                                                                                               \n$$$$$$$$\\ $$$$$$\\ $$$$$$$\\  $$$$$$$$\\ $$$$$$$\\                                                 \n\\__$$  __|\\_$$  _|$$  __$$\\ $$  _____|$$  __$$\\                                                \n   $$ |     $$ |  $$ |  $$ |$$ |      $$ |  $$ |                                               \n   $$ |     $$ |  $$$$$$$  |$$$$$\\    $$ |  $$ |                                               \n   $$ |     $$ |  $$  __$$< $$  __|   $$ |  $$ |                                               \n   $$ |     $$ |  $$ |  $$ |$$ |      $$ |  $$ |                                               \n   $$ |   $$$$$$\\ $$ |  $$ |$$$$$$$$\\ $$$$$$$  |                                               \n   \\__|   \\______|\\__|  \\__|\\________|\\_______/   ");
        Mesh go = new Mesh(" $$$$$$\\   $$$$$$\\        $$$$$$\\       $$\\      $$\\ $$$$$$\\ $$\\       $$\\       \n$$  __$$\\ $$  __$$\\       \\_$$  _|      $$ | $\\  $$ |\\_$$  _|$$ |      $$ |      \n$$ /  \\__|$$ /  $$ |        $$ |        $$ |$$$\\ $$ |  $$ |  $$ |      $$ |      \n\\$$$$$$\\  $$ |  $$ |        $$ |        $$ $$ $$\\$$ |  $$ |  $$ |      $$ |      \n \\____$$\\ $$ |  $$ |        $$ |        $$$$  _$$$$ |  $$ |  $$ |      $$ |      \n$$\\   $$ |$$ |  $$ |        $$ |        $$$  / \\$$$ |  $$ |  $$ |      $$ |      \n\\$$$$$$  | $$$$$$  |      $$$$$$\\       $$  /   \\$$ |$$$$$$\\ $$$$$$$$\\ $$$$$$$$\\ \n \\______/  \\______/       \\______|      \\__/     \\__|\\______|\\________|\\________|\n                                                                                 \n                                                                                 \n                                                                                 \n $$$$$$\\   $$$$$$\\        $$\\   $$\\  $$$$$$\\  $$\\      $$\\                       \n$$  __$$\\ $$  __$$\\       $$$\\  $$ |$$  __$$\\ $$ | $\\  $$ |                      \n$$ /  \\__|$$ /  $$ |      $$$$\\ $$ |$$ /  $$ |$$ |$$$\\ $$ |                      \n$$ |$$$$\\ $$ |  $$ |      $$ $$\\$$ |$$ |  $$ |$$ $$ $$\\$$ |                      \n$$ |\\_$$ |$$ |  $$ |      $$ \\$$$$ |$$ |  $$ |$$$$  _$$$$ |                      \n$$ |  $$ |$$ |  $$ |      $$ |\\$$$ |$$ |  $$ |$$$  / \\$$$ |                      \n\\$$$$$$  | $$$$$$  |      $$ | \\$$ | $$$$$$  |$$  /   \\$$ |                      \n \\______/  \\______/       \\__|  \\__| \\______/ \\__/     \\__|");
        Mesh sub = new Mesh("$$$$$$$\\   $$$$$$\\  $$\\   $$\\ $$$$$$$$\\       $$$$$$$$\\  $$$$$$\\  $$$$$$$\\   $$$$$$\\  $$$$$$$$\\ $$$$$$$$\\       $$$$$$$$\\  $$$$$$\\  \n$$  __$$\\ $$  __$$\\ $$$\\  $$ |\\__$$  __|      $$  _____|$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  _____|\\__$$  __|      \\__$$  __|$$  __$$\\ \n$$ |  $$ |$$ /  $$ |$$$$\\ $$ |   $$ |         $$ |      $$ /  $$ |$$ |  $$ |$$ /  \\__|$$ |         $$ |            $$ |   $$ /  $$ |\n$$ |  $$ |$$ |  $$ |$$ $$\\$$ |   $$ |         $$$$$\\    $$ |  $$ |$$$$$$$  |$$ |$$$$\\ $$$$$\\       $$ |            $$ |   $$ |  $$ |\n$$ |  $$ |$$ |  $$ |$$ \\$$$$ |   $$ |         $$  __|   $$ |  $$ |$$  __$$< $$ |\\_$$ |$$  __|      $$ |            $$ |   $$ |  $$ |\n$$ |  $$ |$$ |  $$ |$$ |\\$$$ |   $$ |         $$ |      $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |         $$ |            $$ |   $$ |  $$ |\n$$$$$$$  | $$$$$$  |$$ | \\$$ |   $$ |         $$ |       $$$$$$  |$$ |  $$ |\\$$$$$$  |$$$$$$$$\\    $$ |            $$ |    $$$$$$  |\n\\_______/  \\______/ \\__|  \\__|   \\__|         \\__|       \\______/ \\__|  \\__| \\______/ \\________|   \\__|            \\__|    \\______/ \n                                                                                                                                    \n                                                                                                                                    \n                                                                                                                                    \n $$$$$$\\  $$\\   $$\\ $$$$$$$\\   $$$$$$\\   $$$$$$\\  $$$$$$$\\  $$$$$$\\ $$$$$$$\\  $$$$$$$$\\       $$$$$$$$\\  $$$$$$\\                    \n$$  __$$\\ $$ |  $$ |$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\ \\_$$  _|$$  __$$\\ $$  _____|      \\__$$  __|$$  __$$\\                   \n$$ /  \\__|$$ |  $$ |$$ |  $$ |$$ /  \\__|$$ /  \\__|$$ |  $$ |  $$ |  $$ |  $$ |$$ |               $$ |   $$ /  $$ |                  \n\\$$$$$$\\  $$ |  $$ |$$$$$$$\\ |\\$$$$$$\\  $$ |      $$$$$$$  |  $$ |  $$$$$$$\\ |$$$$$\\             $$ |   $$ |  $$ |                  \n \\____$$\\ $$ |  $$ |$$  __$$\\  \\____$$\\ $$ |      $$  __$$<   $$ |  $$  __$$\\ $$  __|            $$ |   $$ |  $$ |                  \n$$\\   $$ |$$ |  $$ |$$ |  $$ |$$\\   $$ |$$ |  $$\\ $$ |  $$ |  $$ |  $$ |  $$ |$$ |               $$ |   $$ |  $$ |                  \n\\$$$$$$  |\\$$$$$$  |$$$$$$$  |\\$$$$$$  |\\$$$$$$  |$$ |  $$ |$$$$$$\\ $$$$$$$  |$$$$$$$$\\          $$ |    $$$$$$  |                  \n \\______/  \\______/ \\_______/  \\______/  \\______/ \\__|  \\__|\\______|\\_______/ \\________|         \\__|    \\______/                   \n                                                                                                                                    \n                                                                                                                                    \n                                                                                                                                    \n $$$$$$\\   $$$$$$\\  $$$$$$$\\   $$$$$$\\        $$\\    $$\\ $$$$$$$\\                                                                   \n$$  __$$\\ $$  __$$\\ $$  __$$\\ $$  __$$\\       $$ |   $$ |$$  __$$\\                                                                  \n$$ /  \\__|$$ /  $$ |$$ |  $$ |$$ /  $$ |      $$ |   $$ |$$ |  $$ |                                                                 \n\\$$$$$$\\  $$ |  $$ |$$$$$$$  |$$$$$$$$ |      \\$$\\  $$  |$$$$$$$  |                                                                 \n \\____$$\\ $$ |  $$ |$$  __$$< $$  __$$ |       \\$$\\$$  / $$  __$$<                                                                  \n$$\\   $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |        \\$$$  /  $$ |  $$ |                                                                 \n\\$$$$$$  | $$$$$$  |$$ |  $$ |$$ |  $$ |         \\$  /   $$ |  $$ |                                                                 \n \\______/  \\______/ \\__|  \\__|\\__|  \\__|          \\_/    \\__|  \\__|  ");
        Mesh bye = new Mesh("$$$$$$$\\ $$\\     $$\\ $$$$$$$$\\       $$$$$$$\\ $$\\     $$\\ $$$$$$$$\\             \n$$  __$$\\\\$$\\   $$  |$$  _____|      $$  __$$\\\\$$\\   $$  |$$  _____|            \n$$ |  $$ |\\$$\\ $$  / $$ |            $$ |  $$ |\\$$\\ $$  / $$ |                  \n$$$$$$$\\ | \\$$$$  /  $$$$$\\          $$$$$$$\\ | \\$$$$  /  $$$$$\\                \n$$  __$$\\   \\$$  /   $$  __|         $$  __$$\\   \\$$  /   $$  __|               \n$$ |  $$ |   $$ |    $$ |            $$ |  $$ |   $$ |    $$ |                  \n$$$$$$$  |   $$ |    $$$$$$$$\\       $$$$$$$  |   $$ |    $$$$$$$$\\ $$\\ $$\\ $$\\ \n\\_______/    \\__|    \\________|      \\_______/    \\__|    \\________|\\__|\\__|\\__|");
        Mesh bye2 = new Mesh("$$$$$$$\\ $$\\     $$\\ $$$$$$$$\\       $$$$$$$\\ $$\\     $$\\ $$$$$$$$\\ $$\\ \n$$  __$$\\\\$$\\   $$  |$$  _____|      $$  __$$\\\\$$\\   $$  |$$  _____|$$ |\n$$ |  $$ |\\$$\\ $$  / $$ |            $$ |  $$ |\\$$\\ $$  / $$ |      $$ |\n$$$$$$$\\ | \\$$$$  /  $$$$$\\          $$$$$$$\\ | \\$$$$  /  $$$$$\\    $$ |\n$$  __$$\\   \\$$  /   $$  __|         $$  __$$\\   \\$$  /   $$  __|   \\__|\n$$ |  $$ |   $$ |    $$ |            $$ |  $$ |   $$ |    $$ |          \n$$$$$$$  |   $$ |    $$$$$$$$\\       $$$$$$$  |   $$ |    $$$$$$$$\\ $$\\ \n\\_______/    \\__|    \\________|      \\_______/    \\__|    \\________|\\__|");
        Mesh last = new Mesh(" $$$$$$\\  $$\\   $$\\        $$$$$$\\  $$\\   $$\\ $$$$$$$$\\       $$\\        $$$$$$\\   $$$$$$\\ $$$$$$$$\\ \n$$  __$$\\ $$ |  $$ |      $$  __$$\\ $$$\\  $$ |$$  _____|      $$ |      $$  __$$\\ $$  __$$\\\\__$$  __|\n$$ /  $$ |$$ |  $$ |      $$ /  $$ |$$$$\\ $$ |$$ |            $$ |      $$ /  $$ |$$ /  \\__|  $$ |   \n$$ |  $$ |$$$$$$$$ |      $$ |  $$ |$$ $$\\$$ |$$$$$\\          $$ |      $$$$$$$$ |\\$$$$$$\\    $$ |   \n$$ |  $$ |$$  __$$ |      $$ |  $$ |$$ \\$$$$ |$$  __|         $$ |      $$  __$$ | \\____$$\\   $$ |   \n$$ |  $$ |$$ |  $$ |      $$ |  $$ |$$ |\\$$$ |$$ |            $$ |      $$ |  $$ |$$\\   $$ |  $$ |   \n $$$$$$  |$$ |  $$ |       $$$$$$  |$$ | \\$$ |$$$$$$$$\\       $$$$$$$$\\ $$ |  $$ |\\$$$$$$  |  $$ |   \n \\______/ \\__|  \\__|       \\______/ \\__|  \\__|\\________|      \\________|\\__|  \\__| \\______/   \\__|   \n                                                                                                     \n                                                                                                     \n                                                                                                     \n$$$$$$$$\\ $$\\   $$\\ $$$$$$\\ $$\\   $$\\  $$$$$$\\                                                       \n\\__$$  __|$$ |  $$ |\\_$$  _|$$$\\  $$ |$$  __$$\\                                                      \n   $$ |   $$ |  $$ |  $$ |  $$$$\\ $$ |$$ /  \\__|                                                     \n   $$ |   $$$$$$$$ |  $$ |  $$ $$\\$$ |$$ |$$$$\\                                                      \n   $$ |   $$  __$$ |  $$ |  $$ \\$$$$ |$$ |\\_$$ |                                                     \n   $$ |   $$ |  $$ |  $$ |  $$ |\\$$$ |$$ |  $$ |                                                     \n   $$ |   $$ |  $$ |$$$$$$\\ $$ | \\$$ |\\$$$$$$  |                                                     \n   \\__|   \\__|  \\__|\\______|\\__|  \\__| \\______/  ");
        Mesh thanks = new Mesh("$$$$$$$$\\ $$\\   $$\\  $$$$$$\\  $$\\   $$\\ $$\\   $$\\  $$$$$$\\        $$$$$$$$\\  $$$$$$\\  $$$$$$$\\  \n\\__$$  __|$$ |  $$ |$$  __$$\\ $$$\\  $$ |$$ | $$  |$$  __$$\\       $$  _____|$$  __$$\\ $$  __$$\\ \n   $$ |   $$ |  $$ |$$ /  $$ |$$$$\\ $$ |$$ |$$  / $$ /  \\__|      $$ |      $$ /  $$ |$$ |  $$ |\n   $$ |   $$$$$$$$ |$$$$$$$$ |$$ $$\\$$ |$$$$$  /  \\$$$$$$\\        $$$$$\\    $$ |  $$ |$$$$$$$  |\n   $$ |   $$  __$$ |$$  __$$ |$$ \\$$$$ |$$  $$<    \\____$$\\       $$  __|   $$ |  $$ |$$  __$$< \n   $$ |   $$ |  $$ |$$ |  $$ |$$ |\\$$$ |$$ |\\$$\\  $$\\   $$ |      $$ |      $$ |  $$ |$$ |  $$ |\n   $$ |   $$ |  $$ |$$ |  $$ |$$ | \\$$ |$$ | \\$$\\ \\$$$$$$  |      $$ |       $$$$$$  |$$ |  $$ |\n   \\__|   \\__|  \\__|\\__|  \\__|\\__|  \\__|\\__|  \\__| \\______/       \\__|       \\______/ \\__|  \\__|\n                                                                                                \n                                                                                                \n                                                                                                \n$$$$$$$\\  $$\\        $$$$$$\\ $$\\     $$\\ $$$$$$\\ $$\\   $$\\  $$$$$$\\                             \n$$  __$$\\ $$ |      $$  __$$\\\\$$\\   $$  |\\_$$  _|$$$\\  $$ |$$  __$$\\                            \n$$ |  $$ |$$ |      $$ /  $$ |\\$$\\ $$  /   $$ |  $$$$\\ $$ |$$ /  \\__|                           \n$$$$$$$  |$$ |      $$$$$$$$ | \\$$$$  /    $$ |  $$ $$\\$$ |$$ |$$$$\\                            \n$$  ____/ $$ |      $$  __$$ |  \\$$  /     $$ |  $$ \\$$$$ |$$ |\\_$$ |                           \n$$ |      $$ |      $$ |  $$ |   $$ |      $$ |  $$ |\\$$$ |$$ |  $$ |                           \n$$ |      $$$$$$$$\\ $$ |  $$ |   $$ |    $$$$$$\\ $$ | \\$$ |\\$$$$$$  |                           \n\\__|      \\________|\\__|  \\__|   \\__|    \\______|\\__|  \\__| \\______/  ");
        Mesh lazy = new Mesh("$$$$$$\\ $$\\      $$\\       $$$$$$$$\\  $$$$$$\\        $$\\        $$$$$$\\  $$$$$$$$\\ $$\\     $$\\         \n\\_$$  _|$$$\\    $$$ |      \\__$$  __|$$  __$$\\       $$ |      $$  __$$\\ \\____$$  |\\$$\\   $$  |        \n  $$ |  $$$$\\  $$$$ |         $$ |   $$ /  $$ |      $$ |      $$ /  $$ |    $$  /  \\$$\\ $$  /         \n  $$ |  $$\\$$\\$$ $$ |         $$ |   $$ |  $$ |      $$ |      $$$$$$$$ |   $$  /    \\$$$$  /          \n  $$ |  $$ \\$$$  $$ |         $$ |   $$ |  $$ |      $$ |      $$  __$$ |  $$  /      \\$$  /           \n  $$ |  $$ |\\$  /$$ |         $$ |   $$ |  $$ |      $$ |      $$ |  $$ | $$  /        $$ |            \n$$$$$$\\ $$ | \\_/ $$ |         $$ |    $$$$$$  |      $$$$$$$$\\ $$ |  $$ |$$$$$$$$\\     $$ |            \n\\______|\\__|     \\__|         \\__|    \\______/       \\________|\\__|  \\__|\\________|    \\__|            \n                                                                                                       \n                                                                                                       \n                                                                                                       \n$$$$$$$$\\  $$$$$$\\        $$$$$$$$\\ $$$$$$$\\  $$$$$$\\ $$\\      $$\\       $$$$$$$$\\ $$\\   $$\\ $$$$$$$$\\ \n\\__$$  __|$$  __$$\\       \\__$$  __|$$  __$$\\ \\_$$  _|$$$\\    $$$ |      \\__$$  __|$$ |  $$ |$$  _____|\n   $$ |   $$ /  $$ |         $$ |   $$ |  $$ |  $$ |  $$$$\\  $$$$ |         $$ |   $$ |  $$ |$$ |      \n   $$ |   $$ |  $$ |         $$ |   $$$$$$$  |  $$ |  $$\\$$\\$$ $$ |         $$ |   $$$$$$$$ |$$$$$\\    \n   $$ |   $$ |  $$ |         $$ |   $$  __$$<   $$ |  $$ \\$$$  $$ |         $$ |   $$  __$$ |$$  __|   \n   $$ |   $$ |  $$ |         $$ |   $$ |  $$ |  $$ |  $$ |\\$  /$$ |         $$ |   $$ |  $$ |$$ |      \n   $$ |    $$$$$$  |         $$ |   $$ |  $$ |$$$$$$\\ $$ | \\_/ $$ |         $$ |   $$ |  $$ |$$$$$$$$\\ \n   \\__|    \\______/          \\__|   \\__|  \\__|\\______|\\__|     \\__|         \\__|   \\__|  \\__|\\________|\n                                                                                                       \n                                                                                                       \n                                                                                                       \n$$\\      $$\\ $$\\   $$\\  $$$$$$\\  $$$$$$\\  $$$$$$\\                                                      \n$$$\\    $$$ |$$ |  $$ |$$  __$$\\ \\_$$  _|$$  __$$\\                                                     \n$$$$\\  $$$$ |$$ |  $$ |$$ /  \\__|  $$ |  $$ /  \\__|                                                    \n$$\\$$\\$$ $$ |$$ |  $$ |\\$$$$$$\\    $$ |  $$ |                                                          \n$$ \\$$$  $$ |$$ |  $$ | \\____$$\\   $$ |  $$ |                                                          \n$$ |\\$  /$$ |$$ |  $$ |$$\\   $$ |  $$ |  $$ |  $$\\                                                     \n$$ | \\_/ $$ |\\$$$$$$  |\\$$$$$$  |$$$$$$\\ \\$$$$$$  |                                                    \n\\__|     \\__| \\______/  \\______/ \\______| \\______/                                                     \n                                                        ");
        Mesh wait = new Mesh(" $$$$$$\\   $$$$$$\\           $$$$$\\ $$\\   $$\\  $$$$$$\\ $$$$$$$$\\       $$\\      $$\\  $$$$$$\\  $$$$$$\\ $$$$$$$$\\ \n$$  __$$\\ $$  __$$\\          \\__$$ |$$ |  $$ |$$  __$$\\\\__$$  __|      $$ | $\\  $$ |$$  __$$\\ \\_$$  _|\\__$$  __|\n$$ /  \\__|$$ /  $$ |            $$ |$$ |  $$ |$$ /  \\__|  $$ |         $$ |$$$\\ $$ |$$ /  $$ |  $$ |     $$ |   \n\\$$$$$$\\  $$ |  $$ |            $$ |$$ |  $$ |\\$$$$$$\\    $$ |         $$ $$ $$\\$$ |$$$$$$$$ |  $$ |     $$ |   \n \\____$$\\ $$ |  $$ |      $$\\   $$ |$$ |  $$ | \\____$$\\   $$ |         $$$$  _$$$$ |$$  __$$ |  $$ |     $$ |   \n$$\\   $$ |$$ |  $$ |      $$ |  $$ |$$ |  $$ |$$\\   $$ |  $$ |         $$$  / \\$$$ |$$ |  $$ |  $$ |     $$ |   \n\\$$$$$$  | $$$$$$  |      \\$$$$$$  |\\$$$$$$  |\\$$$$$$  |  $$ |         $$  /   \\$$ |$$ |  $$ |$$$$$$\\    $$ |   \n \\______/  \\______/        \\______/  \\______/  \\______/   \\__|         \\__/     \\__|\\__|  \\__|\\______|   \\__|   \n                                                                                                                \n                                                                                                                \n                                                                                                                \n$$$$$$$$\\ $$$$$$\\ $$\\       $$\\             $$$$$$$$\\ $$\\   $$\\ $$$$$$$$\\       $$$$$$$$\\ $$\\   $$\\ $$$$$$$\\    \n\\__$$  __|\\_$$  _|$$ |      $$ |            \\__$$  __|$$ |  $$ |$$  _____|      $$  _____|$$$\\  $$ |$$  __$$\\   \n   $$ |     $$ |  $$ |      $$ |               $$ |   $$ |  $$ |$$ |            $$ |      $$$$\\ $$ |$$ |  $$ |  \n   $$ |     $$ |  $$ |      $$ |               $$ |   $$$$$$$$ |$$$$$\\          $$$$$\\    $$ $$\\$$ |$$ |  $$ |  \n   $$ |     $$ |  $$ |      $$ |               $$ |   $$  __$$ |$$  __|         $$  __|   $$ \\$$$$ |$$ |  $$ |  \n   $$ |     $$ |  $$ |      $$ |               $$ |   $$ |  $$ |$$ |            $$ |      $$ |\\$$$ |$$ |  $$ |  \n   $$ |   $$$$$$\\ $$$$$$$$\\ $$$$$$$$\\          $$ |   $$ |  $$ |$$$$$$$$\\       $$$$$$$$\\ $$ | \\$$ |$$$$$$$  |  \n   \\__|   \\______|\\________|\\________|         \\__|   \\__|  \\__|\\________|      \\________|\\__|  \\__|\\_______/ ");
        
        Mesh[] meshes =
        {
            none, title, author, director, written, program, design, art, model, concept, tech, music, voice, koban, cucumber,
            dontKnow, cool, asCucumber, anyway, stalling, so, what,
            care, even, computer, anything, tired, go, sub, bye, bye2, last, thanks, lazy, wait
        };

        Sequence when = new Sequence();
        when.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Credits\\UmOfirWhereAreWe.wav");
        when.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Credits\\IThinkTheRealQuestionIs.wav");
        when.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\Credits\\WhenAreWe.wav");
        
        CutsceneLevel level = new CutsceneLevel(meshes, $"{Environment.CurrentDirectory}\\MIDI\\NeverGonnaGiveYouUp.mid", AnimeStore(), _gameManager);
        level.AddEndDialogue(when);
        level.AddEndingURL("https://youtu.be/MMU-CPrUBlk?t=552");
        level.AddEndingMesh(new Mesh("$$\\  $$$$$$$\\        $$$$$$$\\  $$$$$$$$\\ $$\\   $$\\       $$$$$$$\\   $$$$$$\\  $$$$$$$\\                               \n$$  __$$\\ $$  __$$\\ $$  __$$\\       $$  __$$\\ $$  _____|$$$\\  $$ |      $$  __$$\\ $$  __$$\\ $$  __$$\\                              \n$$ |  $$ |$$ /  $$ |$$ |  $$ |      $$ |  $$ |$$ |      $$$$\\ $$ |      $$ |  $$ |$$ /  $$ |$$ |  $$ |                             \n$$ |  $$ |$$ |  $$ |$$$$$$$  |      $$$$$$$\\ |$$$$$\\    $$ $$\\$$ |      $$ |  $$ |$$ |  $$ |$$$$$$$  |                             \n$$ |  $$ |$$ |  $$ |$$  __$$<       $$  __$$\\ $$  __|   $$ \\$$$$ |      $$ |  $$ |$$ |  $$ |$$  __$$<                              \n$$ |  $$ |$$ |  $$ |$$ |  $$ |      $$ |  $$ |$$ |      $$ |\\$$$ |      $$ |  $$ |$$ |  $$ |$$ |  $$ |                             \n$$$$$$$  | $$$$$$  |$$ |  $$ |      $$$$$$$  |$$$$$$$$\\ $$ | \\$$ |      $$$$$$$  | $$$$$$  |$$ |  $$ |                             \n\\_______/  \\______/ \\__|  \\__|      \\_______/ \\________|\\__|  \\__|      \\_______/  \\______/ \\__|  \\__|                             \n                                                                                                                                   \n                                                                                                                                   \n                                                                                                                                   \n$$\\      $$\\ $$$$$$\\ $$\\       $$\\             $$$$$$$\\  $$$$$$$$\\ $$$$$$$$\\ $$\\   $$\\ $$$$$$$\\  $$\\   $$\\       $$$$$$\\ $$\\   $$\\ \n$$ | $\\  $$ |\\_$$  _|$$ |      $$ |            $$  __$$\\ $$  _____|\\__$$  __|$$ |  $$ |$$  __$$\\ $$$\\  $$ |      \\_$$  _|$$$\\  $$ |\n$$ |$$$\\ $$ |  $$ |  $$ |      $$ |            $$ |  $$ |$$ |         $$ |   $$ |  $$ |$$ |  $$ |$$$$\\ $$ |        $$ |  $$$$\\ $$ |\n$$ $$ $$\\$$ |  $$ |  $$ |      $$ |            $$$$$$$  |$$$$$\\       $$ |   $$ |  $$ |$$$$$$$  |$$ $$\\$$ |        $$ |  $$ $$\\$$ |\n$$$$  _$$$$ |  $$ |  $$ |      $$ |            $$  __$$< $$  __|      $$ |   $$ |  $$ |$$  __$$< $$ \\$$$$ |        $$ |  $$ \\$$$$ |\n$$$  / \\$$$ |  $$ |  $$ |      $$ |            $$ |  $$ |$$ |         $$ |   $$ |  $$ |$$ |  $$ |$$ |\\$$$ |        $$ |  $$ |\\$$$ |\n$$  /   \\$$ |$$$$$$\\ $$$$$$$$\\ $$$$$$$$\\       $$ |  $$ |$$$$$$$$\\    $$ |   \\$$$$$$  |$$ |  $$ |$$ | \\$$ |      $$$$$$\\ $$ | \\$$ |\n\\__/     \\__|\\______|\\________|\\________|      \\__|  \\__|\\________|   \\__|    \\______/ \\__|  \\__|\\__|  \\__|      \\______|\\__|  \\__|\n                                                                                                                                   \n                                                                                                                                   \n                                                                                                                                   \n$$\\   $$\\  $$$$$$\\  $$\\       $$$$$$$$\\       $$\\       $$$$$$\\ $$$$$$$$\\ $$$$$$$$\\       $$$$$$$$\\                                \n$$ |  $$ |$$  __$$\\ $$ |      $$  _____|      $$ |      \\_$$  _|$$  _____|$$  _____|      \\____$$  |                               \n$$ |  $$ |$$ /  $$ |$$ |      $$ |            $$ |        $$ |  $$ |      $$ |                $$  /                                \n$$$$$$$$ |$$$$$$$$ |$$ |      $$$$$\\          $$ |        $$ |  $$$$$\\    $$$$$\\             $$  /                                 \n$$  __$$ |$$  __$$ |$$ |      $$  __|         $$ |        $$ |  $$  __|   $$  __|           $$  /                                  \n$$ |  $$ |$$ |  $$ |$$ |      $$ |            $$ |        $$ |  $$ |      $$ |             $$  /                                   \n$$ |  $$ |$$ |  $$ |$$$$$$$$\\ $$ |            $$$$$$$$\\ $$$$$$\\ $$ |      $$$$$$$$\\       $$  /                                    \n\\__|  \\__|\\__|  \\__|\\________|\\__|            \\________|\\______|\\__|      \\________|      \\__/                       "));

        return level;
    } //End credits

    #region Other Levels

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

        Actor me = new Actor(22, 5, 1, 1, new Graphics('!', ConsoleColor.DarkRed));        
        TriggerBox meTrigger = new TriggerBox(22, 4, 2, 2);
        Sequence withoutMe = new Sequence();
        withoutMe.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\ObanKoban\\WithoutMe.wav");
        meTrigger.AddSequance(withoutMe);
        
        Actor wall = new Actor(35, 2, 5, 1, new Graphics('|', ConsoleColor.Black));
        Actor wall2 = new Actor(0, 0, 6, 2, new Graphics('|', ConsoleColor.Black));
        
        Chest chest = new Chest(new Healing("Shibuia Ramen", 76, "Delicate fish and pork stock, Japanese spices, sesame, ramen noodles, a piece of pork, Half an egg, bamboo shoots, shiitake mushrooms, spinach, sprouts, green onions."), 0, 1);
        
        Actor[] actors =
        {
            door, cashier, cashier2, table, table2, table3, table4, table5, table6, table7, table8, wall, doorCover, wall2, chest, meTrigger, me
            
        };
        
        Level level = Utilities.CreateLevel("Oban Koban", 40, 6, _player, actors);
        
        Enemy enemy = Utilities.GenerateEnemy(level, "Angry customer (He got napkin in 2 minutes instead of 1 minute)");
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
    
    static Level AnimeStore()
    {
        Door door = new Door(1, 0, DoorDirection.Down, true, true);
        
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
        Door door = new Door(1, 0, DoorDirection.Down, true, true);
        
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
        Door door = new Door(1, 0, DoorDirection.Down, true, true);
        
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
        Door door = new Door(1, 0, DoorDirection.Down, true, true);
        TriggerBox clashTrigger = new TriggerBox(2, 2);
        Sequence clashSequence = new Sequence();
        clashSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TheThirdEar\\ExcuseMeDoYouHaveAnythingByTheClashAtDemonhead.wav");
        clashSequence.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\TheThirdEar\\HaveYouTriedTheSectionMarkedTheClashAtDemonhead.wav");
        clashTrigger.AddSequance(clashSequence);
        
        Actor cashier = new Actor(0, 7, 4, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(4, 7, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Chest chest = new Chest(new Item("Vinyl", "A vinyl of \"Sex Bob-Omb\". I heard the bass player had to fight 7 evil exes."), 17, 2);
        Chest chest2 = new Chest(new Weapon("Small bag", 34, "The small bag from the song \"Small bag\". This song is so bad... Everyone who hears this gets an 30 HP damage."), 17, 5);
        
        Actor[] actors =
        {
            door, cashier, cashier2, chest, chest2, clashTrigger
        };
        
        Level level = Utilities.CreateLevel("The third ear", 10, _player, actors);
        
        Enemy enemy = Utilities.GenerateEnemy(level, "Julie");
        Enemy[] enemies = { enemy };
        level.SetEnemies(enemies);
        
        return level;
    }
    
    static Level BooksCrossroad()
    {
        Door door = new Door(1, 0, DoorDirection.Down, true, true);
        
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
    
    static Level DMC()
    {
        Door door = new Door(1, 0, DoorDirection.Down, true, true);
        
        Actor cashier = new Actor(0, 7, 4, 1, new Graphics('.', ConsoleColor.Gray));
        Actor cashier2 = new Actor(4, 7, 1, 2, new Graphics('.', ConsoleColor.Gray));

        Chest chest = new Chest(new Weapon("Devil Sword Sparda", "Cool sword, it says she deals 63 HP damage.", 63), 17, 2);
        Chest chest2 = new Chest(new Item("Arm", "An arm of a dead weight."), 17, 5);

        Enemy v = new Enemy(1, 9, "V");

        TriggerBox vTrigger = new TriggerBox(2, 8, 1, 2);
        Sequence bible = new Sequence();
        bible.AddLine($"{Environment.CurrentDirectory}\\VoiceLines\\DMC\\Bible.wav");
        vTrigger.AddSequance(bible);
        
        Actor[] actors =
        {
            door, cashier, cashier2, chest, chest2,  vTrigger
        };
        
        Level level = Utilities.CreateLevel("Devil May Cry", 10, _player, actors);
        level.SetEnemies(new[] {v});
        
        return level;
    }

    #endregion
}