using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {
    public string Name { get; set; }
    public List<Item> Inventory { get; set; }


    public string GetTemplate()
    {
      string template = "Inventory: \n";
      foreach (var inv in Inventory)
      {
        template += $"{inv.Name}: {inv.Description}\n";
      }
      return template;
    }





    public Player()
    {
      Inventory = new List<Item>();
    }
  }
}

