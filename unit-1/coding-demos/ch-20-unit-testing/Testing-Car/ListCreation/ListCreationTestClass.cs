using System;
using System.Collections.Generic;

namespace ListCreation
{
    public class ListCreationTest
    {

        public ListCreationTest()
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
