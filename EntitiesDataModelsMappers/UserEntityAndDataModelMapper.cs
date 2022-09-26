using Entities;
using DataModels;

namespace EntitiesDataModelsMappers
{
    public static class UserEntityAndDataModelMapper
    {
        public static UserDataModel UserEntityToData(UserEntity entity)
        {
            return new UserDataModel
            {
                Login = entity.Login,
            };
        }

        public static UserEntity UserDataToEntity(UserDataModel data, UserEntity? entity = null)
        {
            entity ??= new UserEntity();

            entity.Id = data.Id;
            entity.Login = data.Login;

            return entity;
        }
    }
}
