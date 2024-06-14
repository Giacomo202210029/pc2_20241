using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using pc2_202401.insurance.domain.model.aggregates;
using pc2_202401.insurance.domain.model.queries;
using pc2_202401.insurance.domain.repositories;
using pc2_202401.insurance.domain.services;

namespace pc2_202401.insurance.Application.Internal.CommandServices;

public class PolicyQueryService : IPolicyQueryService
{
    IPolicyRepository _policyRepository;
    IUnitOfWork _unitOfWork;

    public PolicyQueryService(IPolicyRepository policyRepository, IUnitOfWork unitOfWork)
    {
        _policyRepository = policyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Policy> Handle(GetPolicyByIdQuery query)
    {
        return await _policyRepository.GetPolicyById(query.id);
    }

    public async Task<Policy> Handle(GetPolicyByCustomerAndProductIdQuery query)
    {
        return await _policyRepository.GetPolicyByCustomerAndProductId(query.customer, query.productid);
    }
}