using pc2_202401.insurance.domain.model.commands;
using pc2_202401.insurance.interfaces.REST.resources;

namespace pc2_202401.insurance.interfaces.REST.Transform;

public class CreatePolicyCommandFromResourceAssembler
{
    public static CreatePolicyCommand ToCommand(CreatePolicyResource resource)
    {
        return new CreatePolicyCommand(resource.customer, resource.productid, resource.address, resource.dni,
            resource.age); 
    }
}