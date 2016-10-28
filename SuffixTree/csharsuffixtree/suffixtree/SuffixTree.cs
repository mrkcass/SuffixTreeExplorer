/* SuffixTree.cs
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
using System.IO;

namespace ThirdParty_SuffixTree
{
   public class SuffixTree
   {
      public List<int> theString;
      public Dictionary<int, Edge> Edges = null;
      public Dictionary<int, Node> Nodes = null;

      public SuffixTree(List<int> input)
      {
         theString = input;
         Nodes = new Dictionary<int, Node>();
         Edges = new Dictionary<int, Edge>();
      }

      public void BuildTree()
      {
         Suffix active = new Suffix(theString, Edges, 0, 0, -1);
         for (int i = 0; i <= theString.Count - 1; i++)
         {
            AddPrefix(active, i);
         }
      }

      public void Save(BinaryWriter writer, SuffixTree tree)
      {
         writer.Write(Edges.Count);
         writer.Write(theString.Count);
         //todo: mcass 10/27/2016
         //writer.Write(SuffixTree.theString);
         foreach (KeyValuePair<int, Edge> edgePair in Edges)
         {
            writer.Write(edgePair.Key);
            writer.Write(edgePair.Value.endNode);
            writer.Write(edgePair.Value.startNode);
            writer.Write(edgePair.Value.indexOfFirstCharacter);
            writer.Write(edgePair.Value.indexOfLastCharacter);
         }
      }

      public void Save(Stream stream, SuffixTree tree)
      {
         using (BinaryWriter writer = new BinaryWriter(stream))
         {
            Save(writer, tree);
         }
      }

      public SuffixTree LoadFromFile(BinaryReader reader)
      {
         SuffixTree tree = null;
         int count = reader.ReadInt32();
         int theStringLength = reader.ReadInt32();
         string theString = reader.ReadString();
         //todo: mcass 10/27/2016
         //tree = new SuffixTree(theString);
         for (int i = 0; i < count; i++)
         {
            int key = reader.ReadInt32();
            Edge readEdge = new Edge(-1);
            readEdge.endNode = reader.ReadInt32();
            readEdge.startNode = reader.ReadInt32();
            readEdge.indexOfFirstCharacter = reader.ReadInt32();
            readEdge.indexOfLastCharacter = reader.ReadInt32();
            Edges.Add(key, readEdge);
         }
         return tree;
      }

      public SuffixTree LoadFromFile(Stream stream)
      {
         SuffixTree tree;
         using (BinaryReader reader = new BinaryReader(stream))
         {
            tree = LoadFromFile(reader);
         }
         return tree;
      }

      public bool Search(List<int> search)
      {
         return Search(search, false);
      }

      public bool Search(List<int> search, bool caseSensitive)
      {
         if (search.Count == 0)
         {
            return false;
         }
         int index = 0;
         Edge edge;
         if (!Edges.TryGetValue((int)Edge.Hash(0, search[0]), out edge))
         {
            return false;
         }

         if (edge.startNode == -1)
         {
            return false;
         }
         else
         {
            for (;;)
            {
               for (int j = edge.indexOfFirstCharacter; j <= edge.indexOfLastCharacter; j++)
               {
                  if (index >= search.Count)
                  {
                     return true;
                  }
                  int test = theString[j];
                  if (theString[j] != search[index++])
                  {
                     return false;
                  }
               }
               if (index < search.Count)
               {
                  Edge value;
                  if (Edges.TryGetValue(Edge.Hash(edge.endNode, search[index]), out value))
                  {
                     edge = value;
                  }
                  else
                  {
                     return false;
                  }
               }
               else
               {
                  return true;
               }
            }
         }
      }

      private void AddPrefix(Suffix active, int indexOfLastCharacter)
      {
         int parentNode;
         int lastParentNode = -1;

         for (;;)
         {
            Edge edge;
            parentNode = active.originNode;

            if (active.IsExplicit)
            {
               edge = Edge.Find(theString, Edges, active.originNode, theString[indexOfLastCharacter]);
               if (edge.startNode != -1)
               {
                  break;
               }
            }
            else
            {
               edge = Edge.Find(theString, Edges, active.originNode, theString[active.indexOfFirstCharacter]);
               int span = active.indexOfLastCharacter - active.indexOfFirstCharacter;
               if (theString[edge.indexOfFirstCharacter + span + 1] == theString[indexOfLastCharacter])
               {
                  break;
               }
               parentNode = edge.SplitEdge(active, theString, Edges, Nodes);
            }

            Edge newEdge = new Edge(theString, indexOfLastCharacter, theString.Count - 1, parentNode);
            newEdge.Insert(theString, Edges);
            if (lastParentNode > 0)
            {
               Nodes[lastParentNode].suffixNode = parentNode;
            }
            lastParentNode = parentNode;

            if (active.originNode == 0)
            {
               active.indexOfFirstCharacter++;
            }
            else
            {
               active.originNode = Nodes[active.originNode].suffixNode;
            }
            active.Canonize(theString, Edges);
         }
         if (lastParentNode > 0)
         {
            Nodes[lastParentNode].suffixNode = parentNode;
         }
         active.indexOfLastCharacter++;
         active.Canonize(theString, Edges);
      }
   }
}