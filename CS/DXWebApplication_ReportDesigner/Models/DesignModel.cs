using DevExpress.XtraReports.UI;

namespace DXWebApplication_ReportDesigner.Models {
    public class DesignModel {
        public int Id { get; set; }
        public string NewName { get; set; }
        public XtraReport Report { get; set; }
        public object DataSource { get; set; }
    }
}