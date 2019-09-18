using System.Data;

namespace CV.Core.Data
{
    public interface IUnitOfWork
    {
        void Commit();

        void BenginTran(IsolationLevel iSolationLevel);

        void RollBackTran();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : new();
    }
}