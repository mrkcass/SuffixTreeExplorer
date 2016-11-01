/* Edge.cs
 * To Do: add comments
 * I need a better hashing system for large data sets.
 *
 *
 * This is a suffix tree algorithm for .NET written in C#. Feel free to use it as you please!
 * This code was derived from Mark Nelson's article located here: http://marknelson.us/1996/08/01/suffix-trees/
 * Have Fun
 *
 * Zikomo A. Fields 2008
 *

 *
 */

using System.Collections.Generic;

namespace ThirdParty_SuffixTree
{
   public struct Edge
   {
      public int indexOfFirstCharacter;
      public int indexOfLastCharacter;
      public int startNode;
      public int endNode;

      public const int HASH_TABLE_SIZE = 306785407;

      public Edge(int startNode)
      {
         this.startNode = -1;
         this.indexOfFirstCharacter = 0;
         this.indexOfLastCharacter = 0;
         this.endNode = 0;
      }

      public Edge(List<int> theString, int indexOfFirstCharacter, int indexOfLastCharacter, int parentNode)
      {
         this.indexOfFirstCharacter = indexOfFirstCharacter;
         this.indexOfLastCharacter = indexOfLastCharacter;
         this.startNode = parentNode;
         this.endNode = Node.Count++;
      }

      public Edge(Edge edge)
      {
         this.startNode = edge.startNode;
         this.endNode = edge.endNode;
         this.indexOfFirstCharacter = edge.indexOfFirstCharacter;
         this.indexOfLastCharacter = edge.indexOfLastCharacter;
      }

      public void Copy(Edge edge)
      {
         this.startNode = edge.startNode;
         this.endNode = edge.endNode;
         this.indexOfFirstCharacter = edge.indexOfFirstCharacter;
         this.indexOfLastCharacter = edge.indexOfLastCharacter;
      }

      public void Insert(List<int> theString, Dictionary<int, Edge> Edges)
      {
         int i = Hash(this.startNode, theString[this.indexOfFirstCharacter]);
         if (!Edges.ContainsKey(i))
         {
            Edges.Add(i, new Edge(-1));
         }
         while (Edges[i].startNode != -1)
         {
            i = ++i % HASH_TABLE_SIZE;
            if (!Edges.ContainsKey(i))
            {
               Edges.Add(i, new Edge(-1));
            }
         }
         Edges[i] = this;
      }

      public void Remove(List<int> theString, Dictionary<int, Edge> Edges)
      {
         int i = Hash(this.startNode, theString[this.indexOfFirstCharacter]);
         while (Edges[i].startNode != this.startNode || Edges[i].indexOfFirstCharacter != this.indexOfFirstCharacter)
         {
            i = ++i % HASH_TABLE_SIZE;
         }
         for (;;)
         {
            Edge tempEdge = Edges[i];
            tempEdge.startNode = -1;
            Edges[i] = tempEdge;
            int j = i;
            for (;;)
            {
               i = ++i % HASH_TABLE_SIZE;
               if (!Edges.ContainsKey(i))
               {
                  Edges.Add(i, new Edge(-1));
               }
               if (Edges[i].startNode == -1)
               {
                  return;
               }

               int r = Hash(Edges[i].startNode, theString[Edges[i].indexOfFirstCharacter]);
               if (i >= r && r > j)
               {
                  continue;
               }
               if (r > j && j > i)
               {
                  continue;
               }
               if (j > i && i >= r)
               {
                  continue;
               }
               break;
            }
            Edges[j].Copy(Edges[i]);
         }
      }

      public int SplitEdge(Suffix s, List<int> theString, Dictionary<int, Edge> edges, Dictionary<int, Node> nodes)
      {
         Remove(theString, edges);
         Edge newEdge = new Edge(theString, 
                                 this.indexOfFirstCharacter,
                                 this.indexOfFirstCharacter + s.indexOfLastCharacter - s.indexOfFirstCharacter,
                                 s.originNode);
         newEdge.Insert(theString, edges);
         if (nodes.ContainsKey(newEdge.endNode))
         {
            nodes[newEdge.endNode].suffixNode = s.originNode;
         }
         else
         {
            Node newNode = new Node();
            newNode.suffixNode = s.originNode;
            nodes.Add(newEdge.endNode, newNode);
         }

         this.indexOfFirstCharacter += s.indexOfLastCharacter - s.indexOfFirstCharacter + 1;
         this.startNode = newEdge.endNode;
         this.Insert(theString, edges);
         nodes[newEdge.startNode].addChild(nodes[newEdge.endNode]);
         return newEdge.endNode;
      }

      public static Edge Find(List<int> theString, Dictionary<int, Edge> edges, int node, int c)
      {
         int i = Hash(node, c);
         for (;;)
         {
            if (!edges.ContainsKey(i))
            {
               edges.Add(i, new Edge(-1));
            }
            if (edges[i].startNode == node)
            {
               if (c == theString[edges[i].indexOfFirstCharacter])
               {
                  return edges[i];
               }
            }
            if (edges[i].startNode == -1)
            {
               return edges[i];
            }
            i = ++i % HASH_TABLE_SIZE;
         }
      }

      public static int Hash(int node, int c)
      {
         long rtnValue = ((node << 32) + (long)c) % (long)HASH_TABLE_SIZE;
         return (int)rtnValue;
      }
   }
}