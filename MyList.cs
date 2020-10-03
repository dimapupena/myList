using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Text;

namespace lab_1__sem_5_
{
    class MyList<T> : IList<T>
    {
        private T[] items = new T[0];
        private int size = 0;
        //    private int size

        private delegate void ListHalper(object sender, ListEventArgs e);
        private event ListHalper eventHelper;

        public MyList()
        {
            eventHelper += DisplayMessage;
         
        }

        public MyList(IEnumerable<T> items)
        {
            eventHelper += DisplayMessage;
            this.AddRange(items);
        }

        private static void DisplayMessage(object sender, ListEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public T this[int index] {
            get
            {
                if (index <= size - 1)
                {
                    return items[index];
                }
                else 
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index <= size)
                {
                    items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            } 
        }

        public int Count => size;
        public bool IsReadOnly => items.IsReadOnly;

        public void Add(T item)
        {
            T[] copyArr = new T[size+1];
            Array.Copy(items, copyArr, size);
            items = copyArr;
            items[size] = item;
            size += 1;
            eventHelper.Invoke(this, new ListEventArgs("Element added\n"));
        }

        public void AddRange(IEnumerable<T> list)
        {
            foreach (var item in list)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            if (size != 0)
            {
                items = new T[0];
                size = 0;
                eventHelper.Invoke(this, new ListEventArgs("List is cleared\n"));
            }
            else 
            {
                throw new ArgumentNullException();
            }
        }

        public bool Contains(T item)
        {
            if (item is null)
            {
                if (Array.Find(items, element => element.Equals(item)) != null)
                {
                    eventHelper.Invoke(this, new ListEventArgs("List find this element\n"));
                    return true;
                }
                else
                {
                    eventHelper.Invoke(this, new ListEventArgs("List can`t find element\n"));
                    return false;
                }
            }
            else 
            {
                throw new ArgumentNullException();
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            try
            {
                Array.Copy(items, 0, array, arrayIndex, size);
                eventHelper.Invoke(this, new ListEventArgs("DONE\n"));
            }
            catch
            {
                Console.WriteLine();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
            {
                yield return item;
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(items, item);
        }

        public void Insert(int index, T item)
        {
            if (index < size)
            {
                if (index < 0 || index >= size)
                    throw new IndexOutOfRangeException();
                if (item == null)
                    throw new ArgumentNullException();
                int j = 0;
                T[] copy = new T[Count + 1];
                for (int i = 0; i < Count + 1; i++)
                {
                    if (i == index)
                    {
                        copy[i] = item;
                    }
                    else
                    {
                        copy[i] = items[j];
                        j++;
                    }
                }

                Array.Copy(copy, items, size);
                size += 1;
                eventHelper.Invoke(this, new ListEventArgs("Insert was done\n"));
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                int index = IndexOf(item);
                size--;
                if (index < size && index != null)
                {
                    Array.Copy(items, index + 1, items, index, size);
                    items[size] = default(T);
                }
                eventHelper.Invoke(this, new ListEventArgs("removed\n"));
                return true;
             }
            else
            {
                eventHelper.Invoke(this, new ListEventArgs("this arr don`t have such item\n"));
                return false;
            }
        }

        public void RemoveAt(int index)
        {
           if (index < size && index != null)
           {

                T[] copy = new T[size - 1];
                var itemToDelete = items[index];
                int j = 0;

                for (int i = 0; i < size; i++)
                {
                    if (i != index)
                    {
                        copy[j] = items[i];
                        j++;
                    }

                }
                items = copy;
                eventHelper.Invoke(this, new ListEventArgs("removed\n"));
            }
            else
            {
                eventHelper.Invoke(this, new ListEventArgs("this arr don`t have such item\n"));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public class ListEventArgs
    {
        public string Message { get; }

        public ListEventArgs(string mes)
        {
            Message = mes;
        }
    }
}