using System;

namespace Morse_Code
{
    public class Program
    {
        private static void Main()
        {
            var mUtility = new Utility();

            Console.Write("Type the Sentance you would like to encrypt to Morse ::");

            var morseSentance = mUtility.Sentance_To_Morse(Console.ReadLine());

            Console.WriteLine("Your sentance has been encrypted to {0}", morseSentance);

            Console.WriteLine(mUtility.Morse_To_Sentance(morseSentance));

            mUtility.PlayMessage(morseSentance);

            Console.Read();
        }
    }
}
