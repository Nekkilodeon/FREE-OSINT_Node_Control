using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodeControl.Nodes;
using System.Windows.Forms;
using System.Drawing;

namespace NodeControl.Factories
{
    public class SubNodeFactory : NodeFactory
    {
        public SubNodeFactory()
            : base("Intel")
        {
        }

        public override Keys[] GetShortcutKeys()
        {
            return new Keys[] { Keys.N, Keys.S };
        }

        public override Type NodeType
        {
            get { return typeof(ConditionNode); }
        }
        public override Node CreateNode(NodeDiagram diagram)
        {
            return new ConditionNode(diagram, Color.Cyan, false);
        }
    }
}
