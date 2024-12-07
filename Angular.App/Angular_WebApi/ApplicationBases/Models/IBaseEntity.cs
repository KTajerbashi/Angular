﻿namespace Angular_WebApi.ApplicationBases.Models;

public interface IBaseEntity<TId>
{
    TId Id { get; set; }
    bool IsDeleted { get; set; }
    bool IsActive { get; set; }
}
public abstract class BaseEntity<TId> : IBaseEntity<TId>
{
    public TId Id { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
}

public abstract class BaseEntity : BaseEntity<long>
{
    public void Delete()
    {
        IsActive = false;
        IsDeleted = true;
    }
}