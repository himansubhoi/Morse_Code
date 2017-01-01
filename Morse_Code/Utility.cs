using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Morse_Code
{
   public class Utility
    {
        public Dictionary<string, string> TheLibrary { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Initiates the Library inorder to use the Morse Code
        /// </summary>
        public Utility()
        {
            LoadMorse();
        }
        /// <summary>
        /// Converts a Sentance into A string
        /// </summary>
        /// <param name="sentance">Sentance you would like to convert</param>
        /// <returns>String Value => The encrypted Morse Code</returns>
        public string Sentance_To_Morse(string sentance)
        {
            //A single Space will identify inter character spaces in our words
            //A Triple Space will identify inter word spaces in our sentance
            var returnString = "";
            //We will start by deconstucting our sentance into a String List 
            //to hold our words in the sentance
            var words = sentance.Split(' ').ToList();
            //then we will loop through our words to start 
            //creating the morse value for each letter in the list
            foreach (var word in words)
            {
                for (var letter = 0; letter < word.Length; letter++)
                {
                    //to upper is used to check if the value is in our library
                    if (TheLibrary.ContainsKey(word[letter].ToString().ToUpper()))
                    {
                        returnString += TheLibrary[word[letter].ToString().ToUpper()];//Gets the morse value for our letter
                    }//Makes Sure That the character is in our library
                    else
                    {
                        Console.WriteLine("The Character {0} is not reconized in the morse Library", letter.ToString().ToUpper());
                    }//tell the user there was a mistake
                    returnString += " ";//add inter character space
                }
                returnString = returnString.Trim(' ');  //remove the single space from the back to add
                //inter word space other wize we will have four spaces
                returnString += "   ";
            }
            return returnString.Trim(' ');
        }

        /// <summary>
        /// Converts The Code From Morse To A readable Sentance
        /// </summary>
        /// <param name="morse">The Code that Needs to Be Docoded</param>
        /// <returns>String Value => The Readable Sentance</returns>
        public string Morse_To_Sentance(string morse)
        {
            var returnString = "";
            //we will split the Code received into word segments remember the triple space
            //well now we will just replace that with a comma and split the Code on the comma
            morse = morse.Replace("   ", ",");
            var morceWords = morse.Split(',');
            foreach (var word in morceWords)
            {
                if (word != "")
                {
                    //remember the inter character spaces we assigned now we will split the word into its charaters
                    var morseCodeLetters = word.Split(' ');
                    returnString = (from morseCodeLetter in morseCodeLetters
                                    where TheLibrary.ContainsValue(morseCodeLetter)
                                    from morseItem in TheLibrary
                                    where morseItem.Value == morseCodeLetter
                                    select morseItem
                                    ).Aggregate(returnString, (current, morseItem) => current + morseItem.Key
                                   );
                }
                returnString += " ";//add inter word space
            }
            return returnString.Trim(' ');
        }

        /// <summary>
        /// Plays the complete Morse Code using Console Beeps
        /// </summary>
        /// <param name="message">The Message of the Morse Code</param>
        public void PlayMessage(string message)
        {
            message.ToList().ForEach((c) =>
            {
                switch (c)
                {
                    case '.':
                        CreateDit(200);
                        break;
                    case '-':
                        CreateDah(600);
                        break;
                    default:
                        Thread.Sleep(200);
                        break;
                }
            });

        }

        /// <summary>
        /// Play a single sound representing a dot
        /// </summary>
        /// <param name="time">The lenth of the sound</param>
        protected void CreateDit(int time)
        {
            Console.Beep(1100, time);
        }
        /// <summary>
        /// Play a single sound representing a Dash
        /// </summary>
        /// <param name="time">The lenth of the sound</param>
        protected void CreateDah(int time)
        {
            Console.Beep(1100, time);
        }

        protected void LoadMorse()
        {
            #region Alphabet A-Z
            TheLibrary.Add("A", ".-");//1
            TheLibrary.Add("B", "-...");//2
            TheLibrary.Add("C", "-.-.");//3
            TheLibrary.Add("D", "-..");//4
            TheLibrary.Add("E", ".");//5
            TheLibrary.Add("F", "..-.");//6
            TheLibrary.Add("G", "--.");//7
            TheLibrary.Add("H", "....");//8
            TheLibrary.Add("I", "..");//9
            TheLibrary.Add("J", ".---");//10
            TheLibrary.Add("K", "-.-");//11
            TheLibrary.Add("L", ".-..");//12
            TheLibrary.Add("M", "--");//13
            TheLibrary.Add("N", "-.");//14
            TheLibrary.Add("O", "---");//15
            TheLibrary.Add("P", ".--.");//16
            TheLibrary.Add("Q", "--.-");//17
            TheLibrary.Add("R", ".-.");//18
            TheLibrary.Add("S", "...");//19
            TheLibrary.Add("T", "-");//20
            TheLibrary.Add("U", "..-");//21
            TheLibrary.Add("V", "...-");//22
            TheLibrary.Add("W", ".--");//23
            TheLibrary.Add("X", "-..-");//24
            TheLibrary.Add("Y", "-.--");//25
            TheLibrary.Add("Z", "--..");//26
            #endregion

            #region Numuric 0-9
            //Numbers
            TheLibrary.Add("1", ".----");//1
            TheLibrary.Add("2", "..---");//2
            TheLibrary.Add("3", "...--");//3
            TheLibrary.Add("4", "....-");//4
            TheLibrary.Add("5", ".....");//5
            TheLibrary.Add("6", "-....");//6
            TheLibrary.Add("7", "--...");//7
            TheLibrary.Add("8", "---..");//8
            TheLibrary.Add("9", "----.");//9
            TheLibrary.Add("0", "-----");//10
            #endregion

            #region Abstract @ / ? etc

            TheLibrary.Add("@", ".--.-.");
            TheLibrary.Add("?", "..--..");
            TheLibrary.Add("/", ".--.-.");

            #endregion
        }

    }
}
