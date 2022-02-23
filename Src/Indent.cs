using System.Collections;
using System.Text;

namespace Scopes {
    public class Indent : IndecomposableNode, IEnumerable {
        public string Prefix { get; }
        public string Suffix { get; }

        private Group _content = null;
        public Group Content {
            get {
                if (_content == null) {
                    _content = new Group();
                }
                return _content;
            }
            set => _content = value;
        }

        public Indent(string prefix, string suffix) {
            Prefix = prefix;
            Suffix = suffix;
        }

        public override void Build(StringBuilder builder, int indent) {
            if (Prefix!=null)
                builder.Append('\t', indent).AppendLine(Prefix);
            _content?.Build(builder, indent + 1);

            if (Suffix!=null)
                builder.Append('\t', indent).AppendLine(Suffix);
        }

        public void Add(object node) {
            Content.Add(node);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return null;
        }
    }

}
