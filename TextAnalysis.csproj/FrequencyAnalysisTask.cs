
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static string KeyValue(int kindOfNGramm, string sentences1, string sentences2)
        {
            if (CheckNGramm(kindOfNGramm) == 2)
                return sentences2 + " " + sentences1;
            return sentences1;
        }

        public static int CheckNGramm(int kindOfNGramm)
        {
            if (kindOfNGramm == 3)
                return 2;
            return 1;
        }

        public static Dictionary<string, string> GetNGramms(List<List<string>> text, int kindOfNGramm)
        {
            Dictionary<string, Dictionary<string, int>> nGramm = GetValuesOfFrequences(kindOfNGramm, text);
            Dictionary<string, string> finallyNGramm = new Dictionary<string, string>();
            foreach (var newKey in nGramm.Keys)
            {
                var actualValue = nGramm[newKey].First().Key;
                foreach (var otherValue in nGramm[newKey].Keys)
                    if (nGramm[newKey][otherValue] >= nGramm[newKey][actualValue])
                        if (nGramm[newKey][otherValue] == nGramm[newKey][actualValue])
                        {
                            if (string.CompareOrdinal(actualValue, otherValue) > 0)
                                actualValue = otherValue;
                        }
                        else actualValue = otherValue;
                if (nGramm[newKey][actualValue] == 1)
                    foreach (var otherValue in nGramm[newKey].Keys)
                        if (string.CompareOrdinal(actualValue, otherValue) > 0)
                            actualValue = otherValue;

                finallyNGramm.Add(newKey, actualValue);
            }
            return finallyNGramm;
        }

        public static Dictionary<string, Dictionary<string, int>> GetValuesOfFrequences(
            int kindOfNGramm,
            List<List<string>> text)
        {
            var frequencesValue = new Dictionary<string, Dictionary<string, int>>();
            var firstIndex = CheckNGramm(kindOfNGramm);
            foreach (var sentence in text)
            {
                for (var i = firstIndex; i < sentence.Count; i++)
                {
                    string key;
                    var value = sentence[i];
                    if (CheckNGramm(kindOfNGramm) == 2)
                        key = KeyValue(kindOfNGramm, sentence[i - 1], sentence[i - 2]);
                    else
                        key = KeyValue(kindOfNGramm, sentence[i - 1], null);
                    if (!frequencesValue.ContainsKey(key))
                        frequencesValue.Add(key, new Dictionary<string, int>());
                    if (!frequencesValue[key].ContainsKey(value))
                        frequencesValue[key].Add(value, 0);
                    frequencesValue[key][value]++;
                }
            }
            return frequencesValue;
        }

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var triGramms = GetNGramms(text, 3);
            var biGramms = GetNGramms(text, 2);
            foreach (var key in triGramms.Keys)
                result.Add(key, triGramms[key]);
            foreach (var key in biGramms.Keys)
                result.Add(key, biGramms[key]);
            return result;
        }
    }
}