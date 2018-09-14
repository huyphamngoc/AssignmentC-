using Assignment1.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Sevices
{
    class InforSevices
    {
        public static ObservableCollection<Infor> Infors = null;
        public static void LoadStaticSong()
        {
            if (Infors == null)
            {
                Infors = new ObservableCollection<Infor>();
            }
            if (Infors.Count == 0)
            {
                Infors.Add(new Infor
                {
                    Name = "Giấc mơ chỉ là giấc mơ",
                    Phone = "0101001",
                    Email = "huy@gmail.com",
                    Address = "HA NOI",
                    Avatar = "https://c1-ex-swe.nixcdn.com/NhacCuaTui945/GiacMoChiLaGiacMoSeeSingShare2-HaAnhTuan-5082049.mp3",
                });

            }
        }

        public static ObservableCollection<Infor> GetSongs(int page, int limit)
        {
            LoadStaticSong();
            //if (MetaData == null)
            //{
            //    MetaData = new MetaData();
            //}
            //// tao moi meta data tu api hoac fix tai local.
            //MetaData.Page = page;
            //MetaData.Limit = limit;
            //MetaData.TotalPage = 1;
            //MetaData.From = 1;
            //MetaData.To = 6;
            //MetaData.Total = 6;
            return Infors;
        }
    }
}
