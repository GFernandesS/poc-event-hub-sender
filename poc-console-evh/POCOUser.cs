using System;
using System.Collections.Generic;

namespace poc_console_evh
{
    public class POCOUser
    {
        private static List<string> possibleNames = new List<string> { "Guilherme", "Fernando", "Gustavo", "Felipe" };

        public string Name { get; private set; } = possibleNames[new Random().Next(0, possibleNames.Count)];
        public int Age { get; private set; } = new Random().Next(0, 50);
    }
}
