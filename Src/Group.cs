using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Scopes {
    public class Group : IndentContract , IEnumerable<object> {
        public bool IsEmpty => _items.Count == 0;

        private List<object> _items = new List<object>();


        public void Add(IndentContract item) {
            _items.Add(item);
        }
        
        public void Add(string item) {
            _items.Add(item);
        }
        
        public void Add(Group item) {
            _items.AddRange(item);
        }

        public override void Build(StringBuilder builder, int indent) {
            foreach (var i in _items) {
                if (i is IndentContract indentContract) {
                    indentContract.Build(builder, indent);
                } else {
                    builder.Append('\t', indent).AppendLine(i.ToString());
                }
            }
        }

        public IEnumerator GetEnumerator() {
            return _items.GetEnumerator();
        }

        IEnumerator<object> IEnumerable<object>.GetEnumerator() {
            return _items.GetEnumerator();
        }

    }
}
