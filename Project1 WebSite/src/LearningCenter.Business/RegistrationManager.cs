using System.Linq;
using LearningCenter.Repository;

namespace LearningCenter.Business
{
    public interface IRegistrationManager
    {
        RegistrationModel Add(int userId, int classId);
        bool Remove(int userId, int classId);
        RegistrationModel[] GetAll(int userId);
    }

    public class RegistrationModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public decimal ClassPrice { get; set; }
    }

    public class RegistrationManager : IRegistrationManager
    {
        private readonly IRegistrationRepository registrationRepository;
        private readonly IClassRepository classRepository;

        public RegistrationManager(IRegistrationRepository registrationRepository, IClassRepository classRepository)
        {
            this.registrationRepository = registrationRepository;
            this.classRepository = classRepository;
        }

        public RegistrationModel Add(int userId, int classId)
        {
            var item = registrationRepository.Add(userId, classId);

            return new RegistrationModel
            {
                ClassId = item.ClassId,
            };
        }

        public RegistrationModel[] GetAll(int userId)
        {
            var items = registrationRepository.GetAll(userId)
                .Select(t =>
                {
                    var classes = classRepository.GetClass(t.ClassId);

                    return new RegistrationModel
                    {
                        ClassId = t.ClassId,
                        ClassName = classes.Name,
                        ClassPrice = classes.Price
                    };
                })
                .ToArray();

            return items;
        }

        public bool Remove(int userId, int classId)
        {
            return registrationRepository.Remove(userId, classId);
        }
    }
}