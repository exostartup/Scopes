using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Scopes {

    namespace C {
        public class Scope : IndecomposableNode, IEnumerable {
            public string Prefix { get; set; }

            public Scope(string prefix) {
                Prefix = prefix;
            }
            
            public Group Content {
                get => _content ??= new Group();
                set => _content = value;
            }

            private Group _content = null;
            
            public override void Build(StringBuilder builder, int indent) {
                builder.Append('\t', indent).Append(Prefix).AppendLine("{");
                _content?.Build(builder, indent + 1);
                builder.Append('\t', indent).AppendLine("}");
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return null;
            }

            public void Add(Node item) {
                Content.Add(item);
            }
            public void Add(IEnumerable<Node> item) {
                Content.Add(item);
            }

            /*public void Add(string item) {
                Content.Add(item);
            }
            
            public void Add(Group item) {
                Content.Add(item);
            }*/
        }
    }
}
