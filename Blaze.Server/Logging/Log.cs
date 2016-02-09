// -----------------------------------------------------------
// This program is private software, based on C# source code.
// To sell or change credits of this software is forbidden,
// except if someone approves it from the Blaze INC. team.
// -----------------------------------------------------------
// Copyrights (c) 2016 Blaze.Server INC. All rights reserved.
// -----------------------------------------------------------

#region

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
// ReSharper disable UnusedMember.Global

#endregion

namespace Blaze.Server.Logging
{
    internal enum LogLevel
    {
        None = 0,
        Debug = 1,
        Info = 2,
        Warning = 4,
        Error = 8,
        Data = 16,
        All = 31
    }

    internal static class Log
    {
        private static string _fileName;
        private static StringBuilder _writeString;

        public static void Initialize(string fileName)
        {
            _fileName = fileName;
            _writeString = new StringBuilder();

            try
            {
                File.Delete(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Log file couldn't be deleted: {0}", e);
            }
        }

        private static void Write(string message, LogLevel level)
        {
            var trace = new StackTrace();

            var frame = trace.GetFrame(2);

            var caller = "";

            if (frame?.GetMethod().DeclaringType != null)
            {
                caller = frame.GetMethod().DeclaringType?.Name + ": ";
            }

            switch (level)
            {
                case LogLevel.Debug:
                    SemiColoredWrite(ConsoleColor.Cyan, caller, "[DEBUG] ", message);
                    message = "DEBUG: " + message;
                    break;
                case LogLevel.Info:
                    SemiColoredWrite(ConsoleColor.Green, caller, "[INFO] ", message);
                    message = "INFO: " + message;
                    break;
                case LogLevel.Warning:
                    SemiColoredWrite(ConsoleColor.Magenta, caller, "[WARNING] ", message);
                    message = "WARNING: " + message;
                    break;
                case LogLevel.Error:
                    SemiColoredWrite(ConsoleColor.Red, caller, "[ERROR] ", message);
                    message = "ERROR: " + message;
                    break;
            }

            var text = caller + message;

            _writeString.AppendLine(text);
        }

        private static void SemiColoredWrite(ConsoleColor color, string noColorText1, string coloredText, string noColorText2)
        {
            var originalColor = Console.ForegroundColor;
            Console.Write($"[{DateTime.Now.ToString("hh:mm:ss")}] ");
            Console.ForegroundColor = color;
            Console.Write(coloredText);
            Console.ForegroundColor = originalColor;
            Console.Write(noColorText1);
            Console.Write(noColorText2 + Environment.NewLine);
        }

        public static void WriteAway()
        {
            var stringToWrite = _writeString.ToString();
            _writeString.Length = 0;

            var _logWriter = new StreamWriter(_fileName, true);

            _logWriter.Write(stringToWrite);
            _logWriter.Flush();
            _logWriter.Close();
        }

        public static void Data(string message) => Write(message, LogLevel.Data);

        public static void Error(string message) => Write(message, LogLevel.Error);

        public static void Warn(string message) => Write(message, LogLevel.Warning);

        public static void Info(string message) => Write(message, LogLevel.Info);

        public static void Debug(string message) => Write(message, LogLevel.Debug);
    }
}