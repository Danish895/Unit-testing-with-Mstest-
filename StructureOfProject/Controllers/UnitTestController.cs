using StructureOfProject.Models;

namespace StructureOfProject.Controllers
{
    public class UnitTestController
    {
        public User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            return (user.IsAdmin || MadeBy == user);
        }
    }
}
