namespace pc2_202401.insurance.interfaces.REST.resources;

public record PolicyResource(int id, int productid, string customer, string address, string dni, int age);