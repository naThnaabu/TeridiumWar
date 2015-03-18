
```javascript
  _____         _     _ _                   ____  ____   ____ 
 |_   _|__ _ __(_) __| (_)_   _ _ __ ___   |  _ \|  _ \ / ___|
   | |/ _ \ '__| |/ _` | | | | | '_ ` _ \  | |_) | |_) | |  _ 
   | |  __/ |  | | (_| | | |_| | | | | | | |  _ <|  __/| |_| |
   |_|\___|_|  |_|\__,_|_|\__,_|_| |_| |_| |_| \_\_|    \____|
                                    
                        ^     \    /      ^                        
                       / \    \\__//     / \                   
                      /   \  ('\  /')   /   \                  
    _________________/_____\__\@  @/___/_____\________________ 
   |                          ¦\,,/¦                          |
   |                           \VV/                           |
   |                  An Oldschool text RPG                   |
   |              Have fun and feel free to help              |
   |                   Developed by Tehral                    |
   |__________________________________________________________|
                   | ./\/\ /            \ /\/\. |
                   |/     V              V     \|
                   "                            "
```

SOON translated to english...

Einleitung
Da ich ziemlich neu in der Programmierung bin, habe ich mit einem Textbasiertem RPG mit dem Namen Teridium War angefangen.
Das Spiel selbst verfügt über keine Story, hat jedoch meiner Meinung nach alle benötigte Sachen um als RPG deklariert werden zu dürfen.

Über das Spiel

Generell
Name: Teridium War
Typ: Konsolenanwendung
Sprache: Englisch

Der Charakter
Der Charakter besitzt folgende Eigenschaften:
- Leben (HP)
- Mana (MP)
- Waffe
- Waffengrundschaden
- Waffenzusatzschaden (Würfel6)
- Attackewert (1-20)
- Verteidigungswert (1-20)
- Rüstungswert
- Rüstungsteile
- Level
- Gold
- EXP

Die Gegner
Jeder Gegner besitzt verschiedene Werte für folgende Attribute:
- Name
- Leben (HP)
- Mana (MP)
- Attacke (1-20)
- Verteidigung (1-20)
- EXP Reward
- Gold Reward
- ASCII Bild


Funktionen
- Kampf gegen Random Monster (27 verschiedene)
- Rundenbasiert
- Mit Waffe
- Zauber
- 3 DMG & 1 Heal
- Tränke
- Mana (MP)
- Leben (HP)
- Gold Reward
- EXP Reward
- Levelanstieg -> Attacke und oder Verteidigung wird erhöht.

- Shop um einzukaufen
- Waffen
- 3 Kategorien
- Rüstungsteile
- 5 Kategorien
- Tränke
- Leben (HP)
- Mana (MP)

- Taverne
- Essen & Trinken -> HP/MP auffüllen
- Rasten -> HP/MP auffüllen

- Charakter Status anzeigen
- Name
- HP
- MP
- Attacke
- Verteidigung

- Spiel speichern
- Alle Charakter Werte anhand Namen
- Mehrere Spielstände möglich

- Spiel laden
- Alle Charakter Werte anhand Namen
- Mehrere Spielstände möglich

- Einleitungstutorial
- Kampfinstruktionen

Das Spielsystem
Das Spiel läuft folgender Massen ab:
1.Spieler muss Auswahl treffen
Open Player Stats
- Status anzeigen

Visit the Shop
- Shop öffnen
- Kategorie aussuchen
- Unterkategorie aussuchen
- Gegenstand kaufen

Go to the Tavern
- Rest -> Restore HP & MP
- Trinken -> Restore HP & MP

Fight against a Monster

Save Game

Exit the Game

Wenn abgeschlossen zurück zu 1.

Das Kampfsystem
Das Kampfsystem ist relativ simpel sobald man den dreh raus hat:
Runde I
Spieler greift zuerst an


```javascript
-> Attacke
   -> Würfel 20 werfen
      -> Wenn Wert <= Angriffswert dann erfolg
            -> Gegner Würfel 20 auf Verteidigung
                  -> Wenn <= Verteidigungswert Gegner dann Erfolg
                  -> Wenn > Verteidigungswert Gegner kann nicht parieren
                        -> Spieler wirft die Anzahl Würfel 6 für seine Waffe
                        -> Schaden = Alle Ergebnisse Würfel 6 + Grundschaden der Waffe
     -> Wenn Wert > Angriffswert dann Misserfolg
-> Zauber
     -> Auswahl
          -> Mana >= Zauberkosten
               -> Gegner verliert Zauberdmg  
-> Tränke
     -> Auswahl
          -> Attribute anpassen

Gegner attackiert
-> Attacke
   -> Würfel 20 wird im Hintergrund geworfen
      -> Wenn Wert <= Angriffswert dann Erfolg
            -> Spieler Würfel 20 auf Verteidigung
                  -> Wenn <= Verteidigungswert Spieler dann Erfolg
                  -> Wenn > Verteidigungswert Spieler kann nicht parieren
                          -> Schaden = DMG Monsterwaffe - Rüstungswert des Helden
     -> Wenn Wert > Angriffswert dann Misserfolg
-> Zauber (sofern Magisch begabt)
          -> Random Zauber
          -> Mana >= Zauberkosten
               -> Gegner verliert Zauberdmg

Runde II
.
.
.
```
