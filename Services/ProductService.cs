using App.Models;

namespace App.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() {Id =1,Name="Iphone",Price=6000},
                new ProductModel() {Id =2,Name="Samsung",Price=3000},
                new ProductModel() {Id =3,Name="Nokia",Price=4000},
                new ProductModel() {Id =4,Name="Hwei",Price=8000},
                new ProductModel() {Id =5,Name="Xiaomi",Price=2000},
            });
        }
    }
}
