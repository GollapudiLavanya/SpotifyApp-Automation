/*
 * project = DBAutomation
 * Author = Lavanya Gollapudi
 * Created Date = 20/08/2021
 */


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Text;


namespace DataBaseAutomation
{
    [TestClass]
    public class UnitTest1
    {
        SpotifyAutomation method = new SpotifyAutomation();

        [Priority(1)]
        [TestMethod]
        public void Insert1()
        {
            int expected = 1;
            var actual = method.InsertRecord_InDatabase();
            Assert.AreEqual(expected, actual);
        }


        [Priority(2)]
        [TestMethod]
        public void Retrieve1()
        {
            int expected = 31;
            var actual = method.retriveData();
            Assert.AreEqual(expected,actual);
        }
        [Priority(3)]
        [TestMethod]
        public void Updation()
        {
            int expected = 1;
            SpotifyTable table = new SpotifyTable();
            var actual = method.Updatingtable(table);
            Assert.AreEqual(expected, actual);
        }
        [Priority(4)]

        [TestMethod]
        public void Deletion()
        {
            int expected = 1;
            SpotifyTable table = new SpotifyTable();
            var actual = method.Delete(table);
            Assert.AreEqual(expected, actual);
        }



    }
}