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
        RPSModel.Instance.AddPlayer(RPSModel.Instance.COMPUTER_PLAYER, true);
    }

    public void GameLoop(){
        BasePlayer computerPlayer = RPSModel.Instance.GetPlayerByName(RPSModel.Instance.COMPUTER_PLAYER);
        BasePlayer livePlayer = RPSModel.Instance.GetPlayerByName(RPSModel.Instance.LIVEPLAYER);



        string answer = "";
        do
        {

            RPSModel.Instance.ChangeState(RPSModel.GameState.StartGame);


            computerPlayer.ChooseWeapon();
            RPSModel.Instance.ChangeState(RPSModel.GameState.PlayerCanChoose);


            livePlayer.ChooseWeapon();

            if (livePlayer == computerPlayer)
            {
                RPSModel.Instance.ChangeState(RPSModel.GameState.Draw);
                RPSModel.Instance.AddDrawScore();
            }
            else
            {
                BasePlayer winner = livePlayer * computerPlayer;
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
}

