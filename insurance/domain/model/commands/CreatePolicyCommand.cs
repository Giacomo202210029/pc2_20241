namespace pc2_202401.insurance.domain.model.commands;

public record CreatePolicyCommand(string customer, int productid, string address, string dni, int age);