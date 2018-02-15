using System;
public class Player : BasePlayer
{
    int _weaponOfChoise;
    public Player(string name) : base(name)
    {
        
    }

    public override void ChooseWeapon(){

        bool result = Int32.TryParse(Console.ReadLine(), out int outWeapon);
        if (result == false){
            _weaponOfChoise = -1;
        }

        _weaponOfChoise = outWeapon -1;

    }

    public override bool IsAValidWeapon(){

        bool success = Enum.IsDefined(typeof(BasePlayer.Weapon), _weaponOfChoise);

        if(success)
            _choosenWeapon = (BasePlayer.Weapon)_weaponOfChoise;

        return success;
    }
    public override bool isComputerPlayer()
    {
        return false;
    }
}

