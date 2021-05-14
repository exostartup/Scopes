using System.Collections;
using System.Text;

namespace Scopes {

    namespace C {
        public class Scope : IndentContract, IEnumerable {
            public string Prefix { get; set; }

            public Scope(string prefix) {
                Prefix = prefix;
            }

            private Group content = null;
            public Group Content {
                get {
                    if (content == null) {
                        content = new Group();
                    }
                    return content;
                }
                set {
                    content = value;
                }
            }

            public override void Build(StringBuilder builder, int indent) {
                builder.Append('\t', indent).Append(Prefix).AppendLine("{");
                content?.Build(builder, indent + 1);
                builder.Append('\t', indent).AppendLine("}");
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return Content.GetEnumerator();
            }

            public void Add(IndentContract item) {
                Content.Add(item);
            }
            public void Add(string item) {
                Content.Add(item);
            }
            public void Add(Group item) {
                Content.Add(item);
            }
        }

    }

}
