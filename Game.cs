using System;

namespace ZuulCS
{
	public class Game
	{
        private Player player;
		private Parser parser;

		public Game ()
		{
            player = new Player();
			createRooms();
			parser = new Parser();
		}
            
		private void createRooms()
		{
			Room outside, theatre, pub, lab, office, mainhall, stair1f, stair2f, upperhall;

			// create the rooms
			outside = new Room("outside the main entrance of the university");
			theatre = new Room("in a lecture theatre");
			pub = new Room("in the campus pub");
			lab = new Room("in a computing lab");
			office = new Room("in the computing admin office");
            mainhall = new Room("in the main hall");
            upperhall = new Room("in the hall on the 2nd floor");
            stair1f = new Room("down by the stairs");
            stair2f = new Room("at the top of the stairs");

            // initialise room exits
            outside.setExit("east", theatre);
			outside.setExit("south", mainhall);
			outside.setExit("west", pub);

            mainhall.setExit("north", outside);
            mainhall.setExit("east", stair1f);
            mainhall.setExit("south", lab);

            stair1f.setExit("west", mainhall);
            stair1f.setExit("up", stair2f);

            stair2f.setExit("down", stair1f);
            stair2f.setExit("west", upperhall);

            upperhall.setExit("east", stair2f);

			theatre.setExit("west", outside);

			pub.setExit("east", outside);

			lab.setExit("north", mainhall);
			lab.setExit("east", office);

			office.setExit("west", lab);

            outside.Inventory.Add(new Rock("Rock",10,"A rock, perfect for throwing."));

			player.currentRoom = outside;  // start game outside
		}


		/**
	     *  Main play routine.  Loops until end of play.
	     */
		public void play()
		{
			printWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the game is over.
			bool finished = false;
			while (! finished) {
				Command command = parser.getCommand();
				finished = processCommand(command);
			}
			Console.WriteLine("Thank you for playing.");
		}

		/**
	     * Print out the opening message for the player.
	     */
		private void printWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine(player.currentRoom.getLongDescription());
		}

		/**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
		private bool processCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.isUnknown()) {
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.getCommandWord();
			switch (commandWord) {
				case "help":
                    line();
                    printHelp();
                    line();
                    break;
				case "go":
                    line();
                    player.goRoom(command);
                    line();
                    break;
				case "quit":
					wantToQuit = true;
					break;
				case "look":
                    line();
                    Console.WriteLine(player.currentRoom.getLongDescription());
                    inRoomInv();
                    line();
                    break;
                case "inv":
                case "inventory":
                    line();
                    inInv();
                    line();
                    break;
                case "take":
                    line();
                    takeItem(command);
                    line();
                    break;
                //temp
                case "health":
                    line();
                    Console.WriteLine(player.Health);
                    line();
                    break;
		    }

			return wantToQuit;
		}

		// implementations of user commands:

		/**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
		private void printHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			Console.WriteLine("Your command words are:");
			parser.showCommands();
		}

        public void inRoomInv() {
            Console.WriteLine("Items in this room:");
            if (player.currentRoom.Inventory.Items.Count > 0) {
                for (int i = 0; i < player.currentRoom.Inventory.Items.Count; i++) {
                    Console.WriteLine(player.currentRoom.Inventory.Items[i].getName + " - " + player.currentRoom.Inventory.Items[i].getDescription);
                }
            } else {
                Console.WriteLine("There are no items in this room");
            }
        }

        public void inInv() {
            Console.WriteLine("Items in your inventory:");
            if (player.Inventory.Items.Count > 0) {
                for (int i = 0; i < player.Inventory.Items.Count; i++) {
                    Console.WriteLine(player.Inventory.Items[i].getName + " - " + player.Inventory.Items[i].getDescription);
                }
            } else {
                Console.WriteLine("Nothing in your inventory");
            }
        }

        private void takeItem(Command command) {
            if (!command.hasSecondWord()) {
                Console.WriteLine("You take all the items in the room and put them away");
                for (int i = player.currentRoom.Inventory.Items.Count - 1; i >= 0; i--) {
                    Item currentItem = player.currentRoom.Inventory.Items[i];
                    Console.WriteLine("Added" + currentItem.getName);
                    player.currentRoom.Inventory.transferItem(player.Inventory, currentItem.getName);
                }
            }
        }

        private void line() {
            Console.WriteLine("------------------------------------------------------");
        }
    }
}

