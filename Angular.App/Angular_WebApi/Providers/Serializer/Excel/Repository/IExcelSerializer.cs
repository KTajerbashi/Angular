namespace Angular_WebApi.Providers.Serializer.Excel.Repository;

public interface IExcelSerializer
{
    Task<byte[]> ListToExcelByteArray<TModel>(List<TModel> dataList);
}
