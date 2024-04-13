namespace APIRHIU.Core.DomainObjects
{
    public class RetornoUnico
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public Data? Data { get; set; }
    }

    public class Data
    {
        public int Page { get; set; }
        public int MaxPage { get; set; }
        public int Count { get; set; }
        public List<Envelope> Envelopes { get; set; } = new List<Envelope>();
        public int Rows { get; set; }
    }

    public class Document
    {
        public string Url { get; set; } = string.Empty;
        public string UrlVoucher { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string EmitterUserName { get; set; } = string.Empty;
        public string EmitterUserUUID { get; set; } = string.Empty;
        public string EmitterUserEmail { get; set; } = string.Empty;
        public string CompanySocialName { get; set; } = string.Empty;
        public string UUID { get; set; } = string.Empty;
        public bool HasFile { get; set; }
        public List<Subscriber> Subscribers { get; set; } = new List<Subscriber>();
        public bool IsTemplate { get; set; }
    }

    public class Envelope
    {
        public string CreatedDate { get; set; } = string.Empty;
        public int ID_EnvelopeStatus { get; set; }
        public string EnvelopeStatus { get; set; } = string.Empty;
        public string UUID { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
        public bool HasFrame { get; set; }
        public List<Document>? Documents { get; set; }
        public List<object>? EnvelopeTags { get; set; }
        public bool RequireGeolocation { get; set; }
    }

    public class Subscriber
    {
        public string? SubscriberName { get; set; }
        public string? SubscriberCPF { get; set; }
        public string? SubscriberEmail { get; set; }
        public string? SubscriberPhone { get; set; }
        public int ID_SubscriberStatus { get; set; }
        public int SubscriberOrder { get; set; }
        public int SubscriberRole { get; set; }
        public string? URLFrameFull { get; set; }
        public bool IsUser { get; set; }
    }
}
