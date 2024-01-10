using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator
{
    public enum QuizType
    {
        TransliterationToHiragana = 0,
        TransliterationToKatakana,
        HiraganaToTransliteration,
        KatakanaToTransliteration,
        HiraganaToKatakana,
        KatakanaToHiragana,
        Random
    }
}
