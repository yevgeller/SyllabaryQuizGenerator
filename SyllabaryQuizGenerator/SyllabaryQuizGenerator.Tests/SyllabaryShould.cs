using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator.Tests
{
    [TestClass]
    public class SyllabaryShould
    {
        char[] katakanaSyllables, hiraganaSyllables;
        List<string> translit;
        [TestInitialize] public void Initialize()
        {
            katakanaSyllables = "アイウエオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴ".ToCharArray();
            hiraganaSyllables = "あいうえおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔ".ToCharArray();
            translit = "a i u e o ka ga ki gi ku gu ke ge ko go sa za shi ji su zu se ze so zo ta da chi ji tsu zu te de to do na ni nu ne no ha ba pa hi bi pi fu bu pu he be pe ho bo po ma mi mu me mo ya yu yo".Split(' ').ToList<string>();

        }

        [TestMethod]
        public void Check_IsKatakana()
        {
            foreach(char k in katakanaSyllables)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsKatakana(k.ToString()));
            }

        }
        [TestMethod]
        public void Check_IsHiragana()
        {
            foreach (char h in hiraganaSyllables)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsHiragana(h.ToString()));
            }
        }

        [TestMethod]
        public void Check_IsTransliteration()
        {
            foreach(var s in translit)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsTransliteration(s));
            }
        }
    }
}
