using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using pc2_202401.insurance.domain.model.aggregates;

namespace pc2_202401.insurance.domain.repositories;

public interface IPolicyRepository : IBaseRepository<Policy>
{
    Task<Policy> GetPolicyById(int Id);
    Task<Policy> GetPolicyByCustomerAndProductId(string customer, int productId);
}