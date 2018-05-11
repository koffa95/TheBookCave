using TheBookCave.Models.ViewModels;
namespace TheBookCave.Services
{
    public interface IUserService
    {
        void processUser(RegisterViewModel user);
    }
}