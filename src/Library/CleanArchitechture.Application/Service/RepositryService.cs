
using AutoMapper;
using CleanArchitechture.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArchitechture.Application.Service;

public class RepositryService<TEntiy, IModel> : IRepositryService<TEntiy, IModel> where TEntiy : class, new()
    where IModel : class
{
    private readonly ApplicationDbContext _context; 
    private readonly IMapper _mapper;

    public RepositryService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _DbSet=_context.Set<TEntiy>();
    }
    private DbSet<TEntiy> _DbSet { get; }


    public async Task<IModel> Delete(int id, CancellationToken cancellationToken)
    {
       var entity=await _DbSet.FindAsync(id, cancellationToken);
        if (entity == null) return null;
        _DbSet.Remove(entity);
        await _context.SaveChangesAsync();
        var data=_mapper.Map<TEntiy,IModel>(entity);
        return data;    
    }

    public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entity=await _DbSet.ToListAsync(cancellationToken);
        if (entity == null) return null;
        var data = _mapper.Map<IEnumerable<IModel>>(entity);
        return data;
    }

    public async Task<IModel> GetFindIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity=await _DbSet.FindAsync(id,cancellationToken);
        if (entity == null) return null;
        var data=_mapper.Map<TEntiy,IModel>(entity);
        return data;
    }

    public async Task<IModel> Insert(IModel model, CancellationToken cancellationToken)
    {
        var entity=_mapper.Map<IModel,TEntiy>(model);
        _DbSet.Add(entity);
        await _context.SaveChangesAsync();
        var data = _mapper.Map<TEntiy, IModel>(entity);
        return data;
    }

    public async Task<IModel> Update(int id, IModel model, CancellationToken cancellationToken)
    {
        var entity=await _DbSet.FindAsync(id,cancellationToken);
        if (entity == null) return null;
        _mapper.Map(entity, model); 
        await _context.SaveChangesAsync();
        var data = _mapper.Map<TEntiy, IModel>(entity);
        return data;    
    }
}
