using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator
{
    public class SyllabaryCharacter
    {
        public string Hiragana { get; set; } = string.Empty;
        public string Katakana { get; set; } = string.Empty;
        public string Transliteration { get; set; } = string.Empty;
        public int UniqueId { get; set; }
        public bool IsDigraph { get; set; } = false;
        public bool IsWithDiacritics { get; set; } = false;
    }
}
