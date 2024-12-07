using Angular_WebApi.Providers.Serializer.Excel.Repository;

namespace Angular_WebApi.Providers.Serializer.Excel.Service;

public class ExcelSerializer : IExcelSerializer
{
    public Task<byte[]> ListToExcelByteArray<TModel>(List<TModel> dataList)
    {
        throw new NotImplementedException();
    }
}