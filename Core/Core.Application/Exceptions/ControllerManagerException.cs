

namespace Core.Application.Exceptions
{
    public class ControllerManagerException : Exception
    {
        public string ControllerName { get; private set; }
        public ControllerManagerException(string message, string ControllerName) :base(message)
        {
            this.ControllerName = ControllerName;

        }
    }
}
