using pc2_202401.insurance.domain.model.aggregates;
using pc2_202401.insurance.domain.model.queries;

namespace pc2_202401.insurance.domain.services;

public interface IPolicyQueryService
{
    Task<Policy> Handle(GetPolicyByIdQuery query); 
    Task<Policy> Handle(GetPolicyByCustomerAndProductIdQuery query);
}