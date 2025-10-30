USE ProductDB;
GO

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL CHECK (Price > 0),
    Stock INT NOT NULL CHECK (Stock >= 0),
    Description NVARCHAR(255) NULL
);
GO

INSERT INTO Products (Name, Price, Stock, Description)
VALUES
(N'VinFast Evo 200', 32000000, 5, N'Xe máy điện VinFast đời mới'),
(N'Honda Vision', 34000000, 10, N'Xe tay ga tiết kiệm xăng'),
(N'Yamaha Exciter', 45000000, 7, N'Xe côn tay thể thao'),
(N'Suzuki Raider', 48000000, 4, N'Xe thể thao hiệu suất cao'),
(N'Cub 50', 20000000, 12, N'Xe cổ điển, tiết kiệm xăng');
GO

SELECT * FROM Products;
