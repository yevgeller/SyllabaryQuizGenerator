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
        [TestMethod]
        public void Check_IsKatakana()
        {
            //static string hiragana = "あいうえおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔ";
            char[] katakanaSyllables = "アイウエオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴ".ToCharArray();
            //static string translit = "aiueokagakigikugukegekogosazashijisuzusezesozotadachijitsuzutedetodonaninunenohabapahibipifubupuhebepehobopomamimumemoyayuyo";
            foreach(char k in katakanaSyllables)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsKatakana(k.ToString()));
            }

        }
        [TestMethod]
        public void Check_IsHiragana()
        {
            char[] hiraganaSyllables = "あいうえおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔ".ToCharArray();
            //char[] katakanaSyllables = "アイウエオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴ".ToCharArray();
            //static string translit = "aiueokagakigikugukegekogosazashijisuzusezesozotadachijitsuzutedetodonaninunenohabapahibipifubupuhebepehobopomamimumemoyayuyo";
            foreach (char h in hiraganaSyllables)
            {
                Assert.IsTrue(Syllabary.Syllabary.IsHiragana(h.ToString()));
            }

        }
    }
}
