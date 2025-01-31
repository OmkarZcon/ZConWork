using Pagination.Models;

namespace Pagination.Services
{
    public class PropertyServices
    {
        static List<Property> Property { get; }
        static int nextId = 3;

        static PropertyServices()
        {
            Property = new List<Property>
            {
                new Property { propertyId = 1, PropertyName = "Ashiyana", isVerified = false },
                new Property { propertyId = 2, PropertyName = "Jindal", isVerified = true },
                 new Property { propertyId = 3, PropertyName = "Jesal green", isVerified = false },
                 
               
            };
        }


        //get all employees from employee list
        public static List<Property> GetAll() => Property;


        //filtering employee record by employee id
        public static Property? Get(int id) => Property.FirstOrDefault(e => e.propertyId == id);


        //add employee record to employee list
        public static void Add(Property property)
        {
            property.propertyId = nextId++;
            Property.Add(property);
        }

        //delete employee record in employee list
        public static void Delete(int id)
        {
            var property = Get(id);
            if (property is null)
                return;
            Property.Remove(property);
        }


        //update employee record
        public static void Update(Property property)
        {
            var index = Property.FindIndex(e => e.propertyId == property.propertyId);
            if (index == -1)
                return;
            Property[index] = property;
        }
    }
}
