using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

using Scopes;
using Scopes.C;

namespace Scopes {

    namespace C {

    }

}


namespace Example {
    class Program {
        static string GetThisFilePath([CallerFilePath] string thisFilePath = "") {
            return thisFilePath;
        }
        
        static void Main(string[] args){
            var outputFilePath = Path.Combine(Path.GetDirectoryName(GetThisFilePath()), "Output.ecs");

            var header = new Group() {
                "//This file is generated",
                "using System;"
            };

            var output = new Group() {
                header,
                new Scope("namespace GeneratedNamespace"){
                    new Scope("public class GeneratedClass"){
                        new Scope("public class GeneratedNestedClass"){
                            new Scope("public void PrintHelloWorld()"){
                                "Console.WriteLine(\"Hello World\");"
                            }
                        },
                        new Scope("public GeneratedNestedClass CreateNestedClass()"){
                            "return new GeneratedNestedClass();"
                        }                        
                    }
                }
            };


            File.WriteAllText(outputFilePath, output.ToString());
        }
    }
}
