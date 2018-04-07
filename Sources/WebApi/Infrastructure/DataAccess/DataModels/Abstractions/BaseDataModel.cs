namespace Mmu.Mls2.WebApi.Infrastructure.DataAccess.DataModels.Abstractions
{
    public abstract class BaseDataModel
    {
        public string DataModelTypeName
        {
            get
            {
                return GetType().FullName;
            }
        }

        public string Id { get; set; }
    }
}