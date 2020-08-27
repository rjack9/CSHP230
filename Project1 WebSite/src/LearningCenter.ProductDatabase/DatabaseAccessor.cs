using LearningCenter.ProductDatabase;

namespace LearningCenter.ProductDatabase
{
    public class DatabaseAccessor
    {
        static DatabaseAccessor()
        {
            Instance = new minicstructorContext();
        }

        public static minicstructorContext Instance { get; private set; }
    }

}