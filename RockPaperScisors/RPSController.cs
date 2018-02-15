using System;
public class RPSController
{


    public RPSController()
    {
        
    }

    public void StartGame(){
        AddPlayers();
        GameLoop();     
    }

    public void AddPlayers(){
        RPSModel.Instance.AddPlayer(RPSModel.Instance.LIVEPLAYER);
        bool computer = false;
        if (RPSModel.Instance.gameMode == RPSModel.GameMode.SinglePlayer)
        {
            computer = true;
        }
        RPSModel.Instance.AddPlayer(RPSModel.Instance.COMPUTER_PLAYER, computer);
    }

    public void ChooseGame(){
        string answer = "";
        do
        {
            //Console.Clear();
            Console.WriteLine("-- Rock, Paper, Scissors --");
            Console.WriteLine("-- How Many Players : --");
            Console.Write("1 or 2 ");

            answer = Console.ReadLine();

            Console.Write("--- answer  {0} ",answer);
        } while (answer != "1" && answer != "2");
        if(answer == "1"){
            RPSModel.Instance.gameMode = RPSModel.GameMode.SinglePlayer;
        }
        if(answer =="2"){
            RPSModel.Instance.gameMode = RPSModel.GameMode.Multiplayer;

        }

        StartGame();
    }

    public void GameLoop(){
       
        BasePlayer player1 = RPSModel.Instance.GetPlayerByName(RPSModel.Instance.LIVEPLAYER);
        BasePlayer player2 = RPSModel.Instance.GetPlayerByName(RPSModel.Instance.COMPUTER_PLAYER);



        string answer = "";
        do
        {

            RPSModel.Instance.ChangeState(RPSModel.GameState.StartGame);


            PlayerChooseeLoop(player2);
            PlayerChooseeLoop(player1);
           

            if (player1 == player2)
            {
                RPSModel.Instance.ChangeState(RPSModel.GameState.Draw);
                RPSModel.Instance.AddDrawScore();
            }
            else
            {
                BasePlayer winner = player1 * player2;
                winner.AddScore();
                if (winner.name.Equals((RPSModel.Instance.LIVEPLAYER)))
                {
                    RPSModel.Instance.ChangeState(RPSModel.GameState.PlayerWon);
                }
                else
                {
                    RPSModel.Instance.ChangeState(RPSModel.GameState.PlayerLose);
                }

            }

            RPSModel.Instance.ChangeState(RPSModel.GameState.PlayAgain);
            answer = Console.ReadLine();


        } while (answer.ToLower() == "y" || answer.ToLower() == "yes");
    }

    public void PlayerChooseeLoop(BasePlayer player){
        if (player.isComputerPlayer())
        {
            player.ChooseWeapon();
        }
        else
        {
            do
            {
                RPSModel.Instance.ChangeState(RPSModel.GameState.PlayerCanChoose);


                player.ChooseWeapon();

                bool testResponse = player.IsAValidWeapon();
                if (testResponse == false)
                {
                    RPSModel.Instance.ChangeState(RPSModel.GameState.PlayerChooseError);
                }

            } while (player.IsAValidWeapon() == false);
        }

    }
}

