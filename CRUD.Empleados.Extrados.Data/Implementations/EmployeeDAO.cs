namespace CRUD.Empleados.Extrados.Data.Implementations
{
    public class EmployeeDAO
    {
        private string _connectionString = @"data source=DESKTOP-KCGGJDV\SQLEXPRESS;initial Catalog=ejemplo; Integrated Security=True;";

        private string _insertNewEmployeeQuery = @"INSERT INTO [users] (name, last_name, phone_number, date_of_birth,position) values(@Name,@LastName, @PhoneNumber,@DateOfBrith,@Position)";
        private string _selectEmployees = @"SELECT * FROM [users] where status = 1";

        private string _updateStatusEmployee = @"UPDATE [users] SET status = @StatusUser WHERE user_id = @UserId";

        private string _updateEmployee = "UPDATE [users] SET name = @Name, last_name = @LastName, phone_number = @PhoneNumber, date_of_birth = @Date, position = @Position WHERE user_id = @UserId";
    }
}
