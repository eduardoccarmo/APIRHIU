namespace APIRHIU.Core.DomainObjects
{
    public class Document
    {
        public string Url { get; set; }
        public string UrlVoucher { get; set; }
        public string DocumentType { get; set; }
        public string CreatedDate { get; set; }
        public string EmitterUserName { get; set; }
        public string EmitterUserUUID { get; set; }
        public string EmitterUserEmail { get; set; }
        public string CompanySocialName { get; set; }
        public string UUID { get; set; }
        public bool HasFile { get; set; }
        public List<Subscriber> Subscribers { get; set; }
        public bool IsTemplate { get; set; }
    }
}