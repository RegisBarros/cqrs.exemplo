using CQRS.Application.Catalog.Commands;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.IO;
using System.Threading;

namespace CQRS.Jobs
{
    class Program
    {
        static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();


            Console.WriteLine("Iniciando Job");

            for(int i = 0; i < 100; i++)
            {
                var product = ProductFactory.Generate();

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(product);

                Console.WriteLine(json);

                SendProduct(product);

                Thread.Sleep(1000);
            }

            Console.WriteLine("Finalizando Job");
        }

        static void SendProduct(CreateProductCommand createProduct)
        {
            string endpoint = configuration.GetSection("Product").Value;

            var client = new RestClient(endpoint);

            var request = new RestRequest(Method.POST);

            request.AddJsonBody(createProduct);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Console.WriteLine($"Status: {response.StatusCode} - Content: {content}");
        }
    }
}
