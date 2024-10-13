using CrudApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CrudApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly string connectionString;
        public ProductsController(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:SqlServerDb"] ?? "";
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Products " +
                        "(name, brand, category, price, description) VALUES" +
                        "(@name, @brand, @category, @price, @description)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", productDto.Name);
                        command.Parameters.AddWithValue("@brand", productDto.Brand);
                        command.Parameters.AddWithValue("@category", productDto.Category);
                        command.Parameters.AddWithValue("@price", productDto.Price);
                        command.Parameters.AddWithValue("@description", productDto.Description);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "Sorry, but we have an exception: " + ex.Message);
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Products";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Brand = reader.GetString(2),
                                    Category = reader.GetString(3),
                                    Price = reader.GetDecimal(4),
                                    Description = reader.GetString(5),
                                    CreatedAt = reader.GetDateTime(6)
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Product", "Sorry, but we have an exception: " + ex.Message);
                return BadRequest(ModelState);
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            Product product = new Product();

            try
            {
                using(var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "select * from products where id = @id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using(var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                product.Id = reader.GetInt32(0);
                                product.Name = reader.GetString(1);
                                product.Brand = reader.GetString(2);
                                product.Category = reader.GetString(3);
                                product.Price = reader.GetDecimal(4);
                                product.Description = reader.GetString(5);
                                product.CreatedAt = reader.GetDateTime(6);
                            }
                            else
                            {
                                return NotFound(); 
                            }
                        }
                    }
                }

            }catch(Exception ex)
            {
                ModelState.AddModelError("Product", "Sorry, but we have an exception: " + ex.Message);
                return BadRequest(ModelState);
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductDto productDto)
        {
            try
            {
                using(var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "update products SET name=@name, brand=@brand, category=@category, " +
                        "price=@price, description=@description where id=@id";

                    using(var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", productDto.Name);
                        command.Parameters.AddWithValue("@brand", productDto.Brand);
                        command.Parameters.AddWithValue("@category", productDto.Category);
                        command.Parameters.AddWithValue("@price", productDto.Price);
                        command.Parameters.AddWithValue("@description", productDto.Description);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }

            }catch(Exception ex)
            {
                ModelState.AddModelError("Product", "Sorry, but we have an exception: " + ex.Message);
                return BadRequest(ModelState);
            }
            return Ok();
        }

    }
}

