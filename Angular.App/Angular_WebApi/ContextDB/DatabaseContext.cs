using Angular_WebApi.Models.Security.User;

namespace Angular_WebApi.ContextDB;

public static class DatabaseContext
{
    private static List<UserDTO> Users = new List<UserDTO>()
    {
        new UserDTO { Id = 1, Name = "Kamran", Family = "Tajerbashi", Phone = "09011001233", Email = "Kamran@mail.com" },
        new UserDTO { Id = 2, Name = "Reza", Family = "Attaii", Phone = "0323238923", Email = "Reza@mail.com" },
        new UserDTO { Id = 3, Name = "Javad", Family = "Karimi", Phone = "234234", Email = "Javad@mail.com" },
        new UserDTO { Id = 4, Name = "Sharif", Family = "Amini", Phone = "234234234", Email = "Sharif@mail.com" },
        new UserDTO { Id = 5, Name = "Mohammad", Family = "Mahamoudi", Phone = "2342342342342", Email = "Mohammad@mail.com" },
        new UserDTO { Id = 6, Name = "Mashoud", Family = "Kaboudany", Phone = "23424352656456", Email = "Mashood@mail.com" }
    };
    public static void SetUser(UserDTO model)
    {
        Users.Add(model);
    }
    public static void SetUsers(List<UserDTO> users)
    {
        Users = users;
    }
    public static List<UserDTO> GetUsers()
    {
        return Users.ToList();
    }
    public static void RemoveUser(UserDTO model)
    {
        Users.Remove(model);
    }
}
