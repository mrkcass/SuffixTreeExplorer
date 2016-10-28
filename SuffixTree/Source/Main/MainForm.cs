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
         ctrlInputString.Text = "10 20 30 40 500 10234 40 50 40 50";
         string[] tokens = ctrlInputString.Text.Split();
         int [] numbers = Array.ConvertAll(tokens, int.Parse);
         List<int> numberList = new List<int>(numbers);
         m_Stree = new SuffixTree(numberList);
         m_Stree.BuildTree();
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
               List<int> substring = m_Stree.theString.GetRange(edge.indexOfFirstCharacter, (edge.indexOfLastCharacter - edge.indexOfFirstCharacter) + 1);
               graphEdge.LabelText = ListToString(substring);
            }
         }

         graph.Attr.BackgroundColor = new Msagl.Color(255, 60, 60, 60);
         ctrlGraph.Graph = graph;
      }

      private void ctrlBuild_Click(object sender, EventArgs e)
      {
         Build(ctrlInputString.Text);
      }

      private void ctrlInputString_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)13)
         {
            e.Handled = true;
            Build(ctrlInputString.Text);
         }
      }

      private void Build(string input)
      {
         m_Input = input;
         string[] tokens = ctrlInputString.Text.Split();
         int[] numbers = Array.ConvertAll(tokens, int.Parse);
         List<int> numberList = new List<int>(numbers);
         m_Stree = new SuffixTree(numberList);
         m_Stree.BuildTree();
         DisplayTree();
      }

      private string ListToString(List<int> list)
      {
         return string.Join(" ", list.ToArray());
      }

      SuffixTree m_Stree;
      private string m_Input = "";
   }
}