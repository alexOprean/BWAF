﻿namespace BWAF_DAL.Provisioning.Entities
{
    using BWAF_DAL.Models;
    using System.Linq;

    public class EntityProvision
    {
        public void ProvisionData(Context context)
        {
            if (context.Entities.Any())
            {
                return;
            }

            Entity[] entities = new Entity[]
            {
                new Entity{ Name = "FirstEntity" },
                new Entity{ Name = "SecondEntity" },
                new Entity{ Name = "ThirdEntity" }
            };

            context.Entities.AddRange(entities);
            context.SaveChanges();
        }
    }
}
