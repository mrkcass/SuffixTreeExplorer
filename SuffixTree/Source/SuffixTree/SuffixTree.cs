/* cs
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
using System.IO;
using System.Globalization;
using System.Collections;

namespace SuffixTree
{

    public class SuffixTree<DATA_T> where DATA_T : IComparable<DATA_T>
    {        
        public DATA_T [] m_Source = null;       
        public Dictionary<int, Edge<DATA_T>> Edges = null;
        public Dictionary<int, Node<DATA_T>> Nodes = null;
        public SuffixTree(IEnumerable<DATA_T> source)
        {
            m_Source = source.ToArray<DATA_T>();
            Nodes = new Dictionary<int, Node<DATA_T>>();
            Edges = new Dictionary<int, Edge<DATA_T>>();            
        }

        public void BuildTree()
        {
            Suffix<DATA_T> active = new Suffix<DATA_T>(0, 0, -1);
            for (int i = 0; i <= m_Source.Count() - 1; i++)
            {
                AddPrefix(active, i);
            }
        }

        public bool Search(IEnumerable<DATA_T> searchPattern)
        {
            bool found = false;
            if (searchPattern.Count() > 0)
            {
                int index = 0;
                Edge<DATA_T> edge;
                if (!Edges.TryGetValue((int)Edge<DATA_T>.Hash(0, searchPattern.ElementAt(0)), out edge))
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
                            if (index >= searchPattern.Count())
                            {
                                return true;
                            }
                            if (m_Source[j].CompareTo(searchPattern.ElementAt(index++)) != 0)
                            {
                                return false;
                            }
                        }
                        if (index < searchPattern.Count())
                        {
                            Edge<DATA_T> value;
                            if (Edges.TryGetValue(Edge<DATA_T>.Hash(edge.endNode, searchPattern.ElementAt(index)), out value))
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

            return found;
        }

        private void AddPrefix(Suffix<DATA_T> active, int indexOfLastCharacter)
        {
            int parentNode;
            int lastParentNode = -1;

            for (; ; )
            {
                Edge<DATA_T> edge = new Edge<DATA_T>(-1);
                parentNode = active.m_OriginNode;

                if (active.IsExplicit)
                {
                    edge = Edge<DATA_T>.Find(m_Source, Edges, active.m_OriginNode, m_Source[indexOfLastCharacter]);
                    if (edge.startNode != -1)
                    {
                        break;
                    }
                }
                else
                {
                    edge = Edge<DATA_T>.Find(m_Source, Edges, active.m_OriginNode, m_Source[active.m_IndexOfFirstCharacter]);
                    int span = active.m_IndexOfLastCharacter - active.m_IndexOfFirstCharacter;
                    if (m_Source[edge.indexOfFirstCharacter + span + 1].CompareTo(m_Source[indexOfLastCharacter]) == 0)
                    {
                        break;
                    }
                    parentNode = Edge<DATA_T>.SplitEdge(this, active, ref edge);
                }

                Edge<DATA_T> newEdge = new Edge<DATA_T>(indexOfLastCharacter, m_Source.Length - 1, parentNode);                
                Edge<DATA_T>.Insert(this, newEdge);
                if (lastParentNode > 0)
                {
                    Nodes[lastParentNode].suffixNode = parentNode;                   
                }
                lastParentNode = parentNode;

                if (active.m_OriginNode == 0)
                {
                    active.m_IndexOfFirstCharacter++;
                }
                else
                {
                    active.m_OriginNode = Nodes[active.m_OriginNode].suffixNode;
                }                
                active.Canonize(this);
            }
            if (lastParentNode > 0)
            {
                Nodes[lastParentNode].suffixNode = parentNode;
            }
            active.m_IndexOfLastCharacter++;
            active.Canonize(this);
        }
    }
}
