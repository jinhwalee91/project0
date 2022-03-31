using System;
using System.Data.SqlClient;


namespace hotel_booking{

class security {

#region Properties (username, password)
public string username {get ; set;}
public string password {get; set;}

#endregion

#region Login Method
public bool Login (string username, string password) {

SqlConnection con = new SqlConnection("server=DESKTOP-TDF3AT3\\SQLEXPRESS; database=project0; integrated security=true");

SqlCommand cmd_login = new SqlCommand ("select count (*) from accounts where username=@username and password =@password",con);

cmd_login.Parameters.AddWithValue("@username",username);
cmd_login.Parameters.AddWithValue("@password",password);

try {
    con.Open();
    int login_count =(int) cmd_login.ExecuteScalar();
    if (login_count > 0)
    {
        return true ; 
    }
    else {
        return false ; 
    }
}
catch (System.Exception ex) 
{
throw new Exception (ex.Message);
}
finally 
{
    con.Close();
}
#endregion

         }

    }




}