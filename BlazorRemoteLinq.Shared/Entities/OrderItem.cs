// Copyright (c) Christof Senn. All rights reserved. See license.txt in the project root for license information.

namespace BlazorRemoteLinq.Shared.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
