using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2009M1NguyenCuongUWP.Data;
using T2009M1NguyenCuongUWP.Entities;

namespace T2009M1NguyenCuongUWP.Models
{
    public class ContactModel
    {
        private static string _insertStatementTemplate = "INSERT INTO contacts (Name, PhoneNumber)" +
             "values (@name, @phonenumber)";
        private static string _selectStatementTemplate = "SELECT * FROM contacts";
        private static string _selectStatementWithConditionTemplate = "SELECT * FROM contacts WHERE Name like @keyword";

        public bool Save(Contact contact)
        {
            try
            {
                using (SqliteConnection cnn = new SqliteConnection($"Filename = {DatabaseContact._databasePath}"))
                {
                    cnn.Open();
                    SqliteCommand insertCommand = new SqliteCommand(_insertStatementTemplate, cnn);
                    insertCommand.Parameters.AddWithValue("@name", contact.Name);
                    insertCommand.Parameters.AddWithValue("@phonenumber", contact.PhoneNumber);                   
                    insertCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }


        public List<Contact> FindAll()
        {
            List<Contact> result = new List<Contact>();
            try
            {
                // Mở kết nối.
                using (SqliteConnection cnn = new SqliteConnection($"Filename = {DatabaseContact._databasePath}"))
                {
                    cnn.Open();
                    // Tạo câu lệnh.
                    SqliteCommand command = new SqliteCommand(_selectStatementTemplate, cnn);
                    // bắn lệnh vào và lấy dữ liệu.
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {                       
                        var name = Convert.ToString(reader["Name"]);
                        var phonenumber = Convert.ToString(reader["PhoneNumber"]);
                        var contact = new Contact()
                        {
                            Name = name,
                            PhoneNumber = phonenumber
                        };
                        result.Add(contact);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return result;
        }


        public List<Contact> SearchByKeyword(string keyword)
        {
            List<Contact> contacts = new List<Contact>();
            try
            {
                // Mở kết nối.
                using (SqliteConnection cnn = new SqliteConnection($"Filename = {DatabaseContact._databasePath}"))
                {
                    cnn.Open();
                    // Tạo câu lệnh.
                    SqliteCommand command = new SqliteCommand(_selectStatementWithConditionTemplate, cnn);
                    command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    // bắn lệnh vào và lấy dữ liệu.                  
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var name = Convert.ToString(reader["Name"]);
                        var phonenumber = Convert.ToString(reader["PhoneNumber"]);
                        var contact = new Contact()
                        {
                            Name = name,
                            PhoneNumber = phonenumber
                        };
                        contacts.Add(contact);
                    }                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return contacts;
        }
    }
}
