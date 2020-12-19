namespace BWAF_Core.Services
{
    using BWAF_DAL;
    using BWAF_DAL.Repositories.Services;

    public class ApplicationRepository: Repository<Context>
    {
        public ApplicationRepository(Context context) : base(context) {}
    }
}
