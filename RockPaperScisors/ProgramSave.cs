

using System;



class RockPaperScissors {

	public static void Main (string[] args) {

//		int ROCK = 0;
//		int PAPER = 1;
//		int SCISSORS = 2;

		int DRAW = 0;
		int LOSE = -1;
		int WIN = 1;

		int[,] winTable = new int[3,3] { 
			{DRAW,LOSE,WIN},  
			{WIN,DRAW,LOSE},  
			{LOSE,WIN,DRAW}   
		}; 

		int playerScore = 0;
		int computerScore = 0;
		int drawScore = 0;
		Random rand = new Random ();

		string answer = "";
		do {
			Console.WriteLine("-- Rock, Paper, Scissors --");

			int computerChoice = rand.Next(0,3);

			Console.WriteLine("Choose your weapon. Computer has already Choosen!\n\n");
			Console.WriteLine("Player Score: " + playerScore + "  Computer Score: " + computerScore + " Draws: " + drawScore + "\n\n");
			Console.Write("1] Rock\n2] Paper\n3] Scissors\n\n::-> ");

			int playerChoice = Convert.ToInt32(Console.ReadLine()) - 1;

			if(playerChoice >= 3) {
				Console.WriteLine("\n\nPlease enter a valid choice");
				Console.ReadLine();

				answer = "y";
			} else {
				if(winTable[playerChoice,computerChoice] == DRAW) {
					Console.WriteLine("It's a Draw!");
					drawScore++;
				} else if(winTable[playerChoice,computerChoice] == LOSE) {
					Console.WriteLine("You LOSE!");
					computerScore++;
				} else if(winTable[playerChoice,computerChoice] == WIN) {
					Console.WriteLine("You WIN!");
					playerScore++;
				}
				Console.WriteLine("Would you like to play again? [y/n]  ");
				answer = Console.ReadLine();	
			}

			Console.Clear();

		} while(answer.ToLower() == "yes" || answer.ToLower() == "y");
	}
}