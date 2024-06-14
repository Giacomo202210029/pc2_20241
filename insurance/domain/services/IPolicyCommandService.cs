using pc2_202401.insurance.domain.model.aggregates;
using pc2_202401.insurance.domain.model.commands;

namespace pc2_202401.insurance.domain.services;

public interface IPolicyCommandService
{
    Task<Policy> Handle(CreatePolicyCommand command);
}