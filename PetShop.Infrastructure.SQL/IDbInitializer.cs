namespace PetShop.Infrastructure.SQL
{
    public interface IDbInitializer
    {
        void Initialize(PetShop2019Context context);
    }
}