using System;

namespace OdooManager.AppModels.Attrs
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
