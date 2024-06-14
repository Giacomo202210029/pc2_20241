using pc2_202401.insurance.domain.model.aggregates;
using pc2_202401.insurance.interfaces.REST.resources;

namespace pc2_202401.insurance.interfaces.REST.Transform;

public class PolicyResourceFromEntityAssembler
{
    public static PolicyResource ToResource(Policy policy)
    {
        return new PolicyResource(policy.Id, policy.Productid, policy.Customer, policy.Address, policy.Dni, policy.Age);
    }
}