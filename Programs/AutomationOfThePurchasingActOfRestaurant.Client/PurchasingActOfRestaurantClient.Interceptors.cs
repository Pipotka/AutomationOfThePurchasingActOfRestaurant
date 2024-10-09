using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Client
{
    public partial class PurchasingActOfRestaurantClient
    {
        private Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder, CancellationToken cancellationToken)
        => Task.CompletedTask;

        private Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, string urlBuilder, CancellationToken cancellationToken)
        => Task.CompletedTask;

        private Task ProcessResponseAsync(HttpClient client_, HttpResponseMessage response_, CancellationToken cancellationToken)
        => Task.CompletedTask;
    }
}
