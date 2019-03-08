using System;

namespace _1_16.迭代器模式
{
    // 客户端
    internal class Program
    {
        private static void Main(string[] args)
        {

            IListCollection list = new ConcreteList();
            Iterator iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                int content = (int)iterator.GetCurrent();
                Console.WriteLine(content.ToString());
                iterator.Next();
            }

            Console.Read();
        }
    }

    // 抽象聚合类
    public interface IListCollection
    {
        Iterator GetIterator();
    }

    // 具体聚合类
    public class ConcreteList : IListCollection
    {
        private int[] collection;

        public ConcreteList()
        {
            collection = new int[] { 2, 4, 6, 8 };
        }

        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Length
        {
            get { return collection.Length; }
        }

        public int GetElement(int index)
        {
            return collection[index];
        }
    }

    // 迭代器抽象类
    public interface Iterator
    {
        bool MoveNext();

        Object GetCurrent();

        void Next();

        void Reset();
    }

    // 具体迭代器类
    public class ConcreteIterator : Iterator
    {
        // 迭代器要集合对象进行遍历操作，自然就需要引用集合对象
        private ConcreteList _list;

        private int _index;

        public ConcreteIterator(ConcreteList list)
        {
            _list = list;
            _index = 0;
        }

        public bool MoveNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            return false;
        }

        public Object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }
        }
    }
}