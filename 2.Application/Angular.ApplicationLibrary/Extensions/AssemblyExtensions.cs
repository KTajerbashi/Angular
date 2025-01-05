using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Angular.ApplicationLibrary.Extensions;

public static class AssemblyExtensions
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nameSpace"></param>
    /// <returns></returns>
    public static List<Assembly> GetAssemblies(this string nameSpace)
    {
        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default?.RuntimeLibraries;
        foreach (var library in dependencies!)
        {
            if (IsCandidateCompilationLibrary(library, nameSpace.Split(',')))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }
        return assemblies;
    }
    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assemblyName)
    {
        return assemblyName.Any(d => compilationLibrary.Name.Contains(d))
            || compilationLibrary.Dependencies.Any(d => assemblyName.Any(c => d.Name.Contains(c)));
    }
}
