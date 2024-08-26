
namespace WebAPICoreTasks.Controllers
{
    public class db
    {
        public object Product { get; internal set; }
        public object Products { get; internal set; }

        internal static bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        internal static object GetAllProducts()
        {
            throw new NotImplementedException();
        }

       

        internal static object GetProductByName(string name, int id)
        {
            throw new NotImplementedException();
        }
    }
}