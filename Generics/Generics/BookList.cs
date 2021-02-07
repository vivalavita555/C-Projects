using System;

namespace Generics
{
    public class BookList
    {
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public Book this[int| index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    //public class ObjectList
    //{
    //    public void Add(object value)
    //    {

    //    }

    //    public object this[int index]
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}

    public class GenericDictionary<TKey, TValue> //Always prefix your generic parameters with T
    {
        public void Add(TKey key, TValue value)
        {

        }
    }

    public class GenericList<T>
    {
        public void Add(T value)
        {

        }

        public T this [int index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
