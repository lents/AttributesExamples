using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Attributes
{
    [Serializable]
    internal class SampleClass
    {
        public string Name { get; set; }
        [Obsolete("Please use SecondName instead")]
        public string Description { get; set; }
        public string SecondName { get; set; }

        public void SomeMethod() { }
    }
}
