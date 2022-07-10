using System;
using System.Collections;

namespace LinkedList.Model
{
    internal class LinkedList<T> : IEnumerable
    {
        public Item<T> Head { get; private set; }
        public Item<T> Tail { get; private set; }
        public int Count { get; private set; }

        public LinkedList()
        {
            Clear();
        }

        public LinkedList(T data)
        {
            SetHeadAndTail(data);
        }

        public void Add(T data)
        {
            if (Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count += 1;
            }
            else
            {
                SetHeadAndTail(data);
            }
        } 

        public void Delete(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count -= 1;
                    return;
                }

                var current = Head.Next;
                var previous = Head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count -= 1;
                        return;
                    }

                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);

            Head = item;
            Tail = item;
            Count = 1;
        }

        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                var item = new Item<T>(data);
                var current = Head.Next;

                while(current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        item.Next = current.Next;
                        current.Next = item;
                        
                        Count += 1;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                SetHeadAndTail(target);
                Add(data);
            }
        }

        public void AppendHead(T data)
        {
            var item = new Item<T>(data);

            item.Next = Head;
            Head = item;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            return $"Linked list holds {Count} elements";
        }
    }
}
