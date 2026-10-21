


using mudblazorapp.src.feature.church.Models;

namespace mudblazorapp.src.feature.church.Services;

public interface IChurchService
{
    List<Church> GetAll();
    Church Add(Church church);
    bool Update(Church church);
    bool Delete(Guid id);
}
