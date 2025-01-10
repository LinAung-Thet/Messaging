
using Confluent.Kafka;
using Shared;
using System.Text.Json;

namespace ProductAPI.ProductServices

{
    public class ProductService(IProducer<Null, string> producer) : IProductService
    {
        private List<Product> products = [];
        public async Task AddProduct(Product product)
        {
            products.Add(product);
            var result = await producer.ProduceAsync("add-product-topic",
                new Message<Null, string> { Value = JsonSerializer.Serialize(product) });
            if (result.Status != PersistenceStatus.Persisted)
            {
                //Get last product
                var lastProduct = products.Last();
                // Remove the last product
                products.Remove(lastProduct);
            }
        }
        public async Task DeleteProduct(int id)
        {
            products.Remove(products.FirstOrDefault(p => p.Id == id));
            await producer.ProduceAsync("delete-product-topic", new Message<Null, string>
            {
                Value = id.ToString()
            });
        }
    }
}
