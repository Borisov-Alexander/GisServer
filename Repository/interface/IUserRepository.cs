using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using GisSystemServer.Entity;

namespace GisSystemServer.Repository 
{
    public interface  IUserRepository : IDisposable
    {
        void createCustomer(Customer customer);
        Customer getCustomerByEmail(string email);
        void updUser(Customer customer);
        void addMessage(Message message);
        List<Message> getAllMessage(string email);
        Message getMessageBy(int id , string email);
        Count getMessageCount(string email);
    }
}