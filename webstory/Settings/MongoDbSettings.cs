namespace webstory.Settings
{
    public class  MongoDbSettings
    {
        public string Host {get;set;}
        public int Port { get; set; }
        public string User {get; set;}
        public string Password {get; set;}
        public string ConnectionString 
        { 
            get
            { 
                //return $"mongodb://vi:291199@{Host}:{Port}"; --mongodb cua may
                //return "mongodb+srv://qhamnguyen:pn291199@cluster0.3bxcs.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"; --mongo atlas
               // return $"mongodb://{Host}:{Port}"; //mongodb cua docker
                return $"mongodb://{User}:{Password}@{Host}:{Port}"; //mongodb co xac thuc cua docker
            }
        }
    }
}