using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask

    {

        public static List<List<string>> ParseSentences(string text)
        {
            
            var listSentences = new List<List<string>>(); // Возвращаемый список для предложений
            
            if (text == null) return null; //проверка на наличие текста
            
            text = text.ToLower();//Убираем верхний регистр из текста


            var sentences = text.Split(new char[] { '.', '!', '?', ';', ':', '(', ')' },
                StringSplitOptions.RemoveEmptyEntries);//парсеный на предложения текст


            foreach (var word in sentences)
            {
                var listWords = new List<string>(); // Список для слов

                var textSentence = CheckSimbol(word);

                string[] wrd = textSentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //Убираем пробелы
                foreach (var i in wrd)
                {
                    if (i!= null && i != "")
                        listWords.Add(i);
                }

                if (listWords.Count == 0) continue;
                else listSentences.Add(listWords);
            }

            return listSentences;
        }

        private static string CheckSimbol(string word)
        {
            var wrd = "";

            foreach (var simbol in word)
            {
                if (char.IsLetter(simbol) || (simbol == '\''))
                    wrd = wrd + simbol;
                else wrd = wrd + ' ';
            }
            return wrd;
        }
    }
}