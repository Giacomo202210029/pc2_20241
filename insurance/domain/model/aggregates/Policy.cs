using pc2_202401.insurance.domain.model.commands;

namespace pc2_202401.insurance.domain.model.aggregates;

public partial class Policy
{
    public int Id { get; set; }
    public string Customer { get; set; }
    public int Productid { get; set; }
    public string Address { get; set; }
    public string Dni { get; set; }
    public int Age { get; set; }
    //todo ver los createdAt 
    

    public Policy(CreatePolicyCommand command)
    {
        this.Customer = command.customer; 
        this.Productid = command.productid;
        this.Address = command.address;
        this.Dni = command.dni;
        this.Age = command.age;

        
    }
}