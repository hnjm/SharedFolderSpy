#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Fesslersoft.SharedFolderSpy.Controls.Ribbon.Classes
{
    /// <summary>
    ///     There is no HashSet&lt;T&gt; available in .net 2.0.
    /// </summary>
    /// <typeparam name="T">Der Typ des Sets</typeparam>
    [Serializable]
    public class Set<T> : ICollection<T>, IEnumerable<T>, IEnumerable
    {
        private readonly Dictionary<T, object> _items = new Dictionary<T, object>();

        #region ICollection<T>

        public void Add(T item)
        {
            if (item == null)
                return;
            _items[item] = null;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            if (item == null)
                return false;
            return _items.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.Keys.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            if (item == null)
                return false;
            return _items.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }

        #endregion

        public void AddRange(IEnumerable<T> items)
        {
            if (items == null)
                return;
            foreach (var item in items)
                Add(item);
        }

        public T[] ToArray()
        {
            var array = new T[_items.Count];
            CopyTo(array, 0);
            return array;
        }
    }
}