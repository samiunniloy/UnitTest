using MyStackApp;
using MyStackApp.Models;
using NUnit.Framework;
namespace MyStackAppTest
{
    [TestFixture]
    public class MyStackTest
    {   
        [Test]
        public async Task IsEmpty()
        {
            var stack = new MyStackApp<int>();
            Assert.IsTrue(stack.IsEmpty());

        }

        [Test]
        public async Task PushOneItem()
        {
            var stack = new MyStackApp<int>();
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Size());
        }

        [Test]
        public async Task PushThreeItem()
        {
            var stack = new MyStackApp<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(3, stack.Size());
        }
        

        [Test]
        public async Task PushThreePopOne()
        {
            var stack = new MyStackApp<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(2, stack.Size());
        }
        
        [Test]
        public async Task PushOnePopOne()
        {
            var stack = new MyStackApp<mango>();
            var obj = new mango(2,"Langhra");
            stack.Push(obj);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }
        
        [Test]
        public async Task PushOnePopOneWithRemember()
        {
            var stack = new MyStackApp<mango>();
            var obj = new mango(10, "Fozli"); 
            stack.Push(obj);
            var retObj = await stack.Pop(true);
            Assert.AreEqual(obj, retObj);
        }
        
        [Test]
        public async Task PushThreePopThreeWithRemember()
        {
            var stack = new MyStackApp<mango>();
            List<mango> myList = new List<mango>();
            for (int i = 0; i < 3; i++)
            {
                mango obj = new mango(i, "fojli");
                stack.Push(obj);
                myList.Add(obj);
            }
            for(int i = 2; i >= 0; i--)
            {
                var retObj = await stack.Pop(true);
                Assert.AreEqual(myList[i], retObj);
            }
        }

        [Test]
        public  async Task PopStackCheckUnderflow()
        {
            var stack = new MyStackApp<mango>();
            var ex = Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.That(ex.Message, Is.EqualTo("Stack underflow"));
        }

        [Test]
        public async Task PushOneCheckEmpty()
        {
            var stack = new MyStackApp<mango>();
            var obj = new mango(2, "Langhra");
            stack.Push(obj);
            Assert.IsTrue(!stack.IsEmpty());
        }
        [Test]
        public  void PushOneTopOneWithRemember()
        {
            var stack = new MyStackApp<mango>();
            var obj = new mango(10, "Fozli");
            stack.Push(obj);
            var retObj = stack.Top();
            Assert.AreEqual(obj, retObj);
        }

        [Test]
        public void CallTopCheckUnderflow()
        {
            var stack = new MyStackApp<mango>();
            var ex = Assert.Throws<InvalidOperationException>(() => stack.Top());
            Assert.That(ex.Message, Is.EqualTo("Stack underflow"));
        }
    }
}