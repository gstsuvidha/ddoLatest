using System.Threading.Tasks;
namespace DDO.Persistence
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}