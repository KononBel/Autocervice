using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Models
{
    static class Parts
    {
        private static Dictionary<string, int> s_names;

        static Parts()
        {
            s_names = new Dictionary<string, int>();

            s_names.Add("Колесо", 80);
            s_names.Add("Фара", 105);
            s_names.Add("Двигатель", 503);
            s_names.Add("Коробка передач", 301);
            s_names.Add("Привод", 107);
            s_names.Add("Тормозной диск", 34);
            s_names.Add("Радиатор охлаждения", 268);
            s_names.Add("Стабилизатор устойчивости", 20);
            s_names.Add("Сиденье", 51);
            s_names.Add("Педали", 17);
        }

        public static List<Part> Get(int countPartEch = 1)
        {
            List<Part> newParts = new List<Part>();

            foreach (var partName in s_names)
            {
                for (int i = 0; i < countPartEch; i++)
                    newParts.Add(new Part(partName.Key, partName.Value));
            }

            return newParts;
        }
    }
}