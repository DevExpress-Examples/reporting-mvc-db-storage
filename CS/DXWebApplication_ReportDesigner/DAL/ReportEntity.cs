using DevExpress.Xpo;

namespace DXWebApplication_ReportDesigner.DAL {
    [DeferredDeletion(false)]
    public class ReportEntity : XPObject {
        string name;
        byte[] layout;

        public ReportEntity(Session session)
            : base(session) {
        }

        public string Name {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }


        public byte[] Layout {
            get { return layout; }
            set { SetPropertyValue("Layout", ref layout, value); }
        }
    }
}