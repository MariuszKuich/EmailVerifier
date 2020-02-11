namespace EmailVerifier
{
    public class ErrorContent
    { 
        public AnError Error { get; set; }

        public class AnError
        {
            public int Code { get; set; }
            public string Type { get; set; }
            public string Info { get; set; }
        }
    }
}