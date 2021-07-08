using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Scopes {
    public class Group : Node, IEnumerable<IndecomposableNode> {
        public bool IsEmpty => _items.Count == 0;

        private List<IndecomposableNode> _items = new();

        public void Add(object node) {
            if (node == null) return;

            if (node is IndecomposableNode indecomposableNode) {
                _items.Add(indecomposableNode);
                return;
            }

            if (node is string stringNode) {
                _items.Add(new String(stringNode));
                return;
            }

            if (node is IEnumerable enumerable) {
                foreach (var i in enumerable) {
                    Add(i);
                }
                return;
            }

            _items.Add(new String(node.ToString()));
        }

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
