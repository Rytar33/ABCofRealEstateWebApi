using System.ComponentModel.DataAnnotations;

namespace ABCofRealEstate.Data.Models.Entities;

public abstract class BaseEntity
{
    [Display(Name = "id")]
    public Guid Id { get; init; }

    public override bool Equals(object? obj)
        => obj is BaseEntity entity 
        && entity.Id == Id
        && GetHashCode() == entity.GetHashCode();

    public override int GetHashCode()
        => Id.GetHashCode();
}
