﻿namespace CRUD.Empleados.Extrados.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public DateTime date_of_birth { get; set; }
        public string position { get; set; }
    }
}
