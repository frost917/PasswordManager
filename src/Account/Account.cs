using System;

namespace PasswordManager
{
    class AccountStorage
    {
        string id, passwd, info;
        public string ID { set; get; }
        public string Passwd { set; get; }
        public string Info { set; get; }
        public AccountStorage(string info, string id, string passwd)
        {
            ID = id;
            Passwd = passwd;
            Info = info;
        }
    }
}