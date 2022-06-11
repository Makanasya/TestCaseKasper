using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TestCaseKasper
{
    internal class Dir
    {
        string PathForDir = "";
        public int badCheck = 0;
        public List<MyFile> files = new List<MyFile>();
        public Dictionary<string, int> suspectFiles = new Dictionary<string, int>();
        //заполнение словаря уязвимостей для директории
        public void GetSuspects()
        {
            foreach (var item in MyVulnerability.Commonlist)
                suspectFiles.Add(item, 0);
            foreach (var item in MyVulnerability.JSlist)
                suspectFiles.Add(item, 0);
        }
        public Dir(string p) 
        { 
            List<string> f = new List<string>();
            PathForDir = p;
            f=Directory.GetFiles(p).ToList();
            foreach (var item in f)
                files.Add(new MyFile (p, item));
            GetSuspects();
            CheckDir();
        }
        
        public void CheckDir() 
        {
            foreach (var item in files)
            {
                item.CheckFile();
                //Подсчет количества уязвимостей каждого вида в конкретном файле
                foreach (var item2 in suspectFiles)
                { 
                    CountEachVulnerability(item2.Key, item);
                }
                badCheck += item.err;
            }
        }
        public void CountEachVulnerability(string vul,MyFile file)
        {
            if ((suspectFiles.ContainsKey(vul))&& (file.suspect.ContainsKey(vul)))
            {
                suspectFiles[vul] += file.suspect[vul];
            }
        }
        //Вывод информации о просканированной директории
        public void PrintAboutDir() 
        {
            Console.WriteLine("путь к директории, сканирование которой производилось: {0}", this.PathForDir);
            Console.WriteLine("Общее количество обработанных файлов: {0}", this.files.Count);
            Console.WriteLine("Количество обнаружений на каждый тип \"подозрительного\" содержимого\n");
            foreach (var item in suspectFiles)
            {
                Console.WriteLine("Тип уязвимости: {0} \nКоличество содержащих уязвимость файлов: {1}\n", item.Key, item.Value);
            }
            Console.WriteLine("Количество ошибок анализа файлов (например, не хватает прав на чтение файла): {0}", this.badCheck);
        }
        //В конкретном тестовом список BadFiles (-список файлов, в которых обнаружены уязвимости), не нужен
        public List<MyFile> BadFiles = new List<MyFile>();
    }
}
