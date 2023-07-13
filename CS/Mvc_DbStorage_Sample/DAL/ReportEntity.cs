using DevExpress.Xpo;

namespace Mvc_DbStorage_Sample.Services.DAL {
    [DeferredDeletion(false)]
    public class ReportEntity : XPCustomObject {
        string url;
        string name;
        byte[] layout;

        public ReportEntity(Session session)
            : base(session) {
        }

        [Key]
        public string Url {
            get { return url; }
            set { SetPropertyValue("Url", ref url, value); }
        }

        public byte[] Layout {
            get { return layout; }
            set { SetPropertyValue("Layout", ref layout, value); }
        }
    }
}
