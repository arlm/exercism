using System;
using System.Collections.Generic;

namespace Accumulate
{
    public class Generics<T>
    {
        private readonly T[] lista;

        public Generics(int capacidade)
        {
            lista = new T[capacidade];
        }

        public T Get(int index)
        {
            return lista[index];
        }

        public void Set(int index, T item)
        {
            lista[index] = item;
        }

        public IEnumerable<T> Items
        {
            get
            {
                return lista;
            }
        }
    }
}
