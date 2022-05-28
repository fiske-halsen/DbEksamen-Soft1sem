


sh.enableSharding("orders")
db.adminCommand( { shardCollection: "orders.ordersCollection", key: { RestaurantId: 1 } } )