using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    private List<Room> _rooms { get; set; } = new List<Room>();

    //NOTE Make yo rooms here...
    public void Setup()
    {
      //Room to Room relationship
      Room room1 = new Room("Room1", "your at the start of the cave there are 3 dark paths you have a small dim light that barely lights the way");

      Room room2 = new Room("Room2", "you fall on something very slippery and slide down the edge of a cliff. you Take a 'look' around to see what it was.");

      Room room3 = new Room("Room3", "you see there is 2 paths east and west and something shiny on the ground you may need to get close and 'look' to see it.");

      Room room4 = new Room("Room4", "there is not enough light and you fall down a waterfall GAME OVER");

      Room room5 = new Room("Room5", "you enter the main chamber and see the Batmobile. You hear someone yell Who are you?\n Its bruce wayne! You have 3 choices.\n 1 quit your mission\n 2 Mabey have a banana\n 3 or you may have something in your inventory that would be Useful'");

      _rooms.Add(room1);
      _rooms.Add(room2);
      _rooms.Add(room3);
      _rooms.Add(room4);
      _rooms.Add(room5);

      room1.Exits.Add("west", room3);
      room1.Exits.Add("east", room4);
      room1.Exits.Add("north", room2);

      // Room2.Exits.Add("west", Room3);
      // Room2.Exits.Add("east", Room4);
      // Room2.Exits.Add("south", Room1);

      room3.Exits.Add("east", room2);
      room3.Exits.Add("south", room1);
      room3.Exits.Add("north", room5);


      // creating items to get/ use in certain rooms 
      Item banana = new Item("Banana", " kinda like a gun you can put it in your holster, but is loaded with nutrition");
      Item gun = new Item("Gun", "This has got to be useful....");
      Item rope = new Item("Rope", "What a tangled mess....");

      room2.Items.Add(rope);
      room2.Items.Add(banana);
      room3.Items.Add(gun);

      //setting the strarting point
      CurrentRoom = room1;
    }

    public void UnlockRoom(IRoom room, string dir, string roomName)
    {
      var nextRoom = _rooms.Find(r => r.Name == roomName);
      if (nextRoom == null) { return; }
      room.Exits.Add(dir, nextRoom);
    }

    public Game()
    {
      CurrentPlayer = new Player();
      CurrentRoom = CurrentRoom;
      Setup();
    }


  }
}