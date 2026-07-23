using System;

namespace DependencyInjectionExample
{
    public class CustomerService
    {
        private readonly CustomerRepository repository;

        // Constructor Injection
        public CustomerService(CustomerRepository repository)
        {
            this.repository = repository;
        }

        public void GetCustomer(int id)
        {
            Console.WriteLine(repository.FindCustomerById(id));
        }
    }
}