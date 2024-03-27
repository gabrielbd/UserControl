using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserControl.Application.DTO
{
    public interface IEntityDTO<TKey>
    {
        public Guid Id { get; set; }


    }
}
