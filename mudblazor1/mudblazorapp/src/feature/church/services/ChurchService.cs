

using mudblazorapp.src.feature.church.Models;

namespace mudblazorapp.src.feature.church.Services;

public class ChurchService : IChurchService
{
    private readonly List<Church> _churches = new()
    {
        new Church
        {
            Name = "MFM Ijaiye",
            Address = "Ijaiye",
            City = "Lagos",
            State = "Lagos",
            ZipCode = "100001",
            PhoneNumber = "08000000000",
            Email = "info@example.com",
            ItHasBranch = true
        },
        new Church
        {
            Name = "Grace Chapel",
            Address = "Main Street",
            City = "Ibadan",
            State = "Oyo",
            PhoneNumber = "08100000000",
            Email = "grace@example.com",
            ItHasBranch = false
        }
    };

    public List<Church> GetAll()
        => _churches.ToList();

    public Church Add(Church church)
    {
        if (church.Id == Guid.Empty)
            church.Id = Guid.NewGuid();

        _churches.Add(church);

        return church;
    }

    public bool Update(Church church)
    {
        var existing = _churches.FirstOrDefault(x => x.Id == church.Id);

        if (existing is null)
            return false;

        existing.Name = church.Name;
        existing.Address = church.Address;
        existing.City = church.City;
        existing.State = church.State;
        existing.ZipCode = church.ZipCode;
        existing.PhoneNumber = church.PhoneNumber;
        existing.Email = church.Email;
        existing.ItHasBranch = church.ItHasBranch;

        return true;
    }

    public bool Delete(Guid id)
    {
        var church = _churches.FirstOrDefault(x => x.Id == id);

        if (church is null)
            return false;

        return _churches.Remove(church);
    }
}
