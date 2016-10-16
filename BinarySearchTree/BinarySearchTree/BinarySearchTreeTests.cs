using NUnit.Framework;

namespace MyPrivateBinarySearchTree
{
    /// <summary>
    /// Test class for BinarySearchTree<T> class
    /// </summary>
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void InsertSimpleTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>();
            Assert.IsTrue(bst.Insert("hello"));
        }

        [Test]
        public void ContainsSimpleTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("dolly");
            Assert.IsTrue(bst.Contains("dolly"));
        }

        [Test]
        public void RemoveSimpleTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("dolly");
            Assert.IsTrue(bst.Remove("dolly"));
        }

        [Test]
        public void RemoveAndContainsSimpleTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("hello");
            Assert.IsTrue(bst.Remove("hello"));
            Assert.IsFalse(bst.Contains("hello"));
        }

        [Test]
        public void RemoveAndContainsAndInsertSimpleTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(1);
            Assert.IsTrue(bst.Remove(1));
            Assert.IsTrue(bst.Insert(2));
            Assert.IsTrue(bst.Contains(2));
        }

        [Test]
        public void InsertTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            Assert.IsTrue(bst.Insert(5));
            Assert.IsTrue(bst.Insert(3));
            Assert.IsTrue(bst.Insert(7));
            Assert.IsTrue(bst.Insert(1));
            Assert.IsTrue(bst.Insert(9));
            Assert.IsTrue(bst.Insert(12));
            Assert.IsTrue(bst.Insert(4));
        }

        [Test]
        public void FalseInsertTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(5);
            Assert.IsFalse(bst.Insert(5));
        }

        [Test]
        public void RemoveAndContainsAndInsertTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>(1);
            Assert.IsTrue(bst.Remove(1));
            Assert.IsFalse(bst.Remove(1));
            Assert.IsTrue(bst.Insert(2));
            Assert.IsFalse(bst.Contains(1));
            Assert.IsTrue(bst.Contains(2));
            Assert.IsFalse(bst.Insert(2));
        }

        [Test]
        public void EnumeratorSimpleTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("hello");
            bst.Insert("dolly");
            bst.Insert("louis");
            bst.Insert("armstrong");
            foreach (string word in bst)
            {
                if (word.Length > 5)
                {
                    Assert.IsTrue(word == "armstrong");    
                }
            }
        }

        [Test]
        public void AnotherEnumeratorSimpleTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>("peaceandlove");
            bst.Insert("blackandwhite");
            bst.Insert("drugsanddesease");
            bst.Insert("waterandfire");
            foreach (string word in bst)
            {
                word.Remove(0, 5);
                word.Remove(3, word.Length - 3);
                Assert.IsTrue(word == "and");
            }
        }
    }
}
