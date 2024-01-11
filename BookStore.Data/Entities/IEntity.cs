namespace BookStore.API.Domain;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}