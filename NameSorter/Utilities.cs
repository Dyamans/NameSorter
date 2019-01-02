using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    public class Utilities
    {
        // split the person data.
        public static string[] SplitWhitespace(string input)
        {
            char[] whitespace = new char[] { ' ', '\t' };
            return input.Split(whitespace);
        }

        // validate the string array
        public static bool IsNullOrEmpty(string[] myStringArray)
        {
            return myStringArray == null || myStringArray.Length < 1;
        }

        //returns the list object.
        public static List<Object> GetListObject()
        {
            return new List<Object>();
        }
    }
}
