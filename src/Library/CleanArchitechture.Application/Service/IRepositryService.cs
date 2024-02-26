namespace CleanArchitechture.Application.Service;

public interface IRepositryService<TEntity,IModel> where TEntity : class,new() where IModel : class
{
    public Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken);
    public Task<IModel> GetFindIdAsync(int id,CancellationToken cancellationToken);
    public Task<IModel> Insert(IModel model,CancellationToken cancellationToken);
    public Task<IModel> Update(int id,IModel model,CancellationToken cancellationToken);
    public Task<IModel> Delete(int id,CancellationToken cancellationToken);

}
