using HumanFriends.Domain.Entity;
using HumanFriends.Entity.Response;

namespace HumanFriends.Service.Interfaces
{
    public interface IBaseService<T>
    {
        Task<IBaseResponse<IEnumerable<T>>> GetAnimals();
        Task<IBaseResponse<bool>> DeleteAnimal(int id);
        Task<IBaseResponse<T>> CreateAnimal(T animalView);
        Task<IBaseResponse<T>> EditAnimal(int id, T animalView);
        BaseResponse<List<TypeAnimal>> GetTypes();
        Task<IBaseResponse<T>> GetAnimal(int id);
    }
}
