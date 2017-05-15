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

        public Customer getCustomerByEmail(string email)
        {
            return (Customer)context.customer.FirstOrDefault(m => m.email == email);
        }
    }
}