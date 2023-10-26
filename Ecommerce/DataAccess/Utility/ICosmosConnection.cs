using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace PwC_Ecommerce.DataAccess.Utility
{
   
    public interface ICosmosConnection
    {
        Task<DocumentClient> InitializeAsync(string collectionId);
    }
}
