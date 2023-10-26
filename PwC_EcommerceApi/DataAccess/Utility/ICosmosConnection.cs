using Microsoft.Azure.Documents.Client;
using System.Threading.Tasks;

namespace PwC_EcommerceApi.DataAccess.Utility
{
   
    public interface ICosmosConnection
    {
        Task<DocumentClient> InitializeAsync(string collectionId);
    }
}
