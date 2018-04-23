using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using System.Web.Configuration;

namespace DXWebApplication_ReportDesigner.DAL {
    public static class SessionFactory {
        static readonly IDataLayer dataLayer;

        static SessionFactory() {
            var dictionary = new ReflectionDictionary();
            dictionary.GetDataStoreSchema(typeof(SessionFactory).Assembly);

            var connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var dataStore = XpoDefault.GetConnectionProvider(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

            dataLayer = new ThreadSafeDataLayer(dictionary, dataStore);
        }

        public static UnitOfWork Create() {
            return new UnitOfWork(dataLayer);
        }
    }
}