namespace AngularApp.Core.Application.Utilities.DataGrid;
public static class DataGridExtensions
{
    private static List<Column> getColumns(Type type, IDictionary<string, IDictionary<string, string>> fields = null)
    {
        var columns = new List<Column>();
        IDictionary<string, string> properties = new Dictionary<string, string>();
        foreach (var prop in type.GetProperties())
        {

            var propName = prop.Name;
            var firstChar = Char.ToLower(propName[0]);

            propName = firstChar + propName.Substring(1, propName.Length - 1);

            var hasPropertiesValue = false;

            if (fields != null)
                hasPropertiesValue = fields.TryGetValue(prop.Name, out properties);

            if (hasPropertiesValue)
            {
                var hasIgnoreValue = properties.TryGetValue("ignore", out string ignore);
                if (hasIgnoreValue && ignore == "true")
                {
                    properties = new Dictionary<string, string>();
                    continue;
                }
                else if (hasIgnoreValue && ignore == "false")
                {
                    var hasDataSetStringValue = properties.TryGetValue("dataset", out string dataSetString);

                    if (hasDataSetStringValue)
                    {
                        Column viewColumn = System.Text.Json.JsonSerializer.Deserialize<Column>(dataSetString);

                        var filter = viewColumn.Filter;

                        if (String.IsNullOrWhiteSpace(filter))
                        {
                            if (prop.PropertyType == typeof(bool))
                            {
                                filter = "toActiveDeactive";
                            }
                            else if (prop.PropertyType.IsEnum)
                            {
                                filter = $"toEnumString,{prop.PropertyType.Name}";
                            }
                        }

                        var column = new Column()
                        {
                            Title = viewColumn.Title,
                            OrderNumber = (viewColumn.OrderNumber != -99 ? viewColumn.OrderNumber : (columns.Any() ? columns.Max(item => item.OrderNumber) + 1 : 0)),
                            Field = propName,
                            Filter = filter,
                            ColumnType = viewColumn.ColumnType,
                            EnumTitleValueName = viewColumn.EnumTitleValueName,
                            EntityTypeGroup = viewColumn.EntityTypeGroup,
                            CalculateSum = viewColumn.CalculateSum,
                            CalculateAggregateAverage = viewColumn.CalculateAggregateAverage,
                            NeedSubstring = viewColumn.NeedSubstring,
                            LeftAssign = viewColumn.LeftAssign,
                            Editable = viewColumn.Editable,
                            FunctionName = viewColumn.FunctionName,
                        };

                        Type columnType = typeof(Column);
                        foreach (var propertyField in properties)
                        {
                            PropertyInfo property = type.GetProperty(propertyField.Key);
                            if (property != null)
                            {
                                object value = Convert.ChangeType(propertyField.Value, property.PropertyType);
                                property.SetValue(column, value);
                            }
                        }

                        columns.Add(column);
                        properties = new Dictionary<string, string>();
                        continue;
                    }
                }
            }
            else
                properties = new Dictionary<string, string>();

            foreach (var viewColumn in prop.GetCustomAttributes(false).OfType<ViewColumnAttribute>())
            {
                var filter = viewColumn.Filter;

                if (String.IsNullOrWhiteSpace(filter))
                {
                    if (prop.PropertyType == typeof(bool))
                    {
                        filter = "toActiveDeactive";
                    }
                    else if (prop.PropertyType.IsEnum)
                    {
                        filter = $"toEnumString,{prop.PropertyType.Name}";
                    }
                }

                var column = new Column()
                {
                    Title = viewColumn.Title,
                    OrderNumber = (viewColumn.OrderID != -99 ? viewColumn.OrderID : (columns.Any() ? columns.Max(item => item.OrderNumber) + 1 : 0)),
                    Field = propName,
                    Filter = filter,
                    ColumnType = viewColumn.ColumnType,
                    EnumTitleValueName = viewColumn.EnumTitleValueName,
                    EntityTypeGroup = viewColumn.EntityTypeGroup,
                    CalculateSum = viewColumn.CalculateSum,
                    CalculateAggregateAverage = viewColumn.CalculateAggregateAverage,
                    NeedSubstring = viewColumn.NeedSubstring,
                    LeftAssign = viewColumn.LeftAssign,
                    Editable = viewColumn.Editable,
                    FunctionName = viewColumn.FunctionName,
                };

                Type columnType = typeof(Column);
                foreach (var propertyField in properties)
                {
                    PropertyInfo property = type.GetProperty(propertyField.Key);
                    if (property != null)
                    {
                        object value = Convert.ChangeType(propertyField.Value, property.PropertyType);
                        property.SetValue(column, value);
                    }
                }

                columns.Add(column);
                properties = new Dictionary<string, string>();
            }
        }

        if (!columns.Any())
            throw new Exception("لطفا ستون های نمایش را مشخص نمایید.");

        return columns.OrderBy(item => item.OrderNumber).ToList();
    }

    /// <summary>
    /// دریافت ستونهای یک 
    /// view
    /// که مزین به اتریبیوت
    /// ViewColumn
    /// هستند
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static List<Column> GetColumns(Type type, int[] entityTypes = null, IDictionary<string, IDictionary<string, string>> fields = null)
    {
        var columns = new List<Column>();
        if (entityTypes == null)
            columns = getColumns(type, fields: fields);
        else
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();
            foreach (var prop in type.GetProperties())
            {
                var propName = prop.Name;
                var firstChar = Char.ToLower(propName[0]);

                propName = firstChar + propName.Substring(1, propName.Length - 1);
                var hasPropertiesValue = false;

                if (fields != null)
                    hasPropertiesValue = fields.TryGetValue(prop.Name, out properties);

                if (hasPropertiesValue)
                {
                    var hasIgnoreValue = properties.TryGetValue("ignore", out string ignore);
                    if (hasIgnoreValue && ignore == "true")
                    {
                        properties = new Dictionary<string, string>();
                        continue;
                    }
                    else if (hasIgnoreValue && ignore == "false")
                    {
                        var hasDataSetStringValue = properties.TryGetValue("dataset", out string dataSetString);

                        if (hasDataSetStringValue)
                        {
                            Column viewColumn = System.Text.Json.JsonSerializer.Deserialize<Column>(dataSetString);

                            var filter = viewColumn.Filter;

                            if (String.IsNullOrWhiteSpace(filter))
                            {
                                if (prop.PropertyType == typeof(bool))
                                {
                                    filter = "toActiveDeactive";
                                }
                                else if (prop.PropertyType.IsEnum)
                                {
                                    filter = $"toEnumString,{prop.PropertyType.Name}";
                                }
                            }

                            var column = new Column()
                            {
                                Title = viewColumn.Title,
                                OrderNumber = (viewColumn.OrderNumber != -99 ? viewColumn.OrderNumber : (columns.Any() ? columns.Max(item => item.OrderNumber) + 1 : 0)),
                                Field = propName,
                                Filter = filter,
                                ColumnType = viewColumn.ColumnType,
                                EnumTitleValueName = viewColumn.EnumTitleValueName,
                                EntityTypeGroup = viewColumn.EntityTypeGroup,
                                CalculateSum = viewColumn.CalculateSum,
                                CalculateAggregateAverage = viewColumn.CalculateAggregateAverage,
                                NeedSubstring = viewColumn.NeedSubstring,
                                LeftAssign = viewColumn.LeftAssign,
                                Editable = viewColumn.Editable,
                                FunctionName = viewColumn.FunctionName,
                            };

                            Type columnType = typeof(Column);
                            foreach (var propertyField in properties)
                            {
                                PropertyInfo property = type.GetProperty(propertyField.Key);
                                if (property != null)
                                {
                                    object value = Convert.ChangeType(propertyField.Value, property.PropertyType);
                                    property.SetValue(column, value);
                                }
                            }

                            columns.Add(column);
                            properties = new Dictionary<string, string>();
                            continue;
                        }
                    }
                }
                else
                    properties = new Dictionary<string, string>();

                foreach (var viewColumn in prop.GetCustomAttributes(false).OfType<ViewColumnAttribute>())
                {
                    var filter = viewColumn.Filter;

                    if (String.IsNullOrWhiteSpace(filter))
                    {
                        if (prop.PropertyType == typeof(bool))
                        {
                            filter = "toActiveDeactive";
                        }
                        else if (prop.PropertyType.IsEnum)
                        {
                            filter = $"toEnumString,{prop.PropertyType.Name}";
                        }
                    }

                    var column = new Column()
                    {
                        Title = viewColumn.Title,
                        OrderNumber = (viewColumn.OrderID != -99 ? viewColumn.OrderID : (columns.Any() ? columns.Max(item => item.OrderNumber) + 1 : 0)),
                        Field = propName,
                        Filter = filter,
                        ColumnType = viewColumn.ColumnType,
                        EnumTitleValueName = viewColumn.EnumTitleValueName,
                        EntityTypeGroup = propName.ToLower().Equals("referralstatus") ? entityTypes : viewColumn.EntityTypeGroup,
                        CalculateSum = viewColumn.CalculateSum,
                        CalculateAggregateAverage = viewColumn.CalculateAggregateAverage,
                        NeedSubstring = viewColumn.NeedSubstring,
                        LeftAssign = viewColumn.LeftAssign,
                        Editable = viewColumn.Editable,
                        FunctionName = viewColumn.FunctionName,
                    };

                    Type columnType = typeof(Column);
                    foreach (var propertyField in properties)
                    {
                        PropertyInfo property = type.GetProperty(propertyField.Key);
                        if (property != null)
                        {
                            object value = Convert.ChangeType(propertyField.Value, property.PropertyType);
                            property.SetValue(column, value);
                        }
                    }

                    columns.Add(column);
                    properties = new Dictionary<string, string>();
                }
            }

            if (!columns.Any())
                throw new Exception("لطفا ستون های نمایش را مشخص نمایید.");

            columns = columns.OrderBy(item => item.OrderNumber).ToList();
        }

        return columns;
    }

}
