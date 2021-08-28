using GetOffMyLawnBot.Helpers;
using System;

namespace GetOffMyLawnBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[GetOffMyLawnBot]");

            //проверка текущей версии
            if (Settings.SupportedVersion != Settings.Version)
            {
                WriteLine("Внимание, конфиг может не подходить к текущей версии! Удалите его и нажмите на любую кнопку", MessageType.Warning);
                ReadLine();
                Settings.InitConfig();
            }



        }

        static void WriteLine(string message, MessageType type = MessageType.Info)
        {
            switch (type)
            {
                case MessageType.Info:
                    message = "[INFO] " + message;
                    break;
                case MessageType.Warning:
                    message = "[WARN] " + message;
                    break;
                case MessageType.Error:
                    message = "[ERROR] " + message;
                    break;
            }    
            Console.WriteLine(message);
        }

        static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
