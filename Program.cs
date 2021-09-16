//Created by Claudia Campos
//Date: Sep 15, 2021

using System;

namespace MarsRovers
{
    class Rover
    {

        public int x { get; set; } // Rover x
        public int y { get; set; } // Rover y
        private int row_max;
        private int col_max;

        public string dir; // Rover direction
        string[] str_dir = { "N", "E", "S", "W" };

        public Rover(string loc, int row_max, int col_max)
        {
            string[] str = loc.Split(" ");
            this.x = Int32.Parse(str[0]);
            this.y = Int32.Parse(str[1]);
            dir = str[2];
            this.row_max = row_max;
            this.col_max = col_max;
        }

        public void TurnLeft()
        {
            int index = Array.IndexOf(str_dir, dir);
            if (index > -1 && index < str_dir.Length)
            {
                dir = str_dir[(index - 1 + str_dir.Length) % str_dir.Length];
            }
            else
            {
                // throw new ArgumentException();  
            }
        }

        public void TurnRight()
        {
            int index = Array.IndexOf(str_dir, dir);
            if (index > -1 && index < str_dir.Length)
            {
                dir = str_dir[(index + 1) % str_dir.Length];
            }
            else
            {
                // throw new ArgumentException();  
            }
        }

        public void Move()
        {
            switch (dir)
            {
                case "N":
                    if (y < row_max)
                        y = y + 1;
                    break;
                case "W":
                    if (x > 0)
                        x = x - 1;
                    break;
                case "S":
                    if (y > 0)
                        y = y - 1;
                    break;
                case "E":
                    if (x < col_max)
                        x = x + 1;
                    break;
                default:
                    // throw new ArgumentException();
                    break;
            }
        }

        //Move the rovers and change direction
        public void Move(string strMessages)
        {
            char[] messages = strMessages.ToCharArray();

            for (int i = 0; i < messages.Length; i++)
            {
                switch (messages[i])
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        // throw new ArgumentException();
                        break;
                }
            }
        }
    }
}


namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine(); // 5 5
            string s2 = Console.ReadLine(); // 1 2 N
            string s3 = Console.ReadLine(); // LMLMLMLMM
            string s4 = Console.ReadLine(); // 3 3 E
            string s5 = Console.ReadLine(); // MMRMMRMRRM

            string[] str = s1.Split(" ");
            int row = Int32.Parse(str[0]);
            int col = Int32.Parse(str[1]);

            Rover rover = new Rover(s2, row, col);
            rover.Move(s3);
            Console.WriteLine(rover.x + " " + rover.y + " " + rover.dir);

            Rover rover1 = new Rover(s4, row, col);
            rover1.Move(s5);
            Console.WriteLine(rover1.x + " " + rover1.y + " " + rover1.dir);
        }
    }
}