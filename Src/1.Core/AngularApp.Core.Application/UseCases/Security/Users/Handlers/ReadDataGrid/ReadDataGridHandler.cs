using AngularApp.Core.Application.UseCases.Security.Users.Repository;
using AngularApp.Core.Application.Utilities.DataGrid;
using AngularApp.Core.Domain.Entities.Security.User;

namespace AngularApp.Core.Application.UseCases.Security.Users.Handlers.ReadDataGrid;

public class ReadDataGridView : BaseView
{
    [ViewColumn("نام", ColumnType = ColumnType.String)]
    public required string FirstName { get; set; }
    [ViewColumn("فامیل", ColumnType = ColumnType.String)]
    public required string LastName { get; set; }
    [ViewColumn("نام کاربری", ColumnType = ColumnType.String)]
    public required string UserName { get; set; }
    [ViewColumn("ایمیل", ColumnType = ColumnType.String)]
    public required string Email { get; set; }
    [ViewColumn("شماره تماس", ColumnType = ColumnType.Number)]
    public required string PhoneNumber { get; set; }
    [ViewColumn("نام نمایشی", ColumnType = ColumnType.String)]
    public required string DisplayName { get; set; }

    public bool IsDeleted { get; set; }
    [ViewColumn("وضعیت حذف", ColumnType = ColumnType.Boolean)]
    public string IsDeletedDesc => IsDeleted ? "حذف شده" : "موجود";

    public bool IsActive { get; set; }
    [ViewColumn("وضعیت", ColumnType = ColumnType.Boolean)]
    public string IsActiveDesc => IsActive ? "فعال" : "غیر فعال";
    public bool IsOnline { get; set; }

    [ViewColumn("وضعیت", ColumnType = ColumnType.Boolean)]
    public string IsOnlineDesc => IsOnline ? "آنلاین" : "آفلاین";
}

public class ReadDataGridQuery : DataGridQuery<ReadDataGridView>
{
}

public class ReadDataGridHandler : DataGridHandler<ReadDataGridQuery, ReadDataGridView>
{
    private readonly IUserRepository _repository;
    public ReadDataGridHandler(ProviderServices provider, IUserRepository repository) : base(provider)
    {
        _repository = repository;
    }

    public override async Task<TableData<ReadDataGridView>> Handle(ReadDataGridQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var viewData = new List<ReadDataGridView>();
            var records = await _repository.GetAsync(cancellationToken);
            viewData = Provider.Mapper.MapList<UserEntity, ReadDataGridView>(records).ToList();
            return Return(request, viewData);
        }
        catch (Exception ex)
        {
            throw ex.ThrowAppException();
        }
    }
}
