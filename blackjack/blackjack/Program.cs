using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Program
    {
        //create and shuffle deck, ready to draw
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
        }

        //deal cards to player
        static List<Card> DealPlayerCards(List<Card> randomDeck1, List<Card> playerHand1)
        {
            playerHand1.Add(randomDeck1[0]);
            Console.WriteLine($"You drew the {randomDeck1[0]}");
            randomDeck1.RemoveAt(0);
            return playerHand1;
        }

        //deal cards to dealer
        static List<Card> DealDealerCards(List<Card> randomDeck2, List<Card> dealerHand1)
        {
            dealerHand1.Add(randomDeck2[0]);
            Console.WriteLine($"The dealer drew the {randomDeck2[0]}");
            randomDeck2.RemoveAt(0);
            return dealerHand1;
        }


        //get the total of the hand by converting card class to int
        static int GetHandTotal(List<Card> hand)
        {
            var sum = 0;
            foreach (var card in hand)
            {
                sum += card.GetCardValue();
            }

            return sum;
        }

        //Opening deal 
        static void OpeningDraw(int countu, List<Card> randomDeckOpen, List<Card> playerHandOpen, List<Card> dealerHandOpen, int playerTotalOpen, int dealerTotalOpen)
        {
            while (countu < 2)
            {
                DealPlayerCards(randomDeckOpen, playerHandOpen);
                DealDealerCards(randomDeckOpen, dealerHandOpen);
                playerTotalOpen = GetHandTotal(playerHandOpen);
                dealerTotalOpen = GetHandTotal(dealerHandOpen);
                Console.WriteLine($"Your points [ {playerTotalOpen} ]");
                Console.WriteLine($"The dealer's points [ {dealerTotalOpen}  ]");
                Console.WriteLine("");
                countu++;


            }
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




        //if player decides to stand..





        static void Main(string[] args)
        {

            var randomDeck = CreateAndShuffleDeck(); //shuffle deck and declare to a variable 
            int count = 0;
            var playerHand = new List<Card>();
            var playerTotal = 0;
            var hitOrStand = 0;
            var dealerHand = new List<Card>();
            var dealerTotal = 0;
            bool stand = true;

            Console.WriteLine("Welcome to the Pranye West Blackjack challenge");
            Console.ReadLine();

            OpeningDraw(count, randomDeck, playerHand, dealerHand, playerTotal, dealerTotal);
            playerTotal = GetHandTotal(playerHand);
            dealerTotal = GetHandTotal(dealerHand);







            while (playerTotal != 21 && dealerTotal != 21 && count < 3 && playerTotal < 22 && stand == true)
            {

             Console.WriteLine("Would you like to hit or stand? Enter 1 to hit or 2 to stand");
             hitOrStand = HitOrStand(Console.ReadLine()); //asks the user the stand or hit

                if (hitOrStand == 1 && playerTotal < 22) //if player hits, card is added to hand
                {
                    DealPlayerCards(randomDeck, playerHand);
                    playerTotal = GetHandTotal(playerHand);
                    Console.WriteLine($"Your points [ {playerTotal} ]");
                }

                dealerTotal = GetHandTotal(dealerHand);
                if (dealerTotal < 16 & playerTotal < 21)
                {
                    DealDealerCards(randomDeck, dealerHand);
                    Console.WriteLine("The dealer drew a card and placed it face down");
                    dealerTotal = GetHandTotal(dealerHand);
                }

            if (dealerTotal < 16 && hitOrStand == 2) //checks to see if the dealer will hit or stand. continues to deal the dealer cards even if player stands
            {
                DealDealerCards(randomDeck, dealerHand);
                Console.WriteLine("The dealer drew a card and placed it face down");
                dealerTotal = GetHandTotal(dealerHand);
            }

            if (dealerTotal > 15 && hitOrStand == 2) //ends the game
            {
                stand = false;
                
            }
            count++;

        }

            if (playerTotal == 21)
            {
                Console.WriteLine("BLACKJACK! You win the game!");
            }
            else if (dealerTotal == 21)
            {
                Console.WriteLine("Dealer gets BLACKJACK, you LOSE!");
            }
            else if (playerTotal > 21)
            {
                Console.WriteLine("You got more than 21, you lose!");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Let's compare cards");
                Console.WriteLine("Your points: " + playerTotal + " and Dealer's points: " + dealerTotal);
                if ((playerTotal > dealerTotal) && playerTotal< 22 || dealerTotal> 21)
                {
                    Console.WriteLine("You win!");
                }
                if ((playerTotal<dealerTotal) && dealerTotal< 22 || playerTotal> 21)
                {
                    Console.WriteLine("You lose!");
                }
                if (playerTotal == dealerTotal)
                {
                    Console.WriteLine("The game is a tie???? WHAT! Let's try and play again...");
                }
            }
              


                
            








           
          

                   
            

           
         



            
  





                
            
          
            

        }
    }
}
