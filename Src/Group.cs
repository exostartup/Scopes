using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Scopes {
    public class Group : Node, IEnumerable<IndecomposableNode> {
        public bool IsEmpty => _items.Count == 0;

        private List<IndecomposableNode> _items = new();

        public void Add(object node) {


            switch (node) {
                case IndecomposableNode indecomposable:
                    _items.Add(indecomposable);
                    break;

                case IEnumerable<Node> enumerable:
                    foreach (var i in enumerable) {
                        Add(i);
                    }
                    break;

                default:
                    Add(new String(node.ToString()));
                    break;

            }
        }

        /*public void Add(IEnumerable<Node> items) {
            foreach (var i in items) {
                Add(i);
            }
        }*/

        public override void Build(StringBuilder builder, int indent) {
            foreach (var i in _items) {
                i.Build(builder, indent);
            }
        }

        public IEnumerator<IndecomposableNode> GetEnumerator() {
            return ((IEnumerable<IndecomposableNode>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)_items).GetEnumerator();
        }
    }
}
