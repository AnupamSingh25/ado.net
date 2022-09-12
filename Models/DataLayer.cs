using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication5.Models
{
    public class DataLayer
    {
        DbConnection db = new DbConnection();
        public DataTable getallrecord(Prop pr)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] p = new SqlParameter[]
                {
                    new SqlParameter("@name",pr.Name),
                    new SqlParameter("@email",pr.Email),
                    new SqlParameter("@pass",pr.Pass),
                    new SqlParameter("@contact",pr.Contact),  
                    new SqlParameter("@dob",pr.Dob),
                    new SqlParameter("@pic",pr.Pic),
                    new SqlParameter("@action",pr.Action),
                    new SqlParameter("@id",pr.Id),
                    
                    new SqlParameter("@gender",pr.gender  )
                };
                dt = db.executedatatable("sp_register", p);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }
    }
}