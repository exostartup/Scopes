using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Scopes {
    public class Group : IndentContract , IEnumerable<object> {

        List<object> items = new List<object>();
        public bool IsEmpty => items.Count == 0;

        


        public void Add(IndentContract item) {
            items.Add(item);
        }
        public void Add(string item) {
            items.Add(item);
        }
        public void Add(Group item) {
            items.AddRange(item);
        }

        public override void Build(StringBuilder builder, int indent) {
            foreach (var i in items) {
                if (i is IndentContract indentContract) {
                    indentContract.Build(builder, indent);
                } else {
                    builder.Append('\t', indent).AppendLine(i.ToString());
                }
            }
        }

        public IEnumerator GetEnumerator() {
            return items.GetEnumerator();
        }

        IEnumerator<object> IEnumerable<object>.GetEnumerator() {
            return items.GetEnumerator();
        }

    }



}
