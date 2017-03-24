using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Program
    {
        static List<Card> CreateAndShuffleDeck()
        {
            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
}

            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            return randomDeck;
        }  //create and shuffle deck, ready to draw 

        //deal cards to player
        static List<Card> DealPlayerCards(List<Card> randomDeck, List<Card> playerHand)
        {
            playerHand.Add(randomDeck[0]); 
            Console.WriteLine($"You drew the {randomDeck[0]}"); 
            randomDeck.RemoveAt(0);
            return playerHand;
        }

        //deal cards to dealer
        static List<Card> DealDealerCards(List<Card> randomDeck, List<Card> dealerHand)
        {
            dealerHand.Add(randomDeck[0]);
            Console.WriteLine($"The dealer drew {randomDeck[0]}");
            randomDeck.RemoveAt(0);
            return dealerHand;
        }

        //get the total of the hand by converting card class to int
        static int GetHandTotal(List<Card> hand) 
        {
            var sum = 0;
            foreach (var card in hand)
            {
                sum += card.GetCardValue();
            }
            Console.WriteLine($"Total points: {sum} points");
            Console.WriteLine(" ");
            return sum;
        }


            


        //Hit or stand response from user. Coded to only accept a number 
        static int HitOrStand(string message) 
        {
            var input = message;
            int number = 0;
            bool wasFormatCorrect = int.TryParse(input, out number);
            while (!wasFormatCorrect)
            {
                Console.WriteLine("Please enter the number 1 or 2, do not use words");
                input = Console.ReadLine();
                wasFormatCorrect = int.TryParse(input, out number);
            }
            return number;
        }



        static void Main(string[] args)
        {

            //cards are in random order in deck

            // Greetings Message goes here

            //Draw a card from deck

            var randomDeck = CreateAndShuffleDeck(); //shuffle deck and declare to a variable 

            int count = 0;
            var playerHand = new List<Card>();
            var playerTotal = 0;
            var hitOrStand = 0;
            var dealerHand = new List<Card>();
            var dealerTotal = 0;
            bool stand = true;


            while (count < 5 && playerTotal < 22 && stand == true)
            {
                for (int i = 0; i < 2; i++)
                {
                DealPlayerCards(randomDeck, playerHand); //deal 1 card to player and remove from deck
                playerTotal = GetHandTotal(playerHand); //calculates the sum so far of the player hand
                
                    if (dealerTotal < 16)
                    {
                        DealDealerCards(randomDeck, dealerHand); //dealer draws next card & remove from deck 
                        dealerTotal = GetHandTotal(dealerHand); //calculates the sum so far of the dealer hand
                    }
                }


                 Console.WriteLine("Enter 1 to hit or 2 to stand");
                 hitOrStand = HitOrStand(Console.ReadLine());

                if (hitOrStand == 1 && count > 2 && dealerTotal < 16 && playerTotal < 21)
                 {
                    DealPlayerCards(randomDeck, playerHand);
                    playerTotal = GetHandTotal(playerHand);

                    DealPlayerCards(randomDeck, dealerHand);
                    dealerTotal = GetHandTotal(dealerHand);
                }
               
                if (hitOrStand == 2)
                {
                    stand = false;
                }
                    
                count++;
                        
            }

            if (stand == false)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Let's compare cards");
                if (playerTotal > dealerTotal)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Your points: " + playerTotal + " and Dealer's points: " + dealerTotal);
                    Console.WriteLine("COngratulations, you win!");
                }
                else if (playerTotal < dealerTotal)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Your points: " + playerTotal + " and Dealer's points: " + dealerTotal);
                    Console.WriteLine("You lose");
                }
                else if (playerTotal == dealerTotal)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Your points: " + playerTotal + " and Dealer's points: " + dealerTotal);
                    Console.WriteLine("It's a tie!");
                }
            }
            else
            {
                Console.WriteLine("You lose!");
            }


            
  





                
            
          
            

        }
    }
}
