using MongoDB.Bson;

namespace Mmu.Mls2.WebApi.Infrastructure.DomainExtensions.ModelAbstractions.Handlers
{
    internal static class IdFactory
    {
        internal static string CreateId()
        {
            return ObjectId.GenerateNewId().ToString();
        }
    }
}