using HumanFriends.DAL.Interfaces;
using HumanFriends.DAL.Repositories;
using HumanFriends.Domain.Entity;
using HumanFriends.Entity.Enum;
using HumanFriends.Entity.Response;
using HumanFriends.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HumanFriends.Service.Implementations
{
    public class AnimalService : IBaseService<Animal>
    {
        public Animal Animal { set; get; }

        private readonly IBaseRepository<Animal> baseRepository;
        private readonly IBaseRepository<TypeAnimal> typeAnimalRepository;

        public AnimalService(IBaseRepository<Animal> baseRepository, IBaseRepository<TypeAnimal> typeAnimalRepository)
        {
            this.baseRepository = baseRepository;
            this.typeAnimalRepository = typeAnimalRepository;
        }

        public async Task<IBaseResponse<bool>> DeleteAnimal(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var animal = await baseRepository.GetAll().FirstOrDefaultAsync(x => x.ID == id);

                if (animal == null)
                {
                    baseResponse.Description = "Animal is Not Found";
                    baseResponse.StatusCode = StatusCode.AnimalNotFound;
                    return baseResponse;
                }
                await baseRepository.Delete(animal);
                baseResponse.Data = true;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCar]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<Animal>> CreateAnimal(Animal animalView)
        {
            var baseResponse = new BaseResponse<Animal>();
            try
            {
                var animal = new Animal()
                {
                    Name = animalView.Name,
                    Birthday = animalView.Birthday,
                    TypeAnimal = animalView.TypeAnimal
                };
                await baseRepository.Create(animal);
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Animal>()
                {
                    Description = $"[CreateAnimal]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Animal>>> GetAnimals()
        {
            var baseResponse = new BaseResponse<IEnumerable<Animal>>();
            try
            {
                var animals = await baseRepository.GetAll().ToListAsync();
                if (animals.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = animals;
                baseResponse.StatusCode = StatusCode.OK;


            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Animal>>()
                {
                    Description = $"[GetAnimals]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<Animal>> EditAnimal(int id, Animal animalView)
        {
            var baseResponse = new BaseResponse<Animal>();
            try
            {
                var animal = await baseRepository.GetAll().FirstOrDefaultAsync(x => x.ID == id);
                if (animal == null)
                {
                    baseResponse.Description = "Animal is Not Found";
                    baseResponse.StatusCode = StatusCode.AnimalNotFound;
                    return baseResponse;
                }
                animal.Name = animalView.Name;
                animal.Birthday = animalView.Birthday;
                animal.TypeAnimal = animalView.TypeAnimal;
                await baseRepository.Update(animal);
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Animal>()
                {
                    Description = $"[CreateAnimal]: {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }



        public BaseResponse<List<TypeAnimal>> GetTypes()
        {
            try
            {
                var types = typeAnimalRepository.GetAll().ToList();

                return new BaseResponse<List<TypeAnimal>> ()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<TypeAnimal>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Animal>> GetAnimal(int id)
        {
            try
            {
                var animal = await baseRepository.GetAll().FirstOrDefaultAsync(x => x.ID == id);
                if (animal == null)
                {
                    return new BaseResponse<Animal>()
                    {
                        Description = "Animal Not Found",
                        StatusCode = StatusCode.AnimalNotFound
                    };
                }


                return new BaseResponse<Animal>()
                {
                    StatusCode = StatusCode.OK,
                    Data = animal
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Animal>()
                {
                    Description = $"[GetAnimal] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }





    }
}