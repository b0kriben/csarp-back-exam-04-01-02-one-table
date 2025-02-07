namespace Kreta.Shared.Assemblers
{
    public abstract class Assambler<Tmodel, TDto>
    {
        public abstract Tmodel ToModel(TDto dto);
        public abstract TDto ToDto(Tmodel domainEntity);
    }
}
