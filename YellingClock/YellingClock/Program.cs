using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellingClock
{
    class Program
    {
        static void Main(string[] args)
        {

            string currentTime = DateTime.Now.ToString("HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            WhatTimeIsIt(currentTime);
            while (true)
            {
                System.Threading.Thread.Sleep(5000);
                Console.Clear();
                currentTime = DateTime.Now.ToString("HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                WhatTimeIsIt(currentTime);
            }


        }


        public static void WhatTimeIsIt(string input)
        {
            string time = input;
            string[] words = time.Split(':');
            string[] vHours = { "00.wav", "1a.wav", "2a.wav", "3a.wav", "4a.wav", "5a.wav", "6a.wav", "7a.wav", "8a.wav", "9a.wav", "10a.wav", "11a.wav", "12a.wav" };
            string[] vTenEnds = { "twen.wav", "thir.wav", "for.wav", "fif.wav" };
            string[] vTeens = { "10.wav", "11a.wav", "12a.wav", "thir.wav", "for.wav", "fif.wav", "six.wav", "seven.wav", "eight.wav", "nine.wav" };
            string[] hours = { "twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve" };
            string[] minutesTens = { "twenty", "thirty", "forty", "fifty" };
            string[] teenMinutes = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            int hour, minutes;
            var soundPlayer = new System.Media.SoundPlayer();
            var soundPlayerTY = new System.Media.SoundPlayer("yelling clock\\ty.wav");
            hour = Convert.ToInt32(words[0]);
            minutes = Convert.ToInt32(words[1]);
            Console.Write("It's {0} ", hours[hour % 12]);
            soundPlayer.SoundLocation = "yelling clock\\" + vHours[hour % 12];
            soundPlayer.PlaySync();


            if (minutes != 0)
            {
                if (minutes / 10 > 1)
                {
                    Console.Write("{0} ", minutesTens[minutes / 10 - 2]);
                    soundPlayer.SoundLocation = "yelling clock\\" + vTenEnds[minutes / 10 - 2];
                    soundPlayer.PlaySync();
                    soundPlayer.SoundLocation = "yelling clock\\ty.wav";
                    soundPlayer.PlaySync();

                    if (minutes % 10 != 0)
                    {
                        Console.Write("{0} ", hours[minutes % 10]);
                        soundPlayer.SoundLocation = "yelling clock\\" + vHours[minutes % 10];
                        soundPlayer.PlaySync();

                    }
                }
                else if (minutes / 10 > 0)
                {
                    Console.Write("{0} ", teenMinutes[minutes % 10]);
                    if (minutes % 10 > 2)
                    {
                        soundPlayer.SoundLocation = "yelling clock\\" + vHours[minutes % 10];
                        soundPlayer.PlaySync();
                        soundPlayer.SoundLocation = "yelling clock\\teen.wav";
                        soundPlayer.PlaySync();
                    }
                    soundPlayer.SoundLocation = "yelling clock\\" + vHours[minutes % 10];
                    soundPlayer.PlaySync();
                }
                else
                {
                    Console.Write("oh {0} ", hours[minutes]);
                    soundPlayer.SoundLocation = "yelling clock\\o.wav";
                    soundPlayer.PlaySync();
                    soundPlayer.SoundLocation = "yelling clock\\" + vHours[minutes];
                    soundPlayer.PlaySync();
                }
            }
            if (hour > 11)
            {
                Console.Write("pm \n");
                soundPlayer.SoundLocation = "yelling clock\\pm.wav";
                soundPlayer.PlaySync();
            }
            else
            {
                Console.Write("am \n");
                soundPlayer.SoundLocation = "yelling clock\\am.wav";
                soundPlayer.PlaySync();
            }
        }
    }
}

