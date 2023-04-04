using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashProject
{
    class MyHash
    {
        public int sizeTable; // размер таблицы;
        static int step = 37; //шаг для разрешения коллизий
        int size; // число элементов в таблице
        public THashItem[] h; // хеш-таблица
        public MyHash(int sizeTable)
        {
            this.sizeTable = sizeTable;
            h = new THashItem[sizeTable];
            HashInit();
        }
        public void HashInit()
        {
            size = 0;
            for (int i = 0; i < sizeTable; i++)
            {
                this.h[i].empty = true;
                this.h[i].visit = false;
            }
        }
        int hashKey(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result += Convert.ToInt32(s[i]) * i;
                result %= sizeTable;
            }
            return result;
        }
        public int AddHash(string fio, string phone)
        {
            int adr = -1;
            if (size < sizeTable)
            {
                adr = hashKey(phone);// таблица не переполнена
                while (!h[adr].empty)
                    adr = (adr + step) % sizeTable;
                // место свободно - можно ставить элемент
                h[adr].empty = false; //признак занятости
                h[adr].visit = true; //признак посещенности
                h[adr].info.fio = fio;
                h[adr].info.phone = phone;
                size++;
            }
            return adr;
        }
        public bool DelHash(string phone, out int i)
        {
            bool result = false;
            i = 0;
            if (size != 0) // таблица не пуста
            {
                i = hashKey(phone);
                // вычисление индекса элемента
                if (h[i].info.phone == phone)
                // элемент найден
                {
                    h[i].empty = true;
                    result = true;
                    size--;
                }
                else // коллизия
                {
                    string FIO; int count;
                    i = FindHash(phone, out FIO, out count);
                    if (i != -1)
                    // Элемент найден. Можно удалять
                    {
                        h[i].empty = true;
                        result = true;
                        size--;
                    }
                }
            }
            return result;
        }
        public void ClearVisit()
        {

        }
        public int FindHash(string phone, out string fio, out int count) // поиск в хеш-таблице
        {
            int result = -1;
            bool ok;
            fio = "";
            count = 1;
            ClearVisit();
            int i = hashKey(phone);
            ok = h[i].info.phone == phone;
            while (!ok && !h[i].visit)
            {
                count++;
                h[i].visit = true;
                i = (i + step) % sizeTable; // продолжаем поиск
                ok = h[i].info.phone == phone;
            }
            if (ok)
            {
                result = i;
                fio = h[result].info.fio;
            }
            return result;
        }
    }
}
