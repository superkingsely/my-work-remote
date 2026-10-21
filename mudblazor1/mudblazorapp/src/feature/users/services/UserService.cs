

using mudblazorapp.src.feature.users.Models;

namespace mudblazorapp.src.feature.users.Services;

public class UserService : IUserService
{
    private readonly List<User> _users =
    [
        new User
        {
            Id = 1,
            Name = "Chijioke",
            Email = "chijioke@example.com",
            Occupation = "Software Developer"
        },
        new User
        {
            Id = 2,
            Name = "Ada",
            Email = "ada@example.com",
            Occupation = "Accountant"
        },
        new User
        {
            Id = 3,
            Name = "David",
            Email = "david@example.com",
            Occupation = "Teacher"
        }
    ];

    private int _nextId = 4;

    public List<User> GetAll()
    {
        return _users.ToList();
    }

    public User Add(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);

        return user;
    }

    public bool Update(User user)
    {
        var existingUser = _users.FirstOrDefault(x => x.Id == user.Id);

        if (existingUser is null)
            return false;

        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.Occupation = user.Occupation;

        return true;
    }

    public bool Delete(int id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);

        if (user is null)
            return false;

        return _users.Remove(user);
    }
}