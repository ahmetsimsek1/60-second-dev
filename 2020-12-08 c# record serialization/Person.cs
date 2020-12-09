// uncomment one of these

// public class Person
// {
//     public Person(int personID, string firstName, string lastName)
//         => (PersonID, FirstName, LastName) = (personID, firstName, lastName);
    
//     public int PersonID { get; set; }
//     public string FirstName { get; set; }
//     public string LastName { get; set; }

//     public override string ToString()
//     => $"Person {{ PersonID = {PersonID}, FirstName = {FirstName}, LastName = {LastName} }}";
// }

public record Person(int PersonID, string FirstName, string LastName);