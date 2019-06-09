using System;
using System.Threading;
using NLog;

namespace ConsoleApplication1
{
    class Program
    {
        //Не знаю как правильнее - создать один static Logger, либо в каждом потоке создавать свой объект Logger
        
        //static Logger log = LogManager.GetCurrentClassLogger(); 
        static void Main()
        {
            int numberOfThreads = 20;
            for (int i = 0; i < numberOfThreads; i++)
                ThreadPool.QueueUserWorkItem(JobForAThread);
            Thread.Sleep(3000);
            Console.WriteLine("Логирование {0} потоков завершено", numberOfThreads);
            Console.ReadLine();
        }

        static void JobForAThread(object state)
        {
            GenerateLog();
            Console.WriteLine("Выполнение внутри потока {0} из пула ", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(50);
        }

        static void GenerateLog()
        {
            Logger log = LogManager.GetCurrentClassLogger();
            log.Trace("trace message");
            log.Debug("debug message");
            log.Info("info message");
            log.Warn("warn message");
            log.Error("error message");
            log.Fatal("fatal message");
        }
    }
}