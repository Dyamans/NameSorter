using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
 

namespace NameSorterTests
{
    [TestClass]
    public class NameSortingTests
    {

        private NameSorter.ISorter sorter = null;        
        private String unsortedFile = null;
        private string sortedFile = null;

        [TestInitialize]
        public void TestInit()
        {
            sorter = new NameSorter.Sorting();
            unsortedFile = "./unsorted-names-list.txt";
            sortedFile = "./sorted-names-list.txt";
        }

        [TestCleanup]
        public void TestClean()
        {
            sorter = null;
            unsortedFile = string.Empty;
            sortedFile = string.Empty;
        }


        [TestMethod]
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

        [TestMethod]
        public void Test_ValidateData()
        {
            //Arrange                       
            List<Object> personData = sorter.ReadData(unsortedFile);

            //Assert
            Assert.AreEqual(11, personData.Count);
            List<object> properData = sorter.ValidateData(personData);
            Assert.AreEqual("Janet Parsons", personData[0]);
            Assert.AreEqual("Frankie Conner Ritter", personData[10]);
        }

        [TestMethod]
        public void Test_WriteData()
        {
            //Arrange
            List<Object> personData = sorter.ReadData(unsortedFile);
            List<object> properData = sorter.ValidateData(personData);
            sorter.WriteData(sortedFile, properData);

            //Assert
            Assert.AreEqual(11, personData.Count);
            Assert.AreEqual(11, properData.Count);
            Assert.AreEqual("Alvarez", ((NameSorter.Person) properData[0]).LastName); 
            Assert.AreEqual("Hunter", ((NameSorter.Person) properData[3]).FirstName);            
        }


        [TestMethod] 
        public void Test_ShowData()
        {
            //Arrange           
            List<Object> personData = sorter.ReadData(unsortedFile);
            List<object> properData = sorter.ValidateData(personData);
            sorter.WriteData(sortedFile, properData);
            sorter.ShowData(properData);

            //Assert 
            Assert.AreEqual("Shelby", ((NameSorter.Person)properData[10]).FirstName);
        }
    }
}
