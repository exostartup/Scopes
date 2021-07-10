using System.Collections.Generic;

namespace Scopes {

    namespace C {

        public class Scopeꓼ : Indent{
            public Scopeꓼ(string title) : base(title + " {", "};") { }
        }

        public class Scope : Indent {
            public Scope(string title): base(title + " {", "}") {}
        }
    }
}
