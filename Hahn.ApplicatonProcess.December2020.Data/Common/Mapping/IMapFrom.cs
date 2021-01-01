using AutoMapper;

namespace Hahn.ApplicatonProcess.December2020.Data.Common.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
