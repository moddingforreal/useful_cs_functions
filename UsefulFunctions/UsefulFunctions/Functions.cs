using System;
using System.Threading;

namespace UsefulFunctions
{
    public static class Functions
    {
        static void slowwrite(string text, int duration_milliseconds)
        {
            for (int i = 0; i <= text.Length; i++)
            {
                Console.Clear();
                Console.Write(text.Substring(0, i));
                Thread.Sleep(duration_milliseconds);
            }
        }
        static void old_slowwrite(string text, int duration_milliseconds)
        {
            string printtext = "";
            for (int i = 0; i <= text.Length; i++)
            {
                printtext = printtext.Substring(i - 1, i);
                Console.Write(printtext);
                Thread.Sleep(duration_milliseconds);
            }
        }
        static void cycle_rand_textcolor(int wait_time_millisecs)
        {
            Random r = new Random();
            ConsoleColor[] consoleColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            while (true)
            {
                Console.ForegroundColor = consoleColors[r.Next(0, 16)];
                Thread.Sleep(wait_time_millisecs);
            }
        }
        static void cycle_rand_backgroundcolor(int wait_time_millisecs)
        {
            Random r = new Random();
            ConsoleColor[] consoleColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            while (true)
            {
                Console.BackgroundColor = consoleColors[r.Next(0, 16)];
                Thread.Sleep(wait_time_millisecs);
            }
        }
        static int factorial(int number)
        {
            int result = 0;
            for (int i = 1; i < number; i++)
            {
                result = number * i;
            }
            return result;
        }
        static bool IsWholeNumber(double number)
        {
            bool isInt = number == (int)number;
            return isInt;
        }
        static double power_of(double base_num, double exponent_num)
        {
            double result = 0;
            if (exponent_num == 0)
            {
                return 1;
            }
            else if (exponent_num > 0)
            {
                for (int i = 0; i <= exponent_num; i--)
                {
                    base_num = base_num / base_num;
                }
                result = base_num;
                return result;
            }
            else if (IsWholeNumber(exponent_num) == true)
            {
                for (int i = 0; i <= exponent_num; i++)
                {
                    base_num = base_num * base_num;
                }
                result = base_num;
                return result;
            }
            else
            {
                throw new Exception("Not a whole number, use roots!");
            }
        }
        static double NthRootOf(double number, double e)
        {
            double root = Convert.ToInt32(Math.Pow(number, (1 / e)));
            return root;
        }
        static bool IsOdd(double number)
        {
            if (IsWholeNumber(number) == false)
            {
                return true;
            }
            double mod_of_two = number % 2;


            if (mod_of_two == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static string replace_strings(string[] replace_strings, string[] strings_to_replace, string original)
        {
            string res = "";
            res = original.Replace(strings_to_replace[0], replace_strings[0]);
            for (int i = 1; i < original.Length; i++)
            {
                res = res.Replace(strings_to_replace[i], replace_strings[i]);
            }
            return res;
        }

        /*Some technical functions*/
        static string path_of_exe()
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            return path;
        }
        static string PathOfExeWithPath()
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location;
            return path;
        }
        static void create_batch_cmd_command(int mode, string save_path, string filename, string commands)
        {
            switch(mode)
            {
                case 0:
                    System.IO.File.Create(save_path);
                    System.IO.File.WriteAllText(save_path + filename + ".bat", commands);
                    break;
                case 1:
                    System.IO.File.Create(save_path);
                    System.IO.File.WriteAllText(save_path + filename + ".cmd", commands);
                    break;
                default:
                    throw new Exception("Not a valid mode!");
            }
        }
        static void register_cmd_command(string file_with_path, string filename)
        {
            System.IO.File.Move(file_with_path, @"C:\Windows\System32\" + filename);
        }
        static double area_of_circle(double radius_or_diameter, bool is_diameter)
        {
            double pi = 3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679;
            double rad = 0;
            if (is_diameter)
            {
                rad = radius_or_diameter / 2;
            }
            else
            {
                rad = radius_or_diameter;
            }
            //this returns it as in "square original_length_unit" for example: 2 meters squared
            double area = pi * rad;
            return area;
        }
        static void change_console_encoding(string encoding, bool change_input_enc, bool change_output_enc)
        {
            if (change_input_enc & change_output_enc)
            {
                switch (encoding)
                {
                    default:
                        throw new Exception("Not a supported format!");
                    case "Ascii":
                        Console.OutputEncoding = System.Text.Encoding.ASCII;
                        Console.InputEncoding = System.Text.Encoding.ASCII;
                        break;
                    case "utf-8":
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        Console.InputEncoding = System.Text.Encoding.UTF8;
                        break;
                    case "utf-7":
                        Console.OutputEncoding = System.Text.Encoding.UTF7;
                        Console.InputEncoding = System.Text.Encoding.UTF7;
                        break;
                    case "utf-32":
                        //this is currently not supported by consoles, but maybe in the future
                        Console.OutputEncoding = System.Text.Encoding.UTF32;
                        Console.InputEncoding = System.Text.Encoding.UTF32;
                        break;
                }
            }
            else if (change_input_enc)
            {
                switch (encoding)
                {
                    default:
                        throw new Exception("Not a supported format!");
                    case "Ascii":
                        Console.InputEncoding = System.Text.Encoding.ASCII;
                        break;
                    case "utf-8":
                        Console.InputEncoding = System.Text.Encoding.UTF8;
                        break;
                    case "utf-7":
                        Console.InputEncoding = System.Text.Encoding.UTF7;
                        break;
                    case "utf-32":
                        //this is currently not supported by consoles, but maybe in the future
                        Console.InputEncoding = System.Text.Encoding.UTF32;
                        break;
                }
            }
            else if (change_output_enc)
            {
                switch (encoding)
                {
                    default:
                        throw new Exception("Not a supported format!");
                    case "Ascii":
                        Console.OutputEncoding = System.Text.Encoding.ASCII;
                        Console.InputEncoding = System.Text.Encoding.ASCII;
                        break;
                    case "utf-8":
                        Console.OutputEncoding = System.Text.Encoding.UTF8;
                        Console.InputEncoding = System.Text.Encoding.UTF8;
                        break;
                    case "utf-7":
                        Console.OutputEncoding = System.Text.Encoding.UTF7;
                        Console.InputEncoding = System.Text.Encoding.UTF7;
                        break;
                    case "utf-32":
                        //this is currently not supported by consoles, but maybe in the future
                        Console.OutputEncoding = System.Text.Encoding.UTF32;
                        Console.InputEncoding = System.Text.Encoding.UTF32;
                        break;
                }
            }
            else
            {
                throw new Exception("Something went wrong!");
            }

        }

        /*Some just for fun functions*/
        static string owofy(string original)
        {
            string[] abca = { "w", "w", "W", "W" };
            string[] abcb = { "r", "l", "R", "L" };
            string abc = replace_strings(abca, abcb, original);
            return abc;
        }
        static string random_string(int length)
        {
            string random = "";
            Random r = new Random();
            string[] a = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "!", "\"", "§", "$", "%", "&", "/", "(", ")", "=", "?", "²", "³", "{", "[", "]", "}", @"\", "^", "°", "@", "<", ">", "|", ",", ";", ".", ":", "-", "_", "#", "'", "*", "+", "~", "´", "`", "€", "µ", "¥", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string b = "";
            int a_length = a.Length;
            for (int i = 0;i<length;i++)
            {
                b = b + r.Next(0, a_length);
            }
            random = b;
            return random;
        }
    }
}
