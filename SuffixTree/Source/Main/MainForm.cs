//using Microsoft.Msagl.Drawing;
using System;
using System.Windows.Forms;
using Msagl = Microsoft.Msagl.Drawing;

namespace SuffixTree
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ctrlInputString.Text = "abracadabra";
            Build("abracadabra");
        }

        private void DisplayTree (SuffixTree<char> sft)
        {
            Msagl.Graph graph = new Msagl.Graph();
            var iter = sft.Edges.GetEnumerator();
            while (iter.MoveNext())
            {
                Edge<char> edge = iter.Current.Value;
                int startNameIdx = edge.startNode;
                if (startNameIdx >= 0)
                {
                    int endNameIdx = edge.endNode;
                    Msagl.Edge graphEdge = graph.AddEdge(startNameIdx.ToString(), endNameIdx.ToString());
                    graphEdge.LabelText = new string(sft.m_Source, edge.indexOfFirstCharacter, (edge.indexOfLastCharacter - edge.indexOfFirstCharacter)+1);
                }
            }

            graph.Attr.BackgroundColor = new Msagl.Color(255, 60, 60, 60);
            ctrlGraph.Graph = graph;
        }

        private void ctrlBuild_Click(object sender, EventArgs e)
        {
            Build(ctrlInputString.Text);
        }

        private string m_Input = "";

        private void ctrlInputString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                Build(ctrlInputString.Text);
            }
        }

        private void Build (string input)
        {
            m_Input = input;
            SuffixTree<char> sft = new SuffixTree<char>(m_Input);
            sft.BuildTree();
            DisplayTree(sft);
        }
    }
}
