using System;
public class ComputerPlayer:BasePlayer
{
    public ComputerPlayer(string name):base(name)
    {
    }

    public override void ChooseWeapon(){
        _choosenWeapon = (BasePlayer.Weapon)rand.Next(0, 3);
    }
}

