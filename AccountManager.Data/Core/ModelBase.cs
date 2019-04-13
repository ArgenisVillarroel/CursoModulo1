using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountManager.Data.Core
{
    public class ModelBase<T>
    {
        public T Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}
