using Angular.ApplicationLibrary.Providers.Serializers;
using Angular.ApplicationLibrary.Providers.Translator;
using Angular.ApplicationLibrary.Utilities.Extensions;
using Angular.InfrastructureLibrary.Extensions.Methods;
using System.Data;

namespace Angular.InfrastructureLibrary.Providers.Serializers.EPPlus;

public class EPPlusExcelSerializer : IExcelSerializer
{
    private readonly ITranslator _translator;

    public EPPlusExcelSerializer(ITranslator translator)
    {
        _translator = translator;
    }

    public byte[] ListToExcelByteArray<T>(List<T> list, string sheetName = "Result") => list.ToExcelByteArray(_translator, sheetName);

    public DataTable ExcelToDataTable(byte[] bytes) => bytes.ToDataTableFromExcel();

    public List<T> ExcelToList<T>(byte[] bytes) => bytes.ToDataTableFromExcel().ToList<T>(_translator);
}