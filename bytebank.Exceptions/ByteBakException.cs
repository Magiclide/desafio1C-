 


 namespace bytebank.Exception{


    [System.Serializable]
    public class ByteBankExceptionException : System.Exception
    {
        public ByteBankExceptionException() { }
        public ByteBankExceptionException(string message) : base(message) { }
        public ByteBankExceptionException(string message, System.Exception inner) : base(message, inner) { }
        protected ByteBankExceptionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    




 }