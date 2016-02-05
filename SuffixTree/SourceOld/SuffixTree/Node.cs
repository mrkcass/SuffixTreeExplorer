﻿/* Node.cs
 * To Do: add comments
 * 
 * 
 * This is a suffix tree algorithm for .NET written in C#. Feel free to use it as you please!
 * This code was derived from Mark Nelson's article located here: http://marknelson.us/1996/08/01/suffix-trees/
 * Have Fun 
 * 
 * Zikomo A. Fields 2008
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class Node
    {
        public int suffixNode;

        public Node()
        {
            suffixNode = -1;
        }
        public Node(Node node)
        {
            this.suffixNode = node.suffixNode;
        }
        public static int Count = 1; 
    }
}
