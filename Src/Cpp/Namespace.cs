using System.Collections.Generic;
using System.Linq;

namespace Scopes.Cpp {
    public class Namespace : Recursive {
        public Namespace(IEnumerable<string> prefix) : base(prefix.Select(x=>$"namespace {x} {{").ToArray(), "}") {
        }
        public Namespace(params string[] prefix) : this((IEnumerable<string>)prefix) {
        }
    }
}
