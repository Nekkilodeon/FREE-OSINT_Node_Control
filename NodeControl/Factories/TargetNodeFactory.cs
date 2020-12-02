using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodeControl.Nodes;
using System.Windows.Forms;
using System.Drawing;

namespace NodeControl.Factories
{
    public class TargetNodeFactory : NodeFactory
    {
        public TargetNodeFactory()
            : base("Target")
        {
        }

        public override Keys[] GetShortcutKeys()
        {
            return new Keys[] { Keys.N, Keys.T };
        }

        public override Type NodeType
        {
            get { return typeof(ConditionNode); }
        }

        public override Node CreateNode(NodeDiagram diagram)
        {
            return new ConditionNode(diagram, Color.Orange, true);
        }
    }
}
