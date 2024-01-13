using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskKiller
{
    public class Parameter
    {
        public List<string> ProgramNames { get; set; }

        internal static Parameter Read(string _path)
        {
            string json = System.IO.File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<Parameter>(json);
        }

        internal static void Write(string _path, Parameter _params)
        {
            System.IO.File.WriteAllText(_path, JsonConvert.SerializeObject(_params, Formatting.Indented));
        }

        internal static Parameter DefaultData()
        {
            return new Parameter()
            {
                ProgramNames = new List<string>() { "Microsoft Excel", "EXCEL" }
            };
        }
    }
}
