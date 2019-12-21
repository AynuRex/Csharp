//Copyright gooseInc©
using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp2
{ 
    delegate KeyValuePair<Tkey,TValue> GenerateElement<Tkey,TValue>(int j);
    class TestCollections<Tkey, TValue>
    {
        System.Collections.Generic.List<Tkey> testLisTkey;
        System.Collections.Generic.List<string> testListStr;
        System.Collections.Generic.Dictionary<Tkey, TValue> tesTkeyDictionary;
        System.Collections.Generic.Dictionary<string, TValue> testStrDictionary;
        GenerateElement<Tkey, TValue> generate; 

        public TestCollections(int lisTkeyAm, int listStrAm, int tesTkeyDictionaryAm, int testStrDictionaryAm, GenerateElement<Tkey, TValue> generate2)
        {
            testLisTkey = new List<Tkey>();
            testListStr = new List<string>();
            tesTkeyDictionary = new Dictionary<Tkey, TValue>();
            testStrDictionary = new Dictionary<string, TValue>();
            for (int i = 0; i < lisTkeyAm; i++)
                testLisTkey.Add(generate2(i).Key);
            for (int i = 0; i < listStrAm; i++)
                testListStr.Add(i.ToString());
            for (int i = 0; i < tesTkeyDictionaryAm; i++)
                tesTkeyDictionary.Add(generate2(i).Key,generate2(i).Value);
            for (int i = 0; i < testStrDictionaryAm; i++)
                testStrDictionary.Add(i.ToString(), generate2(i).Value);
            generate = generate2;
        }
        public void countTime(int i, GenerateElement<Tkey, TValue> method)
        {
            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            Tkey someEdKey = method(i).Key;
            SW.Start();
            testLisTkey.Contains(someEdKey);
            SW.Stop();
            Console.WriteLine("Duration of search of all in List<Team>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Reset();
            SW.Start();
            testListStr.Contains(someEdKey.ToString());
            SW.Stop();
            Console.WriteLine("Duration of search of all in List<String>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Reset();
            TValue tempres=method(i).Value;
            SW.Start();
            tesTkeyDictionary.ContainsKey(someEdKey);
            SW.Stop();
            Console.WriteLine("Duration of search of all in Dictionary<Team, ResearchTeam>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Restart();
            testStrDictionary.ContainsKey(someEdKey.ToString());
            SW.Stop();
            Console.WriteLine("Duration of search of all in Dictionary<String, ReseachTeam>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Restart();
            tesTkeyDictionary.ContainsValue(tempres);
            SW.Stop();
            Console.WriteLine("Duration of search of all in Dictionary<Team, ReseachTeam>:" + SW.ElapsedMilliseconds + " Miliseconds");

        }
    }
}
