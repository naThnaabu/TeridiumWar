using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Basilisk : Character
    {
        public Basilisk()
        {
            CurrentHealth = 30;
            MaxHealth = 30;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 13;
            Defense = 7;
            Experience = 20;
            Gold = 20;
            Identifier = "Basilisk";
            isAlive = true;
            AttackDamage = 12;
            Print = @"
                                                 ,_
                              ,;;,  .-""```'-.     \\
                             ,;;;;,/^;/)^/)-.`.___//
                         <`\ <`\;;;|  \ / \  `-...'
                       <\) <\) |;;' \^ | , |
                        |` /|` /;'  |\/ =  |
                      <\/ <\/ /;'  / | ,  /`'-.,_
                       \ /;\ /;'  / / =   \  ^   `'.
                      _/_;/ /'   | /  ""    '--:-.^  `'.
                   .-' <g>`""`\   / | ,    _,=""/  '.    \
                  /\__    \\ Ss\ | /   ,=""   |     \ ^  \
                 ( ( ,)   | \ `S|| | ,""      L_     |  ^ |
                  \) `-.  | ||  \| |     _,=.-""`    /    |
                        | | || ^ \/   ,=""  /__  _.-'  ^ /
                        / | //   /  ,""    |   ``""-._^_.'
                       /  \_/   /         '--,^     `-.
                      |  ^    ^;     _,==""""/`     ^   `\
                      \ ^      |   ,""""  _.-'    ^  .-.^  |
                       \    ^  ;     (`    ^   .'`\  ) ^|
                        '.^    \   ,}` ^__,.-'`\ ^ '' ^ /
                          '-.^__\    \'`        `-.^_.-'
                            /   {     }
                            `//""`.___.'
                        ,==='`=,__||___
                         ,=`=``(,=,=.-=;
                                 (/(|  
" + "\n";
        }
    }
}
