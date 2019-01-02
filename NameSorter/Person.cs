using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    /*
     *  <summary>
        The main Person class
        Contains properties FirstName, MiddleName1, MiddleName2 and LastName
        </summary>
        <remarks>
          This class initializes the properties through constructor.
        </remarks>
    */
    public class Person : IComparable
    {
        // initialise the properties by Sorting class.
        public Person(string firstname, string middlename1, string middlename2, string lastname)
        {
            FirstName = firstname;
            MiddleName1 = middlename1;
            MiddleName2 = middlename2;
            LastName = lastname;
        }

        // <value>SET and Gets the value of FirstName.</value>
        public string FirstName { get; set; }

        // <value>SET and Gets the value of MiddleName1.</value>
        public string MiddleName1 { get; set; }

        // <value>SET and Gets the value of MiddleName2.</value>
        public string MiddleName2 { get; set; }

        // <value>SET and Gets the value of LastName.</value>
        public string LastName { get; set; }


        //over
        public override string ToString()
        {
            return FirstName+" "+MiddleName1+" "+MiddleName2+" "+LastName;
        }

        // compares lastname property and returns the int result
        //<returns>
        // returns int value.
        //</returns>
        public int CompareTo(object obj)
        {
            Person compare = (Person)obj;
            int result = this.LastName.CompareTo(compare.LastName);
            if (result == 0)
                result = this.LastName.CompareTo(compare.LastName);
            return result;
        }
    }
}
