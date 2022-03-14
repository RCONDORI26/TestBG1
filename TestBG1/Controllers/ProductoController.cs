using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

//Los que no estaban agregados
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TestBG1.Models;

namespace TestBG1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductoController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get() {

            string query = @"
                              select ProductoId,Nombre,Price,mrp,stock,isPublished from dbo.producto order by 1 asc
                             ";

            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("ProductoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Producto dep)
        {

            string query = @"
                              insert into producto values(@Nombre,@price,@mrp,@stock,@IsPublish)
                           ";

            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("ProductoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Nombre", dep.Nombre);
                    myCommand.Parameters.AddWithValue("@price", dep.Price);
                    myCommand.Parameters.AddWithValue("@mrp", dep.mrp);
                    myCommand.Parameters.AddWithValue("@stock", dep.stock);
                    myCommand.Parameters.AddWithValue("@IsPublish", dep.isPublished);

                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPut]
        public JsonResult Put(Producto dep)
        {

            string query = @"
                                 update producto set Nombre=@Nombre,Price=@price, mrp=@mrp,
                                 stock=@stock, isPublished=@IsPublish where ProductoId=@ProductoId
                           ";

            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("ProductoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Nombre", dep.Nombre);
                    myCommand.Parameters.AddWithValue("@price", dep.Price);
                    myCommand.Parameters.AddWithValue("@mrp", dep.mrp);
                    myCommand.Parameters.AddWithValue("@stock", dep.stock);
                    myCommand.Parameters.AddWithValue("@IsPublish", dep.isPublished);
                    myCommand.Parameters.AddWithValue("@ProductoID", dep.ProductoID);

                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int Id)
        {

            string query = @"
                                Delete from dbo.producto where ProductoId=@ProductoID
                           ";

            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("ProductoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProductoID", Id);

                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPatch("update/{id}")]
        public JsonResult Patch(int Id)
        {

            string query = @"
                                Delete from dbo.producto where ProductoId=@ProductoID
                           ";

            DataTable table = new DataTable();
            string sqlDataSourse = _configuration.GetConnectionString("ProductoAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSourse))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProductoID", Id);

                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);

        }

    }
}
