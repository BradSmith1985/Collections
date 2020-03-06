using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionTests {

	[TestClass]
	public class UnitTests {

		[TestMethod]
		public void TestSort() {
			int[] values = new int[] { 5, 25, 1, -9, 18, 26, 25, 2, 9, 3, 7 };
			
			SinglyLinkedList<int> list = new SinglyLinkedList<int>(values);
			list.Sort();

			Assert.IsTrue(list.SequenceEqual(values.OrderBy(x => x)));
		}
	}
}
