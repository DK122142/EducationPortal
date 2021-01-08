using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;

namespace CustomersLinq
{
    public static class Operations
    {
        public static Customer FirstRegistered(List<Customer> customers)
        {
            return customers.OrderBy(customer => customer.RegistrationDate).First();
        }

        public static double AverageBalance(List<Customer> customers)
        {
            return customers.Average(customer => customer.Balance);
        }

        public static IEnumerable<Customer> FilterByDate(List<Customer> customers, DateTime from, DateTime to)
        {
            return customers.Where(customer =>
                customer.RegistrationDate >= from && customer.RegistrationDate <= to
            );
        }

        public static IEnumerable<Customer> FilterById(List<Customer> customers, int idFrom, int idTo)
        {
            return customers.Where(customer => customer.Id >= idFrom && customer.Id <= idTo);
        }

        public static IEnumerable<Customer> FilterByName(List<Customer> customers, string input)
        {
            return customers.Where(customer => customer.Name.ToLower().Contains(input.ToLower()));
        }

        public static IEnumerable<IOrderedEnumerable<Customer>> SimilarMonthCustomers(List<Customer> customers)
        {
            return customers.OrderBy(customer => 
                customer.RegistrationDate).GroupBy(byDate => 
                byDate.RegistrationDate.Month).Select(g => 
                g.OrderBy(c => c.Name));
        }

        public static IEnumerable<Customer> ByField(List<Customer> customers, string field, bool isDescending = false)
        {
            if (isDescending)
            {
                return customers.OrderByDescending(customer => GetMethodInvoke(customer, field));
            }
            return customers.OrderBy(customer => GetMethodInvoke(customer, field));
            
        }

        private static object? GetMethodInvoke(Customer customer, string field)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            var fieldName = ti.ToTitleCase(field.ToLower());
            var type = typeof(Customer);
            var act = Activator.CreateInstance(type, new object[]
            {
                customer.Id, customer.Name, customer.RegistrationDate, customer.Balance
            });
            var member = type.GetMember(fieldName);
            var method = type.GetMethod($"get_{fieldName}");
            var res = method.Invoke(act, null);
            return res;
        }

        public static string AllNames(List<Customer> customers)
        {
            return string.Join(",", customers.Select(customer => customer.Name));
        }


    }
}
