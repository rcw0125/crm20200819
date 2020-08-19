using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,
       AllowMultiple = false, Inherited = true)]
    public class DataMemberAttribute : Attribute
    {
        private readonly string _alias;

        public DataMemberAttribute(string alias)
        {
            _alias = alias;
        }

        public string Alias
        {
            get
            {
                return _alias;
            }
        }
    }
}
