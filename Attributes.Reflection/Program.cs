using System.Reflection;

namespace Attributes.Reflection
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var isAttributeDefined = typeof(UseAttribute).IsDefined(typeof(RemarkAttribute));
            Console.WriteLine(isAttributeDefined);
            var remark = (typeof(UseAttribute).GetCustomAttribute(typeof(RemarkAttribute)) as RemarkAttribute).Remark;
            Console.WriteLine(remark);
            remark = (typeof(UseAttribute).GetCustomAttributes(typeof(RemarkAttribute)).Single() as RemarkAttribute).Remark;
            Console.WriteLine(remark);
            remark = typeof(UseAttribute).GetCustomAttributesData().Single(x => x.AttributeType ==  typeof(RemarkAttribute)).ConstructorArguments.First().Value.ToString();
            Console.WriteLine(remark);

           
        }



    }
}
