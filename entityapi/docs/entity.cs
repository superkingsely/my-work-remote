
// entity relationship
public class Church
{
    public List<UserChurch> Membership{get;set;}
}
public class UserChurch
{
    public Guid Id{get;set;}
    public string UserId{get;set;}
    public string ChurchId{get;set;}
}
public class User
{
    public List<UserChurch> Membership{get;set;}
    
}