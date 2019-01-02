using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NameSorter
{   

    public interface ISorter
    {        
        //read data from a file
        List<object> ReadData(string fileName);
        //write data to a file
        void WriteData(string file, List<object> sortedList);
        //validate data
        List<object> ValidateData(List<object> listData);
        //show data to console
        void ShowData(List<object> listData);               
    }


    /*
       The main Sorting class implements ISorter.
       contains methods to read, write a .txt file 
       then to display the person data to console.
   */
    public class Sorting : ISorter
    {
        private string errorMsg = "Something went wrong";

        static void Main(string[] args)
        {
        }

        // Reading the data using streams from a file.
        /// <exception Exception
        public List<object> ReadData(string fileName)
        {
            List<object> list = Utilities.GetListObject();

            if (fileName != null)
            {
                try
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader.
                    string line = String.Empty;
                    using (StreamReader sr = File.OpenText(fileName))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            list.Add(line);
                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }           
            return list;
        }

        // validate person data and populate person object.
        public List<object> ValidateData(List<object> personList)
        {
            List<Object> namesList = Utilities.GetListObject();

            if (personList.Count > 0)
            {                
                try
                {
                    for (int i = 0; i < personList.Count; i++)
                    {
                        string fullName = (string)personList[i];
                        string[] fullNames = Utilities.SplitWhitespace(fullName);

                        if (fullNames.Length > 0)
                        {
                            if (fullNames.Length.Equals(2))
                            {
                                namesList.Add(new Person(fullNames[0], null, null, fullNames[1]));
                            }
                            else if (fullNames.Length.Equals(3))
                            {
                                namesList.Add(new Person(fullNames[0], fullNames[1], null, fullNames[2]));
                            }
                            else if (fullNames.Length.Equals(4))
                            {
                                namesList.Add(new Person(fullNames[0], fullNames[1], fullNames[2], fullNames[3]));
                            }
                            else
                            {
                                Console.WriteLine("This program does not support more than 4 given names");
                            }
                        }
                        else
                        {
                            Console.WriteLine(errorMsg);
                            namesList.Add(errorMsg);
                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("Something went wrong:");
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine(errorMsg);
                namesList.Add(errorMsg);
            }
            return namesList;
        }

       //sort and write the data to a .txt file.
        public void WriteData(string file, List<object> sortedList)
        {
            if (sortedList.Count > 0)
            {
                sortedList.Sort();
                try
                {
                    using (StreamWriter sw = new StreamWriter(file))
                    {

                        foreach (object obj in sortedList)
                        {
                            Person emp = (Person)obj;
                            sw.WriteLine(emp.ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be written:");
                    Console.WriteLine(e.Message);
                }
            }else
            {
                // Let the user know what went wrong.
                Console.WriteLine(errorMsg);                
            }            
        }       

        // display the person data to console.        
        public void ShowData(List<object> sortedList)
        {
            try
            {
                foreach (object obj in sortedList)
                {
                    Person emp = (Person)obj;
                    Console.WriteLine(emp.ToString());
                }
            }catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine(errorMsg+" :");
                Console.WriteLine(e.Message);
            }
        }
    }
}