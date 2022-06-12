using System.Diagnostics;

namespace TestCaseKasper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Dir> dirs = new List<Dir>();
            List<Task> tasks = new List<Task>();
            List<string> tasksId= new List<string>();
            List<Stopwatch> stopwatch = new List<Stopwatch>();
            string command = Console.ReadLine(); //Здесь будет ввод команды
            string p = ""; //здесь будет ввод директории
            int currentCreateTask = -1;
            string requestIdTask = "";


            #region Меню
            while (command != "exit")
            { 
                #region пункт меню status task реализация
                if (command.Length> "status task".Length && command.Substring(0, "status task".Length) == "status task")
                {
                    requestIdTask = command.Substring("status task".Length+1); //вытаскиваем id задачи из команды
                    //проверяем есть ли задача с таким id в созданных
                    if (tasksId.Contains(requestIdTask))
                    {
                        #region Вывод результатов
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (tasks[i].Id.ToString() == requestIdTask)
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
                        #endregion
                    }
                }
                #endregion

                #region Пункт меню add task реализация
                if (command.Length > "add task".Length && command.Substring(0, "add task".Length) == "add task")
                {
                    //вытаскиваем путь из команды
                    p = command.Substring("add task".Length+1);
                    #region Создаем задачу на проверку
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
                        tasksId.Add(tasks[currentCreateTask].Id.ToString()); //запоминаем в списке id созданной задачи
                        tasks[currentCreateTask].Start();
                    #endregion
                } 
                #endregion

                command = Console.ReadLine(); 
            }
            #endregion

        }

        

    }
}