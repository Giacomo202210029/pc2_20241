namespace pc2_202401.insurance.interfaces.REST.resources;

public record CreatePolicyResource(int productid, string customer, string address, string dni, int age);