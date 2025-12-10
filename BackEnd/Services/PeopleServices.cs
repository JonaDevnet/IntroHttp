using BackEnd.Controllers;

namespace BackEnd.Services
{
    public class PeopleServices : IPeopleServices
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name))
            {
                return false;   
            }
            return true;
        }
    }
}
