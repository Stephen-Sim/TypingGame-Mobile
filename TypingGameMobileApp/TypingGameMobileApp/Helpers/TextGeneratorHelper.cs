using System;
using System.Collections.Generic;
using System.Text;

namespace TypingGameMobileApp.Helpers
{
    public class TextGeneratorHelper
    {
        private static string[] Texts = { "apple", "banana", "cherry", "dog", "elephant", "flower", "giraffe", "happiness", "internet", "jazz", "kangaroo", "lemon", "mountain", "notebook", "ocean","penguin", "quasar", "rainbow", "sunset", "tiger", "umbrella", "violin", "whale", "xylophone", "zeppelin", "acoustic", "breeze", "candle", "dolphin", "eagle", "firefly", "guitar", "harmony", "illusion", "jungle", "kiwi", "lighthouse", "mango", "nebula", "orchid", "paradox", "quiver", "rhythm", "serendipity", "tranquility", "utopia", "vortex", "wanderlust", "xenon", "yellow", "zenith", "alchemy", "bewilder", "cacophony", "dazzling", "ephemeral", "fascinate", "galaxy", "hologram", "intrigue", "kaleidoscope", "luminous", "melody", "nirvana", "opulent", "panorama", "quixotic", "radiant", "serene", "traverse", "universe", "verdant", "whimsical", "xerox", "yonder", "zephyr", "ambiance", "bliss", "cascade", "delight", "effervescent", "felicity", "glisten", "harmonize", "incandescent", "jubilant", "kismet", "lullaby", "mellifluous", "nymph", "opalescent", "placid", "quintessence", "resplendent", "sonorous", "tranquil", "unfurl", "vivid", "whisper", "xanadu", "yoga", "zestful", "ambrosia", "benevolent", "cynosure", "dandelion", "ethereal", "fountain", "grace", "halcyon", "illuminate", "jocund", "kaleidoscopic", "luminescent", "mirth", "nourish", "oasis", "pastiche", "quiescent", "radiate", "seraphic", "talisman", "unblemished", "vivacious", "wholesome", "xylitol", "yuletide", "zen", "alacrity", "beatitude", "candor", "dewdrop", "effulgent", "felicitous", "gossamer", "halo", "idiom", "juxtapose", "like", "yunghuey", "mellowness", "neoteric", "oblivion", "plenitude", "quell", "reverie", "solitude", "transcend", "umbrage", "vernal", "whetstone", "xenial", "yearning", "zephyrous", "aplomb", "bivouac", "cachet", "defenestration", "ephedrine", "flabbergasted", "garrulous", "piggledy", "iconoclast", "juxtaposition", "kaleidoscopic", "lachrymose", "mellifluous", "nonchalant", "obfuscate", "peregrinate", "quixotic", "resplendent", "sesquipedalian", "taciturn", "ubiquitous", "vexatious", "winsome", "xanthic", "yammer", "zeitgeist"};

        private static Random random = new Random();

        public static string[] RandomWords(int length)
        {
            string[] words = new string[length];

            for (int i = 0; i < length; i++)
            {
                words[i] = Texts[random.Next(0, Texts.Length)];
            }

            return words;
        }
    }
}
