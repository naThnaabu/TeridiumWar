﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeridiumRPG
{
    class Gargoyl : Character
    {
        public Gargoyl()
        {
            CurrentHealth = 16;
            MaxHealth = 16;
            CurrentMagic = 0;
            MaxMagic = 0;
            Attack = 9;
            Defense = 8;
            Experience = 43;
            Gold = 11;
            Identifier = "Gargoyl";
            isAlive = true;
            AttackDamage = 5;
            Print = @"
 ,                                                               ,
 \'.                                                           .'/
  ),\                                                         /,( 
 /__\'.                                                     .'/__\
 \  `'.'-.__                                           __.-'.'`  /

  `)   `'-. \                                         / .-'`   ('
  /   _.--'\ '.          ,               ,          .' /'--._   \
  |-'`      '. '-.__    / \             / \    __.-' .'      `'-|
  \         _.`'-.,_'-.|/\ \    _,_    / /\|.-'_,.-'`._         /
   `\    .-'       /'-.|| \ |.-""   ""-.| / ||.-'\       '-.    /`
     )-'`        .'   :||  / -.\\ //.- \  ||:   '.        `'-(
    /          .'    / \\_ |  /o`^'o\  | _// \    '.          \
    \       .-'    .'   `--|  `""/ \""`  |--`   '.    '-.       /
     `)  _.'     .'    .--.; |\__""__/| ;.--.    '.     '._  ('
     /_.'     .-'  _.-'     \\ \/^\/ //     `-._  '-.     '._\
     \     .'`_.--'          \\     //          `--._`'.     /
      '-._' /`            _   \\-.-//   _            `\ '_.-'
          `<     _,..--''`|    \`""`/    |`''--..,_     >`
           _\  ``--..__   \     `'`     /   __..--``  /_
          /  '-.__     ``'-;    / \    ;-'``     __.-'  \
         |    _   ``''--..  \'-' | '-'/  ..--''``   _    |
         \     '-.       /   |/--|--\|   \       .-'     /
          '-._    '-._  /    |---|---|    \  _.-'    _.-'
              `'-._   '/ / / /---|---\ \ \ \'   _.-'`
                   '-./ / / / \`---`/ \ \ \ \.-'
                       `)` `  /'---'\  ` `(`
                      /`     |       |     `\
                     /  /  | |       | |  \  \
                 .--'  /   | '.     .' |   \  '--.
                /_____/|  / \._\   /_./ \  |\_____\
               (/      (/'     \) (/     `\)      \)
" + "\n";
        }
    }
}