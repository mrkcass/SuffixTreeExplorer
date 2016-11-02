/* Node.cs
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

using System.Collections.Generic;

namespace ThirdParty_SuffixTree
{
   public class Node
   {
      public int suffixNode;

      public Node()
      {
         suffixNode = -1;

      }

      public Node(int idx)
      {
         suffixNode = idx;

      }

      public void addChild(Node child)
      {
            //children.Add(child.suffixNode, child);
            children.Add(child.suffixNode, child);
        }

      public SortedDictionary<int,Node>.Enumerator childIterator()
      {
         return children.GetEnumerator();
      }

      public int childCount()
      {
         return children.Count;
      }

      SortedDictionary<int, Node> children = new SortedDictionary<int, Node>();
      public static int Count = 1;
   }
}