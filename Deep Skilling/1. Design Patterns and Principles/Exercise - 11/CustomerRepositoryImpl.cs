namespace DependencyInjectionExample
{
    public class CustomerRepositoryImpl : CustomerRepository
    {
        public string FindCustomerById(int id)
        {
            return $"Customer Found with ID: {id}";
        }
    }
}