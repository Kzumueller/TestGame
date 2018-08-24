using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//realizes a slightly shoddy priority queue by adding elements to a list and sorting it after every insertion
public class PriorityQueue<T> : List<T> {

    public T Dequeue() {
        var element = this[0];
        RemoveAt(0);

        return element;
    }

    public void Enqueue(T element) {
        Add(element);
        Sort(); //ouch
    }
}
