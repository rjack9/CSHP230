using LearningCenter.ProductDatabase;
using System.Linq;

namespace LearningCenter.Repository
{
    public interface IRegistrationRepository
    {
        RegistrationModel Add(int userId, int classId);
        bool Remove(int userId, int classId);
        RegistrationModel[] GetAll(int userId);
    }

    public class RegistrationModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }

    public class RegistrationRepository : IRegistrationRepository
    {
        public RegistrationModel Add(int userId, int classId)
        {
            var item = DatabaseAccessor.Instance.UserClass.Add(
                new LearningCenter.ProductDatabase.UserClass
                {
                    ClassId = classId,
                    UserId = userId,
                });

            DatabaseAccessor.Instance.SaveChanges();

            return new RegistrationModel
            {
                UserId = item.Entity.UserId,
                ClassId = item.Entity.ClassId,
            };
        }

        public RegistrationModel[] GetAll(int userId)
        {
            var items = DatabaseAccessor.Instance.UserClass
                .Where(t => t.UserId == userId)
                .Select(t => new RegistrationModel
                {
                    UserId = t.UserId,
                    ClassId = t.ClassId,
                })
                .ToArray();
            return items;
        }

        public bool Remove(int userId, int classId)
        {
            var items = DatabaseAccessor.Instance.UserClass
                                .Where(t => t.UserId == userId && t.ClassId == classId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseAccessor.Instance.UserClass.Remove(items.First());

            DatabaseAccessor.Instance.SaveChanges();

            return true;
        }
    }
}