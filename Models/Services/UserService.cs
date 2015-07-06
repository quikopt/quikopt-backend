using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mangux.com.quikopt.Model
{
    public class PersonService : EntityService<User>, IUserService
    {
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;
        
        public PersonService(IUnitOfWork unitOfWork, IUserRepository userRepository)
            : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

    }
}
