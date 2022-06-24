using AddressBookADO.NET;

namespace AddressBookProblem
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Welcome in The AddressBook Service\n");
            AddressBook payrollService = new AddressBook();
            bool check = true;


            while (check)
            {
                Console.WriteLine("1. To Insert the Data in DataBase\n");
                Console.WriteLine("Enter the Above Option\n");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddressBookModel empModel = new AddressBookModel();
                        //empModel.Id = 1;
                        empModel.FirstName = "Sunny";
                        empModel.LastName = "Sejwar";
                        empModel.Address = "Chhawani";
                        empModel.City = "Gwa";
                        empModel.State = "MP";

                        empModel.ZipCode = 491335;
                        empModel.PhoneNumber = "7598625487";
                        empModel.Email = "sunny@12gmail.com";

                        payrollService.AddContact(empModel);
                        break;
                    case 2:
                        List<AddressBookModel> empList = empservice.GetAllEmployees();
                        foreach (AddressBookModel data in empList)
                        {
                            Console.WriteLine(data.Id + " " + data.FirstName + " " + data.LastName + " " + data.Address + " " + data.City + " " + data.State + " " + data.ZipCode + " " + data.PhoneNumber + " " + data.Email);
                        }
                        break;
                    case 3:
                        AddressBookModel emp = new AddressBookModel();
                        emp.Id = 1;

                        emp.PhoneNumber = "7847850147";
                        empservice.UpdateEmp(emp);
                        break;
                    case 4:
                        List<AddressBookModel> eList = payrollService.GetAllEmployees();
                        Console.WriteLine("Enter the Contact Id to Delete the Record  From the Table");
                        int empId = Convert.ToInt32(Console.ReadLine());
                        foreach (AddressBookModel data in eList)
                        {
                            if (data.Id == empId)
                            {
                                payrollService.DeleteEmployee(empId);
                                Console.WriteLine("Record Successfully Deleted");
                            }
                            else
                            {
                                Console.WriteLine(empId + "is Not present int he Data base");
                            }
                        }
                        break;
                    case 0:
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter the Correct option");
                        break;
                }
            }
        }
    }
}