using QLGAME.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGAME
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            GameManager nh = new GameManager();
            nh.readFile();
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    nh.menu();
                    break;
                default:
                    break;
            }
        }
    }
}
