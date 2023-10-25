using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        Context context = new Context();
        public List<Message> InboxList()
        {
            return context.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").ToList();
        }

        public List<Message> SentList()
        {
            return context.Messages.Where(x => x.SenderMail == "admin@gmail.com").ToList();
        }
    }
}
