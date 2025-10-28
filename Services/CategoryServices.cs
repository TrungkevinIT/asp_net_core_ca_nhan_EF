using BaiTapQuayVideo_EF.Models;
using BaiTapQuayVideo_EF.Database;
using Microsoft.Data.SqlClient;
namespace BaiTapQuayVideo_EF.Services
{
    public class CategoryServices
    {
        //khai báo biến tham chiếu đến ConnectDatabase
        private readonly ConnectDatabase _connectDatabase;
        //gán tham chiếu đó vào hàm khởi tạo của CategoryServices để CategoryServices có thể sử dụng phương thức trong ConnectDatabase
        public CategoryServices(ConnectDatabase connectDatabase)
        {
            _connectDatabase = connectDatabase;
        }
        //lấy ra tất cả danh sách trong danh mục
        public List<Categories> GetAllCategories()
        {
            try
            {
                var results=_connectDatabase.Categories.ToList();
                return results;
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục", ex);
            }
           
        }
        //hàm dùng để thêm danh mục
        public bool AddCategory(Categories categories)
        {
            try
            {
                _connectDatabase.Categories.Add(categories);   // LINQ - thêm sản phẩm
                _connectDatabase.SaveChanges();           // Lưu thay đổi vào database
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách danh mục", ex);
            }

        }
    }
}