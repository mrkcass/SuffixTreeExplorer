using System;
using System.Windows.Forms;
using Msagl = Microsoft.Msagl.Drawing;
using ThirdParty_SuffixTree;
using System.Collections.Generic;

namespace SuffixTreeExplorer
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      private void MainForm_Shown(object sender, EventArgs e)
      {
         if (ctrlString.Checked)
            ctrlInputString.Text = testString;
         else
            ctrlInputString.Text = testNumbers;
         Build();
      }

      private void DisplayArray()
      {
         for (int i=1; i < m_Stree.suffixArray.Count; i++)
         {
            ctrlSuffixArray.Items.Add(ListToString(m_Stree.suffixArrayStr(i)));
         }
      }

      private void DisplayTree()
      {
         Msagl.Graph graph = new Msagl.Graph();
         var iter = m_Stree.Edges.GetEnumerator();
         while (iter.MoveNext())
         {
            Edge edge = iter.Current.Value;
            int startNameIdx = edge.startNode;
            if (startNameIdx >= 0)
            {
               int endNameIdx = edge.endNode;
               Msagl.Edge graphEdge = graph.AddEdge(startNameIdx.ToString(), endNameIdx.ToString());
               int len = (edge.indexOfLastCharacter - edge.indexOfFirstCharacter) + 1;
               List<int> substring;
               if (edge.indexOfFirstCharacter + len < m_Stree.theString.Count)
                  substring = m_Stree.theString.GetRange(edge.indexOfFirstCharacter, (edge.indexOfLastCharacter - edge.indexOfFirstCharacter)+1);
               else
                  substring = m_Stree.theString.GetRange(edge.indexOfFirstCharacter, (edge.indexOfLastCharacter - edge.indexOfFirstCharacter));
               graphEdge.LabelText = ListToString(substring);
            }
         }

         graph.Attr.BackgroundColor = new Msagl.Color(255, 60, 60, 60);
         ctrlGraph.Graph = graph;
      }

      private void ctrlBuild_Click(object sender, EventArgs e)
      {
         Build();
      }

      private void ctrlInputString_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)13)
         {
            e.Handled = true;
            Build();
         }
      }

      private void Build()
      {
         List<int> numberList = InputToList();
         m_Stree = new SuffixTree(numberList);
         m_Stree.BuildTree();
         m_Stree.buildSuffixArray();
         ClearOuput();
         DisplayTree();
         DisplayArray();
      }

      private void ClearOuput()
      {
         ctrlSuffixArray.Items.Clear();
         ctrlGraph.Graph = null;
      }

      private void Clear()
      {
         ctrlInputString.Text = "";
         ClearOuput();
      }

      private List<int> InputToList()
      {
         List<int> numberList;
         if (ctrlString.Checked)
         {
            numberList = new List<int>();
            foreach (var c in ctrlInputString.Text)
               numberList.Add(c - 'a');
         }
         else
         {
            string[] tokens = ctrlInputString.Text.Split();
            int[] numbers = Array.ConvertAll(tokens, int.Parse);
            numberList = new List<int>(numbers);
         }
         return numberList;
      }

      private string ListToString(List<int> list)
      {
         string result = "";
         if (ctrlString.Checked)
         {
            foreach (int val in list)
            {
               if (val >= 0)
                  result += (char)('a' + val);
               else
                  result += (char)('$');
            }
         }
         else
         {
            result = string.Join(" ", list.ToArray());
         }
         return result;
      }

      SuffixTree m_Stree;
      private string m_Input = "";

      private void ctrlString_CheckedChanged(object sender, EventArgs e)
      {
         if (ctrlString.Checked)
         {
            Clear();
            ctrlInputString.Text = testString;
            Build();
         }
      }

      private void ctrlNumber_CheckedChanged(object sender, EventArgs e)
      {
         if (ctrlNumber.Checked)
         {
            Clear();
            ctrlInputString.Text = testNumbers;
            Build();
         }
      }

      private string testNumbers = "10 20 30 40 500 10234 40 50 40 50";
      private string testString = "missim";
   }
}