

namespace TeridiumRPG
{
    class Program
    {
        static void Main (string[] args)
        {
            MainGame maingame = new MainGame ();
            maingame.Play ();
            //Item TheMightySword = new Item ("Cheap Sword", ItemTypes.Weapon, 10, "Swords", 10, 1, 0, 1, 0, 3, 3, 0);
            //Game.PrintObj (TheMightySword);
        }
    }
}
