using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07._03._19
{
    class Program
    {
        static object key = new object();
        static void Main(string[] args)
        {
            new Thread(() => { NurseCheck(); }).Start();
            new Thread(() => { NurseCheck(); }).Start();
            new Thread(() => { NurseCheck(); }).Start();

            new Thread(() => { DoctorTreatment(); }).Start();
            new Thread(() => { DoctorTreatment(); }).Start();
            new Thread(() => { DoctorTreatment(); }).Start();


            Console.ReadLine();
        }
        static void NurseCheck()
        {
            Monitor.Enter(key);

            Monitor.Wait(key);
            Console.WriteLine("Nurse is checking....");
            Thread.Sleep(5000);
            Monitor.Pulse(key);
            Console.WriteLine("Next patient please!");
            Monitor.Exit(key);
        }
        static void DoctorTreatment()
        {
            Monitor.Enter(key);

            Console.WriteLine("Waiting for my turn... ");
            Monitor.Pulse(key);
            Console.WriteLine("Getting treatment");
            Monitor.Exit(key);
            NurseCheck();
        }
    }
}
