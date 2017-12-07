using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace OP_VitalsDAL
{
    public class EmployeeDatabase
    {
        private SqlDataReader rdr; // Datalæseren
        private SqlCommand cmd;
        private const String db = "F17ST2ITS2201607660";

        private SqlConnection OpenConnection
        {
            get
            {
                var connLocal = new SqlConnection("Data Source=i4dab.ase.au.dk;Initial Catalog=" + db + ";Persist Security Info=True;User ID=" + db + ";Password=" + db + "");

                connLocal.Open();

                return connLocal;
            }
        }

        public bool ValidateLogin(EmployeeDTO Employee)
        {
            bool result_ = false;
            cmd = new SqlCommand("select EmployeeFirstName, EmployeeLastName, Profession, PassWord from EmployeeDatabase where EmployeeID =" + Employee.EmployeeID_, OpenConnection);

            rdr = cmd.ExecuteReader(); //iterator løber det igennem

            if (rdr.Read() == true && string.Equals(rdr["PassWord"].ToString(), Employee.Password_))
            {
                result_ = true;
                //indsæt data fra database

                Employee.FirstName_ = rdr["EmployeeFirstName"].ToString(); //rdr["FirstName"]
                Employee.LastName_ = rdr["EmployeeLastName"].ToString(); // rdr["LastName"]
                Employee.Profession_ = rdr["Profession"].ToString();
                //Tjek at det er de rigtige værdier der indlæses
            }

            OpenConnection.Close();
            return result_;
        }


    }
}
