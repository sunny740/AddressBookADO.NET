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
                    case 0:
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter the Correct Option\n");
                        break;
                }
            }
        }
    }
}