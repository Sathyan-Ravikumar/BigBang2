namespace AngularWithAPI.Exceptions
{
    public class InvalidPrimaryID : Exception
    {
        string message;
        public InvalidPrimaryID()
        {
            message = "primary id must be Empty";
        }
        public InvalidPrimaryID(string message)
        {
            this.message = message;
        }
        public override string Message
        {
            get { return message; }
        }

    }
}
