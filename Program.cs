using System.Diagnostics;

namespace TestCaseKasper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dir> dirs = new List<Dir>();
            List<Task> tasks = new List<Task>();
            List<Stopwatch> stopwatch = new List<Stopwatch>();

            string command = "add task"; //Здесь будет ввод команды
            string p = @"C:\Audit\TestFolder"; //здесь будет ввод директории
            
            //Создаем задачу на проверку директории
            int currentCreateTask = -1;
            
            if (command == "add task")
            {
                currentCreateTask++;
                tasks.Add(
                    new Task(() =>
                        {
                            stopwatch.Add(new Stopwatch());
                            stopwatch[currentCreateTask].Start();
                            dirs.Add(new Dir(p));
                            stopwatch[currentCreateTask].Stop();
                        } 
                    ));
                Console.WriteLine("Scan task was created with ID: {0}", tasks[currentCreateTask].Id);

                tasks[currentCreateTask].Start();
                
            }
            //if (command == "status task")
            int idTask = tasks[0].Id;

            //Отладочная задержка
            System.Threading.Thread.Sleep(50);

            //Вывод результатов
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id==idTask)
                {
                    if (tasks[i].IsCompleted)
                    {
                        Console.WriteLine("====== Scan result ======");
                        dirs[i].PrintAboutDir();
                        Console.WriteLine("Exection time: {0}", stopwatch[i].Elapsed.ToString());
                        Console.WriteLine("=========================");
                    }
                    else Console.WriteLine("Scan task in progress, please wait");
                }
                
            }
            Task.WaitAll(tasks.ToArray());
        }

        

    }
}