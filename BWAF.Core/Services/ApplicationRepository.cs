namespace BWAF.Core.Services
{
    using BWAF.Data;
    using BWAF.Data.Repositories.Services;

    public class ApplicationRepository: Repository<Context>
    {
        public ApplicationRepository(Context context) : base(context) {}
    }
}
