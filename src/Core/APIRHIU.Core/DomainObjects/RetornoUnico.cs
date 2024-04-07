namespace APIRHIU.Core.DomainObjects
{
    public class RetornoUnico
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Data? Data { get; set; }
    }

    public class Data
    {
        public int Page { get; set; }
        public int MaxPage { get; set; }
        public int Count { get; set; }
        public List<Envelope>? Envelopes { get; set; }
        public int Rows { get; set; }
    }

    public class Document
    {
        public string? Url { get; set; }
        public string? UrlVoucher { get; set; }
        public string? DocumentType { get; set; }
        public string? CreatedDate { get; set; }
        public string? EmitterUserName { get; set; }
        public string? EmitterUserUUID { get; set; }
        public string? EmitterUserEmail { get; set; }
        public string? CompanySocialName { get; set; }
        public string? UUID { get; set; }
        public bool HasFile { get; set; }
        public List<Subscriber>? Subscribers { get; set; }
        public bool IsTemplate { get; set; }
    }

    public class Envelope
    {
        public string? CreatedDate { get; set; }
        public int ID_EnvelopeStatus { get; set; }
        public string? EnvelopeStatus { get; set; }
        public string? UUID { get; set; }
        public string? ExpirationDate { get; set; }
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
