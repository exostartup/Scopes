using System.Collections;
using System.Text;

namespace Scopes {
    public class Recursive : IndecomposableNode, IEnumerable {
        public string[] Prefix { get; }
        public string Suffix { get; }

        private Group _content = null;
        public Group Content {
            get => _content ??= new Group();
            set => _content = value;
        }

        public Recursive(string[] prefix, string suffix) {
            Prefix = prefix;
            Suffix = suffix;
        }

        public override void Build(StringBuilder builder, int indent) {
            if (Prefix != null) {
                for (int i = 0; i < Prefix.Length; i++) {
                    builder.Append('\t', indent+i).AppendLine(Prefix[i]);
                }                
            }
            _content?.Build(builder, indent + Prefix.Length);

            if (Suffix != null) {
                for (int i = Prefix.Length-1; i >= 0; i--) {
                    builder.Append('\t', indent + i).AppendLine(Suffix);
                }
            }
        }

        public void Add(object node) {
            Content.Add(node);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return null;
        }
    }

}
