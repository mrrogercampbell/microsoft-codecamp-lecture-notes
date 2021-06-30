using System;
using System.Collections.Generic;

namespace WorkingWithList
{
    public class ListClass
    {
        public ListClass()
        {
        }

        public List<string> AddToListMethod(string[] arr)
        {
            List<string> createdList = new List<string>();

            foreach (string item in arr)
            {
                createdList.Add(item);
            }

            return createdList;
        }
    }
}
