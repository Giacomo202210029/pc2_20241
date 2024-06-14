

using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using pc2_202401.insurance.domain.model.aggregates;
using pc2_202401.insurance.domain.model.commands;
using pc2_202401.insurance.domain.repositories;
using pc2_202401.insurance.domain.services;

namespace pc2_202401.insurance.Application.Internal.CommandServices;

public class PolicyCommandService : IPolicyCommandService
{
    IPolicyRepository _repository;
    IUnitOfWork _unitOfWork;

    public PolicyCommandService(IPolicyRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Policy> Handle(CreatePolicyCommand command)
    {
        //todo estara bien que vayan aqui la logica de negocio
        var existingPolicy = await _repository.GetPolicyByCustomerAndProductId(command.customer, command.productid);
        if(existingPolicy != null)
            throw new Exception("Policy with the same ProductId and Customer already exists");
        var newpolicy = new Policy(command);
        await _repository.AddAsync(newpolicy);
        await _unitOfWork.CompleteAsync();
        return newpolicy; 

    }
}