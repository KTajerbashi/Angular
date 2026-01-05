using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace AngularApp.Core.Domain.Common;

public interface IEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    TId Id { get; }
    Guid EntityId { get; }
}

public abstract class Entity<TId> : IEntity<TId>
    where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{
    /// <summary>
    /// شناسه عددی Entityها
    /// صرفا برای ذخیره در دیتابیس و سادگی کار مورد استفاده قرار بگیرید.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TId Id { get; protected set; }

    public Guid EntityId { get; protected set; } = Guid.NewGuid();
}