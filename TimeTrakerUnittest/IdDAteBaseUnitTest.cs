using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTraker;
using System;


namespace TimeTrakerUnittest
{
    [TestClass]
    public class IdDAteBaseUnitTest
    {
        [TestMethod]
        public void DateStartStringTest()
        {
            // arange
            
            TasksOver tasksOver = new TasksOver(40, "ДаваймногоДней", "ага", new DateTime(2022, 5, 15, 1, 1, 58), new DateTime(2022, 5, 17, 1, 1, 58));
            string resultEX = "15/5/2022";
            // act

            string relust = tasksOver.DateStartString();

            // assert

            Assert.AreEqual(resultEX, relust);
        }

        [TestMethod]
        public void DateStartStringTestFalse()
        {
            // arange
            try
            {
                TasksOver tasksOver = new TasksOver(40, "ДаваймногоДней", "ага", new DateTime(2022, 5, 150, 1, 1, 58), new DateTime(2022, 5, 17, 1, 1, 58));
            }
            catch(System.ArgumentOutOfRangeException e)
            {              
                return;
            }

            // act

           

            // assert

            Assert.Fail("The expected exception was not thrown.");
            
        }


        [TestMethod]
        public void DurationTimeTest()
        {
            // arange

            TasksOver tasksOver = new TasksOver(40, "ДаваймногоДней", "ага", new DateTime(2022, 5, 15, 1, 1, 58), new DateTime(2022, 5, 17, 1, 1, 58));
            string resultEX = "48h, 00m, 00s";
            // act

            string relust = tasksOver.DurationTime();

            // assert

            Assert.AreEqual(resultEX, relust);
        }

        [TestMethod]
        public void DurationTimeTestFalse()
        {
            // arange

            TasksOver tasksOver = new TasksOver(40, "ДаваймногоДней", "ага", new DateTime(2022, 5, 15, 1, 1, 58), new DateTime(2022, 5, 12, 1, 1, 58));
            string resultEX = "-72h, 00m, 00s";
            // act

            string relust = tasksOver.DurationTime();

            // assert

            Assert.AreEqual(resultEX, relust);
        }


    }
}
