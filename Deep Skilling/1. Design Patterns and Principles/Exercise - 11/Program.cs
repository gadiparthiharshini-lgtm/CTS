using DependencyInjectionExample;

CustomerRepository repository = new CustomerRepositoryImpl();

CustomerService service = new CustomerService(repository);

service.GetCustomer(101);