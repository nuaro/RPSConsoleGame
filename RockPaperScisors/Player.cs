using System;
public class Player : BasePlayer
{
    public Player(string name) : base(name)
    {
        
    }

    public override void ChooseWeapon(){
        _choosenWeapon = (BasePlayer.Weapon)(Convert.ToInt32(Console.ReadLine()) - 1);

    }
}

