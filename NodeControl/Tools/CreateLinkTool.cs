using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NodeControl.Nodes;
using System.Windows.Forms;

namespace NodeControl.Tools
{
    class CreateLinkTool : Tool
    {
     
        public CreateLinkTool(NodeDiagram diagram)
            : base(diagram)
        {
            
        }



        public override void OnDraw(System.Drawing.Graphics g)
        {
            if (mousedown)
                g.DrawLine(Pens.Red, orgPos, curPos);
        }

        private Point orgPos;
        private MouseDownInfo mouseDownInfo;
        private bool mousedown;
        private Point curPos;

        public MouseDownInfo MouseDownInfo { get => mouseDownInfo; set => mouseDownInfo = value; }

        public override bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            mousedown = true;
            orgPos = new Point(e.X, e.Y);

            var n = diagram.NodeAt(e.X, e.Y);
            if (n != null/* && n.CanLink*/)
            {
                MouseDownInfo = n.GetMouseDownInfo(e);
                return true;
            }
            else
            {
                MouseDownInfo = null;
                return false;
            }
        }

        public override bool OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (mousedown && MouseDownInfo != null)
            {
                curPos = new Point(e.X, e.Y);
                diagram.Invalidate();
                return true;
            }
            else
                return false;
        }

        public override bool OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            diagram.Invalidate();
            mousedown = false;
            //MessageBox.Show("Gottem");
            if (MouseDownInfo != null)
            {
                if (Math.Abs(orgPos.X - e.X) < 10 && Math.Abs(orgPos.Y - e.Y) < 10)
                {
                    // too close for looping (to prevent accidentially creating loops)
                    diagram.invokeNodeOptions(e ,MouseDownInfo.StartNode);
                    return false;
                }

                var targetNode = diagram.NodeAt(e.X, e.Y);
                if (targetNode != null && targetNode.CanBeLinkedTo)
                {
                    MouseDownInfo.StartNode.AddLink(MouseDownInfo, targetNode);
                    diagram.Redraw();
                    MouseDownInfo.EndNode = targetNode;
                    return true;
                }

            }
            return false;
        }
    }
}
