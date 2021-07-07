using System.Text;

namespace Scopes {
    public class String : IndecomposableNode {
        string _value;

        public String(string value) {
            _value = value;
        }

        public override void Build(StringBuilder builder, int indent) {
            builder.Append('\t', indent).AppendLine(_value);
        }

        public static implicit operator String(string x) {
            return new String(x);
        }

    }


}
