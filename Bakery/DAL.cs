using Bakery.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Bakery
{
    static class DAL
    {
        public static List<Product> GetProductsClient(string category, string name, string price)
        {
            List<Product> result = new List<Product>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@price", price));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();

                            product.Category = (string)reader["Category"];
                            product.Name = (string)reader["ProductName"];
                            product.Weight = (int)reader["Weight"];
                            product.FoodValue = (int)reader["FoodValue"];
                            product.Price = Math.Round((decimal)reader["Price"], 2, MidpointRounding.AwayFromZero);


                            result.Add(product);
                        }
                    }
                }
            }

            return result;
        }

        public static List<Product> GetProductStorekeeper(string category, string name, string price)
        {
            List<Product> result = new List<Product>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@price", price));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();

                            product.Category = (string)reader["Category"];
                            product.Name = (string)reader["ProductName"];
                            product.Weight = (int)reader["Weight"];
                            product.FoodValue = (int)reader["FoodValue"];
                            product.Price = Math.Round((decimal)reader["Price"], 2, MidpointRounding.AwayFromZero);


                            result.Add(product);
                        }
                    }
                }
            }

            return result;
        }

        public static string Login(string username, string password)
        {
            string result;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Login", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@userName", username));
                    command.Parameters.Add(new SqlParameter("@password", password));
                    using (DataTable dt = new DataTable())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(command))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count == 1)
                            {
                                result = dt.Rows[0][0].ToString();
                            }
                            else
                            {
                                result = "null";
                            }
                        }
                    }
                }

            }
            return result;
        }
        public static int Registration(string username, string password)
        {
            int result;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Registration", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@userName", username));
                    command.Parameters.Add(new SqlParameter("@password", password));
                    command.Parameters.Add(new SqlParameter("@role", "1"));

                    result = command.ExecuteNonQuery();
                }

            }
            return result;
        }
        public static int UserNameСheck(string username)
        {
            List<string> resultList = new List<string>();
            int result = -1;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetUserName", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultList.Add((string)reader["UserName"]);
                        }
                    }
                }

                foreach (string sername in resultList)
                {
                    if (sername == username)
                    {
                        result = 1;
                        break;
                    }
                    else
                    {
                        result = 0;
                    }
                }

            }
            return result;

        }
        public static List<Kiosk> GetKiosksClient(string bakeryName, string name, string address)
        {
            List<Kiosk> result = new List<Kiosk>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetKiosk", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@bakeryName", bakeryName));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", address));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kiosk kiosk = new Kiosk();

                            kiosk.Name = (string)reader["KioskName"];
                            kiosk.Address = (string)reader["KioskAddress"];
                            kiosk.Phone = (string)reader["KioskPhone"];
                            kiosk.DateOpen = (DateTime)reader["DateOpen"];
                            kiosk.Owner = (string)reader["FIO"];
                            kiosk.BakeryName = (string)reader["BakeryName"];

                            result.Add(kiosk);
                        }
                    }
                }

            }

            return result;
        }

        public static List<BreadFactory> GetBreadFactoryClient(string name, string address)
        {
            List<BreadFactory> result = new List<BreadFactory>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", address));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BreadFactory bakery = new BreadFactory();

                            bakery.Name = (string)reader["BakeryName"];
                            bakery.Address = (string)reader["BakeryAddress"];
                            bakery.Phone = (string)reader["BakeryPhone"];

                            result.Add(bakery);
                        }
                    }
                }

            }

            return result;
        }

        public static List<Warehouse> GetWarehouse(string bakery, string category, string name)
        {
            List<Warehouse> result = new List<Warehouse>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Getwarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@bakery", bakery));
                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.Parameters.Add(new SqlParameter("@name", name));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Warehouse warehouse = new Warehouse();

                            warehouse.BakeryName = (string)reader["BakeryName"];
                            warehouse.Category = (string)reader["Category"];
                            warehouse.ProductName = (string)reader["ProductName"];
                            warehouse.Quantity = (int)reader["Quantity"];

                            result.Add(warehouse);
                        }
                    }
                }
            }
            return result;
        }
        public static List<string> GetProductName(string category)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.Parameters.Add(new SqlParameter("@name", string.Empty));
                    command.Parameters.Add(new SqlParameter("@price", string.Empty));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["ProductName"]);
                        }
                    }
                }

            }

            return result;
        }
        public static List<string> GetBakerySearch(string name)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakerySearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["BakeryName"]);
                        }
                    }
                }

            }

            return result;
        }

        public static List<BreadFactory> GetBreadFactory(string name)
        {
            List<BreadFactory> result = new List<BreadFactory>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakerySearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BreadFactory breadFactory = new BreadFactory();
                            breadFactory.Name = (string)reader["BakeryName"];
                            breadFactory.Address = (string)reader["BakeryAddress"];
                            breadFactory.Phone = (string)reader["BakeryPhone"];
                            result.Add(breadFactory);
                        }
                    }
                }

            }

            return result;
        }

        public static List<string> GetCategories(string name)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["Category"]);
                        }
                    }
                }
            }

            return result;
        }

        public static List<string> GetDelProductWarehouse(string bakeryName)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetDelProductWarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@bakery", bakeryName));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["ProductCat"]);
                        }
                    }
                }
            }

            return result;
        }

        public static List<string> GetAddProductWarehouse()
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAddProductWarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@product", ""));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["ProductCat"]);
                        }
                    }
                }
            }

            return result;
        }

        public static int GetProductResidue(string bakeryName, string product)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProductResidue", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@bakery", bakeryName));
                    command.Parameters.Add(new SqlParameter("@product", product));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int)reader["ProductResidue"];
                        }
                    }
                }
            }

            return result;
        }

        public static List<int> GetProductWarehouseId(string bakeryName, string product)
        {
            List<int> result = new List<int>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@name", bakeryName));
                    command.Parameters.Add(new SqlParameter("@address", ""));



                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((int)reader["BakeryId"]);
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand("GetAddProductWarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@product", product));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((int)reader["ProductId"]);
                        }
                    }
                }
            }

            return result;
        }

        public static void AddProductWarehouse(int bakery, int product, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddProductWarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@bakeryId", bakery));
                    command.Parameters.Add(new SqlParameter("@productId", product));
                    command.Parameters.Add(new SqlParameter("@quantityId", quantity));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpProductWarehouse(int bakery, int product, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpProductWarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@bakery", bakery));
                    command.Parameters.Add(new SqlParameter("@product", product));
                    command.Parameters.Add(new SqlParameter("@quantity", quantity));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DelProductWarehouse(int bakery, int product)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DelProductWarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@bakeryId", bakery));
                    command.Parameters.Add(new SqlParameter("@productId", product));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<int> GetProductCategoryID(string category, string product)
        {
            List<int> result = new List<int>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.Parameters.Add(new SqlParameter("@name", product));
                    command.Parameters.Add(new SqlParameter("@price", string.Empty));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((int)reader["CategoryId"]);
                            result.Add((int)reader["ProductId"]);
                        }
                    }
                }
            }

            return result;
        }
        public static void UpProduct(int category, int product, int weight, int foodValue, decimal price)
        {

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@categoryId", category));
                    command.Parameters.Add(new SqlParameter("@productId", product));
                    command.Parameters.Add(new SqlParameter("@weight", weight));
                    command.Parameters.Add(new SqlParameter("@foodValue", foodValue));
                    command.Parameters.Add(new SqlParameter("@price", price));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DelProduct(int category, int product)
        {

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DelProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@categoryId", category));
                    command.Parameters.Add(new SqlParameter("@productId", product));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static int GetCategoryId(string category)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@name", category));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int)reader["CategoryId"];
                        }
                    }
                }
            }
            return result;
        }
        public static bool boolCategory(string category)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.Parameters.Add(new SqlParameter("@name", string.Empty));
                    command.Parameters.Add(new SqlParameter("@price", string.Empty));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static bool boolCategoryCheck(string category)
        {
            bool result = false;
            List<string> list = new List<string>();
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@name", string.Empty));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add((string)reader["Category"]);
                        }
                    }
                }
                foreach (string str in list)
                {
                    System.Globalization.TextInfo ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
                    if (ti.ToTitleCase(str) == ti.ToTitleCase(category))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool boolProductCategoryCheck(string category, string product)
        {
            bool result = false;
            System.Globalization.TextInfo ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAddProductWarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@product", ti.ToTitleCase(category + " " + product)));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public static void AddProduct(int categoryId, string product, int weight, int foodValue, decimal price)
        {
            System.Globalization.TextInfo ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@categoryId", categoryId));
                    command.Parameters.Add(new SqlParameter("@productName", ti.ToTitleCase(product)));
                    command.Parameters.Add(new SqlParameter("@weight", weight));
                    command.Parameters.Add(new SqlParameter("@foodValue", foodValue));
                    command.Parameters.Add(new SqlParameter("@price", price));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void AddCategory(string category)
        {
            System.Globalization.TextInfo ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddCatigories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@categoryName", ti.ToTitleCase(category)));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DelCategory(int category)
        {

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DelCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@categoryId", category));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Owner> GetOwner(string data)
        {
            List<Owner> result = new List<Owner>();
            string data1 = string.Empty;
            int number;
            int number1;
            bool isnumber;
            data = data.Replace(".", "-");
            data = data.Replace(",", "-");
            data1 = data;
            data1 = data.Replace("-", "");
            if (int.TryParse(data1, out number))
            {
                isnumber = true;
            }
            else
            {
                isnumber = false;
            }

            if (isnumber == true)
            {
                if (data.Length < 3)
                {
                    data1 = data;
                }
                if (data.Length == 3)
                {
                    string[] words = data.Split(new char[] { '-' });
                    data1 = words[0];
                }
                if (data.Length > 3)
                {
                    string[] words = data.Split(new char[] { '-' });

                    foreach (string s in words)
                    {
                        if (words.Length == 1)
                        {
                            data1 = words[0];
                        }
                        if (words.Length == 2)
                        {
                            if (words[1].Length == 2 || words[1].Length == 4)
                            {
                                if (int.TryParse(words[1], out number1))
                                {
                                    if (number1 < 12)
                                    {
                                        data1 = words[1] + "-" + words[0];
                                    }
                                    else
                                    {
                                        data1 = "-" + words[0];
                                    }
                                }
                            }
                            else if (words[1].Length == 1 || words[1].Length == 3)
                            {
                                data1 = "-" + words[0];
                            }
                        }
                        if (words.Length == 3)
                        {
                            if (words[2].Length == 4)
                            {
                                data1 = words[2] + "-" + words[1] + "-" + words[0];
                            }
                            else if (words[2].Length < 4)
                            {
                                data1 = "-" + words[1] + "-" + words[0];
                            }

                        }
                    }
                }
            }
            else
            {
                data1 = data;
            }

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetOwnerSearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@data", data1));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Owner owner = new Owner();
                            owner.Surname = (string)reader["Surname"];
                            owner.FirstName = (string)reader["FirstName"];
                            owner.Patronymic = (string)reader["Patronymic"];
                            owner.Birthdate = (DateTime)reader["Birthdate"];
                            result.Add(owner);
                        }
                    }
                }
            }

            return result;
        }
        public static List<string> GetOwnerSurname(string data)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetOwnerSearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@data", data));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["Surname"]);
                        }
                    }
                    result = СleaningDouble(result);
                }
            }
            return result;
        }
        public static List<string> GetOwnerFirstName(string data)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetOwnerSearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@data", data));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["FirstName"]);
                        }
                    }
                    result = СleaningDouble(result);
                }
            }
            return result;
        }
        public static List<string> СleaningDouble(List<string> list)
        {
            List<string> result = new List<string> { string.Empty };
            foreach (string s in list)
            {
                bool isnumber = true;
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i] == s)
                    {
                        isnumber = true;
                        break;
                    }
                    else isnumber = false;
                }
                if (isnumber == false)
                {
                    result.Add(s);
                }
            }
            return result;
        }
        public static List<string> GetOwnerPatronymic(string data)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetOwnerSearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@data", data));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["Patronymic"]);
                        }
                    }
                }
                result = СleaningDouble(result);
            }
            return result;
        }
        public static List<string> GetOwnerSurnameFirstName(string data, string data1)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetOwnerSearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@data", data + " " + data1));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["Patronymic"]);
                        }
                    }
                    result = СleaningDouble(result);
                }
            }
            return result;
        }
        public static int GetOwnerSurnameFirstNamePatronymic(string data, string data1, string data2, DateTime data3)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetOwnerAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@surname", data));
                    command.Parameters.Add(new SqlParameter("@firstName", data1));
                    command.Parameters.Add(new SqlParameter("@patronymic", data2));
                    command.Parameters.Add(new SqlParameter("@birthdate", data3));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int)reader["OwnerId"];
                        }
                    }
                }
            }
            return result;
        }
        public static void AddOwner(string surname, string firstname, string patronymic, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddOwner", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@surname", surname));
                    command.Parameters.Add(new SqlParameter("@firstName", firstname));
                    command.Parameters.Add(new SqlParameter("@patronymic", patronymic));
                    command.Parameters.Add(new SqlParameter("@birthdate", date));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DelOwner(int Id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DelOwner", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ownerId", Id));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void UpProduct(int ownerId, string surname, string firstname, string patronymic)
        {

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpOwner", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ownerId", ownerId));
                    command.Parameters.Add(new SqlParameter("@surname", surname));
                    command.Parameters.Add(new SqlParameter("@firstName", firstname));
                    command.Parameters.Add(new SqlParameter("@patronymic", patronymic));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool GetAddProductWarehouseBool(string bakery, string product)
        {
            bool read = false;
            List<string> result = new List<string>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetDelProductWarehouse", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@bakery", bakery));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["ProductCat"]);
                        }
                    }
                }
            }

            foreach (string product1 in result)
            {
                if (product1 == product)
                {
                    read = true;
                    break;
                }
            }
            return read;
        }

        public static List<string> GetBakeryName(string name)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakerySearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["BakeryName"]);
                        }
                    }
                    result = СleaningDouble(result);
                }
            }
            return result;
        }
        public static List<string> GetBakeryAddress(string name)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakerySearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["BakeryAddress"]);
                        }
                    }
                    result = СleaningDouble(result);
                }
            }
            return result;
        }
        public static List<string> GetBreadFactoryPhone(string name, string address)
        {
            List<string> result = new List<string>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", address));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["BakeryPhone"]);
                        }
                    }
                    result = СleaningDouble(result);
                }

            }
            return result;
        }
        public static int GetBakeryNameId(string name)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", string.Empty));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int)reader["BakeryId"];
                        }
                    }
                }
            }
            return result;
        }

        public static void AddBakery(string name, string address, string phone)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddBakery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", address));
                    command.Parameters.Add(new SqlParameter("@phone", phone));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void DelBakery(int bakeryId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DelBakery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@bakeryId", bakeryId));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void UpBakery(int bakeryId, string name, string address, string phone)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpBakery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@bakeryId", bakeryId));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", address));
                    command.Parameters.Add(new SqlParameter("@phone", phone));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Kiosk> GetKiosksOwner(string date)
        {
            List<Kiosk> result = new List<Kiosk>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetKioskAll", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@date", date));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kiosk kiosk = new Kiosk();

                            kiosk.Name = (string)reader["KioskName"];
                            kiosk.Address = (string)reader["KioskAddress"];
                            kiosk.Phone = (string)reader["KioskPhone"];
                            kiosk.DateOpen = (DateTime)reader["DateOpen"];
                            kiosk.Owner = (string)reader["FIO"];
                            kiosk.BakeryName = (string)reader["BakeryName"];

                            result.Add(kiosk);
                        }
                    }
                }

            }
            return result;
        }
        public static List<string> GetKiosksName(string name)
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetKiosk", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@bakeryName", string.Empty));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", string.Empty));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["KioskName"]);
                        }
                    }
                    result = СleaningDouble(result);
                }
            }
            return result;
        }
        public static List<string> GetKioskOwner()
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetOwnerFIO", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["FIO"]);
                        }
                    }
                }

            }
            return result;
        }
        public static List<string> GetKioskAddress()
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetKioskAll", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@date", string.Empty));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["KioskAddress"]);
                        }
                    }
                }

            }
            return result;
        }
        public static List<string> GetKioskPhone()
        {
            List<string> result = new List<string> { string.Empty };

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetKioskAll", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@date", string.Empty));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add((string)reader["KioskPhone"]);
                        }
                    }
                }

            }
            return result;
        }

        public static int GetKioskNameId(string name)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetKioskId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int)reader["KioskId"];
                        }
                    }
                }
            }
            return result;
        }

        public static void AddKiosk(string name, string address, string phone, int bakeryId, int ownerId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddKiosk", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", address));
                    command.Parameters.Add(new SqlParameter("@phone", phone));
                    command.Parameters.Add(new SqlParameter("@date", DateTime.Today));
                    command.Parameters.Add(new SqlParameter("@bakery", bakeryId));
                    command.Parameters.Add(new SqlParameter("@owner", ownerId));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpKiosk(int id, string name, string address, string phone, int bakeryId, int ownerId)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpKiosk", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id", id));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", address));
                    command.Parameters.Add(new SqlParameter("@phone", phone));
                    command.Parameters.Add(new SqlParameter("@bakery", bakeryId));
                    command.Parameters.Add(new SqlParameter("@owner", ownerId));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static int GetBakeryId(string name)
        {
            int result;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBakery", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@address", string.Empty));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        result = 0;
                        while (reader.Read())
                        {
                            result = (int)reader["BakeryId"];
                        }
                    }
                }
            }
            return result;
        }

        public static int GetOwnerId(string fio)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetOwnerId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@fio", fio));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (int)reader["OwnerId"];
                        }
                    }
                }
            }
            return result;
        }

        public static void DelKiosk(int id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DelKiosk", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@id", id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool boolOwner(string fio)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetKioskAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@date", fio));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static List<Log> GetLogSearch(DateTime c, DateTime doc)
        {
            List<Log> result = new List<Log>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetLogSearch", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@dateC", c));
                    command.Parameters.Add(new SqlParameter("@dateDo", doc));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Log log = new Log();

                            log.TableName = (string)reader["TableName"];
                            log.Date = (DateTime)reader["Date"];
                            log.OperationType= (string)reader["OperationType"];
                            log.NameRole = (string)reader["NameRole"];

                            result.Add(log);
                        }
                    }
                }

            }

            return result;
        }
        public static List<Log> GetLog()
        {
            List<Log> result = new List<Log>();

            using (SqlConnection connection = new SqlConnection(Constants.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetLog", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Log log = new Log();

                            log.TableName = (string)reader["TableName"];
                            log.Date = (DateTime)reader["Date"];
                            log.OperationType = (string)reader["OperationType"];
                            log.NameRole = (string)reader["NameRole"];

                            result.Add(log);
                        }
                    }
                }

            }

            return result;
        }
    }
}
