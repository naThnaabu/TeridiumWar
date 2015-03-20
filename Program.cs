using System.Xml.Serialization;
using TeridiumRPG.Items;
using System;

namespace TeridiumRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            var maingame = new MainGame();
            maingame.Play();
        }
    }
}
