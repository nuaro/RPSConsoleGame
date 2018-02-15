using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class RPSModel
{

    public readonly string LIVEPLAYER = "you";
    public readonly string COMPUTER_PLAYER = "Computer";

    public enum WinState
    {
        LOSE = -1,
        DRAW = 0,
        WIN = 1
    }
    public EventArgs e = null;
    public delegate void ModelChangeHandler(GameState state, EventArgs e);
    public event ModelChangeHandler Change;

    private List<BasePlayer> _players = new List<BasePlayer>();

    public ReadOnlyCollection<BasePlayer> players {
        get
        {
            return _players.AsReadOnly();
        }
    }

    private int _drawScore;
    public int drawScore {
        get{
            return _drawScore;
        }
    }

    public GameMode gameMode;
    public enum GameMode {
        SinglePlayer,
        Multiplayer
    }

    public enum GameState {
        StartGame,
        PlayerCanChoose,
        PlayerChooseError,
        Draw,
        PlayerWon,
        PlayerLose,
        PlayAgain
        
    }

    WinState[,] winTable = new WinState[3, 3] { 
            // ROCK
            { 
                // ROCK
                WinState.DRAW, 
                // PAPER
                WinState.LOSE, 
                // SCISSOR
                WinState.WIN
            }, 
            // PAPER
            { // ROCK
            WinState.WIN, 
                // PAPER
            WinState.DRAW, 
                // SCISSOR
            WinState.LOSE
            }, 
            // SCISSORS
            { // ROCK
            WinState.LOSE, 
                // PAPER
            WinState.WIN, 
                // SCISSOR
            WinState.DRAW
            }
    };

    private static RPSModel instance = null;

    public static RPSModel Instance {
        get {
            if(instance == null) {
                instance = new RPSModel();
            }

            return instance;
        }
    }

    private RPSModel()
    {



    }

    public void ChangeState(GameState state){
        Change(state, e);
    }

    public WinState WinTableResult(BasePlayer.Weapon playerOne, BasePlayer.Weapon playerTwo)
    {
        return winTable[(int)playerOne, (int)playerTwo];
    }

    public void AddPlayer(string playerName, bool computerOponent = false){
        BasePlayer player = null;
        if(computerOponent){
            player = new ComputerPlayer(playerName);
        }
        else {
            player = new Player(playerName);
        }
        _players.Add(player);
        
    }

    public BasePlayer GetPlayerByName (string name){
        foreach(BasePlayer player in _players){
            if(player.name == name){
                return player;
            }
        }

        return null;
    }

    public void AddDrawScore(){
        _drawScore++;
    }

    public void ClearPlayerList(){
        _players.Clear();
    }
 }

