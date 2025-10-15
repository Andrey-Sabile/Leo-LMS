namespace LeoLMS.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    private Address(string street1, string street2, string city, string state, int postalCode, string country)
    {
        Street1 = street1;
        Street2 = street2;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    public string Street1 { get; }
    public string Street2 { get; }
    public string City { get; }
    public string State { get; }
    public int PostalCode { get; }
    public string Country { get; }

    public static Address Create(string street1, string street2, string city, string state, int postalCode, string country)
    {
        return new Address(street1, street2, city, state, postalCode, country);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street1;
        yield return Street2;
        yield return City;
        yield return State;
        yield return PostalCode;
        yield return Country;
    }
}