using DevDesafioMagvaBusZap.Models;
using DevDesafioMagvaBusZap.Models.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DevDesafioMagvaBusZap.Service.Interface
{
    public interface IApiService
    {
        public Task<Result<List<Character>>> GetDataByRequestedParameters();
    }
}
