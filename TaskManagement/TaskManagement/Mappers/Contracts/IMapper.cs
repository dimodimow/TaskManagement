using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Web.Mappers.Contracts
{
    public interface IMapper<T, U>
    {
        T Map(U entity);
    }
}
