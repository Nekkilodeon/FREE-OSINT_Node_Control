using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NodeControl.Nodes;
using NodeControl;

namespace NodeControlTest
{
    public partial class Form1 : Form
    {
        private NodeDiagram d;
        public Form1()
        {
            InitializeComponent();

            d= new NodeDiagram();
            d.Dock = DockStyle.Fill;
            pnl.Controls.Add(d);

            var n = new ConditionNode(d, Color.DeepSkyBlue, false) { Text = "Test" };

            var subn = new ConditionNode(d, Color.Orange, true) { Text = "I NEED A LOT OF TEXT TO TEST THE FUNCTIONALITY" };
            subn.LinksTo.Add(new Condition() { Text = "", LinksTo = n });

            subn.LinksTo.Add(new Condition() { Text = "Yes"});


            var noNode = new ConditionNode(d, Color.DeepSkyBlue, false) { Text = "Your loss" };

            subn.LinksTo.Add(new Condition() { Text = "No", LinksTo = noNode });

            d.Nodes.Add(n);
            d.Nodes.Add(subn);
            d.Nodes.Add(noNode);

            d.Nodes.Add(n);

            var unlinkedNode = new ConditionNode(d, Color.Aqua, false) { Text = "Unlinked " };
            var extraNode = new ConditionNode(d, Color.Aqua, false) { Text = "Row2Ples " };
            subn.LinksTo.Add(new Condition() { Text = "Come again? Come again?", LinksTo = unlinkedNode });
            subn.LinksTo.Add(new Condition() { Text = "", LinksTo = extraNode });

            var subn2 = new ConditionNode(d, Color.Orange, true) { Text = "I LITY" };
            var extraNode2 = new ConditionNode(d, Color.Aqua, false) { Text = "Row2Ples " };
            subn2.LinksTo.Add(new Condition() { Text = "", LinksTo = extraNode2 });


            d.Nodes.Add(unlinkedNode);
            d.Nodes.Add(extraNode);
            d.Nodes.Add(subn2);
            d.Nodes.Add(extraNode2);

            foreach (var node in d.Nodes)
            {
                node.Direction = Node.DirectionEnum.Vertical;
            }

            //d.AutoLayout(true);
        }

        private void rdbBezier_CheckedChanged(object sender, EventArgs e)
        {
            d.LineType = LineTypeEnum.Bezier;
            d.Redraw();
        }

        private void rdb4Way_CheckedChanged(object sender, EventArgs e)
        {
            d.LineType = LineTypeEnum.FourWay;
            d.Redraw();
        }


        private void rdbStraight_CheckedChanged(object sender, EventArgs e)
        {
            d.LineType = LineTypeEnum.Straight;
            d.Redraw();
        }

        private void btnAutoLayout_Click(object sender, EventArgs e)
        {
            d.AutoLayout(false, true);
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            using (Form frm = new Form())
            {
                frm.BackgroundImage =  d.AsImage();
                frm.BackgroundImageLayout = ImageLayout.None;
                frm.ShowDialog();
            }
        }

    }

   


}
