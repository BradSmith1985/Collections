using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/// <summary>
/// Represents a singly linked list.
/// </summary>
/// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
public class SinglyLinkedList<T> : IList<T>, IList {

	private class Node {
		public T Value;
		public Node Next;
	}

	Node _first;
	IEqualityComparer<T> _comparer;

	/// <summary>
	/// Gets or sets the element at the specified index.
	/// </summary>
	/// <param name="index">The zero-based index of the element to get or set.</param>
	/// <returns>The element at the specified index.</returns>
	/// <remarks>
	/// Retrieving the value of this property is an O(N) operation; setting the property is also an O(N) operation.
	/// </remarks>
	public T this[int index] {
		get {
			int i = 0;
			foreach (T value in this) {
				if (i == index) return value;
				i++;
			}
			throw new ArgumentOutOfRangeException(nameof(index));
		}
		set {
			int i = 0;
			Node node = _first;
			while (node != null) {
				if (i == index) {
					node.Value = value;
					return;
				}
				node = node.Next;
				i++;
			}
			throw new ArgumentOutOfRangeException(nameof(index));
		}
	}

	/// <summary>
	/// Gets the number of elements contained in the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <remarks>
	/// Retrieving the value of this property is an O(N) operation.
	/// </remarks>
	public int Count => this.Count<T>();

	bool ICollection<T>.IsReadOnly => false;

	bool IList.IsReadOnly => false;

	bool IList.IsFixedSize => false;

	object ICollection.SyncRoot => this;

	bool ICollection.IsSynchronized => false;

	object IList.this[int index] { get => this[index]; set => this[index] = (T)value; }

	/// <summary>
	/// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class 
	/// that is empty and uses the default equality comparer.
	/// </summary>
	public SinglyLinkedList() : this(null) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class 
	/// that is empty and uses the specified equality comparer.
	/// </summary>
	/// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing values in the set, or null to use the default <see cref="EqualityComparer{T}"/> implementation for the set type.</param>
	public SinglyLinkedList(IEqualityComparer<T> comparer) {
		_comparer = comparer ?? EqualityComparer<T>.Default;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class 
	/// that contains elements copied from the specified collection and uses the 
	/// specified equality comparer.
	/// </summary>
	/// <param name="items">The collection whose elements are copied to the new list.</param>
	/// <param name="comparer">The <see cref="IEqualityComparer{T}"/> implementation to use when comparing values in the set, or null to use the default <see cref="EqualityComparer{T}"/> implementation for the set type.</param>
	public SinglyLinkedList(IEnumerable<T> collection, IEqualityComparer<T> comparer = null) : this(comparer) {
		if (collection == null) throw new ArgumentNullException(nameof(collection));
		AddRange(collection);
	}

	void ICollection<T>.Add(T item) {
		AddLast(item);
	}

	/// <summary>
	/// Adds an object to the end of the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <param name="item">The object to be added to the end of the <see cref="SinglyLinkedList{T}"/>. The value can be null for reference types.</param>
	/// <remarks>
	/// This method is an O(N) operation.
	/// </remarks>
	public void AddLast(T item) {
		Node node = _first;
		while (node != null) {
			if (node.Next == null) {
				node.Next = new Node() { Value = item };
				return;
			}
			node = node.Next;
		}

		_first = new Node() { Value = item };
	}

	/// <summary>
	/// Adds an object to the start of the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <param name="item">The object to be added to the start of the <see cref="SinglyLinkedList{T}"/>. The value can be null for reference types.</param>
	/// <remarks>
	/// This method is an O(1) operation.
	/// </remarks>
	public void AddFirst(T item) {
		_first = new Node() { Value = item, Next = _first };
	}

	/// <summary>
	/// Adds the elements of the specified collection to the end of the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <param name="items"></param>
	/// <remarks>
	/// This method is an O(N) operation.
	/// </remarks>
	public void AddRange(IEnumerable<T> collection) {
		Node last = _first;
		while (last != null) {
			if (last.Next != null) {
				last = last.Next;
			}
			else {
				break;
			}
		}

		foreach (T value in collection) {
			if (last != null) {
				last.Next = new Node() { Value = value };
				last = last.Next;
			}
			else {
				last = _first = new Node() { Value = value };
			}
		}
	}

	/// <summary>
	/// Removes all elements from the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <remarks>
	/// This method is an O(1) operation.
	/// </remarks>
	public void Clear() {
		_first = null;
	}

	/// <summary>
	/// Determines whether an element is in the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <param name="item">The object to locate in the <see cref="SinglyLinkedList{T}"/>. The value can be null for reference types.</param>
	/// <returns></returns>
	/// <remarks>
	/// This method is an O(N) operation.
	/// </remarks>
	public bool Contains(T item) {
		return this.Contains<T>(item);
	}

	/// <summary>
	/// Copies the entire <see cref="SinglyLinkedList{T}"/> to a compatible 
	/// one-dimensional array, starting at the specified index of the target 
	/// array.
	/// </summary>
	/// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from List<T>. The <see cref="Array"/> must have zero-based indexing.</param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	public void CopyTo(T[] array, int arrayIndex) {
		foreach (T value in this) {
			array[arrayIndex++] = value;
		}
	}

	/// <summary>
	/// Returns an enumerator that iterates through the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <returns></returns>
	public IEnumerator<T> GetEnumerator() {
		Node node = _first;
		while (node != null) {
			yield return node.Value;
			node = node.Next;
		}
	}

	/// <summary>
	/// Searches for the specified object and returns the zero-based index of the 
	/// first occurrence within the entire <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <param name="item">The object to locate in the <see cref="SinglyLinkedList{T}"/>. The value can be null for reference types.</param>
	/// <returns></returns>
	/// <remarks>
	/// This method is an O(N) operation.
	/// </remarks>
	public int IndexOf(T item) {
		int i = 0;
		foreach (T value in this) {
			if (_comparer.Equals(item, value)) return i;
			i++;
		}

		return -1;
	}

	/// <summary>
	/// Inserts an element into the <see cref="SinglyLinkedList{T}"/> at the specified index.
	/// </summary>
	/// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
	/// <param name="item">The object to insert. The value can be null for reference types.</param>
	/// <remarks>
	/// This method is an O(N) operation.
	/// </remarks>
	public void Insert(int index, T item) {
		int i = 0;
		Node curr = _first;
		Node prev = null;

		while (curr != null) {
			if (i == index) {
				// insert
				if (prev != null) {
					prev.Next = new Node() { Value = item, Next = curr };
				}
				else {
					_first = new Node() { Value = item, Next = curr };
				}
				return;
			}
			prev = curr;
			curr = curr.Next;
			i++;
		}

		if (i == 0) {
			// empty
			_first = new Node() { Value = item };
		}
		else if (i == index) {
			// append
			if (prev != null)
				prev.Next = new Node() { Value = item };
			else
				_first = new Node() { Value = item };
		}
		else {
			throw new ArgumentOutOfRangeException(nameof(index));
		}
	}

	/// <summary>
	/// Removes the first occurrence of a specific object from the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <param name="item">The object to remove from the <see cref="SinglyLinkedList{T}"/>. The value can be null for reference types.</param>
	/// <returns></returns>
	/// <remarks>
	/// This method is an O(N) operation.
	/// </remarks>
	public bool Remove(T item) {
		Node curr = _first;
		Node prev = null;

		while (curr != null) {
			if (_comparer.Equals(curr.Value, item)) {
				if (prev != null) {
					prev.Next = curr.Next;
				}
				else {
					_first = curr.Next;
				}
				return true;
			}
			prev = curr;
			curr = curr.Next;
		}

		return false;
	}

	/// <summary>
	/// Removes the element at the specified index of the <see cref="SinglyLinkedList{T}"/>.
	/// </summary>
	/// <param name="index">The zero-based index of the element to remove.</param>
	/// <remarks>
	/// This method is an O(N) operation.
	/// </remarks>
	public void RemoveAt(int index) {
		int i = 0;
		Node curr = _first;
		Node prev = null;

		while (curr != null) {
			if (i == index) {
				if (prev != null) {
					prev.Next = curr.Next;
				}
				else {
					_first = curr.Next;
				}
				return;
			}
			prev = curr;
			curr = curr.Next;
			i++;
		}

		throw new ArgumentOutOfRangeException(nameof(index));
	}

	IEnumerator IEnumerable.GetEnumerator() {
		return GetEnumerator();
	}

	int IList.Add(object value) {
		AddLast((T)value);
		return Count - 1;
	}

	bool IList.Contains(object value) {
		return (value is T) && Contains((T)value);
	}

	int IList.IndexOf(object value) {
		return IndexOf((T)value);
	}

	void IList.Insert(int index, object value) {
		Insert(index, (T)value);
	}

	void IList.Remove(object value) {
		Remove((T)value);
	}

	void ICollection.CopyTo(Array array, int index) {
		foreach (T value in this) {
			array.SetValue(value, index++);
		}
	}

	/// <summary>
	/// Sorts the elements in the entire <see cref="SinglyLinkedList{T}"/> using the specified comparer.
	/// </summary>
	/// <param name="comparer">The <see cref="IComparer{T}"/> implementation to use when comparing elements, or null to use <see cref="Comparer{T}.Default"/>.</param>
	/// <remarks>
	/// This method uses the merge sort algorithm and is an O(N log N) operation.
	/// </remarks>
	public void Sort(IComparer<T> comparer = null) {
		if (comparer == null) comparer = Comparer<T>.Default;

		Node head = _first;
		MergeSort(ref head, comparer);
		_first = head;
	}

	#region Helper Methods

	private void MergeSort(ref Node headRef, IComparer<T> comparer) {
		Node head = headRef;
		Node a = null;
		Node b = null;

		// Base case -- length 0 or 1
		if ((head == null) || (head.Next == null)) return;

		// Split head into 'a' and 'b' sublists
		FrontBackSplit(head, ref a, ref b);

		// Recursively sort the sublists
		MergeSort(ref a, comparer);
		MergeSort(ref b, comparer);

		// answer = merge the two sorted lists together
		headRef = SortedMerge(a, b, comparer);
	}

	private Node SortedMerge(Node a, Node b, IComparer<T> comparer) {
		Node result = null;

		/* Base cases */
		if (a == null)
			return b;
		else if (b == null)
			return a;

		/* Pick either a or b, and recur */
		if (comparer.Compare(a.Value, b.Value) <= 0) {
			result = a;
			result.Next = SortedMerge(a.Next, b, comparer);
		}
		else {
			result = b;
			result.Next = SortedMerge(a, b.Next, comparer);
		}
		return result;
	}

	private void FrontBackSplit(Node source, ref Node frontRef, ref Node backRef) {
		Node slow = source;
		Node fast = source.Next;

		/* Advance 'fast' two nodes, and advance 'slow' one node */
		while (fast != null) {
			fast = fast.Next;
			if (fast != null) {
				slow = slow.Next;
				fast = fast.Next;
			}
		}

		/* 'slow' is before the midpoint in the list, so split it in two at that point. */
		frontRef = source;
		backRef = slow.Next;
		slow.Next = null;
	}

	#endregion
}