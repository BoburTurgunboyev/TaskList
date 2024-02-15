namespace TaskList.Infrastructure.Repositories;

public interface IBaseRepository<TRepo>
{
    public ValueTask<TRepo> SelectById(int Id);
    public ValueTask<IEnumerable<TRepo>> SelectAll();
    public ValueTask<TRepo> Insert(TRepo repo);
    public ValueTask<TRepo> Update(TRepo repo);
    public ValueTask<TRepo> DeleteById(int Id);
}
