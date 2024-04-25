namespace DungeonCrawler;

public static class DeathScreen
{
    private static string[] _lines =
    {
        "Downside you're dead. But the upside? We've got each other, Bruce. Forever!",
        "This is how it happened. This is how the Batman died.",
        "this is the end Bruce and now we're going to be together FOREVER!!!!",
        "Oops. You're dead! Wait, does that mean I'm dead?! GET UP, BRUCE, GET UP!",
        "Well that's what I get for betting it all on black.",
        "Now, if I was in charge this never would have happened!",
        "Aw, off to see Mom and Pop at that big country club in the sky.",
        "Oh, Bats, you big kidder. You don't fool me. Bats? Bats?",
        "Don't head towards the light, Bruce. It's not fair, they'll never let me in!",
        "Who's going to fight crime now? Robin?",
        "You should take better care of yourself, Batsy. There's two of us in there!",
        "What? You survive everything I ever threw at you only to die now, like this?",
        "What the? Why is everything gone dark? Are we dying? We better not be dying, Bruce.",
        "Come on, Bruce. You can't die! I didn't kill you!",
        "That's it, Bats, play dead. We've got' em right where we-oh dear.",
        "I've sat through my own funeral already, now I have to go through the whole thing again?! Thanks for nothing!",
        "Well, that's one less Gordon to worry about. At least now you won't have to tell him the truth about Babs.",
        "There goes your only lead to finding Barbara. Well, it was fun while it lasted.",
        "I figured you'd have a little more fight in you. Guess I figured wrong!",
        "Oh, Bats! I really figured you'd last longer than that!",
        "It's okay to die, Bats. I'll be here to protect Gotham. I'll do a real good job!",
        "Hahahaha",
        "hahhahahahahahhh!!",
        "Heheheheheheheheh",
        "Get up, Bats! Hey, you ain't looking so good!",
        "Oh, Bats! If you only knew what I have planned! You'd just die!",
        "Aren't you supposed to be up on your feet and trying to stop me?",
        "Oh, isn't that cute? Little bat's a-sleepin! Someone finish him off.",
        "Hey! Someone help Bat-baby up off the floor!",
        "I'd like to thank my fans for their undying support, and the people of Gotham, who I'll be seeing very, very soon...",
        "Gotta say, I thought you'd last longer.",
        "I salute my fallen enemy!",
        "That loser didn't stand a chance! I mean, look at me!",
        "Too easy! Played you like a violin, then cut your strings. Nighty night, Bats!",
        "Tonight, Gotham, I have defeated your dear Dark Knight. Don't be sad - you're next!",
        "One down. Who's next to party with me?",
        "Who else wants to get crazy?!",
        "Awww. Too bad. So sad!",
        "Oh I'm sorry! Did I kill your friend? Oops! My bad! Haha!",
        "Looks like I'm gonna need to find a new playmate. Oh, and we were having so much fun, too!",
        "Ding dong, the Bat is dead! Which old Bat? The dumb old Bat! Ding dong, the dumb old Bat is dead! HAHAHA!",
        "Aw... Gotta say, I thought you'd have more fight in you. A lot more fight."
    };

    public static string RandomLine()
    {
        int random = Random.Shared.Next(_lines.Length - 1);
        return _lines[random];
    }
}