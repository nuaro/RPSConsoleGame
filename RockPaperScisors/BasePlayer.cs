using System;
public abstract class BasePlayer
{
    //      int ROCK = 0;
    //      int PAPER = 1;
    //      int SCISSORS = 2;
    public enum Weapon
    {
        Rock,
        Paper,
        Scissors

    }
    protected Weapon _choosenWeapon;
    public Weapon choosenWeapon{
        get{
            return _choosenWeapon;
        }
    }
    private string _name;
    public string name{
        get {
            return _name;
        }
    }

    protected Random rand = new Random();
    private int _score;
    public int score{
        get
        {
            return _score;
        }
    }

    public BasePlayer(string name)
    {
        this._name = name;
    }

    public abstract void ChooseWeapon();

    public void AddScore(){
        _score++;
    }


    //check draw
    public static bool operator == (BasePlayer p1, BasePlayer p2) {

        bool isDraw = p1.choosenWeapon == p2.choosenWeapon;
        return isDraw;
    }

    public static bool operator !=(BasePlayer p1, BasePlayer p2)
    {
        bool isDraw = p1.choosenWeapon != p2.choosenWeapon;
        return isDraw;
    }

    //need to override because i overload operator ==
    public override bool Equals (object obj){
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static BasePlayer operator *(BasePlayer p1, BasePlayer p2){
        if(RPSModel.Instance.WinTableResult(p1.choosenWeapon,p2.choosenWeapon) == RPSModel.WinState.WIN){
            return p1;
        }
        else{
            return p2;
        }
    }
}
