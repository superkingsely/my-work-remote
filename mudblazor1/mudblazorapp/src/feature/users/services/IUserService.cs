using mudblazorapp.src.feature.users.Models;

namespace mudblazorapp.src.feature.users.Services;

public interface IUserService
{
    List<User> GetAll();

    User Add(User user);

    bool Update(User user);

    bool Delete(int id);
}