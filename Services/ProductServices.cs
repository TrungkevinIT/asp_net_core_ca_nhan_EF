using BaiTapQuayVideo_EF.Models;
using BaiTapQuayVideo_EF.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace BaiTapQuayVideo_EF.Services
{
    public class ProductServices 
    {
        //khai báo biến tham chiếu đến ConnectDatabase
        private readonly ConnectDatabase _connectDatabase;
        //gán biến trên vào Hàm khởi tạo ProductServices để có thể sử dụng các phương thức của ConnectDatabase
        public ProductServices(ConnectDatabase connectDatabase)
        {
            _connectDatabase = connectDatabase;
        }
        public List<Product> GetAllProducts()
        {
            try
            {
                    // LINQ truy vấn tất cả sản phẩm
                    var result = _connectDatabase.products.ToList();
                    return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm", ex);
            }
           
        }
       
        public bool AddProducts(Product product)
        {
            try
            {
                _connectDatabase.products.Add(product);   // LINQ - thêm sản phẩm
                _connectDatabase.SaveChanges();           // Lưu thay đổi vào database
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách san pham", ex);
            }
        }
        public List<Product> GetTop6RanDomProducts()
        {
            try
            {
                var result = _connectDatabase.products
            .Where(p => p.ProductType != null && p.ProductType.Contains("Bike"))
            .OrderBy(p => Guid.NewGuid())
            .Take(6)
            .ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm", ex);
            }
        }
    }
}
