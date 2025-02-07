using Kreta.Shared.Models;
using Kreta.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kreata.Backend.Repos.Base
{
    public class BaseRepo<TDbContext, TEntity> : IBaseRepo<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IDbEntity<TEntity>, new()
    {
        private readonly DbContext? _dbContext;
        protected readonly DbSet<TEntity>? _dbSet;

        public BaseRepo(TDbContext? dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, $"A {nameof(TEntity)} adatbázis tábla nem elérhető!");
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>() ?? throw new ArgumentException($"A {nameof(TEntity)} adatbázis tábla nem elérhető!");
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet!.ToListAsync();
        public async Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression) => await _dbSet!.Where(expression).ToListAsync();
        public async Task<Response> UpdateAsync(TEntity entity)
        {
            Response response = new();
            try
            {
                if (_dbContext is not null)
                {
                    _dbContext.ChangeTracker.Clear();
                    _dbContext.Entry(entity).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return response;
                }
            }
            catch (Exception e)
            {
                return HandleException(nameof(UpdateAsync), e, $"{entity} frissítése nem sikerült!");
            }
            return response;
        }

        public async Task<Response> CreateAsync(TEntity entity)
        {
            try
            {
                _dbSet!.Add(entity);
                await _dbContext!.SaveChangesAsync();
                return new Response();
            }
            catch (Exception e)
            {
                return HandleException(nameof(CreateAsync), e, $"{entity} hozzáadása az adatbázishoz nem sikerült!");
            }
        }

        public async Task<Response> DeleteAsync(Guid id)
        {
            Response response = new();
            TEntity? entityToDelete = _dbSet!.Where(e => e.Id == id).FirstOrDefault();

            if (entityToDelete is null)
                response = HandleException(nameof(DeleteAsync), null, $"A törlendő entitás nem található!");
            else
            {
                try
                {
                    if (_dbContext is not null)
                    {
                        _dbContext.ChangeTracker.Clear();
                        _dbContext.Entry(entityToDelete!).State = EntityState.Deleted;
                        await _dbContext.SaveChangesAsync();
                        return response;
                    }
                }
                catch (Exception e)
                {
                    response.AppendNewError(e.Message);
                }
            }
            response.AppendNewError($"{nameof(BaseRepo<TDbContext, TEntity>)} osztály, {nameof(DeleteAsync)} metódusban hiba keletkezett");
            if (entityToDelete is not null)
                response.AppendNewError($"Az entitás id:{entityToDelete.Id}");
            response.AppendNewError($"Az entitás törlése nem sikerült!");
            return response;
        }

        private static Response HandleException(string methodName, Exception? exception, string additionalMessage = "")
        {
            Response response = new();
            if (!string.IsNullOrEmpty(methodName))
                response.AppendNewError($"{methodName} metódusban hiba történt.");
            if (exception is not null)
                response.AppendNewError(exception.Message);
            if (!string.IsNullOrWhiteSpace(additionalMessage))
                response.AppendNewError(additionalMessage);
            return response;
        }
    }
}
