using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using pc2_202401.insurance.domain.model.aggregates;
using pc2_202401.insurance.domain.repositories;

namespace pc2_202401.insurance.infrastructure.persistance.efc.repositories;

public class PolicyRepository: BaseRepository<Policy>, IPolicyRepository
{
    public PolicyRepository(AppDbContext context) : base(context)
    {
    }

public async Task<Policy> GetPolicyById(int Id)
    {
        return await Context.Set<Policy>().Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<Policy> GetPolicyByCustomerAndProductId(string customer, int productId)
    {
        return await Context.Set<Policy>().Where(x => x.Customer == 
            customer && x.Productid == productId).FirstOrDefaultAsync();
    }
}