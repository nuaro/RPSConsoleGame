using System;

class RockPaperScissors
{



   
	public static void Main (string[] args) {
        RPSView view = new RPSView();
        RPSController controller = new RPSController();
        controller.ChooseGame();

       
	}
}