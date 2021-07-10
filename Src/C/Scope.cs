using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scopes {

    namespace C {

        public class Scopeꓼ : Indent{
            public Scopeꓼ(string title) : base(title + " {", "};") { }
        }

        public class Scope : Indent {
            public Scope(string title) : base(title + " {", "}") { }


            private static Scope RecursivelyNested(Scope parent, IEnumerable<string> names) {
                if (!names.Any()) return parent;
                var scope = new Scope(names.First());
                parent.Add(scope);
                return RecursivelyNested(scope, names.Skip(1));
            }
            public static Scope RecursivelyNested(IEnumerable<string> names) {
                if (names == null) return null;
                if (!names.Any()) return null;
                var scope = new Scope(names.First());
                return RecursivelyNested(scope, names.Skip(1));
            }
            public static Scope RecursivelyNested(params string[] names) {
                return RecursivelyNested((IEnumerable<string>)names);
            }
        }


        




    }
}
