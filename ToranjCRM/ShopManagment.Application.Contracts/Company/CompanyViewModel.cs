namespace ShopManagement.Application.Contracts.Company;

public class CompanyViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Description { get; set; }
    public long ProductCount { get; set; }
}