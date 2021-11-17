using LogicGates.Graphs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicGates.Gates
{
    class AndGate : Gate
    {
        public override Gate Clone()
        {
            return new AndGate();
        }

        public override void SetValue(List<Node<Gate>> inputs)
        {
            foreach (var input in inputs)
            {
                if (!input.Data.IsOn)
                {
                    IsOn = false;
                    return;
                }
            }

            IsOn = true;
        }
    }
}
