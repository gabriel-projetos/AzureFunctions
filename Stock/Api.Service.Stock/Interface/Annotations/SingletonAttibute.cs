using System;
namespace Interfaces.Annotations
{
    public class SingletonAttribute : Attribute
    {
        public Type Interface { get; set; }
    }
}
