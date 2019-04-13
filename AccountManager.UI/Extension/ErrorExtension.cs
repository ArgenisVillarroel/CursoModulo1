using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager.UI.Extension
{
    public static class ErrorExtension
    {
        public static string HandlerErrorMessage<TException>(this TException exception)
            where TException: Exception
        {
            if(exception is DbUpdateException)
            {
                if (exception.InnerException is SqlException)
                {
                    SqlException sqlException = (SqlException)exception.InnerException;
                    return sqlException.Message;

                }
                else
                {
                    return "No se pudieron guardar los cambios por motivos desconocidos";
                }

            }
            else
            {
                return "Error no controlado!";
            }
            
        }
    }
}
