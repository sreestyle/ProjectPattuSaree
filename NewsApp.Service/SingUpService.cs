using AutoMapper;
using PattuSaree.Data.Repositories;
using PattuSaree.Entity;
using PattuSaree.Data.Infrastructure;
using PattuSaree.ViewModel;
using PattuSaree.Service.Abstract;
using PattuSaree.Enums.Encryption;

namespace PattuSaree.Service
{
    public class SingUpService:ISignUpService
    {
        private readonly IEntityBaseRepository<UserMaster> _userMasterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SingUpService(IEntityBaseRepository<UserMaster> userMasterRepository,
                             IUnitOfWork unitOfWork)
        {
            _userMasterRepository = userMasterRepository;
            _unitOfWork = unitOfWork;
        }

        public void SingUp(UserMasterViewModel userVm)
        {
            var user= Mapper.Map<UserMasterViewModel,UserMaster>(userVm);
            user.HashedPassword = PattuSareeEncryption.Encrypt(userVm.Password);
            _userMasterRepository.Add(user);
            _unitOfWork.Commit();
        }
    }
}
