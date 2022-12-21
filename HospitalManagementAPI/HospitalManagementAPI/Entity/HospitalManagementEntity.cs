using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementAPI.Entity
{
    public class HospitalManagementEntity
    {
        public class HospitalManagementRequest
        {
            private int _id;
            private string _firstname;
            private string _lastname;
            private long _mobilenumber;
            private string _disease;
            /*private string _address;

            public string Address
            {
                get { return _address; }
                set { _address = value; }
            }*/
            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }
            public string FirstName
            {
                get { return _firstname; }
                set { _firstname = value; }
            }
            public string LastName
            {
                get { return _lastname; }
                set { _lastname = value; }
            }
            public long MobileNumber
            {
                get { return _mobilenumber; }
                set { _mobilenumber = value; }
            }
            public string Disease
            {
                get { return _disease; }
                set { _disease = value; }
            }
        }
        public class HospitalManagementResponse
        {
            private Boolean _success;
            private string _message;

            public Boolean isSucess
            {
                get { return _success; }
                set { _success = value; }
            }
            public string isMessage
            {
                get { return _message; }
                set { _message = value; }
            }
        }
    }
}
