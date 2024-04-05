
namespace APIRHIU.Core.DomainObjects
{
    public class Envelope
    {
        public string CreatedDate { get; set; }
        public int ID_EnvelopeStatus { get; set; }
        public string EnvelopeStatus { get; set; }
        public string UUID { get; set; }
        public string ExpirationDate { get; set; }
        public bool HasFrame { get; set; }
        public List<Document> Documents { get; set; }
        public List<object> EnvelopeTags { get; set; }
        public bool RequireGeolocation { get; set; }
    }
}
