using System.Text;

namespace Scopes {
    public abstract class IndentContract {
        public abstract void Build(StringBuilder builder, int indent);

        public override string ToString() {
            var builder = new StringBuilder();
            Build(builder, 0);
            return builder.ToString();
        }
    }



}
