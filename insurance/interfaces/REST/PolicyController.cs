using System.Net.Mime;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using pc2_202401.insurance.domain.model.queries;
using pc2_202401.insurance.domain.repositories;
using pc2_202401.insurance.domain.services;
using pc2_202401.insurance.interfaces.REST.resources;
using pc2_202401.insurance.interfaces.REST.Transform;

namespace pc2_202401.insurance.interfaces.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PolicyController : ControllerBase
{
    IPolicyCommandService _policyCommandService;
    IPolicyQueryService _policyQueryService;

    public PolicyController(IPolicyCommandService policyCommandService, IPolicyQueryService policyQueryService)
    {
        _policyCommandService = policyCommandService;
        _policyQueryService = policyQueryService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAgency([FromBody] CreatePolicyResource resource)
    {
        // Validación de productid
        if (resource.productid < 1 || resource.productid > 8)
        {
            return BadRequest("ProductId must be between 1 and 8.");
        }

        var validateByAddress =
            await _policyQueryService.Handle(
                new GetPolicyByCustomerAndProductIdQuery(resource.customer, resource.productid));

        if (validateByAddress == null)
        {
            var policy =
                await _policyCommandService.Handle(CreatePolicyCommandFromResourceAssembler
                    .ToCommand(resource));

            if (policy is null) return BadRequest();

            var policyResource = PolicyResourceFromEntityAssembler.ToResource(policy);

            return Ok(policyResource);
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPolicyById(int id)
    {
        var query = new GetPolicyByIdQuery(id); 
        var policy = await _policyQueryService.Handle(query);
        return Ok(PolicyResourceFromEntityAssembler.ToResource(policy));
    }
    
    [HttpGet("customer/{customer}/product/{productid}")]
    public async Task<IActionResult> GetPolicyByCustomerAndProductId(string customer, int productid)
    {
        var policy = await _policyQueryService.Handle(new GetPolicyByCustomerAndProductIdQuery(customer, productid));
        return Ok(PolicyResourceFromEntityAssembler.ToResource(policy));
    }
}