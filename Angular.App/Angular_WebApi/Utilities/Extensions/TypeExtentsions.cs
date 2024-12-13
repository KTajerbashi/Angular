using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Angular_WebApi.Utilities.Extensions;

public static class TypeExtentsions
{

    public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
    {
        while (toCheck != null && toCheck != typeof(object))
        {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur)
            {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }

    public static (TableAttribute, DescriptionAttribute) GetAttribute(this Type type)
    {
        var tableAtt = type.GetCustomAttributes(typeof(TableAttribute), false)
                                 .Cast<TableAttribute>()
                                 .FirstOrDefault();
        var descAtt = type.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                       .Cast<DescriptionAttribute>()
                                       .FirstOrDefault();
        return (tableAtt, descAtt);
    }

}

