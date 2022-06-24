﻿using AddressBookProblem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO.NET
{
    public class AddressBook
    {
        private SqlConnection con;
        private void connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookADO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(connectingString);
        }
        public string AddContact(AddressBookModel obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("spAddNewPersons", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@FirstName", obj.FirstName);
                com.Parameters.AddWithValue("@LastName", obj.LastName);
                com.Parameters.AddWithValue("@Address", obj.Address);
                com.Parameters.AddWithValue("@City", obj.City);
                com.Parameters.AddWithValue("@State", obj.State);

                com.Parameters.AddWithValue("@ZipCode", obj.ZipCode);
                com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                com.Parameters.AddWithValue("@Email", obj.Email);


                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i != 0)
                {
                    return "data Added";
                }
                else
                {
                    return "data not added";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
        }
        public List<AddressBookModel> GetAllEmployees()
        {
            connection();
            List<AddressBookModel> EmpList = new List<AddressBookModel>();
            SqlCommand com = new SqlCommand("spViewContacts", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new AddressBookModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Address = Convert.ToString(dr["Address"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        ZipCode = Convert.ToInt32(dr["ZipCode"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        Email = Convert.ToString(dr["Email"]),

                    }
                    );
            }
            return EmpList;
        }
        //To Update Emp data   
        public bool UpdateEmp(AddressBookModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("SPUpdateDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);

            com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete details
        public bool DeleteEmployee(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("spDeletePersonById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Retrieve Data from City or State

        public string PrintDataBasedOnCity(string City, string State)
        {
            string nameList = "";
            string query = @"select * from AddressBook_Table where City =" + City + " or State=" + State;
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    DisplayEmployeeDetails(sqlDataReader);
                    nameList += sqlDataReader["FirstName"].ToString() + " ";
                }
            }
            return nameList;
        }
        Contact Contact = new Contact();
        public void DisplayEmployeeDetails(SqlDataReader sqlDataReader)
        {
            Contact.Firstname = Convert.ToString(sqlDataReader["FirstName"]);
            Contact.Lastname = Convert.ToString(sqlDataReader["LastName"]);
            Contact.Address = Convert.ToString(sqlDataReader["Address"] + " " + sqlDataReader["City"] + " " + sqlDataReader["State"] + " " + sqlDataReader["zip"]);
            Contact.PhoneNumber = Convert.ToInt64(sqlDataReader["PhoneNumber"]);
            Contact.Email = Convert.ToString(sqlDataReader["email"]);
            Contact.Zip = Convert.ToInt64(sqlDataReader["Zip"]);
            Contact.Type = Convert.ToString(sqlDataReader["Type"]);
            Console.WriteLine("{0} \n {1} \n {2} \n {3} \n {4} \n {5} \n {6}", Contact.Firstname, Contact.Lastname, Contact.Address, Contact.PhoneNumber, Contact.Email, Contact.Zip, Contact.Type);
        }
    }
}
