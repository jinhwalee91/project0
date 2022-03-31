using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace hotel_booking {
public class customerDetails {

#region properties (booking_no / first_name / last_name / payment / service_date )
public int booking_no { get; set; }
public string first_name { get; set; }
public string last_name { get; set; }
public string payment { get; set; }
public string service_date { get; set; }
public string email { get; set; }

#endregion

#region SQL Connection 
SqlConnection con = new SqlConnection("server=DESKTOP-TDF3AT3\\SQLEXPRESS; database=project0; integrated security=true");
#endregion

#region METHOD : Add Customer 
public string AddNewCustomer(customerDetails newCustomer){

SqlCommand cmd_addProduct = new SqlCommand ("Insert into customer values (@first_name,@last_name,@payment,@service_date,@email)",con);

cmd_addProduct.Parameters.AddWithValue("@first_name",newCustomer.first_name);
cmd_addProduct.Parameters.AddWithValue("@last_name",newCustomer.last_name);
cmd_addProduct.Parameters.AddWithValue("@payment",newCustomer.payment);
cmd_addProduct.Parameters.AddWithValue("@service_date",DateTime.Parse(newCustomer.service_date)); 
cmd_addProduct.Parameters.AddWithValue("@email",newCustomer.email);

try 
{
    con.Open();
    cmd_addProduct.ExecuteNonQuery();
}
catch(SqlException ex)
{
    System.Console.WriteLine(ex.Message);
}
finally
{
    con.Close();
}

Console.Clear();
return "Your reservation added successfully"  ;
    
}

#endregion

#region METHOD Change the Reservation 
public string updateReservation(customerDetails rsvchange){

SqlCommand cmd_updateReservatioin = new SqlCommand ("Update customer set first_name = @newfirst_name, last_name = @newlast_name, payment=@newpayment,service_date=@newservice_date, email=@newemail where booking_no=@booking_no",con);

cmd_updateReservatioin.Parameters.AddWithValue("@newfirst_name",rsvchange.first_name);
cmd_updateReservatioin.Parameters.AddWithValue("@newlast_name",rsvchange.last_name);
cmd_updateReservatioin.Parameters.AddWithValue("@newpayment",rsvchange.payment);
cmd_updateReservatioin.Parameters.AddWithValue("@newservice_date",DateTime.Parse(rsvchange.service_date)); 
cmd_updateReservatioin.Parameters.AddWithValue("@newemail",rsvchange.email);
cmd_updateReservatioin.Parameters.AddWithValue("@booking_no",rsvchange.booking_no);

try 
{
    con.Open();
    cmd_updateReservatioin.ExecuteNonQuery();
}
catch (System.Exception ex)
{
System.Console.WriteLine(ex.Message);
}

finally
{
    con.Close();
}
Console.Clear();
return "Your reservation has been updated!";
}

#endregion

#region METHOD for deleting customer
public string cancelReservation(int booking_no_forcancel){

SqlCommand cmd_cancelReservatioin = new SqlCommand ("delete from customer where booking_no=@booking_no",con);

cmd_cancelReservatioin.Parameters.AddWithValue("@booking_no",booking_no_forcancel);

try 
{
    con.Open();
    cmd_cancelReservatioin.ExecuteNonQuery();
}
catch (System.Exception ex)
{
System.Console.WriteLine(ex.Message);
}
finally
{
    con.Close();
}
Console.Clear();
return "Your reservation has been cancelled successfully! Hope we can see you again soon";
}

#endregion

#region METHOD Check Reservation 
public customerDetails checkReservation(int booking_no_for_review){

customerDetails cd = new customerDetails();

SqlCommand cmd_checkReservatioin = new SqlCommand ("select * from customer where booking_no=@booking_no",con);

cmd_checkReservatioin.Parameters.AddWithValue("@booking_no",booking_no_for_review);

SqlDataReader _read = null; //for the safety 

try 
{
    con.Open();
    _read = cmd_checkReservatioin.ExecuteReader();

   if(_read.Read())
{
    cd.booking_no = booking_no_for_review;
    cd.first_name = Convert.ToString(_read[1]);
    cd.last_name = Convert.ToString(_read[2]);
    cd.payment = Convert.ToString(_read[3]);
    cd.service_date = Convert.ToString(_read[4]);
    cd.email = Convert.ToString(_read[5]);

    return cd;
}
else {
    System.Console.WriteLine("Your information is not exist, please try again");
}
}
    catch (System.Exception ex)
{
    System.Console.WriteLine(ex.Message);
}
finally
{
    _read.Close();
    con.Close();
}
 return cd;
}
#endregion

}

    }