using System;
using System.Collections;
using System.Collections.Generic;
// ReSharper disable All

namespace GenericApp
{
    public interface IMultiDictionary<K, V>
    {
        void Add(K key, V value);
        bool Remove(K key);
        bool Remove(K key, V value);
        void Clear();
        bool ContainsKey(K key);
        bool Contains(K key, V value);
        ICollection<K> Keys { get; }
        ICollection<V> Values { get; }
        int Count { get; }
    }


    public class MultiDictionary<K, V> : IMultiDictionary<K,V> , IEnumerable<KeyValuePair<K, IEnumerable<V>>>
    {
        private Dictionary<K, LinkedList<V>> Dic = new Dictionary<K, LinkedList<V>>();

        public ICollection<K> Keys => Dic.Keys;

        public ICollection<V> Values
        {
            get
            {
                ICollection<V> collect = new List<V>();
                foreach (var key in Dic.Keys)
                {
                    foreach (var val in Dic[key])
                    {
                        collect.Add(val);
                    }
                }
                return collect;
            }
        } 

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var key in Dic.Keys)
                {
                    count += Dic[key].Count;
                }
                return count;
            }
        }

        public void Add(K key, V value)
        {
            var containsKey = Dic.ContainsKey(key);
            if (containsKey)
            {
                Dic[key].AddLast(value);
            }
            else

            {
                Dic[key] = new LinkedList<V>();
                Dic[key].AddLast(value);
            }
        }

        public bool Remove(K key)
        {
            var containsKey = Dic.ContainsKey(key);
            if (containsKey)
            {
                Dic[key].Clear();
                return true;
            }
            return false;
        }

        public bool Remove(K key, V value)
        {
            var containsKey = Dic.ContainsKey(key);
            return (containsKey) && Dic[key].Remove(value);
        }

        public void Clear()
        {
            Dic.Clear();
        }

        public bool ContainsKey(K key)
        {
            return Dic.ContainsKey(key);
        }

        public bool Contains(K key, V value)
        {
            if (Dic.ContainsKey(key))
            {
                foreach (var val in Dic[key])
                {
                    if (Equals(val, value)) return true;
                }
            }
            return false;
        }

        public IEnumerator<KeyValuePair<K, IEnumerable<V>>> GetEnumerator()
        {
            var newList = new List<KeyValuePair<K, IEnumerable<V>>>() ;
            foreach (var item in Dic)
            {
                newList.Add(new KeyValuePair<K, IEnumerable<V>>(item.Key , item.Value));
            }
            return newList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

 

    class Program
    {
        static void Main()
        {

            MultiDictionary<int, string> test = new MultiDictionary<int, string>
            {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {1, "ich"},
                {2, "nee"},
                {3, "sun"}
            };
            Console.WriteLine("\n--Testing Remove & add--");
            Console.WriteLine("BEFORE");
            foreach (var item in test)
            {
                Console.Write(item.Key + " ");

                foreach (var value in item.Value)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
            test.Remove(1);
            Console.WriteLine("\nAFTER remove values from key 1");
            foreach (var item in test)
            {
                Console.Write(item.Key + " ");

                foreach (var value in item.Value)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
            test.Add(1,"bla");
            Console.WriteLine("\nAFTER add 'bla' to key 1");
            foreach (var item in test)
            {
                Console.Write(item.Key + " ");

                foreach (var value in item.Value)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n--Testing Count & Values-");
            foreach (var item in test)
            {
                Console.Write(item.Key + " ");

                foreach (var value in item.Value)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Counter :{0}",test.Count);
            Console.Write("Values :" );
            foreach (var item in test.Values)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            test.Clear();
            Console.WriteLine("\n--Testing Clear-");
            foreach (var item in test)
            {
                Console.Write(item);
            }

        }
    }
}
