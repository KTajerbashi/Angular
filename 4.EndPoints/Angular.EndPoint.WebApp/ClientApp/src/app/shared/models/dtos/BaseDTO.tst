${
  string TypeMap(Property property)
  {
      var type = property.Type;

      if (type.IsPrimitive)
      {
          string typeName;


          if (type.IsDate)
              typeName = "Date";
          else if (type.IsEnum)
              typeName = type.Name;

          else
              typeName = type.name;

          return $"{property.name}: {typeName};";
      }
      else if(type.Name.Contains("any[]"))
      {
          return $"{property.name}: any[];";
      }
      else if(type.Name.Equals("T"))
      {
          return $"{property.name}: T;";
      }

      else if (type.IsGeneric && property.Name == "Attendees")
      {
          return $"{property.name}: IAngucompleteJson<ITitleValue<IMeetingUserAutocompleteJson>>[];";
      }
      else if (type.IsGeneric && type.Name.Contains("AngucompleteJson"))
      {
          return $"{property.name}: IAngucompleteJson<ITitleValue<number>>;";
      }
      else
      {
          return $"{property.name}: I{type.Name.Replace("TableData<","TableData<I")};";
      }
  }

  string GetName(Class @class)
  {
      return $"{@class.Name}{(@class.IsGeneric ? "<T>" : String.Empty)}";
  }
}

${
  string GetBaseClassName(Class pCurrentClass)
  {
      if (pCurrentClass.BaseClass == null)
          return String.Empty;
      else if (pCurrentClass.BaseClass.Name == "GeneralDTO")
          return "extends IGeneralEntity";
      else if (pCurrentClass.BaseClass.Name == "BaseDTO")
          return "extends IBaseDTO";
      else if (pCurrentClass.BaseClass.Name == "DbDTO")
          return "extends IDbEntity";
      else if (pCurrentClass.BaseClass.Name == "RootEntityDTO")
          return " extends IRootEntityDTO";
      else
          return " extends I" +pCurrentClass.BaseClass.Name;
  }
}
${
  Template(Settings settings)
  {

      settings.OutputExtension = "d.ts";
  }
}

${
  string LoudName(Class c)
  {
      return c.Name.ToUpperInvariant();
  }
}

$Classes(*DTO)[
interface I$GetName $GetBaseClassName
{
  $Properties[
  $TypeMap
  ]
}]
