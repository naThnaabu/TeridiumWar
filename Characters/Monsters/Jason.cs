using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Jason : Character
    {
        public Jason()
        {
            CurrentHealth = 15;
            MaxHealth = 15;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 3;
            Defense = 3;
            Experience = 108;
            Gold = 0;
            Identifier = "Wild Jason";
            isAlive = true;
            AttackDamage = 15;
            Print = @"A wild Jason appears
                                 ___
                               .'   '.
                              /     0 \           oOoOo
                             |    0  . |       ,==|||||
                              \     __/       _|| |||||
                               '.___.'    _.-'^|| |||||
                             __/_______.-'     '==HHHHH
                        _.-'` /                   """"""""""
                     .-'     /   oOoOo
                     `-._   / ,==|||||
                         '-/._|| |||||
                          /  ^|| |||||
                         /    '==HHHHH
                        /________""""""""""
                        `\       `\
                          \        `\   /
                           \         `\/
                           /
                          / 
                         /_____
" + "\n";
        }
    }
}
