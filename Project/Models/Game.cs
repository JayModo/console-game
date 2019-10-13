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

      Room Room2 = new Room("Room2", "you fall into a dark damp cavern with a cliff face. Before you fell you saw there was a way out. There is no way to escape mabey you can 'look' to see if there is anything in the cavern");

      Room Room3 = new Room("Room3", "you see there is 2 paths east and west and something shiny on the ground you may need to get close and 'look' to see it.");

      Room Room4 = new Room("Room4", "there is not enough light and you fall down a waterfall GAME OVER");

      Room Room5 = new Room("Room5", "you enter the main chamber and see the Batmobile. You hear someone yell Who are you? Its bruce wayne! You have 3 choices quit your mission, say hi, or you may have something in your inventory that would be Useful'");


      Room1.Exits.Add("west", Room3);
      Room1.Exits.Add("east", Room4);
      Room1.Exits.Add("north", Room2);

      Room2.Exits.Add("west", Room3);
      Room2.Exits.Add("south", Room1);

      Room3.Exits.Add("south", Room1);
      Room3.Exits.Add("north", Room5);


      // creating items to get/ use in certain rooms 
      Item rope = new Item("Rope", "This is just long enough to get up that cliff");
      Item gun = new Item("Gun", "This has got to be useful....");

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