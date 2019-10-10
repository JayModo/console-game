using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      //Room to Room relationship
      Room Room1 = new Room("Room1", "your at the start of the cave there are 3 dark paths you have a small dim light that barely lights the way");
      Room Room2 = new Room("Room2", "");
      Room Room3 = new Room("Room3", "");
      Room Room4 = new Room("Room4", "");
      Room Room5 = new Room("Room5", "");


      Room1.Exits.Add("west", Room3);
      Room1.Exits.Add("east", Room4);
      Room1.Exits.Add("north", Room2);

      Room2.Exits.Add("west", Room3);
      Room2.Exits.Add("south", Room1);

      Room3.Exits.Add("south", Room1);
      Room3.Exits.Add("north", Room5);


      // creating items to get/ use in certain rooms 
      Item rope = new Item();
      Item gun = new Item();

      Room2.Items.Add(rope);
      Room3.Items.Add(gun);

      //setting the strarting point
      CurrentRoom = Room1;


    }
    public Game()
    {
      CurrentPlayer = new Player();
      CurrentRoom = CurrentRoom;
      Setup();
    }


  }
}