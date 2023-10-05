using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager()
        {
        }

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void TDelete(Heading t)
        {
            _headingDal.Delete(t);
            
        }

        public Heading TGetByID(int id)
        {
            return _headingDal.GetByID(id);
        }

        public List<Heading> TGetList()
        {
            return _headingDal.GetList();
        }

        public void TInsert(Heading t)
        {
            _headingDal.Insert(t);
        }

        public void TUpdate(Heading t)
        {
            _headingDal.Update(t);
        }
    }
}
