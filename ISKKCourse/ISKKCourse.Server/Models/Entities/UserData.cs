using System.ComponentModel.DataAnnotations;

namespace ISKKCourse.Server.Models.Entities
{
    public class UserData(string firstName, string lastName, string phoneNumber, string personalCode): Entity<int>
    {
        [MaxLength(30)] public string FirstName { get; private set; } = firstName;
        [MaxLength(30)] public string LastName { get; private set; } = lastName;
        [MaxLength(11)] public string PhoneNumber { get; private set; } = phoneNumber;
        [MaxLength (11)] public string PersonalCode { get; private set; } = personalCode;
    }
}
