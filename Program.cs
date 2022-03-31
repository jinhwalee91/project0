using System;
using System.Collections.Generic;
 #nullable disable

namespace hotel_booking 
{
     class Program
    {
                static void Main(string[] args)
        {
        customerDetails cstDetails = new customerDetails(); 
        
        #region Screen UI
        bool IsPageActive = true ; 
        bool isLoggedIn = false ;

    if(isLoggedIn == false){
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("Please Enter your username");
            Console.ResetColor();
            string username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("Please Enter your password");
            Console.ResetColor();
            string password = Console.ReadLine();
            Console.ResetColor(); 
            security sObj = new security();

            bool loginResult =sObj.Login(username,password);
            if(loginResult == false) {
                System.Console.WriteLine("Your id and pw are not exist, please try again");
            }
            else {
                isLoggedIn = true; 

                Console.Clear();
   
        while (IsPageActive){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n                                   ");
            System.Console.WriteLine("       Welcome to JJ Hotel         \n                                   ");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.ResetColor();  
            System.Console.WriteLine(" please press number from the menu \n");
            System.Console.WriteLine("    1  Make the new reservation         ");
            System.Console.WriteLine("    2  Change my reservation            ");
            System.Console.WriteLine("    3  Cancel my reservation            ");
            System.Console.WriteLine("    4  View my reservation              ");
            System.Console.WriteLine("    5  Exit                             ");
            int choice =Convert.ToInt32(Console.ReadLine());

        #endregion

        #region Make the new reservation
        switch (choice){
        
            case 1 :  
           System.Console.WriteLine("Please Enter your first name");
            string firstname = Console.ReadLine();
            System.Console.WriteLine("Please Enter your last name");
            string lastname = Console.ReadLine();
            System.Console.WriteLine("Please Enter your payment (debit / credit)");
            string payment = Console.ReadLine();
            System.Console.WriteLine("lease Enter your service date (YYYY-MM-DD)");
            string servicedate = Console.ReadLine();
            System.Console.WriteLine("Please Enter your e-mail");
            string email = Console.ReadLine();
            
            customerDetails newCustomer = new customerDetails();
            newCustomer.first_name = firstname;
            newCustomer.last_name = lastname;
            newCustomer.payment = payment;
            newCustomer.service_date = servicedate;
            newCustomer.email = email;

            System.Console.WriteLine(cstDetails.AddNewCustomer(newCustomer));
            break;
        #endregion

        #region change my reservation
            case 2:  
            System.Console.WriteLine("Please Enter your booking number");
            int booking_no = Convert.ToInt32(Console.ReadLine());
           System.Console.WriteLine("Please Enter your first name");
            string newfirstname = Console.ReadLine();
            System.Console.WriteLine("Please Enter your last name");
            string newlastname = Console.ReadLine();
            System.Console.WriteLine("Please Enter your payment (debit / credit)");
            string newpayment = Console.ReadLine();
            System.Console.WriteLine("lease Enter your service date (YYYY-MM-DD)");
            string newservicedate = Console.ReadLine();
            System.Console.WriteLine("Please Enter your e-mail");
            string newemail = Console.ReadLine();
           
           
            customerDetails rsvchange = new customerDetails();
            rsvchange.first_name = newfirstname;
            rsvchange.last_name = newlastname;
            rsvchange.payment = newpayment;
            rsvchange.service_date = newservicedate;
            rsvchange.email = newemail;
            rsvchange.booking_no= booking_no;

            System.Console.WriteLine(cstDetails.updateReservation(rsvchange));
             break;

        #endregion

        #region Cancel my Reservation by putting Booking ID
            case 3:  
            System.Console.WriteLine("Please Enter your Booking number");
            int booking_no_forcancel = Convert.ToInt32(Console.ReadLine());
           
            customerDetails rsvcancel = new customerDetails();
            rsvcancel.booking_no= booking_no_forcancel;

            System.Console.WriteLine(cstDetails.cancelReservation(booking_no_forcancel));
             break;

        #endregion

        #region  View my Reservation by putting Booking ID
            case 4: 
            System.Console.WriteLine("Please Enter your Booking number to check your reservation");
           
            int booking_no_for_review = Convert.ToInt32(Console.ReadLine());
             customerDetails cd = cstDetails.checkReservation(booking_no_for_review);

            Console.Clear();
            System.Console.WriteLine("Dear. " + cd.first_name +" " + cd.last_name + " . Your reservation is on "+ cd. service_date + " paid by " + cd.payment + " card. Your booking confirmation has been sent to your e-mail : " + cd.email + " .. Thank you for using our hotel. Please let us know if we can help you further...");

            break;

        #endregion

        #region Logging Out
            case 5:  
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            System.Console.WriteLine("Thank you for using our JJ hotel service. See you next time");
            Console.ResetColor(); 
            IsPageActive = false; 
            break;

        #endregion

        #region Wrong Number scenario
            default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Wrong Enter, Please press number from 1~5");
            Console.ResetColor(); 
            break;
            
        #endregion
               }
            }
          }
    }
           
  }
}

}