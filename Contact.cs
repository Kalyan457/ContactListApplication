using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactListApplication
{
    public class Contact
    {
        String first_Name;
        String middle_Name;
        String last_Name;
        String address_type;
        String street_Address;
        String city;
        String state;
        String zipcode;
        String phone_type;
        int area_Code;
        String number;
        String date_type;
        DateTime date;

        public String First_Name
        {
            get
            {
                return first_Name;
            }
            set
            {
                first_Name = value;
            }
        }

        public String Middle_Name
        {
            get
            {
                return middle_Name;
            }
            set
            {
                middle_Name = value;
            }
        }

        public String Last_Name
        {
            get
            {
                return last_Name;
            }
            set
            {
                last_Name = value;
            }
        }

        public String Address_type
        {
            get
            {
                return address_type;
            }
            set
            {
                address_type = value;
            }
        }

        public String Street_Address
        {
            get
            {
                return street_Address;
            }
            set
            {
                street_Address = value;
            }
        }

        public String City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        public String State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public String Zipcode
        {
            get
            {
                return zipcode;
            }
            set
            {
                zipcode = value;
            }
        }

        public String Phone_type
        {
            get
            {
                return phone_type;
            }
            set
            {
                phone_type = value;
            }
        }

        public int Area_Code
        {
            get
            {
                return area_Code;
            }
            set
            {
                area_Code = value;
            }
        }

        public String Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public String DateType
        {
            get
            {
                return date_type;
            }
            set
            {
                date_type = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public Contact()
        {

        }

        public Contact(String first_Name, String middle_Name, String last_Name, String address_type, String street_Address,String city, String state, String zipcode, String phone_type, int area_Code, String number, String date_type,DateTime date)
        {
            this.first_Name=first_Name;
            this.middle_Name=middle_Name;
            this.last_Name=last_Name;
            this.address_type=address_type;
            this.street_Address=street_Address;
            this.city=city;
            this.state=state;
            this.zipcode=zipcode;
            this.phone_type=phone_type;
            this.area_Code=area_Code;
            this.number=number;
            this.date_type=date_type;
            this.date=date;
        }
    }
}