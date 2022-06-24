using AddressBookADO.NET;

namespace AddressBookProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            addressBook.SetConnection();
        }
    }
}