namespace Attributes.Reflection
{
    internal partial class Program
    {
        [AttributeUsage(AttributeTargets.Class)]
        public class RemarkAttribute : Attribute
        {
            string _remark;
            public RemarkAttribute(string comment)
            {
                _remark = comment;
            }
            public string Remark
            {
                get { return _remark; }
            }
        }

    }
}
