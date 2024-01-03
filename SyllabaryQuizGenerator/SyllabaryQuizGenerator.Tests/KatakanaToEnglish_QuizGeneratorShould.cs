using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllabaryQuizGenerator.Tests
{
    //Katakana to English Quiz Generator tests
    public partial class QuizGeneratorShould
    {
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(500)]
        [DataRow(50000)]
        [DataRow(1000000)]
        [TestMethod]
        public void K2E_ReturnListOfQuizItems_HasRequestedNumberOfItems(int numberOfItems)
        {
            List<QuizItem> quizItems = qg.GenerateQuizItems(numberOfItems, QuizType.KatakanaToEnglish);
            Assert.IsNotNull(quizItems);
            Assert.IsTrue(quizItems.Count() == numberOfItems, $"Result does not have {numberOfItems} items.");
        }
    }
}
