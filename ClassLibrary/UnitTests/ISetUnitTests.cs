using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
	/// <summary>
	/// Summary description for UnitTests
	/// </summary>
	[TestClass]
	public class ISetUnitTests
	{
		public ISetUnitTests()
		{
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		[TestMethod]
		public void ConstructorTest()
		{
			ISet<string> sets = new Set<string>();
			Assert.IsNotNull(sets.Count);
		}

		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion

		#region Tests for properties

		[TestMethod]
		public void CountTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			Assert.AreEqual(1, sets.Count);
		}

		[TestMethod]
		public void IsEmptyPositiveTest()
		{
			ISet<string> sets = new Set<string>();
			Assert.IsTrue(sets.IsEmpty);
		}

		[TestMethod]
		public void IsEmptyNegasativeTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			Assert.IsFalse(sets.IsEmpty);
		}

		[TestMethod]
		public void ItemsPositiveTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");			
			Assert.ReferenceEquals("item1",sets[0]);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void ItemsNegativeTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			string item = sets[1];
		}

		#endregion

		#region Tests for methods

		[TestMethod]
		public void AddPositiveTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			sets.Add("item2");
			Assert.AreEqual(2, sets.Count);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddNegativeTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			sets.Add("item1");
		}

		[TestMethod]
		public void AddWithDelegatePositiveTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			sets.Add("item22", (i,j) => i.Length == j.Length);
			Assert.AreEqual(2, sets.Count);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddWithDelegateNegativeTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			sets.Add("item2", (i, j) => i.Length == j.Length);	
		}

		[TestMethod]
		public void ExistsPositiveTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			Assert.IsTrue(sets.Exists("item1"));
		}

		[TestMethod]
		public void ExistsNegativeTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			Assert.IsFalse(sets.Exists("item2"));
		}

		[TestMethod]
		public void ExistsWithDelegatePositiveTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			Assert.IsTrue(sets.Exists(i => i.Length == 5));
		}

		[TestMethod]
		public void ExistsWithDelegateNegativeTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			Assert.IsFalse(sets.Exists(i => i.Length == 3));
		}

		[TestMethod]
		public void DeletePositiveTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			sets.Add("item2");
			sets.Delete("item1");
			Assert.AreEqual(1, sets.Count);
		}

		[TestMethod]
		public void DeleteNegativeTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			sets.Add("item2");
			sets.Delete("item3");
			Assert.AreEqual(2, sets.Count);
		}

		[TestMethod]
		public void ClearTest()
		{
			ISet<string> sets = new Set<string>();
			sets.Add("item1");
			sets.Add("item2");
			sets.Clear();
			Assert.AreEqual(0, sets.Count);
		}

		#endregion
	}
}
