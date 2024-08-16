namespace C_BookStoreBackEndAPI.CustomException
{
    /// <summary>
    /// Custom Exception class
    /// </summary>
    public class InternalServerErrorException : Exception
    {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
        public InternalServerErrorException(string message) : base(message) { }
    }
}
