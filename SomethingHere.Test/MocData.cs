using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomethingHere.Utility;
using SomethingHere.Utility.Enums;
using System.Linq;
namespace SomethingHere.Test
{
    [TestClass]
    public class MocData
    {
        [TestMethod]
        public void CreateCategory()
        {
            List<string> categories = new List<string>();
            categories.Add("Beyaz Esya");
            categories.Add("Elektronik" );
            categories.Add("Oyuncak");
            categories.Add( "Bilgisayar");
            categories.Add("Aksesuar" );
            categories.Add( "Kitap" );
            categories.Add("Otomobil" );
            categories.Add( "Cep Telefonu");
            categories.Add( "Spor Malzemeleri");
            SomethingsHereEntities db = new SomethingsHereEntities();
            foreach (string item in categories)
            {
                Category category = new Category();
                category.CategoryName = item;
                category.Description = "This is Desc for :" + item;
                category.IsActive = true;
                db.Category.Add(category);
                db.SaveChanges();

            }
        }
        [TestMethod]
        public void CreateBrand()
        {
            List<string> brands = new List<string>();
            brands.Add("İphone");
            brands.Add("Samsung");
            brands.Add("Nokia");
            brands.Add("Lego");
            brands.Add("Lg");
            brands.Add("Bosch");
            brands.Add("Adidas");
            brands.Add("Asus");
            brands.Add("Kodlab");
            SomethingsHereEntities db = new SomethingsHereEntities();
            foreach (string item in brands)
            {
                Brand brand = new Brand();
                brand.Name = item;
                brand.IsActive = true;
                brand.Description = "This is desc for " + item;
                db.Brand.Add(brand);
                db.SaveChanges();
            }


        }
        [TestMethod]
        public void LoginUser()
        {
            SomethingsHereEntities entities = new SomethingsHereEntities();
            LoginUser user = new LoginUser();
            user.Answer = "Answer";
            user.CreatedDate = DateTime.Now;
            user.Email = "mehmetkicirti@hotmail.com";
            user.IsActive = true;
            user.Password = CryptoManager.Encrypt("123");
            //user.Password = CryptoManager.Decrypt(user.Password);
            //sifreleme aes kullanılır public ve private key vardır 
            user.Question = "Question";
            user.Username = "admin";
            
            entities.LoginUser.Add(user);
            entities.SaveChanges();
            LoginUserDetail loginUserDetail = new LoginUserDetail();
            loginUserDetail.ID = user.ID;
            loginUserDetail.DeliveryAddress = "İzmir";
            loginUserDetail.Fullname = "Mehmet Aydın Kıcırtı";
            loginUserDetail.Gender = /*Convert.ToInt32(E_Gender.Male);*/(int)E_Gender.Male;
            loginUserDetail.InvoiceAddress = "İzmir";
            loginUserDetail.Phone = "0544083044";
            entities.LoginUserDetail.Add(loginUserDetail);
            entities.SaveChanges();
        }
        [TestMethod]
        public void CreateSupplier()
        {
            List<string> supplier = new List<string>();
            supplier.Add("apple Company");
            supplier.Add("Electronic arts");
            supplier.Add("Microsoft");
            foreach(string item in supplier)
            {
                SomethingsHereEntities entities = new SomethingsHereEntities();
                Supplier supplierGetir = new Supplier();
                supplierGetir.Name = item;
                supplierGetir.ContactName = "Contact Text";
                supplierGetir.Phone = "123456";
                supplierGetir.StartDate = DateTime.Now;
                supplierGetir.IsActive = true;
                entities.Supplier.Add(supplierGetir);
                entities.SaveChanges();
            }
        }
        [TestMethod]
        public void CreateProduct()
        {
            SomethingsHereEntities entities = new SomethingsHereEntities();
            List<Brand> brands = entities.Brand.ToList();
            List<Supplier> suppliers = entities.Supplier.ToList();
            Random random = new Random();
            for (int i = 1; i <1001; i++)
            {
                
                Product product = new Product();
                product.BrandID = brands[random.Next(0, brands.Count)].ID;
                product.SupplierID = suppliers[random.Next(0, suppliers.Count)].ID;
                product.ProductName = "Product Name:" + i;
                product.Price = random.Next(1, 10000);
                
                if (i % 100 == 0)
                {
                    product.Stock = 0;
                    product.IsActive = false;

                }
                else
                {
                    //bir döngünün icinde db saveschange yapmak icin kayıt sayısının 500 den kücük olması gerekir aksi takdirde dısarıda olması gerekir.
                    product.Stock = random.Next(1, 1001);
                    product.IsActive = true;

                }
                product.CreatedDate = DateTime.Now.AddDays(random.Next(1, 366));
                entities.Product.Add(product);
                
            }
            entities.SaveChanges();
        }
        [TestMethod]
        public void CreateProductProperty()
        {
            SomethingsHereEntities entities = new SomethingsHereEntities();
            List<Product> products = entities.Product.ToList();
            Random random = new Random();
            foreach (Product item in products)
            {
                for (int i = 0; i <random.Next(1,11); i++)
                {
                    ProductProperty productProperty = new ProductProperty();
                    productProperty.IsActive = true;
                    productProperty.Name = "Property" + item.ProductName + " " + i;
                    productProperty.Value = "Value " + i;
                    productProperty.ProductID = item.ID;
                    entities.ProductProperty.Add(productProperty);
                }
            }
            entities.SaveChanges();
        }
        

        [TestMethod]
        public void CreateProductImages()
        {
            SomethingsHereEntities entities = new SomethingsHereEntities();
            List<Product> products = new List<Product>();
            products = entities.Product.ToList();
            Random random = new Random();
            foreach (var item in products)
            {
                int randomNumber = random.Next(0, 3);
                for (int i = 0; i <3; i++)
                {
                    ProductImage image = new ProductImage();
                    image.Name = (i + 1) + ".gif";
                    image.ProductID = item.ID;
                    image.Type = (int)E_Type.GIF;
                    image.ImagePath = "/ProductImages/" + (i + 1) + ".gif";
                    if (i == randomNumber)
                    {
                        image.IsActive = true;
                    }
                    else
                    {
                        image.IsActive = false;
                    }
                    entities.ProductImage.Add(image);
                }
                entities.SaveChanges();
            }
            

        }
        public void CreateUser()
        {

            SomethingsHereEntities entities = new SomethingsHereEntities();
            LoginUser user = new LoginUser();
            user.Answer = "Answer";
            user.CreatedDate = DateTime.Now;
            user.Email = "mehmetkicirti@hotmail.com";
            user.IsActive = true;
            user.Password = CryptoManager.Encrypt("123");
            //user.Password = CryptoManager.Decrypt(user.Password);
            //sifreleme aes kullanılır public ve private key vardır 
            user.Question = "Question";
            user.Username = "admin";

            entities.LoginUser.Add(user);
            entities.SaveChanges();
            LoginUserDetail loginUserDetail = new LoginUserDetail();
            loginUserDetail.ID = user.ID;
            loginUserDetail.DeliveryAddress = "İzmir";
            loginUserDetail.Fullname = "Mehmet Aydın Kıcırtı";
            loginUserDetail.Gender = /*Convert.ToInt32(E_Gender.Male);*/(int)E_Gender.Male;
            loginUserDetail.InvoiceAddress = "İzmir";
            loginUserDetail.Phone = "0544083044";
            entities.LoginUserDetail.Add(loginUserDetail);
            entities.SaveChanges();
        }

    }
    
}
