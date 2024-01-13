using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TaskKiller
{
    class Program
    {
        private static string ParamsPath { get; set; } = "params.json";
        private static Parameter Parameters { get; set; } = Parameter.DefaultData();
        static void Main(string[] args)
        {
            if (System.IO.File.Exists(ParamsPath))
            {
                Parameters = Parameter.Read(ParamsPath);
            }
            else { Parameter.Write(ParamsPath, Parameter.DefaultData()); return; }

            string[] programNames = Parameters.ProgramNames.Where(x => x.Length > 0).ToArray();
            IEnumerable<Process> processes = Process.GetProcesses().Where(x => x.ProcessName.IsOneOf(programNames));
            if (processes != null && processes.Count() > 0)
            {
                foreach (Process proc in processes)
                {
                    proc.Kill(true);
                }
            }
        }
    }
}
