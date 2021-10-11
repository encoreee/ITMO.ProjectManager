using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Repositories.Abstract
{
    public interface IAcsessLevelsRepository
    {
        IQueryable<AcsessLevel> getAcsessLevels();
        AcsessLevel getAcsessLevelbyId(Guid id);
        AcsessLevel getAcsessLevelbyTitle(String title);
        void saveAcsessLevel(AcsessLevel level);
        void deleteAcsessLevel(Guid id);
    }
}
