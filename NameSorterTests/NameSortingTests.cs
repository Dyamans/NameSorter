using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;


namespace NameSorterTests
{
    [TestFixture]
    public class NameSortingTests
    {

        private NameSorter.ISorter sorter = null;        
        private String unsortedFile = null;
        private string sortedFile = null;
        private string getPath = null;        

        [SetUp]
        public void SetUp()
        {
            sorter = new NameSorter.Sorting();
            unsortedFile = "/unsorted-names-list.txt";
            sortedFile = "/sorted-names-list.txt";
            //File.OpenRead(@"C:\ftp\inbox\test.txt");
            getPath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            sorter = null;
            unsortedFile = string.Empty;
            sortedFile = string.Empty;
        }


        [Test]
        public void Test_ReadData()
        {

            //Arrange
            String file = null;
            int actual = 0;          

            //Act
            List<object> personList = sorter.ReadData(file);           

            //Assert
            Assert.AreEqual(actual, personList.Count); 

        }        

        [Test]
        public void Test_ValidateData()
        {
            //Arrange                       
            List<Object> personData = sorter.ReadData(getPath+unsortedFile);

            //Assert
            Assert.AreEqual(11, personData.Count);
            List<object> properData = sorter.ValidateData(personData);
            Assert.AreEqual("Janet Parsons", personData[0]);
            Assert.AreEqual("Frankie Conner Ritter", personData[10]);
        }

        [Test]
        public void Test_WriteData()
        {
            //Arrange
            List<Object> personData = sorter.ReadData(getPath+unsortedFile);
            List<object> properData = sorter.ValidateData(personData);
            sorter.WriteData(getPath+sortedFile, properData);

            //Assert
            Assert.AreEqual(11, personData.Count);
            Assert.AreEqual(11, properData.Count);
            Assert.AreEqual("Alvarez", ((NameSorter.Person) properData[0]).LastName); 
            Assert.AreEqual("Hunter", ((NameSorter.Person) properData[3]).FirstName);            
        }


        [Test] 
        public void Test_ShowData()
        {
            //Arrange           
            List<Object> personData = sorter.ReadData(getPath+unsortedFile);
            List<object> properData = sorter.ValidateData(personData);
            sorter.WriteData(getPath+sortedFile, properData);
            sorter.ShowData(properData);

            //Assert 
            Assert.AreEqual("Alvarez", ((NameSorter.Person)properData[0]).LastName);
            Assert.AreEqual("Shelby", ((NameSorter.Person)properData[10]).FirstName);
            

        }
    }
}
