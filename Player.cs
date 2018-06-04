using System;

namespace ZuulCS
{
	public class Player 
    {
        private Room _currentRoom;
        private int health = 100;
        private bool alive = true;

        public Room currentRoom {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }

        public int damage(int amount) {
            health = health - amount;
            return health;
        }

        public int heal(int amount) {
            health = health + amount;
            return health;
        }

        public int Health {
            get { return health; }
        }

        public bool isAlive() {
            if (health < 1) {
                Console.WriteLine("");
                Console.WriteLine("██╗   ██╗ ██████╗ ██╗   ██╗    ██████╗ ██╗███████╗██████╗");
                Console.WriteLine("╚██╗ ██╔╝██╔═══██╗██║   ██║    ██╔══██╗██║██╔════╝██╔══██╗");
                Console.WriteLine(" ╚████╔╝ ██║   ██║██║   ██║    ██║  ██║██║█████╗  ██║  ██║");
                Console.WriteLine("  ╚██╔╝  ██║   ██║██║   ██║    ██║  ██║██║██╔══╝  ██║  ██║");
                Console.WriteLine("   ██║   ╚██████╔╝╚██████╔╝    ██████╔╝██║███████╗██████╔╝");
                Console.WriteLine("   ╚═╝    ╚═════╝  ╚═════╝     ╚═════╝ ╚═╝╚══════╝╚═════╝");
                Console.WriteLine("");
                alive = false;
                return alive;
            } else {
                alive = true;
                return alive;
            }
        }

        /**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
        public void goRoom(Command command) {
            
            if (!command.hasSecondWord()) {
                // if there is no second word, we don't know where to go...
                Console.WriteLine("Go where?");
                return;
            }

            string direction = command.getSecondWord();

            // Try to leave current room.
            Room nextRoom = currentRoom.getExit(direction);
            isAlive();
            if (alive == true) {
                if (nextRoom == null) {
                    Console.WriteLine("There is no door to " + direction + "!");
                } else {
                    currentRoom = nextRoom;
                    damage(2);
                    Console.WriteLine(currentRoom.getLongDescription());
                }
            }
        }
    }
}
