using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace MetadataApi
{


    public class ILDemo
    {
        public static void Main()
        {
            DynamicMethod method = new DynamicMethod("HelloMethod", typeof(string), null);

            ILGenerator il = method.GetILGenerator();

            il.Emit(OpCodes.Ldstr, "Hello, IL!");
            il.Emit(OpCodes.Ret);

            Func<string> helloDelegate = (Func<string>)method.CreateDelegate(typeof(Func<string>));

            Console.WriteLine(helloDelegate());




            // Path to an assembly (e.g., a DLL or EXE file)
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            string assemblyPath = currentAssembly.Location;
            //string assemblyPath = @"path\to\your\assembly.dll";

            // Open the assembly as a PE (Portable Executable) file
            using (FileStream stream = new FileStream(assemblyPath, FileMode.Open, FileAccess.Read))
            {
                PEReader peReader = new PEReader(stream);
                MetadataReader metadataReader = peReader.GetMetadataReader();

                // Read types defined in the assembly
                foreach (TypeDefinitionHandle typeHandle in metadataReader.TypeDefinitions)
                {
                    TypeDefinition typeDef = metadataReader.GetTypeDefinition(typeHandle);
                    string typeName = metadataReader.GetString(typeDef.Name);
                    Console.WriteLine($"Type: {typeName}");
                }

                // Read method definitions
                foreach (MethodDefinitionHandle methodHandle in metadataReader.MethodDefinitions)
                {
                    MethodDefinition methodDef = metadataReader.GetMethodDefinition(methodHandle);
                    string methodName = metadataReader.GetString(methodDef.Name);
                    Console.WriteLine($"Method: {methodName}");

                    // Get IL body if available
                    if (!methodDef.RelativeVirtualAddress.Equals(0))
                    {
                        MethodBodyBlock methodBody = peReader.GetMethodBody(methodDef.RelativeVirtualAddress);
                        Console.WriteLine($"IL Length: {methodBody.GetILBytes().Length} bytes");
                    }
                }
            }
        }
    }

}
