using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BaiTapQuayVideo.Database
{
    public class ConnectDatabase :DbContext
    {
        // 2. Constructor chuẩn của DbContext để nhận cấu hình
        public ConnectDatabase(DbContextOptions<ConnectDatabase> options): base(options) { }
    }
}
