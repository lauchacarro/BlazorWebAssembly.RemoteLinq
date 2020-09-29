// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

namespace BlazorRemoteLinq.Shared.Entities
{
    public class ProductMarket
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int MarketId { get; set; }

        public Market Market { get; set; }
    }
}
