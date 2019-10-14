using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;



namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public string GetDetails()
    {
      return _game.CurrentRoom.GetTemplate() + System.Environment.NewLine;
    }

    public void Go(string direction)
    {
      // string used = _game.CurrentPlayer.Inventory.ToString();
      // string to = _game.CurrentRoom.Name.ToString();
      // string to = _game.CurrentRoom.Exits.ToString();

      _game.CurrentRoom = _game.CurrentRoom.Go(direction);

      if (_game.CurrentRoom.Name == "Room4")
      {
        Messages.Add("type 'quit' to end the game or 'reset' to start over");
      }
      return;

      // used = "rope";
      // to = from;\

      // string to = _game.CurrentRoom.Name;

      // return;

    }
    public void Help()
    {
      Messages.Add($"Commands: 'Go' = move through exits\n 'Inv' = Will show what you have in your Inventory\n 'Look' = Check your surroundings and get details\n 'Take Item' = pickup any item available in the room\n 'Use Item' = Use item in your inventory by its name  ");
    }

    public void Inventory()
    {
      if (_game.CurrentPlayer.Inventory == null)
      {
        Messages.Add("Nothing in your Inventory");
      }
      else
      {
        foreach (var inv in _game.CurrentPlayer.Inventory)
        {
          Console.WriteLine("Inventory:");
          Messages.Add($"{inv.Name}");

        }
      }
    }

    public void Look()
    {
      Console.Clear();
      foreach (var item in _game.CurrentRoom.Items)
      {
        Messages.Add($"You found A  {item.Name}: {item.Description}");
      }
    }

    public void Quit(string input)
    {

      Console.Clear();
      Environment.Exit(0);
    }

    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      Console.Clear();
      _game.CurrentPlayer.Inventory.Clear();
      _game.Setup();
    }

    public void Setup(string playerName)
    {

      //   playerName = _game.CurrentPlayer.Name;
      // Messages.Add(_game.CurrentRoom.Description);
      _game.Setup();
      Messages.Add($"{playerName}");
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("Nothing to take...");
        return;
      }
      Messages.Add($"{_game.CurrentPlayer.Inventory.Count + 1} Item added to Inventory");
      _game.CurrentPlayer.Inventory.AddRange(_game.CurrentRoom.Items);
      _game.CurrentRoom.Items.Clear();

    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      int freq = 800;
      int duration = 200;

      var room = _game.CurrentRoom.Name.ToString();

      // for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      // {
      itemName = itemName.ToLower();
      var item = _game.CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
      if (item == null) { Messages.Add("You dont have a " + itemName); return; }

      // if (item.Name.ToLower() == itemName)
      // {
      //   Messages.Add("that is a item");
      // }
      switch (itemName)
      {
        case "rope":
          if (room == "Room2")
          {
            _game.CurrentPlayer.Inventory.Remove(item);
            Messages.Add("After serveral attemps you manage to hook the rope on something and climb out");
            _game.CurrentRoom.Description = "You made it to the top of the cliff and can see your exits";
            _game.UnlockRoom(_game.CurrentRoom, "west", "Room3");
            _game.UnlockRoom(_game.CurrentRoom, "east", "Room4");
            _game.UnlockRoom(_game.CurrentRoom, "south", "Room1");
          }
          break;
        case "banana":
          if (room == "Room5" && item.Name.ToLower() == itemName)
          {
            Messages.Add(@"
 _
//\
V  \
 \  \_
  \,'.`-.
   |\ `. `.       
   ( \  `. `-.                        _,.-:\
    \ \   `.  `-._             __..--' ,-';/
     \ `.   `-.   `-..___..---'   _.--' ,'/
      `. `.    `-._        __..--'    ,' /
        `. `-_     ``--..''       _.-' ,'
          `-_ `-.___        __,--'   ,'
             `-.__  `----""");
            Messages.Add("You ate the banana... But Bruce wayne threw his batarang at you and killed you..... GAME OVER!");
            Messages.Add("type 'quit' to end the game or 'reset' to start over");

          }
          break;
        case "gun":
          if (room == "Room5" && item.Name.ToLower() == itemName)
          {
            Messages.Add(@"
              
                T\ T\
                | \| \
                |  |  :
           _____I__I  |
         .'            '.
       .'                '
       |   ..             '
       |  /__.            |
       :.' -'             |
      /__.                |
     /__, \               |
        |__\        _|    |
        :  '\     .'|     |
        |___|_,,,/  |     |    _..--.
     ,--_-   |     /'      \../ /  /\\
    ,'|_ I---|    7    ,,,_/ / ,  / _\\
  ,-- 7 \|  / ___..,,/   /  ,  ,_/   '-----.
 /   ,   \  |/  ,____,,,__,,__/            '\
,   ,     \__,,/                             |
| '.       _..---.._                         !.
! |      .' z_M__s. '.                        |
.:'      | (-_ _--')  :          L            !
.'.       '.  Y    _.'             \,         :
 .          '-----'                 !          .
 .           /  \                   .          .
              
              ");
            Messages.Add("PEW PEW You killed Bruce Wayne You are now BATMAN!");

            Console.Beep(freq, duration);
            Console.Beep(freq, duration);
            Messages.Add("press any button to reset");
            Reset();



          }
          else if (room != "Room5" && item.Name.ToLower() == "gun")
          {
            Messages.Add("PEW PEW");
            Console.Beep();
            Console.Beep();
          }
          break;
        default:
          return;
      }
    }

  }

}







