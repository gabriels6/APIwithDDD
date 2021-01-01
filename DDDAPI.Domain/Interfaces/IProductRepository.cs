using DDDAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DDDAPI.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ActionResult<IEnumerable<Product>>> GetAll();

        Task<ActionResult<Product>> GetById(int id);

        Task<IActionResult> Update(int id, Product product);

        Task<ActionResult<Product>> Create(Product product);

        Task<IActionResult> Delete(int id);

    }
}
