using System.Text;

namespace Scopes {
    public abstract partial class Node {
        public abstract void Build(StringBuilder builder, int indent);

        public override string ToString() {
            var builder = new StringBuilder();
            Build(builder, 0);
            return builder.ToString();
        }

        public static implicit operator Node(string x) {
            return new String(x);
        }

    }


}
