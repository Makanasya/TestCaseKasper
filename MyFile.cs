using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseKasper
{
    internal class MyFile
    {
        public MyFile(string pf, string fp)
        {
            PathForFile = pf;
            FullPath = fp;
            NameForFile = FullPath.Substring(FullPath.IndexOf(pf) + pf.Length + 1);
            Extention = Path.GetExtension(FullPath);
            GetSuspects();
        }
        public string NameForFile { get; set; } //имя файла с расширением
        public string PathForFile { get; set; } //путь до файла, исключая имя файла
        public string FullPath { get; set; } //полный путь до файла, включая имя самого файла
        public string Extention { get; set; } //расширение файла, содержит '.' в начале
        public int err = 0;
        
        public Dictionary<string, int> suspect = new Dictionary<string, int>(); //словарь уязвимостей для конкретного файла
        //заполнение словаря уязвимостей для файла
        public void GetSuspects() 
        { 
            foreach(var item in MyVulnerability.Commonlist)
                suspect.Add(item,0);
            if (Extention == ".js")
            {
                foreach (var item in MyVulnerability.JSlist)
                    suspect.Add(item, 0);
            }
        }
        //Проверка какие уязвимости содержит файл
        public void CheckFile()
        {
            try
            {
                string line = "";
                StreamReader sr = new StreamReader(FullPath);
                line = sr.ReadLine();
                while (line != null)
                {
                    foreach (var item in suspect)
                    {
                        if (line.Contains(item.Key))
                        {
                            string k = item.Key;
                            suspect[k] += 1;
                        }
                    }
                    line = sr.ReadLine();
                }
            }
            catch { err ++; }
        }
        
        //отладочная функция, выводит инфо о файле
        public void PrintAboutFile()
        {
            Console.WriteLine("FullPath: {0}", this.FullPath);
            Console.WriteLine("NameForFile: {0}", this.NameForFile);
            Console.WriteLine("PathForFile: {0}", this.PathForFile);
            Console.WriteLine("Extention: {0}", this.Extention);
        }

    }
}
