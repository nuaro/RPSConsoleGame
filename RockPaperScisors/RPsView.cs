using System;
public class RPSView
{
    public RPSView()
    {
        RPSModel.Instance.Change += new RPSModel.ModelChangeHandler(updateView);
    }

    public void updateView(RPSModel.GameState state, EventArgs e)
    { 
        switch(state){
            case RPSModel.GameState.StartGame:
                //dosomething
                DisplayGreeting();
                DisplayPlayerScores();
                break;

            case RPSModel.GameState.Draw:
                DisplayDraw();
                break;
            case RPSModel.GameState.PlayerCanChoose:
                PrintWeaponChoise();
                break;
            case RPSModel.GameState.PlayerLose:
                DisplayLose();
                break;
            case RPSModel.GameState.PlayerWon:
                DisplayWin();
                break;
            case RPSModel.GameState.PlayAgain:
                QuestionDisplayAgain();
                break;
            case RPSModel.GameState.PlayerChooseError:
                DisplayGreeting();
                DisplayError();
                DisplayPlayerScores();
                break;
            case RPSModel.GameState.ChooseGameMode:
                //display choose option
                DisplayChooseGameMode();
                break;
                
        }
    }

    private  void DisplayGreeting()
    {
        ClearDisplay();
        Console.WriteLine("-- Rock, Paper, Scissors --");
    }

    private  void DisplayPlayerScores()
    {
        Console.WriteLine("Player Score: " + RPSModel.Instance.GetPlayerByName(RPSModel.Instance.LIVEPLAYER).score + " Computer Score: " + RPSModel.Instance.GetPlayerByName(RPSModel.Instance.COMPUTER_PLAYER).score + " Draws: " + RPSModel.Instance.drawScore + "\n\n");

    }

    private  void PrintWeaponChoise()
    {
        Console.WriteLine("Choose your weapon. Computer has already Choosen!\n\n");
        Console.Write("1] Rock\n2] Paper\n3] Scissors\n\n::--> ");

    }

    private void DisplayDraw(){
        Console.WriteLine("It's a Draw");
    }

    private void DisplayWin()
    {
        Console.WriteLine("It's a WIN");
    }

    private void DisplayLose()
    {
        Console.WriteLine("It's a LOSE");
    }

    private void QuestionDisplayAgain(){
        Console.WriteLine("Would you like to play again? [y/n]");
    }

    private void ClearDisplay(){
        Console.Clear();
    }

    private void DisplayError(){
        Console.WriteLine("Enter a Valid Weapon");
    }

    private void DisplayChooseGameMode(){
        ClearDisplay();
        Console.WriteLine("-- Rock, Paper, Scissors --");
        Console.WriteLine("-- How Many Players : --");
        Console.Write("1 or 2 "); 
    }

}

