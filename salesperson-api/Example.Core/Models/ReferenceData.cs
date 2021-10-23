using Example.Core.Enums;
using System.Collections.Generic;

namespace Example.Core.Models
{
    public class ReferenceData
    {
        public IDictionary<int, string> CarTypes { get; set; }
        public IDictionary<int, string> LanguageOptions { get; set; }
    }
}
