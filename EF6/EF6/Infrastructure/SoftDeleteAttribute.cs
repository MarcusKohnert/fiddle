using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace EF6.Infrastructure
{
    internal class SoftDeleteAttribute : Attribute
    {
        public SoftDeleteAttribute(string column)
        {
            this.ColumnName = column;
        }

        public string ColumnName { get; private set; }

        public static string GetSoftDeleteColumnName(EdmType type)
        {
            var annotation = type.MetadataProperties
                                 .SingleOrDefault(_ => _.Name.EndsWith("customannotation:SoftDeleteColumn"));

            return (string)annotation?.Value;
        }
    }
}