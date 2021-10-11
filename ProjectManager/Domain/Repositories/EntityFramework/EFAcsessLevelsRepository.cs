using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Domain.Repositories.EntityFramework
{
    public class EFAcsessLevelsRepository : IAcsessLevelsRepository
    {
        private readonly ProjectManagerDBContext context;

        public EFAcsessLevelsRepository(ProjectManagerDBContext context)
        {
            this.context = context;
        }

        public void deleteAcsessLevel(Guid id)
        {
            context.AcsessLevels.Remove(new AcsessLevel() { Id = id });
        }

        public AcsessLevel getAcsessLevelbyId(Guid id)
        {
            return context.AcsessLevels.FirstOrDefault(x => x.Id == id);
        }

        public AcsessLevel getAcsessLevelbyTitle(string title)
        {
            return context.AcsessLevels.FirstOrDefault(x => x.Acsesslevel == title);
        }

        public IQueryable<AcsessLevel> getAcsessLevels()
        {
            return context.AcsessLevels;

        }

        public void saveAcsessLevel(AcsessLevel level)
        {
            if (level.Id == default)
            {
                context.Entry(level).State = EntityState.Added;
            }
            else
            {
                context.Entry(level).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
