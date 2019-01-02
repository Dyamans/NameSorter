using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace NameSorterTests
{
    [TestClass]
    public class NameSortingTests
    {
        [TestMethod]
        public void Test_ReadData()
        {

            //Arrange
            String file = null;
            int actual = 0;
            

            NameSorter.ISorter sorter = new NameSorter.Sorting();

            //Act
            List<object> personList = sorter.ReadData(file);           

            //Assert
            Assert.AreEqual(actual, personList.Count); 

        }

        [TestMethod]
        public void Test_ReadData1()
        {

            //Arrange
            String file = "./unsorted-names-list.txt";
            int actual = 11;


            NameSorter.ISorter sorter = new NameSorter.Sorting();

            //Act
            List<object> personList = sorter.ReadData(file);

            //Assert
            Assert.AreEqual(actual, personList.Count);
            Assert.AreNotEqual(0, personList.Count);

        }

        [TestMethod]
        public void Test_ShowData()
        {
            //Arrange
            String unsortedFile = "./unsorted-names-list.txt";
            string sortedFile = "./sorted-names-list.txt";

            NameSorter.ISorter sorter = new NameSorter.Sorting();
            List<Object> personData = sorter.ReadData(unsortedFile);
            //Assert
            Assert.AreEqual(11, personData.Count);
            List<object> properData = sorter.ValidateData(personData);            
            sorter.WriteData(sortedFile, properData);
            sorter.ShowData(properData);
        }
    }
}
