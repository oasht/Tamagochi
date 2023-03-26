using System;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Console;

namespace Tamagochi
{

    class Tamagochi
    {
        public int life=100;
        string name { get; set; }
        public Tamagochi(string name)
        {
            this.name = name;
        }
        public ref int Action(string action)
        {
            
            if (action == "feed")
            {
                WriteLine("I'm hungry!\n");
                DialogResult result = MessageBox.Show("Can you feed me?", name, MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No) { life -= 20; } else { life += 20; }
            }

            else if (action == "walk")
            {
                WriteLine("I want to go for a walk!\n");
                DialogResult result = MessageBox.Show("Can you walk me?", name, MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No) { life -= 10; } else { life += 10; }
            }
            else if (action == "play")
            {
                WriteLine("I wanna play!\n");
                DialogResult result = MessageBox.Show("Can you play with me?", name, MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No) { life -= 10; } else { life += 10; }
            }
            else if (action == "pet")
            {
                WriteLine("I want love!\n");
                DialogResult result = MessageBox.Show("Can you pet me?", name, MessageBoxButtons.YesNo,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.No) { life -= 15; } else { life += 15; }
            }

            return ref life;
        }
      
        public override string ToString()
        {
            return $"{name} has {life} % of life";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string[] action = { "feed", "walk", "play", "pet" };
            WriteLine("Enter Tamagochi's name\n");
            string name = Console.ReadLine();
            Tamagochi tm = new Tamagochi(name);
            WriteLine(tm);
            do
            {
                int key = rand.Next(0, 4);
                Clear();
                switch(key)
                {
                    case 0:
                        tm.Action("feed");
                        break;
                        case 1:
                        tm.Action("walk");
                        break;
                        case 2:
                        tm.Action("play");
                        break;
                        case 3:
                        tm.Action("pet");
                        break;
                       
                }
                WriteLine(tm);
                System.Threading.Thread.Sleep(1000);
               
            } while (tm.life > 0 && tm.life < 150);
            Clear();
            if (tm.life <= 0)
                WriteLine($"                  {name} died! You killed poor {name}!");
            else
                WriteLine($"                  {name} grew and became big! You are a good owner");

        }
    }
}
