using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {

            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }

            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList(); //cards are in random order in deck

            //Greetings Message goes here 

            //Draw a card from deck
            var discardPile = new List<Card>();
            int count = 0;
            var playerHand = new List<Card>();
            var playerPoints = new List<int>();
            var playerTotal = 0;
            while (count < 5 && playerTotal < 21)
            {
                Console.WriteLine($"The drawn card is {randomDeck[0]}"); //drawing first card from top
                playerHand.Add(randomDeck[0]); //adds the top card to player's hand list & removes it
                randomDeck.RemoveAt(0);
                Console.WriteLine("  ");
                Console.WriteLine($"The value of the card:{playerHand[count].GetCardValue()}, "); //card points 
                playerPoints.Add(playerHand[count].GetCardValue()); //adds players points to another list
                playerTotal = playerPoints.Sum(); //takes the total of player's points so far
                Console.WriteLine("");
                Console.WriteLine($"The total number of points in your hands: {playerTotal}");
                if (playerTotal < 21)
                {
                    Console.WriteLine("Want me to hit you, or do you wanna fold?");
                    Console.WriteLine(" ");
                }
                count++;
                if (playerTotal > 21)
                {
                    Console.WriteLine("You lose the game!");
                }
            }
                
                
            
          
            

        }
    }
}
