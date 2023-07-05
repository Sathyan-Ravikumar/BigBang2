namespace AngularWithAPI.Exceptions
{
    public class InvalidSqlException :Exception
    {

        string message;
        public InvalidSqlException()
        {
            message = "SQL Exeception";
        }
        public InvalidSqlException(string message)
        {
            this.message = message;
        }
        public override string Message
        {
            get { return message; }
        }
    }
}
