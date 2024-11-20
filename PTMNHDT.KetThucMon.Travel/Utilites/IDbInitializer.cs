namespace PTMNHDT.KetThucMon.Travel.Utilites
{
    public interface IDbInitializer
    {
        /// <summary>
        /// Khởi tạo cơ sở dữ liệu, tạo các vai trò và người dùng mặc định nếu cần thiết.
        /// </summary>
        void Initialize();
    }
}
