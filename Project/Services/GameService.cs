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
      return _game.CurrentRoom.GetTemplate() + System.Environment.NewLine + _game.CurrentPlayer.GetTemplate();
    }
    public void Go(string direction)
    {
      string from = _game.CurrentRoom.Name;
      if (from == "Room2")
      {
        Messages.Add("you can not move without something to get up this cliff... ");
        return;
      }
      else
      {
        _game.CurrentRoom = _game.CurrentRoom.Go(direction);
        string to = _game.CurrentRoom.Name;
      }


    }
    public void Help()
    {
      Messages.Add($"Commands: 'Go' = move through exits\n 'Inventory' = Will show what you have in your Inventory\n 'Look' = Check your surroundings and get details\n 'Take Item' = pickup any item available in the room\n 'Use Item' = Use item in your inventory by its name  ");
    }

    public void Inventory()
    {
      ;
    }

    public void Look()
    {
      Console.Clear();
      foreach (var item in _game.CurrentRoom.Items)
      {
        Messages.Add(item.Name + item.Description);
      }
    }

    public void Quit(string input)
    {

      Environment.Exit(0);
    }

    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup(string playerName)
    {

      //   playerName = _game.CurrentPlayer.Name;
      // Messages.Add(_game.CurrentRoom.Description);
      _game.Setup();
      Messages.Add($"Welcome {playerName}");
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("Nothing to take...");
        return;
      }
      Messages.Add($"Taking {_game.CurrentRoom.Items.Count} Item");
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
      Item item = new Item("gun", "pew pew");
      foreach (Item i in _game.CurrentPlayer.Inventory)
      {
        if (i.Name.ToLower() == itemName)
        {
          item = i;
        }
      }
      if (item.Name == "gun" && _game.CurrentRoom.Name == "Room5")
      {
        Messages.Add("You killed bruce wayne!");
        return;
      }

      // for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      // {
      //   var gunill = _game.CurrentRoom.Name;
      //   var item = _game.CurrentPlayer.Inventory;
      //   switch (itemName)
      //   {
      //     case "gun": 
      //       Messages.Add("pew pew you killed batman");
      //       break;

      //   }
      //   if (itemName in gunkill)

      // }

    }

  }
}
