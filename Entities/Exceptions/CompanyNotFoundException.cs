

namespace Entities.Exceptions
{
    public sealed class CompanyNotFoundException: NotFoundException
    {
        public CompanyNotFoundException(Guid companyId): base($"The company with Id: {companyId} doesn't exist in the database.")
        { }
    }
}
