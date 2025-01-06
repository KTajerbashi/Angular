namespace Angular.ApplicationLibrary.Modules.Identity.Users.Queries.GetById;
public class UserGetByIdDTO
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Result { get; set; }
}



public class UserGetByIdView
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get => $"*{Username}* {FirstName} {LastName}";}
}

