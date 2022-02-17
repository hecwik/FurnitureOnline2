INSERT INTO OrderHistory (CustomerId, TotalPrice, PaymentId, ShippingId, OrderDate, ShippingAdress, ShippingZipCode, ShippingCity)
VALUES
(1, 4306, 1, 2, '2020-04-08 12:35:29', 'Blomstergatan 13', '16941', 'Borås'),
(2, 5999.55, 3, 1, '2021-05-13 14:46:32', 'Akvarellvägen 70', '15945', 'Göteborg')

INSERT INTO OrderDetail (OrderId, ProductsId, Quantity, Price) VALUES
(1, 3, 1, 2599),
(1, 14, 1, 899),
(1, 23, 1, 749),
(2, 11, 1, 399),
(2, 22, 1, 1295.55),
(2, 25, 1, 4256)

Select Name, ArticleNumber FROM Products WHERE Name LIKE '%Gisela%' OR ArticleNumber = 'Billy'
