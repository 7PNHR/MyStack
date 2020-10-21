using System.Collections.Generic;
using System.Linq;

namespace List
{
    public static class Parser
    {
        public static IEnumerable<string> Parsing(string line)
        {
            var result = new List<string>();
            var value = "";
            var list = new List<string> {"+", "-", ":", "^", "(", ")", "*"};
            foreach (var token in line.Select(t => t.ToString()))
            {
                if(token==" ") continue;
                if (list.Contains(token))
                {
                    if(value!="")
                        result.Add(value);
                    value = "";
                    result.Add(token);
                }
                else value += token;
            }
            if (value.Length > 0)
                result.Add(value);
            return result;
        }
    }
}