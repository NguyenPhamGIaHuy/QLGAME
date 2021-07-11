using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGAME.Models
{
    public class Game
    {
        public string Ten_Game { get; set; }
        public string The_Loai { get; set; }
        public int Nam_SX { get; set; }
        public string Dung_Luong { get; set; }
        public string  Phien_Ban { get; set; }
        public string So_Luot_Tai_Ve { get; set; }
        public string ID_Game { get; set; }

        public Game() { }
        public Game(string tenGame, string theLoai, int namSX, string dungLuong, string phienBan, string soLuotTaiVe, string iDGame)
        {
            Ten_Game = tenGame;
            The_Loai = theLoai;
            Nam_SX = namSX;
            Dung_Luong = dungLuong;
            Phien_Ban = phienBan;
            So_Luot_Tai_Ve = soLuotTaiVe;
            ID_Game = iDGame;
        }

        public void Nhap()
        {
            Console.WriteLine("Nhap ten game: ");
            Ten_Game = Console.ReadLine();
            Console.WriteLine("Nhap the loai game: ");
            The_Loai = Console.ReadLine();
            Console.WriteLine("Nhap nam san xuat: ");
            Nam_SX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap dung luong: ");
            Dung_Luong = Console.ReadLine();
            Console.WriteLine("Nhap phien ban: ");
            Phien_Ban = Console.ReadLine();
            Console.WriteLine("Nhap so luot tai ve: ");
            So_Luot_Tai_Ve = Console.ReadLine();
        }

        public void Chinhsua()
        {
            Nhap();
        }

        public void Xuat()
        {
            Console.WriteLine(String.Format("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5, -10} {6, -10}",Ten_Game ,ID_Game, The_Loai, Nam_SX, Dung_Luong, Phien_Ban, So_Luot_Tai_Ve ));
        }

    }
}
