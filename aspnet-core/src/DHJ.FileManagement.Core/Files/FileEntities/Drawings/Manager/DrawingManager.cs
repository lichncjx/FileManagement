using Abp.Domain.Repositories;

namespace DHJ.FileManagement.Files.FileEntities.Drawings.Manager
{
    public class DrawingManager : FileManagerBase<Drawing>, IDrawingManager
    {
        public DrawingManager(IRepository<Drawing> tRepository) : base(tRepository)
        {
        }
    }
}