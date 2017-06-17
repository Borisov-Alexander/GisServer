using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GisSystemServer.Entity;
using GisSystemServer.Context;

namespace GisSystemServer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;
        private Boolean Disposed;
        public UserRepository(UserContext _context)
        {
            context = _context;
        }

        public void addMessage(Message message)
        {
            context.message.Add(message);
            context.SaveChanges();
        }

        public void createCustomer(Customer customer)
        {
            context.customer.Add(customer);
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (context != null)
                {
                    context.Dispose();

                    Disposed = true;
                }
            }
        }

        public List<Message> getAllMessage(string email)
        {
            return context.message.Where(m => m.forCustomer == email).ToList();
        }

        public Count getMessageCount(string email)
        {
            List<Message> list = context.message.Where(m => m.forCustomer == email).ToList();
            Count count = new Count();
            count.materialCount = list.Count;
            return count;
        }



        public Customer getCustomerByEmail(string email)
        {
            return (Customer)context.customer.FirstOrDefault(m => m.email == email);
        }

        public Message getMessageBy(int id , string email)
        {
            return context.message.FirstOrDefault(m => m.messageId == id);
        }

        public void updUser(Customer customer)
        {
            Customer cust = context.customer.Find(customer.customerId);
            cust.adress = customer.adress;
            cust.city = customer.city;
            cust.company = customer.company;
            cust.country = customer.country;
            cust.description = customer.description;
            cust.firstName = customer.firstName;
            cust.lastName = customer.lastName;
            cust.userName = customer.userName;
            context.SaveChanges();
        }
    }
}