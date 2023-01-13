using System;
namespace Interfaces.Annotations
{
    public class IocAttribute : Attribute
    {
        public Type Interface { get; set; }
    }
}
