using QLGAME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QLGAME.Managers
{
    public class GameManager
    {
        public List<Game> Games = new List<Game>();

        public GameManager() { }


        //Kiểm tra dữ liệu 
        private int kiemtraID(String ID)
        {
            for (int i = 0; i < Games.Count; i++)
            {
                if (Games[i].ID_Game == ID)
                {
                    return i;
                }
            }
            return -1;
        }
        //Thêm dữ liệu
        public void them()
        {
            Console.WriteLine("So luong game muon them : ");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Game thu {0}", num);
                Game game = new Game();
                Console.WriteLine("Nhap ID game: ");
                game.ID_Game = Console.ReadLine();
                int test = 0;
                if ((test = kiemtraID(game.ID_Game)) >= 0)
                {
                    Console.WriteLine("Ma ID Da Ton Tai !!!");
                    them();
                }

                game.Nhap();
                Games.Add(game);
            }
        }

        //Chỉnh sửa dữ liệu
        public void edit()
        {
            Console.WriteLine("Nhap phien ban game muon Sua: ");
            String ID = Console.ReadLine();
            int test = 0;
            if ((test = kiemtraID(ID)) >= 0)
            {
                Game check = new Game();
                check.Phien_Ban = ID;
                check.Chinhsua();
                Games[test] = check;

                Console.WriteLine("Chinh Sua Thanh Cong");
            }
            else
            {
                Console.WriteLine("Ma ID Khong Ton Tai !!!");
            }

        }

        //Xóa dữ liệu
        public void delete()
        {
            Console.WriteLine("Nhap Ma Mon Hoc Muon Xoa: ");
            String ID = Console.ReadLine();
            int test = 0;
            if ((test = kiemtraID(ID)) >= 0)
            {
                Games.RemoveAt(test);
                Console.WriteLine("Xoa Thanh Cong");
            }
            else
            {
                Console.WriteLine("Ma ID Khong Ton Tai !!!");
            }
        }

        //Sắp xếp
        public void sapXep()
        {
            var GameSort = Games.OrderBy(P => P.Nam_SX);
            foreach (Game games in GameSort)
            {
                Games.Add(games);
            }
        }

        //Hien thi man hinh
        public void displayAll()
        {
            if (Games.Any())
            {
                Console.WriteLine(String.Format("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5, -10} {6, -10}", "Ten Game","ID Game", "The Loai", "Nam SX", "Dung Luong", "Phien Ban", "So Luot Tai Ve"));
                foreach (Game nh in Games)
                {
                    nh.Xuat();
                }
            }
            else
            {
                Console.WriteLine("Danh sach trong!!!");
            }
        }

        public void writeFile()
        {
            FileStream fs = new FileStream("../../Data/QLGAME.DAT", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Game nh in Games)
            {
                sw.WriteLine(String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} ", nh.ID_Game, nh.Ten_Game, nh.The_Loai, nh.Nam_SX, nh.Dung_Luong, nh.Phien_Ban, nh.So_Luot_Tai_Ve));
            }
            sw.Close();
            fs.Close();
        }

        ////Đọc dữ liệu từ file txt
        public void readFile()
        {

            FileStream fs = new FileStream("../../Data/QLGAME.DAT", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            //Kiếm tra xem file tồn tại hay chưa
            //Sử dụng vòng lặp để add dữ liệu từ file vào mảng NHList
            string ID_Game = sr.ReadLine();
            while (ID_Game != null)
            {
                Games.Add(new Game
                {
                    ID_Game = ID_Game,
                    Ten_Game = sr.ReadLine(),
                    The_Loai = sr.ReadLine(),
                    Nam_SX = Convert.ToInt32(sr.ReadLine()),
                    Dung_Luong = sr.ReadLine(),
                    Phien_Ban = sr.ReadLine(),
                    So_Luot_Tai_Ve = sr.ReadLine(),

                });
                ID_Game = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }

        public void menu()
        {
            int choice;
            do
            {
                Console.WriteLine("=========== Quan ly Game ===========");
                Console.WriteLine("1.Them");
                Console.WriteLine("2.Sua");
                Console.WriteLine("3.Xoa");
                Console.WriteLine("4.Danh Sach");
                Console.WriteLine("5.Luu file");
                Console.WriteLine("0.Back");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        them();
                        break;
                    case 2:
                        edit();
                        break;
                    case 3:
                        delete();
                        break;
                    case 4:
                        displayAll();
                        break;
                    case 5:
                        writeFile();
                        break;
                    case 6:
                        sapXep();
                        break;
                    default:
                        break;
                }
            } while (choice != 0);
        }

    }
}
