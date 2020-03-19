using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionTests {

	[TestClass]
	public class BinarySearchTreeTests {

		[TestMethod]
		public void TestAdd() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			BinarySearchTree<int> bst = new BinarySearchTree<int>(values);
			bst.Add(99);

			Assert.IsTrue(bst.SequenceEqual(values.Concat(Enumerable.Repeat(99, 1)).OrderBy(x => x)));
		}

		[TestMethod]
		public void TestRemove() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			// middle
			BinarySearchTree<int> bst = new BinarySearchTree<int>(values);
			bst.Remove(18);

			Assert.IsTrue(bst.SequenceEqual(values.Where(x => x != 18).OrderBy(x => x)));

			// least
			bst = new BinarySearchTree<int>(values);
			bst.Remove(-9);

			Assert.IsTrue(bst.SequenceEqual(values.Where(x => x != -9).OrderBy(x => x)));

			// greatest
			bst = new BinarySearchTree<int>(values);
			bst.Remove(26);

			Assert.IsTrue(bst.SequenceEqual(values.Where(x => x != 26).OrderBy(x => x)));
		}

		[TestMethod]
		public void TestContains() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };

			BinarySearchTree<int> bst = new BinarySearchTree<int>(values);			

			Assert.IsTrue(bst.Contains(18));
			Assert.IsFalse(bst.Contains(99));
		}
	}
}
