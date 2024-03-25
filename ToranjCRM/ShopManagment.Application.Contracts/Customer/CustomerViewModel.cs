namespace ShopManagement.Application.Contracts.Customer;

public class CustomerViewModel
{
    public long  Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalCode { get; set; }
    public long CompanyId { get; set; }
    public string Company { get; set; }
}