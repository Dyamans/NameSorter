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
        List<object> ReadData(string fileName);
        void WriteData(string file, List<object> sortedList);
        List<object> ValidateData(List<object> listData);
        void ShowData(List<object> listData);               
    }


    /*
       The main Sorting class
       contains methods to read, write a .txt file 
       then to display the person data to console.
   */
    public class Sorting : ISorter
    {

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
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(e.Message);
            }
            return namesList;
        }

       //sort and write the data to a.txt file.
        public void WriteData(string file, List<object> sortedList)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sortedList.Sort();
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
                Console.WriteLine("Some thing went wrong:");
                Console.WriteLine(e.Message);
            }
        }
    }
}