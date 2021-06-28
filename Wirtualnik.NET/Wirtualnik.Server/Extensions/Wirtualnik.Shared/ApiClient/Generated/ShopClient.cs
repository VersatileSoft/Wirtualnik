using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wirtualnik.Shared.Models;

namespace Wirtualnik.Shared.ApiClient.Generated
{
	public class ShopClient : AbstractClient<ShopModel>, IShopClient
	{
		protected override string ControllerPath => "api/shop";
		public ShopClient(HttpClient client) : base(client)
		{
		}

	}
}
