using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpTask.Models
{

  public class UserDetailBLL
    {
        public List<UserDetail> userDetails()
        {
            UserDetailDLL db = new UserDetailDLL();
            return db.userDetails();
        }
        public bool Create(UserDetail userDetail)
        {
            UserDetailDLL db = new UserDetailDLL();
            return db.Create(userDetail);

        }

        public bool Update(UserDetail userDetail)
        {
            UserDetailDLL db = new UserDetailDLL();
            return db.Update(userDetail);
        }
        public bool Delete(int id)
        {
            UserDetailDLL db = new UserDetailDLL();
            return db.Delete(id);
        }
        public UserDetail DetailsById(int id)
        {
            UserDetailDLL db = new UserDetailDLL();
            return db.DetailsById(id);
        }


    }

}