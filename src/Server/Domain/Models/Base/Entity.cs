namespace Domain.Models.Base;

public abstract class Entity : Infrastructure.Interfaces.IEntity
{
    protected Entity() : base()
    {
        Id = System.Guid.NewGuid();
    }

    public System.Guid Id { get; set; }
}
