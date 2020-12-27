namespace BWAF.Data.Provisioning
{
    using BWAF.Data.Provisioning.Entities;

    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            EntityProvision entityProvision = new EntityProvision();
            entityProvision.ProvisionData(context);
        }
    }
}
