using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWatchDogService;

namespace testWatchDogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new TestWatchDogService.TestWatchDogService();
            service.startmethod();
            Console.ReadLine();
        }
    }
}
