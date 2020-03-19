using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionTests {

	[TestClass]
	public class SinglyLinkedListTests {

		[TestMethod]
		public void TestSort() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };
			
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(values);
			list.Sort();

			Assert.IsTrue(list.SequenceEqual(values.OrderBy(x => x)));
		}

		[TestMethod]
		public void TestAddFirst() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			SinglyLinkedList<int> list = new SinglyLinkedList<int>(values);
			list.AddFirst(99);

			Assert.IsTrue(list.SequenceEqual(Enumerable.Repeat(99,1).Concat(values)));
		}

		[TestMethod]
		public void TestAddLast() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			SinglyLinkedList<int> list = new SinglyLinkedList<int>(values);
			list.AddLast(99);

			Assert.IsTrue(list.SequenceEqual(values.Concat(Enumerable.Repeat(99, 1))));
		}

		[TestMethod]
		public void TestInsert() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			// middle
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(values);
			list.Insert(3, 99);

			Assert.IsTrue(list.SequenceEqual(values.Take(3).Concat(Enumerable.Repeat(99, 1)).Concat(values.Skip(3))));

			// start
			list = new SinglyLinkedList<int>(values);
			list.Insert(0, 99);

			Assert.IsTrue(list.SequenceEqual(Enumerable.Repeat(99, 1).Concat(values)));

			// end
			list = new SinglyLinkedList<int>(values);
			list.Insert(values.Length, 99);

			Assert.IsTrue(list.SequenceEqual(values.Concat(Enumerable.Repeat(99, 1))));
		}

		[TestMethod]
		public void TestContains() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			SinglyLinkedList<int> list = new SinglyLinkedList<int>(values);

			Assert.IsTrue(list.Contains(18));
			Assert.IsFalse(list.Contains(99));
		}

		[TestMethod]
		public void TestRemove() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			// middle
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(values);
			list.Remove(18);

			Assert.IsTrue(list.SequenceEqual(values.Where(x => x != 18)));

			// start
			list = new SinglyLinkedList<int>(values);
			list.Remove(5);

			Assert.IsTrue(list.SequenceEqual(values.Where(x => x != 5)));

			// end
			list = new SinglyLinkedList<int>(values);
			list.Remove(7);

			Assert.IsTrue(list.SequenceEqual(values.Where(x => x != 7)));
		}

		[TestMethod]
		public void TestRemoveAt() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			// middle
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(values);
			list.RemoveAt(4);

			Assert.IsTrue(list.SequenceEqual(values.Where(x => x != 18)));

			// start
			list = new SinglyLinkedList<int>(values);
			list.RemoveAt(0);

			Assert.IsTrue(list.SequenceEqual(values.Where(x => x != 5)));

			// end
			list = new SinglyLinkedList<int>(values);
			list.RemoveAt(values.Length-1);

			Assert.IsTrue(list.SequenceEqual(values.Where(x => x != 7)));
		}
	}
}
