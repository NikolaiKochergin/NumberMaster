using Source.Scripts.Data;
using Source.Scripts.Services.PersistentProgress;

namespace Tests.EditMode
{
    public abstract class Create
    {
        public static PersistentProgressService ProgressService()
        {
            return new PersistentProgressService();
        }

        public static PlayerProgress PlayerProgress()
        {
            return new PlayerProgress();
        }
    }
}